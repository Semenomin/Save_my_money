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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Windows.Media.Effects;

namespace SaveMyMoney
{
    public partial class MainWindow : Window
    {
        string lang = "ENG";

        List<Grid> ListShadowEffect = new List<Grid>();

        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

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

        public MainWindow()
        {
            InitializeComponent();
            AddToListShadowEffect();
            AddEventsToListShadowEffect();
            SetShadow();
        }

        private void AddToListShadowEffect()
        {
            ListShadowEffect.Add(Login_Button_Grid);
            ListShadowEffect.Add(Login_grid);
            ListShadowEffect.Add(Password_Grid);
            ListShadowEffect.Add(Button_close_grid);
            ListShadowEffect.Add(Button_svernut_grid);
        }
        private void AddEventsToListShadowEffect()
        {
            foreach (Grid a in ListShadowEffect)
            {
                a.MouseEnter += ShadowEffect_Enter;
                a.MouseLeave += ShadowEffect_Leave;
            }
        }
        private void SetShadow()
        {
            foreach (Grid a in ListShadowEffect)
            {
                a.Effect = Shadow_Leave;
            }
        }

        private void ShadowEffect_Enter(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Effect = Shadow_Enter;
        }
        private void ShadowEffect_Leave(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Effect = Shadow_Leave;
        }

        private UserModel    GetUserModel()
        {
            string sqlExpression = $"Select id,name from Users where Login = '{Text_box_Login_text.Text}' and Password = '{Text_box_password_text.Text}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new UserModel()
                        {
                            Id = int.Parse(reader.GetValue(0).ToString()),
                            Name = reader.GetValue(1).ToString()
                        };
                    }
                }
                else throw new Exception("Invalid Login or Password");
                return null;
            }
        }
        private IncomeModel  GetIncomeMOdel (UserModel model)
        {
            string sqlExpression = $"Select * from Income where Id_user = '{model.Id}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new IncomeModel()
                        {
                            Id = int.Parse(reader.GetValue(0).ToString()),
                            Date = reader.GetValue(6).ToString(),
                            Money = float.Parse(reader.GetValue(3).ToString()),
                            Name = reader.GetValue(2).ToString(),
                            Description = reader.GetValue(4).ToString(),
                            Period = int.Parse(reader.GetValue(5).ToString())
                        };
                    }
                }
                return null;
            }
        }
        private ExpenseModel GetExpenseModel(UserModel model)
        {
            string sqlExpression = $"Select * from Expense where Id_user = '{model.Id}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new ExpenseModel()
                        {
                            Id = int.Parse(reader.GetValue(0).ToString()),
                            Date = reader.GetValue(6).ToString(),
                            Money = float.Parse(reader.GetValue(3).ToString()),
                            Name = reader.GetValue(2).ToString(),
                            Description = reader.GetValue(4).ToString(),
                            Period = int.Parse(reader.GetValue(5).ToString())
                        };
                    }
                }
                return null;
            }
        }
        private DebtModel    GetDebtModel   (UserModel model)
        {
            string sqlExpression = $"Select * from Debts where Id_user = '{model.Id}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new DebtModel()
                        {
                            Id = int.Parse(reader.GetValue(0).ToString()),
                            From_who = reader.GetValue(2).ToString(),
                            Date = reader.GetValue(3).ToString(),
                            Expence = int.Parse(reader.GetValue(4).ToString()),
                            Income = int.Parse(reader.GetValue(5).ToString()),
                            Return_Date = reader.GetValue(6).ToString(),
                            Jar = int.Parse(reader.GetValue(7).ToString()),
                            Description = reader.GetValue(8).ToString(),
                        };
                    }
                }
                return null;
            }
        }

        private void Login               (object sender, MouseButtonEventArgs e)
        {
            try
            {
                UserModel User = GetUserModel();
                IncomeModel Income = GetIncomeMOdel(User);
                ExpenseModel Expense = GetExpenseModel(User);
                DebtModel Debt = GetDebtModel(User);
                FirstWindow firstWindow = new FirstWindow(lang, User, Income, Expense, Debt);
                firstWindow.Show();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void ChangeLang          (object sender, MouseButtonEventArgs e)
        {
            if (lang == "ENG")
            {
                lang = "RUS";
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resorses/Dictionary_rus.xaml") };
            }
            else
            {
                lang = "ENG";
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Resorses/Dictionary_eng.xaml") };
            }
        }
        private void Close               (object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Svernut             (object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void OpenRegistrationForm(object sender, MouseButtonEventArgs e)
        {
            Registration reg = new Registration(lang);
            reg.ShowDialog();
        }
        
        private void TextEffectGotFocus (object sender, RoutedEventArgs e)
        {
            if (Text_box_Login_text.Text == "Login" || Text_box_Login_text.Text == "Логин")
                Text_box_Login_text.Text = "";
            if (Text_box_password_text.Text == "Password" || Text_box_password_text.Text == "Пороль")
                Text_box_password_text.Text = "";
        }
        private void TextEffectLostFocus(object sender, RoutedEventArgs e)
        {
            if (Text_box_Login_text.Text == "")
                Text_box_Login_text.Text = this.TryFindResource("Login").ToString();
            if (Text_box_password_text.Text == "")
                Text_box_password_text.Text = this.TryFindResource("Password").ToString();
        }
       
    }
}

