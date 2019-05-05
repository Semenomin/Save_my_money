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

namespace SaveMyMoney
{

   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";
  
        string lang = "ENG";
        object id;

        public MainWindow()
        {
            InitializeComponent();
        }
        #region Изменение тени при наводе мыши на ЭУ

        private void Log_In_Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Drop_shadow_button.Opacity = 0;
        }

        private void Log_In_Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Drop_shadow_button.Opacity = 0.5;
        }


        private void LogIn_button_text_MouseEnter(object sender, MouseEventArgs e)
        {
            Drop_shadow_button.Opacity = 0;
        }

        private void LogIn_button_text_MouseLeave(object sender, MouseEventArgs e)
        {
            Drop_shadow_button.Opacity = 0.50;
        }

        private void Text_box_password_MouseEnter(object sender, MouseEventArgs e)
        {
            Drop_shadow_Text_box_password.Opacity = 0;
        }

        private void Text_box_password_MouseLeave(object sender, MouseEventArgs e)
        {
            Drop_shadow_Text_box_password.Opacity = 0.50;
        }

        private void Text_box_password_text_MouseEnter(object sender, MouseEventArgs e)
        {
            
            Drop_shadow_Text_box_password.Opacity = 0;
        }

        private void Text_box_password_text_MouseLeave(object sender, MouseEventArgs e)
        {
            Drop_shadow_Text_box_password.Opacity = 0.50;
        }

        private void Text_box_Login_text_MouseEnter(object sender, MouseEventArgs e)
        {
            Drop_shadow_Text_box_login.Opacity = 0;
        }

        private void Text_box_Login_text_MouseLeave(object sender, MouseEventArgs e)
        {
            Drop_shadow_Text_box_login.Opacity = 0.50;
        }
        
        private void Button_close_MouseEnter(object sender, MouseEventArgs e)
        {
            Close_Button_Shadow.Opacity = 0;
        }

        private void Button_close_MouseLeave(object sender, MouseEventArgs e)
        {
            Close_Button_Shadow.Opacity = 0.50;
        }
        private void Button_svernut_MouseEnter(object sender, MouseEventArgs e)
        {
            Svernut_shadow.Opacity = 0;
        }

        private void Button_svernut_MouseLeave(object sender, MouseEventArgs e)
        {
            Svernut_shadow.Opacity = 0.50;
        }
        #endregion
        #region Обработка нажатий на кнопки
        private void Button_close_MouseUp(object sender, MouseButtonEventArgs e) //закрытие формы
        {
            this.Close();
        }
        
        private void Лампочка_green_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e) //изменение стилей
        {
           
            
        }
        private void Language_MouseRightButtonUp(object sender, MouseButtonEventArgs e) //изменение языка
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
        private void Button_svernut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Language_button_Loaded(object sender, RoutedEventArgs e) //загрузка пользовательского ЭУ
        {

        }
        private void LogIn_button_text_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string sqlExpression = $"Select Id from Users where Login_text like '{Text_box_Login_text.Text}' and Password_text like '{Text_box_password_text.Text}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        id = reader.GetValue(0);
                    }
                    FirstWindow firstWindow = new FirstWindow(lang);
                    firstWindow.Show();
                    this.Close();
                }
                else
                {
                    //Alarm.Visibility = Visibility.Visible;
                }
                reader.Close();
            }



          
        }
        #endregion
        #region Изменение работа с текстом внутри TextBox
        private void Text_box_Login_text_GotFocus(object sender, RoutedEventArgs e) //очистка поля
        {
            if (Text_box_Login_text.Text == "Login" || Text_box_Login_text.Text == "Логин")
                Text_box_Login_text.Text = "";
        }

        private void Text_box_Login_text_LostFocus(object sender, RoutedEventArgs e) //возврат если поле пустое
        {
            if (Text_box_Login_text.Text == "")
                Text_box_Login_text.Text = this.TryFindResource("Login").ToString();
        }

        private void Text_box_password_text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Text_box_password_text.Text == "")
                Text_box_password_text.Text = this.TryFindResource("Password").ToString();
        }

        private void Text_box_password_text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Text_box_password_text.Text == "Password" || Text_box_password_text.Text == "Пороль")
                Text_box_password_text.Text = "";
        }



        #endregion
        private void Text_box_password_text_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            
            
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Registration reg = new Registration(lang);
            reg.ShowDialog();
        }
    }

    
}