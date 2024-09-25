using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
    class SalaryData
    {
        public string IDnhanvien { set; get; } // 0
        public string Hoten { set; get; } // 1
        public string Gioitinh { set; get; } // 2
        public string SDT { set; get; } // 3
        public string Chucvu { set; get; } // 4
        public int Luong { set; get; } // 5

        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LUU HUU DUOC\Documents\emloyee.mdf;Integrated Security=True;Connect Timeout=30");

        public List<SalaryData> salaryEmployeeListData()
        {
            List<SalaryData> listdata = new List<SalaryData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM employees WHERE status = 'hoat dong' " +
                        "AND delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            SalaryData sd = new SalaryData();
                            sd.IDnhanvien = reader["employee_id"].ToString();
                            sd.Hoten = reader["full_name"].ToString();
                            sd.Gioitinh = reader["gender"].ToString();
                            sd.SDT = reader["contact_number"].ToString();
                            sd.Chucvu = reader["position"].ToString();
                            sd.Luong = (int)reader["salary"];

                            listdata.Add(sd);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex);
                }
                finally
                {
                    connect.Close();
                }
            }
            return listdata;
        }

    }
}
