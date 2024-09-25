using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
    class EmployeeData
    {

        public int ID { set; get; } // 0
        public string IDnhanvien { set; get; } // 1
        public string Hoten { set; get; } // 2
        public string Gioitinh { set; get; } // 3
        public string SDT { set; get; } // 4
        public string Chucvu { set; get; } // 5
        public string Anh { set; get; } // 6
        public int luong { set; get; } // 7
        public string Trangthai { set; get; } // 8


        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LUU HUU DUOC\Documents\emloyee.mdf;Integrated Security=True;Connect Timeout=30");
    

        public List<EmployeeData> employeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if(connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM employees WHERE delete_date IS NULL";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EmployeeData ed = new EmployeeData();
                            ed.ID = (int)reader["id"];
                            ed.IDnhanvien = reader["employee_id"].ToString();
                            ed.Hoten = reader["full_name"].ToString();
                            ed.Gioitinh = reader["gender"].ToString();
                            ed.SDT = reader["contact_number"].ToString();
                            ed.Chucvu = reader["position"].ToString();
                            ed.Anh = reader["image"].ToString();
                            ed.luong = (int)reader["salary"];
                            ed.Trangthai = reader["status"].ToString();

                            listdata.Add(ed);
                        }
                    }
                        
                }catch(Exception ex)
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

        public List<EmployeeData> salaryEmployeeListData()
        {
            List<EmployeeData> listdata = new List<EmployeeData>();

            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM employees WHERE delete_date IS NULL";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            EmployeeData ed = new EmployeeData();
                            ed.IDnhanvien = reader["employee_id"].ToString();
                            ed.Hoten = reader["full_name"].ToString();
                            ed.Chucvu = reader["position"].ToString();
                            ed.luong = (int)reader["salary"];

                            listdata.Add(ed);
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
