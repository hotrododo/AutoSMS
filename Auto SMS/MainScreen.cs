using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Http;
using System.Configuration;
using System.IO;

namespace Auto_SMS
{
    public partial class MainScreen : Form
    {
        MySqlDataAdapter dataAdapter;
        DataSet ds;
        public MainScreen()
        {
            InitializeComponent();
            tbxNoResult.Enabled = cbxNoResult.Checked;
            tbxResultHasGone.Enabled = cbxHasGone.Checked;
            FillTextBox();
            LoadData();
            CheckTime();
            CheckData();
        }
        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            tbxResultHasGone.Enabled = cbxHasGone.Checked;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Vui lòng xác nhận thay đổi!!", "CẢNH BÁO!!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection connection = DBUtils.GetDBConnection();
                    connection.Open();
                    int CurrentIndex = dataList.CurrentCell.RowIndex;
                    string ID = Convert.ToString(dataList.Rows[CurrentIndex].Cells[0].Value.ToString());
                    string name = Convert.ToString(dataList.Rows[CurrentIndex].Cells[1].Value.ToString());
                    string phone = Convert.ToString(dataList.Rows[CurrentIndex].Cells[2].Value.ToString());
                    string email = Convert.ToString(dataList.Rows[CurrentIndex].Cells[3].Value.ToString());
                    string ngaynop = (Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString())).ToString("yyyy-MM-dd H:mm:ss");
                    string ngaytra = dataList.Rows[CurrentIndex].Cells[5].Value != null && dataList.Rows[CurrentIndex].Cells[5].Value.ToString() != "" ? "'" + (Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString())).ToString("yyyy-MM-dd H:mm:ss") + "'" : "NULL";
                    DateTime dateNow = DateTime.Now;
                    string hoanthanh = dataList.Rows[CurrentIndex].Cells[5].Value == null || dataList.Rows[CurrentIndex].Cells[5].Value.ToString().Equals("") || DateTime.Compare(Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString()), dateNow) > 0 ? "0" : "1";
                    string thoigiankhung = Convert.ToString(dataList.Rows[CurrentIndex].Cells[7].Value.ToString());
                    int timeValue = CheckLV(thoigiankhung);
                    string thoigianthuc = "NULL";
                    if (dataList.Rows[CurrentIndex].Cells[5].Value != null && dataList.Rows[CurrentIndex].Cells[5].Value.ToString() != "")
                    {
                        TimeSpan time = Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString()) - Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString());
                        thoigianthuc = time.Days.ToString();
                    }

                    string delay = "NULL";
                    if (dataList.Rows[CurrentIndex].Cells[5].Value == null || dataList.Rows[CurrentIndex].Cells[5].Value.ToString().Equals(""))
                    {
                        TimeSpan distantTimeToNow = dateNow - Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString());
                        if ((int)distantTimeToNow.Days >= timeValue)
                        {
                            delay = "'" + ((int)distantTimeToNow.Days - timeValue) + "'";
                        }
                    }
                    else
                    {
                        TimeSpan distantTimeToRep = Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString()) - Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString());
                        if ((int)distantTimeToRep.Days >= timeValue)
                        {
                            delay = "'" + ((int)distantTimeToRep.Days - timeValue) + "'";
                        }
                    }
                    string updateStr = "Update ds2018 set `Tên người nộp`='" + name + "',`Số điện thoại`='" + phone + "',`Email`='" + email + "',`Ngày nộp`='" + ngaynop + "',`Ngày trả`=" + ngaytra + ",`Hoàn thành`='" + hoanthanh + "',`Thời gian Khung/lĩnh vực`='" + thoigiankhung + "',`Thời gian thực`=" + thoigianthuc + ",`Đúng/trễ`=" + delay + " where `ID`='" + ID + "'";
                    MySqlCommand updateCmd = new MySqlCommand(updateStr, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    updateCmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Bạn đã lưu thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    connection.Close();
                    CheckData();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Có lỗi khi sửa: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn XÓA?", "CẢNH BÁO!!!", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    MySqlConnection connection = DBUtils.GetDBConnection();
                    connection.Open();
                    int CurrentIndex = dataList.CurrentCell.RowIndex;
                    string ID = Convert.ToString(dataList.Rows[CurrentIndex].Cells[0].Value.ToString());
                    string deletedStr = "Delete from ds2018 where ID='" + ID + "'";
                    MySqlCommand deletedCmd = new MySqlCommand(deletedStr, connection)
                    {
                        CommandType = CommandType.Text
                    };
                    deletedCmd.ExecuteNonQuery();
                    LoadData();
                    MessageBox.Show("Bạn đã xóa thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                    connection.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Có sự cố xảy ra khi xóa: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
                }
            }
            else if (dialog == DialogResult.No)
            {
                
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbxNoResult_CheckedChanged(object sender, EventArgs e)
        {
            tbxNoResult.Enabled = cbxNoResult.Checked;
        }
        private void LoadData()
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            string query = "Select * from ds2018";
            try
            {
                dataAdapter = new MySqlDataAdapter(query, connection);
                ds = new DataSet();
                dataAdapter.Fill(ds, "ds2018");
                
                //(dataList.Columns["UserID"] as DataGridViewComboBoxColumn).DataSource = ds.Tables[0].Columns[1];
                //(dataList.Columns["UserID"] as DataGridViewComboBoxColumn).DisplayMember = "UserID";
                //(dataList.Columns["UserID"] as DataGridViewComboBoxColumn).ValueMember = "UserID";
                int width = dataList.Width;
                dataList.DataSource = ds.Tables["ds2018"];
                dataList.AutoResizeColumnHeadersHeight();
                //dataList.AutoResizeRowHeadersWidth();
                dataList.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataList.Columns[0].FillWeight = 40;
                dataList.Columns[1].FillWeight = 150;
                dataList.Columns[2].FillWeight = 80;
                dataList.Columns[3].FillWeight = 110;
                dataList.Columns[4].FillWeight = 90;
                dataList.Columns[5].FillWeight = 90;
                dataList.Columns[6].FillWeight = 50;
                dataList.Columns[7].FillWeight = 70;
                
                dataList.Columns[8].FillWeight = 60;
                dataList.Columns[9].FillWeight = 60;
                dataList.Columns[10].FillWeight = 50;
                dataList.Columns[10].ReadOnly = true;
                dataList.Columns[0].ReadOnly = true;
                dataList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                dataAdapter = new MySqlDataAdapter("Select * from dslv", connection);
                ds = new DataSet();
                dataAdapter.Fill(ds, "dslv");
                (dataList.Columns[7] as DataGridViewComboBoxColumn).DataSource = ds.Tables["dslv"];
                (dataList.Columns[7] as DataGridViewComboBoxColumn).DisplayMember = "Tên lĩnh vực";
                (dataList.Columns[7] as DataGridViewComboBoxColumn).ValueMember = "Tên lĩnh vực";//"Thời gian/lĩnh vực";
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection connection = DBUtils.GetDBConnection();
                connection.Open();
                int CurrentIndex = dataList.CurrentCell.RowIndex;
                int IDValue = 0;
                for(int i=0;i<dataList.Rows.Count-2; i++)
                {
                    IDValue = Int32.Parse(dataList.Rows[i].Cells[0].Value.ToString()) > IDValue ? Int32.Parse(dataList.Rows[i].Cells[0].Value.ToString()) : IDValue;
                }
                /*foreach (DataGridViewRow row in dataList.Rows)
                {
                    IDValue = Int32.Parse(dataList.Rows[row.Index].Cells[0].Value.ToString()) > IDValue && dataList.Rows[row.Index].Cells[0].Value !=null && !dataList.Rows[row.Index].Cells[0].Value.ToString().Equals("") ? Int32.Parse(dataList.Rows[row.Index].Cells[0].Value.ToString()) : IDValue;
                } */
                string ID = Convert.ToString(IDValue + 1);
                string name = Convert.ToString(dataList.Rows[CurrentIndex].Cells[1].Value.ToString());
                string phone = Convert.ToString(dataList.Rows[CurrentIndex].Cells[2].Value.ToString());
                string email = Convert.ToString(dataList.Rows[CurrentIndex].Cells[3].Value.ToString());
                string ngaynop = (Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString())).ToString("yyyy-MM-dd H:mm:ss");
                string ngaytra = dataList.Rows[CurrentIndex].Cells[5].Value != null && dataList.Rows[CurrentIndex].Cells[5].Value.ToString() != "" ? "'" + (Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString())).ToString("yyyy-MM-dd H:mm:ss") + "'" : "NULL";
                DateTime dateNow = DateTime.Now;
                string hoanthanh = dataList.Rows[CurrentIndex].Cells[5].Value == null || dataList.Rows[CurrentIndex].Cells[5].Value.ToString().Equals("") || DateTime.Compare(Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString()), dateNow) > 0 ? "0" : "1";
                string thoigiankhung = Convert.ToString(dataList.Rows[CurrentIndex].Cells[7].Value.ToString());
                int timeValue = CheckLV(thoigiankhung);
                string thoigianthuc = "NULL";
                if(dataList.Rows[CurrentIndex].Cells[5].Value != null && dataList.Rows[CurrentIndex].Cells[5].Value.ToString() != "")
                {
                    TimeSpan time = Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString()) - Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString());
                    thoigianthuc = time.Days.ToString();
                }

                string delay = "NULL";
                if(dataList.Rows[CurrentIndex].Cells[5].Value == null || dataList.Rows[CurrentIndex].Cells[5].Value.ToString().Equals(""))
                {
                    TimeSpan distantTimeToNow = dateNow - Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString());
                    if ((int)distantTimeToNow.Days >= timeValue)
                    {
                        delay = "'" + ((int)distantTimeToNow.Days - timeValue) + "'";
                    }
                } else
                {
                    TimeSpan distantTimeToRep = Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[5].Value.ToString()) - Convert.ToDateTime(dataList.Rows[CurrentIndex].Cells[4].Value.ToString());
                    if ((int)distantTimeToRep.Days >= timeValue)
                    {
                        delay = "'" + ((int)distantTimeToRep.Days - timeValue) + "'";
                    }
                }
                string state = "1";
                string insertStr = "Insert into ds2018 Values('" + ID + "','" + name + "','" + phone + "','" + email + "','" + ngaynop + "'," + ngaytra + ",'" + hoanthanh + "','" + thoigiankhung + "'," + thoigianthuc + "," + delay + ",'" + state + "')";
                MySqlCommand insertCmd = new MySqlCommand(insertStr, connection)
                {
                    CommandType = CommandType.Text
                };
                insertCmd.ExecuteNonQuery();
                LoadData();
                MessageBox.Show("Bạn đã lưu thành công!", "THÔNG BÁO", MessageBoxButtons.OK);
                connection.Close();
                string mess = tbxNoResult.Text;
                SendSMSAsync(phone, mess);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Có sự cố xảy ra khi thêm mới: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string searchStr = tbxSearch.Text.Trim();
            int rowIndex = -1;
            foreach (DataGridViewRow row in dataList.Rows)
            {
                rowIndex = (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(searchStr)) || (row.Cells[1].Value != null && row.Cells[1].Value.ToString().Equals(searchStr)) || (row.Cells[2].Value != null && row.Cells[2].Value.ToString().Equals(searchStr)) || (row.Cells[3].Value != null && row.Cells[3].Value.ToString().Equals(searchStr)) ? row.Index : rowIndex;
                if (rowIndex != -1)
                {
                    dataList.Rows[rowIndex].Selected = true;
                }

            }
            if (rowIndex == -1)
            {
                MessageBox.Show("Không tìm thấy nội dung!", "THÔNG BÁO", MessageBoxButtons.OK);
            }


        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            if (cbxNoResult.Checked)
            {
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (row.Cells[10].Value != null && row.Cells[10].Value.ToString().Equals("1"))
                    {
                        dataList.Rows[row.Index].Selected = true;
                    }

                }
            }
            else
            {
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (row.Cells[10].Value != null && row.Cells[10].Value.ToString().Equals("1"))
                    {
                        dataList.Rows[row.Index].Selected = false;
                    }

                }
            }
            if (cbxHasGone.Checked)
            {
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (row.Cells[10].Value != null && row.Cells[10].Value.ToString().Equals("2"))
                    {
                        dataList.Rows[row.Index].Selected = true;
                    }

                }
            }
            else
            {
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (row.Cells[10].Value != null && row.Cells[10].Value.ToString().Equals("2"))
                    {
                        dataList.Rows[row.Index].Selected = false;
                    }

                }
            }
        }
        private void BtnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "Microsoft Excel|*.xls|All files|*.*",
                Title = "Nhập tên file xuất",
                AddExtension = true,
                RestoreDirectory = true
            };
            string fileName = "";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFile.FileName;
            }
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                //Header
                Excel.Range head = xlWorkSheet.Range["c1", "g2"];
                head.MergeCells = true;
                head.Value2 = "Báo cáo danh sách " + DateTime.Now.ToString();
                head.Font.Bold = true;
                head.Font.Name = "Tahoma";
                head.Font.Size = "18";
                head.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                //format title
                Excel.Range rowHead = xlWorkSheet.Range["a4", "k4"];
                rowHead.WrapText = true;
                rowHead.Font.Bold = true;
                rowHead.Borders.LineStyle = Excel.Constants.xlSolid;
                rowHead.Interior.ColorIndex = 15;
                rowHead.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                Excel.Range a4 = xlWorkSheet.Range["a4", "a4"];
                a4.ColumnWidth = 6;
                Excel.Range b4 = xlWorkSheet.Range["b4", "b4"];
                b4.ColumnWidth = 22;
                Excel.Range c4 = xlWorkSheet.Range["c4", "c4"];
                c4.ColumnWidth = 15;
                Excel.Range d4 = xlWorkSheet.Range["d4", "d4"];
                d4.ColumnWidth = 20;
                Excel.Range e4 = xlWorkSheet.Range["e4", "e4"];
                e4.ColumnWidth = 13;
                Excel.Range f4 = xlWorkSheet.Range["f4", "f4"];
                f4.ColumnWidth = 13;
                Excel.Range g4 = xlWorkSheet.Range["g4", "g4"];
                g4.ColumnWidth = 13;
                Excel.Range h4 = xlWorkSheet.Range["h4", "h4"];
                h4.ColumnWidth = 13;
                Excel.Range i4 = xlWorkSheet.Range["i4", "i4"];
                i4.ColumnWidth = 13;
                Excel.Range j4 = xlWorkSheet.Range["j4", "j4"];
                j4.ColumnWidth = 13;
                Excel.Range k4 = xlWorkSheet.Range["k4", "k4"];
                k4.ColumnWidth = 13;
                Excel.Range fullRange = xlWorkSheet.Range["a1", "k1000"];
                fullRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                for (int i=0; i < dataList.Columns.Count; i++)
                {
                    xlWorkSheet.Cells[4, i+1] = dataList.Columns[i].HeaderText;
                }
                int j = 5;
                foreach (DataGridViewRow row in dataList.Rows)
                {
                    if (dataList.Rows[row.Index].Selected)
                    {

                        for(int i =0; i < dataList.Columns.Count; i++)
                        {
                            xlWorkSheet.Cells[j, i+1] = dataList[i, row.Index].Value;
                        }
                        j++;
                    }
                }

                xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal,
                misValue, misValue, misValue, misValue,
                Excel.XlSaveAsAccessMode.xlExclusive,
                misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                ReleaseObject(xlWorkSheet);
                ReleaseObject(xlWorkBook);
                ReleaseObject(xlApp);

                MessageBox.Show("Ghi file thành công tại thư mục: " + fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi xuất dữ liệu: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
            }
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private static readonly HttpClient client = new HttpClient();
        private async Task SendSMSAsync(string phoneNumber, string message)
        {
            string userName = tbxUser.Text.Trim();
            string passWord = tbxPassword.Text.Trim();
            string IP = tbxIpAddr.Text.Trim();
            string brandname = tbxBrandname.Text.Trim();
            string messType = tbxMessType.Text.Trim();
            var values = new Dictionary<string, string>
            {
                {"username",userName },
                {"password", passWord },
                {"phonenumber", phoneNumber },
                {"message", message },
                {"brandname", brandname },
                {"loaitin", messType }
            };
            var content = new FormUrlEncodedContent(values);
            WriteLog(phoneNumber + "\t" + userName + "\t" + DateTime.Now);
            var response = await client.PostAsync(IP, content);
            var responseString = await response.Content.ReadAsStringAsync();
            MessageBox.Show("Message notice: " + responseString);
        }
        private void CheckData()
        {
            DateTime dateNow = DateTime.Now;
            foreach (DataGridViewRow row in dataList.Rows)
            {
                if(dataList.Rows[row.Index].Cells[0].Value != null && !dataList.Rows[row.Index].Cells[0].Value.ToString().Equals(""))
                {
                    string delay = "NULL";
                    string state = Convert.ToString(dataList.Rows[row.Index].Cells[10].Value).Trim();
                    string ID = Convert.ToString(dataList.Rows[row.Index].Cells[0].Value.ToString());
                    string thoigiankhung = Convert.ToString(dataList.Rows[row.Index].Cells[7].Value.ToString());
                    int timeValue = CheckLV(thoigiankhung);
                    if (dataList.Rows[row.Index].Cells[5].Value == null || dataList.Rows[row.Index].Cells[5].Value.ToString().Equals(""))
                    {
                        TimeSpan distantTimeToNow = dateNow - Convert.ToDateTime(dataList.Rows[row.Index].Cells[4].Value.ToString());
                        if ((int)distantTimeToNow.Days >= timeValue)
                        {
                            delay = "'" + ((int)distantTimeToNow.Days - timeValue) + "'";
                        }
                    }
                    else
                    {
                        TimeSpan distantTimeToRep = Convert.ToDateTime(dataList.Rows[row.Index].Cells[5].Value.ToString()) - Convert.ToDateTime(dataList.Rows[row.Index].Cells[4].Value.ToString());
                        if ((int)distantTimeToRep.Days >= timeValue)
                        {
                            delay = "'" + ((int)distantTimeToRep.Days - timeValue) + "'";
                        }
                    }
                    if (dataList.Rows[row.Index].Cells[5].Value != null && !dataList.Rows[row.Index].Cells[5].Value.ToString().Equals("") && dataList.Rows[row.Index].Cells[10].Value.ToString().Equals("1"))
                    {
                        string phone = Convert.ToString(dataList.Rows[row.Index].Cells[2].Value.ToString());
                        string mess = tbxResultHasGone.Text;
                        SendSMSAsync(phone, mess);
                        state = "2";
                    }
                    try
                    {
                        MySqlConnection connection = DBUtils.GetDBConnection();
                        connection.Open();
                        string updateStr = "Update ds2018 set `Đúng/trễ`=" + delay + ",`Trạng thái`='" + state + "' where `ID`='" + ID + "'";
                        MySqlCommand updateCmd = new MySqlCommand(updateStr, connection)
                        {
                            CommandType = CommandType.Text
                        };
                        updateCmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Có sự cố xảy ra khi kiểm tra dữ liệu: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
                    }
                }
            }
            LoadData();
        }
        private void FillTextBox()
        {
            tbxNoResult.Text = ConfigurationManager.AppSettings["messNoResult"].ToString();
            tbxResultHasGone.Text = ConfigurationManager.AppSettings["messResultHasGone"].ToString();
            tbxUser.Text = ConfigurationManager.AppSettings["user"].ToString();
            tbxPassword.Text = ConfigurationManager.AppSettings["pass"].ToString();
            tbxIpAddr.Text = ConfigurationManager.AppSettings["ip"].ToString();
            tbxBrandname.Text = ConfigurationManager.AppSettings["brandname"].ToString();
            tbxMessType.Text = ConfigurationManager.AppSettings["messType"].ToString();
        }
        private void SaveTextBox()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["messNoResult"].Value = tbxNoResult.Text;
            config.AppSettings.Settings["messResultHasGone"].Value = tbxResultHasGone.Text;
            config.AppSettings.Settings["user"].Value = tbxUser.Text;
            config.AppSettings.Settings["pass"].Value = tbxPassword.Text;
            config.AppSettings.Settings["ip"].Value = tbxIpAddr.Text;
            config.AppSettings.Settings["brandname"].Value = tbxBrandname.Text;
            config.AppSettings.Settings["messType"].Value = tbxMessType.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Bạn có muốn lưu lại những thay đổi?", "Thông báo!", MessageBoxButtons.YesNoCancel);
            if(dialog == DialogResult.Yes)
            {
                SaveTextBox();
            } else if(dialog == DialogResult.No)
            {

            } else if(dialog == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        

        private void CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm();
            settingForm.ShowDialog();
        }
        private Int32 CheckLV(string name)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            string query = "Select * from dslv where `Tên lĩnh vực`='" + name + "'" ;
            int value = 0;
            try
            {
                MySqlCommand searchCmd = new MySqlCommand(query, connection)
                {
                    CommandType = CommandType.Text
                };
                MySqlDataReader reader = searchCmd.ExecuteReader();
                if (reader.Read())
                {
                    value = Int32.Parse(reader.GetString("Thời gian/lĩnh vực"));
                }
                //searchCmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message + " Sự cố này khiến tác vụ không thể hoàn thành, vui lòng khởi động lại ứng dụng hoặc liên hệ nhà cung cấp!");
            }
            return value;
        }
        private void CheckTime()
        {
            DateTime date = Convert.ToDateTime("1/30/2018");
            DateTime dateNow = DateTime.Now;
            TimeSpan time = dateNow - date;
            if (DateTime.Compare(date, dateNow) <= 0)
            {
                MessageBox.Show("Phần mềm đã hết hạn dùng thử " + time.Days + " ngày, vui lòng liên hệ quản trị viên để gia hạn!");
                Application.Exit();
                System.Environment.Exit(1);
            }
        }
        private void WriteLog(string log)
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\SmsSenderLog.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                File.CreateText(path);
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(log);
            }
        }
    }
}
