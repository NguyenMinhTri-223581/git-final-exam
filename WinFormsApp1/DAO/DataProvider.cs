using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        public static DataProvider Instance 
        { get { if (instance == null) instance = new DataProvider(); return DataProvider. instance; }  
          private set { DataProvider.Instance = value; } 
        }
        private DataProvider() { }

        private string connectionSTR = @"Data Source=NGUYEN-MINH-TRI\SQLEXPRESS;Initial Catalog=QLQNHAU;Integrated Security=True;Trust Server Certificate=True";
       
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();
            

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null) 
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara) 
                    {
                        if (item.Contains('@'))
                        { cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }    
                    }
                    
               }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                connection.Close();
            }
            return data;

        }
        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;


            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            Console.WriteLine($"Adding parameter: {item} = {parameter[i]}"); // Debug xem có đúng không
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                data = cmd.ExecuteNonQuery();  
              connection.Close();
            }
            return data;

        }
        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;


            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {

                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            cmd.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }

                }
                data = cmd.ExecuteScalar();
                connection.Close();
            }
            return data;

        }

    }
}