using System;
using System.Collections.Generic;
using GudangPintarGui.ConfigDatabase;
using GudangPintarGui.Models;
using GudangPintarGui.Utils;
using MySql.Data.MySqlClient;

namespace GudangPintarGui.ServiceGui
{
    public class StockNotificationService
    {
        private readonly StockStateContext _stateContext = new StockStateContext();

        public void CekSemuaBarangSetelahLogin()
        {
            var hasilCek = new List<StateCheckResult>();

            using (var conn = DBConnection.GetInstance().GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT barangid, name, quantity, notification_threshold, alert_state
                    FROM barang
                    WHERE isActive = 1";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        hasilCek.Add(BuatHasilCek(reader));
                    }
                }

                foreach (var item in hasilCek)
                {
                    // Saat login/dashboard dibuka, semua barang Menipis/Habis tetap ditampilkan,
                    // walaupun state-nya sudah pernah tampil sebelumnya.
                    TampilkanPopupJikaPerlu(item);

                    // Tetap update alert_state supaya state di database tetap sinkron.
                    UpdateAlertState(conn, null, item.BarangId, item.CurrentState.State);
                }
            }
        }

        public void CekSatuBarangDalamTransaksi(MySqlConnection conn, MySqlTransaction transaction, int barangId)
        {
            string query = @"
                SELECT barangid, name, quantity, notification_threshold, alert_state
                FROM barang
                WHERE barangid = @barangid AND isActive = 1
                FOR UPDATE";

            StateCheckResult item = null;

            using (var cmd = new MySqlCommand(query, conn, transaction))
            {
                cmd.Parameters.Add("@barangid", MySqlDbType.Int32).Value = barangId;

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        item = BuatHasilCek(reader);
                    }
                }
            }

            if (item == null || !item.StateChanged)
                return;

            UpdateAlertState(conn, transaction, item.BarangId, item.CurrentState.State);
            TampilkanPopupJikaPerlu(item);
        }

        private StateCheckResult BuatHasilCek(MySqlDataReader reader)
        {
            int barangId = reader.GetInt32("barangid");
            string namaBarang = reader.GetString("name");
            int quantity = reader.GetInt32("quantity");
            int threshold = reader.GetInt32("notification_threshold");

            StockAlertState? previousState = ParseState(reader["alert_state"]);
            IStockState currentState = _stateContext.GetState(quantity, threshold);

            bool stateChanged = previousState == null || previousState.Value != currentState.State;

            return new StateCheckResult
            {
                BarangId = barangId,
                NamaBarang = namaBarang,
                CurrentState = currentState,
                StateChanged = stateChanged
            };
        }

        private StockAlertState? ParseState(object value)
        {
            if (value == DBNull.Value)
                return null;

            string teksState = Convert.ToString(value);

            if (string.IsNullOrWhiteSpace(teksState))
                return null;

            StockAlertState state;

            if (Enum.TryParse(teksState, out state))
                return state;

            return null;
        }

        private void UpdateAlertState(MySqlConnection conn, MySqlTransaction transaction, int barangId, StockAlertState state)
        {
            string query = @"
                UPDATE barang 
                SET alert_state = @state 
                WHERE barangid = @barangid";

            MySqlCommand cmd;

            if (transaction == null)
                cmd = new MySqlCommand(query, conn);
            else
                cmd = new MySqlCommand(query, conn, transaction);

            using (cmd)
            {
                cmd.Parameters.Add("@state", MySqlDbType.VarChar).Value = state.ToString();
                cmd.Parameters.Add("@barangid", MySqlDbType.Int32).Value = barangId;
                cmd.ExecuteNonQuery();
            }
        }

        private void TampilkanPopupJikaPerlu(StateCheckResult item)
        {
            if (item.CurrentState.State == StockAlertState.Aman)
                return;

            item.CurrentState.ShowNotification(item.NamaBarang);
        }

        private class StateCheckResult
        {
            public int BarangId { get; set; }
            public string NamaBarang { get; set; }
            public IStockState CurrentState { get; set; }
            public bool StateChanged { get; set; }
        }
    }
}