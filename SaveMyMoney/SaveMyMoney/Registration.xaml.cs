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

    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {

        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

        public Registration(string lang)
        {
            if (lang == "RUS")
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resorses/Dictionary_rus.xaml") };
            } //смена языка
            else
            {
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resorses/Dictionary_eng.xaml") };
            }
            InitializeComponent();
            
        }



        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bool good = true;
            object id=0;
            string sqlExpression1 = $"INSERT INTO Users (Login_text,Password_text,Name_user) VALUES ('{LoginT.Text}', '{PassT.Text}', '{NameT.Text}')";
            string sqlExpression2 = $"Select Login_text from Users";
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if ((string)reader.GetValue(0) == LoginT.Text)
                        {
                            MessageBox.Show("Invalid Login");
                            good = false;
                            break;
                        };
                        good = true;
                    }
                }
                reader.Close();
                if (good)
                {
                    if (PassT.Text != RPassT.Text || RPassT.Text == "None")
                    {
                        MessageBox.Show("Pass are not same");
                    }
                    else
                    {
                        SqlCommand command2 = new SqlCommand(sqlExpression1, connection);
                        command2.ExecuteNonQuery();
                        string sqlExpression3 = $"Select Id from Users where Login_text like '{LoginT.Text}'";
                        SqlCommand command3 = new SqlCommand(sqlExpression3, connection);
                        SqlDataReader reader1 = command3.ExecuteReader();

                        if (reader1.HasRows) // если есть данные
                        {
                            while (reader1.Read()) // построчно считываем данные
                            { 
                                    id = reader1.GetValue(0);
                            }
                        }
                        reader1.Close();
                        for (int a = 1; a <= 6; a++)
                        {
                            string sqlExpression4 = $"INSERT INTO Jars (Id_user,Jar_num,Money_in_jar) VALUES ({id},'{a}','0')";
                            SqlCommand command4 = new SqlCommand(sqlExpression4, connection);
                            int num = command4.ExecuteNonQuery();
                        }
                        this.Close();
                    }
                }
            }
        }
        
        private void LoginT_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox a = sender as TextBox;
            if(a.Text == "None")
            a.Text = "";
        }

        private void LoginT_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox a = sender as TextBox;
            if (a.Text == "")
            {
                a.Text = "None";
            }
        }
    }
}
