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
        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";
        List<Grid> ListShadowEffect = new List<Grid>();
        DropShadowEffect Shadow_Enter = new DropShadowEffect()
        {
            BlurRadius = 6,
            Direction = 315,
            Opacity = 0,
            ShadowDepth = 5
        };
        DropShadowEffect Shadow_Leave = new DropShadowEffect()
        {
            BlurRadius = 6,
            Direction = 315,
            Opacity = 0.5,
            ShadowDepth = 5
        };

        public History(UserModel user, string Database, string lang)
        {
            SetLanguage(lang);
            InitializeComponent();
            AddToListShadowEffect();
            AddEventsToListShadowEffect();
            SetShadow();
            if (Database == "Income")
            {
                AddIncomesInTable(user);
            }
            else if (Database == "Expense")
            {
                AddExpensesInTable(user);
            }
        }

        private void Close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Svernut(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void DeleteString(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void SetLanguage(string lang)
        {
            if (lang == "RUS")
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resorses/Dictionary_rus.xaml") };
            }
            else
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resorses/Dictionary_eng.xaml") };
            }
        }

        private void AddToListShadowEffect      ()
        {
            ListShadowEffect.Add(Button_close_grid);
            ListShadowEffect.Add(Button_svernut_grid);
            ListShadowEffect.Add(Delete_button);
            ListShadowEffect.Add(Update_button);
        }
        private void AddEventsToListShadowEffect()
        {
            foreach (Grid a in ListShadowEffect)
            {
                a.MouseEnter += ShadowEffect_Enter;
                a.MouseLeave += ShadowEffect_Leave;
            }
        }
        private void SetShadow                  ()
        {
            foreach (Grid a in ListShadowEffect)
            {
                a.Effect = Shadow_Leave;
            }
        }
        private void ShadowEffect_Enter         (object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Effect = Shadow_Enter;
        }
        private void ShadowEffect_Leave         (object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Effect = Shadow_Leave;
        }

        private void AddIncomesInTable(UserModel User)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"SELECT * FROM Income where Id_user='{User.Id}'";
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
                            Name = sqlDataReader.GetValue(2),
                            Amount = sqlDataReader.GetValue(3),
                            Description = sqlDataReader.GetValue(4),
                            Period = sqlDataReader.GetValue(5),
                            Date = sqlDataReader.GetValue(6)
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
        private void AddExpensesInTable(UserModel User)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlExpression = $"SELECT * FROM Expense where Id_user='{User.Id}'";
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
                    stockGrid.ItemsSource = listexpense;
                }
                else
                {
                    MessageBox.Show("No strings!");
                }
            }
        }


    }
}