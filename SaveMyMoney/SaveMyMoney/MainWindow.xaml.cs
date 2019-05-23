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
        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";
        List<Grid> ListShadowEffect = new List<Grid>();
        string lang = "ENG";
        string pass;
        public MainWindow()
        {
            InitializeComponent();
            UI.Effect effect = new UI.Effect();
            effect.Effectable = new UI.ShadowEffect();
            effect.SetEffect(AddToListShadowEffect());
        }
        private List<Grid> AddToListShadowEffect()
        {
            ListShadowEffect.Add(Login_Button_Grid);
            ListShadowEffect.Add(Login_grid);
            ListShadowEffect.Add(Password_Grid);
            ListShadowEffect.Add(Button_close_grid);
            ListShadowEffect.Add(Button_svernut_grid);
            ListShadowEffect.Add(Lang_grid);
            return ListShadowEffect;
        }

        private UserModel GetUserModel()
        {
            string sqlExpression = $"declare @login nvarchar(50) = '{Text_box_Login_text.Text}', @password nvarchar(50) = '{Text_box_password_text.Text}' exec GetUser @login,@password";
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

        private void Login(object sender, MouseButtonEventArgs e)
        {
            try
            {
                UserModel User = GetUserModel();
                FirstWindow firstWindow = new FirstWindow(lang, User);
                firstWindow.Show();
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void ChangeLang(object sender, MouseButtonEventArgs e)
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
        private void Close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Svernut(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void OpenRegistrationForm(object sender, MouseButtonEventArgs e)
        {
            Registration reg = new Registration(lang);
            reg.ShowDialog();
        }

        private void TextEffectGotFocus(object sender, RoutedEventArgs e)
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
        private void LogIn_form_Loaded(object sender, RoutedEventArgs e)
        {
            ColculatePlanner();
        }

        private void ColculatePlanner()
        {
            string sqlExpression = $"exec UpdatePeriod";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
        }

    }
}