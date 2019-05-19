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
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Data.SqlClient;
namespace SaveMyMoney
{

    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        string lang;
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
        public Registration(string lang)
        {
            this.lang = lang;
            SetLanguage(lang);
            InitializeComponent();
            AddToListShadowEffect();
            SetShadow();
            AddEventsToListShadowEffect();
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
        private void AddToListShadowEffect()
        {
            ListShadowEffect.Add(A1);
            ListShadowEffect.Add(A2);
            ListShadowEffect.Add(A3);
            ListShadowEffect.Add(A4);
            ListShadowEffect.Add(Registrate_button);
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
        private RegistrationModel GetModel()
        {
            return new RegistrationModel
            {
                Login = LoginT.Text,
                Name = NameT.Text,
                Password = PassT.Text,
                Rep_Password = RPassT.Text
            };
        }
        private bool CheckLogin(RegistrationModel model)
        {
            string sqlExpression = $"Select Login from Users where Login = '{model.Login}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else return false;
            }
        }
        private void Validate(RegistrationModel model)
        {
            if (model.Login == "" || model.Password == "" || model.Rep_Password == "" || model.Name == "")
            {
                throw new Exception("Fill all boxes");
            }
            else if (CheckLogin(model))
            {
                throw new Exception("Change Login");
            }
            else if (model.Password.Length < 5)
            {
                throw new Exception("Password min 5 symbols");
            }
            else if (model.Password != model.Rep_Password)
            {
                throw new Exception("Passwords are not same");
            }
        }
        private void GetUserId(ref RegistrationModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sqlExpression = $"Select Id from Users where Login like '{model.Login}'";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        model.Id = int.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
        }
        private void CreateJars(RegistrationModel model)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                for (int a = 1; a <= 6; a++)
                {
                    string sqlExpression = $"INSERT INTO Jars (Id_user,Jar,Money) VALUES ({model.Id},'{a}','0')";
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int num = command.ExecuteNonQuery();
                }
            }
        }
        private void Registrate(object sender, MouseButtonEventArgs e)
        {
            try
            {
                RegistrationModel model = GetModel();
                Validate(model);
                string sqlExpression = $"INSERT INTO Users (Login,Password,Name) VALUES ('{model.Login}', '{model.Password}', '{model.Name}')";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.ExecuteNonQuery();
                }
                GetUserId(ref model);
                CreateJars(model);
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void LoginT_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox a = sender as TextBox;
            if (a.Text == "None")
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
