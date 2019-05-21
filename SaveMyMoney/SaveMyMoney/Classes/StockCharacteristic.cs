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
    public class StockCharacteristic
    {
        private readonly string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

        public object Name { get; set; }
        public object Amount { get; set; }
        public object Period { get; set; }
        public object Date { get; set; }
        public object Description { get; set; }

        public StockCharacteristic(){}
        public StockCharacteristic(UserModel user, string Database, ref DataGrid grid)
        {
            if (Database == "Income")
            {
                grid.ItemsSource = AddIncomesInTable(user);
            }
            else if (Database == "Expense")
            {
                grid.ItemsSource = AddExpensesInTable(user);
            }
        }
        private List<StockCharacteristic> AddIncomesInTable(UserModel User)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"declare @id tinyint = {User.Id} exec GetIncome @id";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    List<StockCharacteristic> listincome = new List<StockCharacteristic>();
                    while (sqlDataReader.Read())
                    {
                        StockCharacteristic stock = new StockCharacteristic()
                        {
                            Name = sqlDataReader.GetValue(2),
                            Amount = sqlDataReader.GetValue(3),
                            Description = sqlDataReader.GetValue(4),
                            Period = sqlDataReader.GetValue(5),
                            Date = sqlDataReader.GetValue(6)
                        };
                        listincome.Add(stock);
                    }
                    return listincome;
                }
                else
                {
                    MessageBox.Show("No strings!");
                    return null;
                }
            }
        }
        private List<StockCharacteristic> AddExpensesInTable(UserModel User)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"declare @id tinyint = {User.Id} exec GetExpense @id";
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    List<StockCharacteristic> listexpense = new List<StockCharacteristic>();
                    while (sqlDataReader.Read())
                    {
                        StockCharacteristic expense = new StockCharacteristic()
                        {
                            Name = sqlDataReader.GetValue(2),
                            Amount = sqlDataReader.GetValue(3),
                            Description = sqlDataReader.GetValue(4),
                            Period = sqlDataReader.GetValue(5),
                            Date = sqlDataReader.GetValue(6)
                        };
                        listexpense.Add(expense);
                    }
                    return listexpense;
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
