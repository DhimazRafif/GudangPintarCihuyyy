using GudangPintarGui.ControllerGui;
using GudangPintarGui.Models;
using GudangPintarGui.ServiceGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GudangPintarGui.View
{
    public partial class AddEditAkuncs : Form
    {
        private readonly AkunController _akunController;
        private readonly string _mode; // "tambah" atau "edit"
        private readonly User _editUser;
        public AddEditAkuncs(AkunController akunController, string mode, User user = null)
        {
            InitializeComponent();
            _akunController = akunController;
            _mode = mode;
            _editUser = user;

            if (_mode == "tambah")
            {
                lblTambahdanEditAkun.Text = "Tambah Akun";
                btnTambah.Text = "Tambah";
            }
            else if (_mode == "edit" && _editUser != null)
            {
                lblTambahdanEditAkun.Text = "Edit Akun";
                btnTambah.Text = "Update";
                // Isi data user ke kontrol
                txtNamaLengkap.Text = _editUser.Name;
                textUsername.Text = _editUser.Username;
                // Password tidak diisi (biarkan kosong)
                cmbRole.SelectedItem = _editUser.Role == RoleService.ROLE_ADMIN ? "Admin" : "Pegawai";
                // Hak akses diabaikan karena tidak disimpan di form ini (hanya role)
            }
            else
            {
                throw new ArgumentException("Mode tidak valid atau user null untuk edit.");
            }

            // Load role ke combobox jika belum diisi
            if (cmbRole.Items.Count == 0)
            {
                cmbRole.Items.Clear();
                cmbRole.Items.Add("Admin");
                cmbRole.Items.Add("Pegawai");
            }
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            if (_mode == "tambah" && cmbRole.SelectedIndex == -1)
                cmbRole.SelectedIndex = 1; // default Pegawai
        }
        

        private void btnHakAkses_Click(object sender, EventArgs e)
        {
            checkedListBox1.Visible = !checkedListBox1.Visible;
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string nama = txtNamaLengkap.Text.Trim();
            string username = textUsername.Text.Trim();
            string password = txtPassword.Text;
            string roleStr = cmbRole.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(roleStr))
            {
                MessageBox.Show("Pilih role.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int roleId = (roleStr == "Admin") ? RoleService.ROLE_ADMIN : RoleService.ROLE_PEGAWAI;

            if (_mode == "tambah")
            {
                if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Semua field harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_akunController.CreateUser(nama, username, password, roleId))
                {
                    MessageBox.Show("User berhasil ditambahkan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else if (_mode == "edit")
            {
                if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(username))
                {
                    MessageBox.Show("Nama dan Username harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_akunController.UpdateUser(_editUser.UserId, nama, username, password, roleId))
                {
                    MessageBox.Show("User berhasil diupdate.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
       

        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
