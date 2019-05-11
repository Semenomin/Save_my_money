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
namespace SaveMyMoney
{
    class StockCharacteristic
    {
        public object Name { get; set; }
        public object Amount { get; set; }
        public object Period { get; set; }
        public object Date { get; set; }
        public object Description { get; set; }

    }

    public partial class History : Window
    {
        object id;
        public History(object id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Show_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"SELECT * FROM Income where Id_user='{id}'";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    List<StockCharacteristic> listincome = new List<StockCharacteristic>();
                    while (sqlDataReader.Read())
                    {
                        StockCharacteristic income = new StockCharacteristic()
                        {
                            Name = sqlDataReader.GetValue(1),
                            Amount = sqlDataReader.GetValue(2),
                            Description = sqlDataReader.GetValue(3),
                            Period = sqlDataReader.GetValue(4),
                            Date = sqlDataReader.GetValue(5)
                        };
                        listincome.Add(income);

                    }
                    stockGrid.ItemsSource = listincome;
                }
                else
                {
                    MessageBox.Show("No strings!");
                }
            }
        }
    }
}