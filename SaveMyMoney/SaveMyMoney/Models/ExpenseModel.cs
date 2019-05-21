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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace SaveMyMoney
{
    public class ExpenseModel
    {
        public readonly string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

        public int Id { get; set; }
        public string Date { get; set; }
        public float Money { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Period { get; set; }

        public void Work(UserModel User, int Jar)
        {
            AddExpenseInDatabase(User, Jar);
            ChangeMoneyInJars(User, Jar);
        }
        private void AddExpenseInDatabase(UserModel User,int Jar)
        {
            string money = Money.ToString();
            money = money.Replace(',', '.');
            string sqlExpression2 = $"Declare @id tinyint = '{User.Id}',@name nvarchar(50) = '{Name}',@money money = '{Money}',@desc nvarchar(50) = '{Description}',@Period tinyint = '{Period}',@Jar tinyint = '{Jar}' exec AddExpense @id,@name,@money,@desc,@Period,@Jar";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                int a = command.ExecuteNonQuery();
            }
        }
        private void ChangeMoneyInJars(UserModel User, int Jar)
        {
            string money = Money.ToString();
            money = money.Replace(',', '.');
            string sqlExpression = $"Declare @id tinyint = '{User.Id}',@Money money = {money},@Jar tinyint = '{Jar}' exec UpdateJars @id,@Money,@Jar";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
