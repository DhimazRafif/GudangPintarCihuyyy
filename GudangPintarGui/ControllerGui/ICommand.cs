using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GudangPintarGui.ControllerGui
{
    // ini untuk mendefinisikan kontrak umum bagi semua perintah (Command) yang akan dieksekusi oleh controller

    /// <summary>
    /// Mendefinisikan kontrak untuk eksekusi perintah (Command Pattern).
    /// Setiap operasi CRUD atau transaksi harus mengimplementasikan interface ini.
    /// </summary>
    /// 

    // ini untuk memastikan bahwa setiap perintah memiliki metode Execute yang mengembalikan hasil operasi dan pesan feedback untuk pengguna
    public interface ICommand
    {
        /// <summary>
        /// Mengeksekusi logika perintah ke layer Service/Database.
        /// </summary>
        /// <param name="pesanHasil">Pesan feedback untuk pengguna (misal: "Barang berhasil disimpan").</param>
        /// <returns>True jika operasi berhasil, False jika terjadi kegagalan.</returns>
        bool Execute(out string pesanHasil);
    }
}