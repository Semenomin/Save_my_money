using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Windows.Media.Effects;

namespace SaveMyMoney
{
    class StockPlanner
    {
        private readonly string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public float Money { get; set; }
        public string Date { get; set; }
        public int Period { get; set; }

        public StockPlanner(){}

        public StockPlanner(UserModel User,ref DataGrid grid)
        {
            grid.ItemsSource = AddPlannesInTable(User);
        }

        private List<StockPlanner> AddPlannesInTable(UserModel User)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"declare @a int = {User.Id} exec GetPlanner @a";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    List<StockPlanner> listPlann = new List<StockPlanner>();
                    while (sqlDataReader.Read())
                    {
                        StockPlanner stock = new StockPlanner()
                        {
                            Id = int.Parse(sqlDataReader.GetValue(0).ToString()),
                            Type = sqlDataReader.GetValue(1).ToString(),
                            Name = sqlDataReader.GetValue(2).ToString(),
                            Money = float.Parse(sqlDataReader.GetValue(3).ToString()),
                            Date = sqlDataReader.GetValue(4).ToString(),
                            Period = int.Parse(sqlDataReader.GetValue(5).ToString())
                        };
                        listPlann.Add(stock);
                    }
                    return listPlann;
                }
                else
                {
                    MessageBox.Show("No strings!");
                    return null;
                }
            }
        }
    }
}
