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
    public class IncomeModel
    {
        public readonly string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

        public int Id { get; set; }
        public string Date { get; set; }
        public float Money { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Period { get; set; }

        public void Work(UserModel user)
        {
            AddMoneyInJars(DivideIncome(), user);
            AddIncomeInDatabase(user);
        }

        private List<float> DivideIncome()
        {
            List<float> ListJarsMoney = new List<float>();
            ListJarsMoney.Add(0);
            ListJarsMoney.Add((Money / 100) * 55);
            ListJarsMoney.Add((Money / 100) * 10);
            ListJarsMoney.Add((Money / 100) * 10);
            ListJarsMoney.Add((Money / 100) * 10);
            ListJarsMoney.Add((Money / 100) * 10);
            ListJarsMoney.Add((Money / 100) * 5);
            return ListJarsMoney;
        }
        private void AddMoneyInJars(List<float> ListJarsMoney,UserModel User)
        {
            for (int i = 1; i < 7; i++)
            {
                string money = $"{ListJarsMoney[i]}";
                money = money.Replace(',', '.');
                string sqlExpression = $"Update jars set Money = Money+{money} where Id_User = '{User.Id}' and Jar = '{i}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int a = command.ExecuteNonQuery();
                }
            }
        }
        private void AddIncomeInDatabase(UserModel User)
        {
            string money = Money.ToString();
            money = money.Replace(',', '.');
            string sqlExpression2 = $"INSERT INTO Income (Id_user,Name,Money,Description,Period,Date) values('{User.Id}','{Name}','{money}','{Description}','{Period}',GETDATE());";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                int a = command.ExecuteNonQuery();
            }
        }

    }
}
