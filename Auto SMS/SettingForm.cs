using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Auto_SMS
{
    public partial class SettingForm : Form
    {
        MySqlDataAdapter dataAdapter;
        DataSet ds;
        public SettingForm()
        {
            InitializeComponent();
            loadForm();
        }
        private void loadForm()
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            string query = "Select * from dslv";
            dataAdapter = new MySqlDataAdapter(query, connection);
            ds = new DataSet();
            try
            {
                dataAdapter.Fill(ds);
                dataSet.DataSource = ds.Tables[0];
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddSet_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                int CurrentIndex = dataSet.CurrentCell.RowIndex;
                string name = Convert.ToString(dataSet.Rows[CurrentIndex].Cells[0].Value.ToString());
                string value = Convert.ToString(dataSet.Rows[CurrentIndex].Cells[1].Value.ToString());
                string insertStr = "Insert into dslv Values('" + name + "','" + value + "')";
                MySqlCommand insertCmd = new MySqlCommand(insertStr, connection);
                insertCmd.CommandType = CommandType.Text;
                insertCmd.ExecuteNonQuery();
                loadForm();
                MessageBox.Show("Bạn đã lưu thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Có sự cố xảy ra khi thêm mới: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
            }
        }

        private void btnEditSet_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Vui lòng xác nhận thay đổi!!", "CẢNH BÁO!!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection connection = DBUtils.GetDBConnection();
                    connection.Open();
                    int CurrentIndex = dataSet.CurrentCell.RowIndex;
                    string name = Convert.ToString(dataSet.Rows[CurrentIndex].Cells[0].Value.ToString());
                    string value = Convert.ToString(dataSet.Rows[CurrentIndex].Cells[1].Value.ToString());
                    string updateStr = "Update dslv set `Thời gian/lĩnh vực`='" + value + "'  where `Tên lĩnh vực`='" + name + "'";
                    MySqlCommand updateCmd = new MySqlCommand(updateStr, connection);
                    updateCmd.CommandType = CommandType.Text;
                    updateCmd.ExecuteNonQuery();
                    loadForm();
                    MessageBox.Show("Bạn đã lưu thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Có lỗi khi sửa: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
                }
            }
        }

        private void btnDeleteSet_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn XÓA?", "CẢNH BÁO!!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataSet.Rows)
                {
                    if (dataSet.Rows[row.Index].Selected)
                    {
                        try
                        {
                            MySqlConnection connection = DBUtils.GetDBConnection();
                            connection.Open();
                            int CurrentIndex = dataSet.CurrentCell.RowIndex;
                            string name = Convert.ToString(dataSet.Rows[CurrentIndex].Cells[0].Value.ToString());
                            string deletedStr = "Delete from dslv where `Tên lĩnh vực`='" + name + "'";
                            MySqlCommand deletedCmd = new MySqlCommand(deletedStr, connection);
                            deletedCmd.CommandType = CommandType.Text;
                            deletedCmd.ExecuteNonQuery();
                            loadForm();
                            MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                            connection.Close();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Có sự cố xảy ra khi xóa: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
                        }
                    }
                }
            }
        }
    }
}
