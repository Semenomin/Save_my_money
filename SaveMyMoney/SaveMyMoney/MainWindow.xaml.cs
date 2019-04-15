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

namespace SaveMyMoney
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string style = "ThemesDark";
        string lang = "ENG";

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
        private void Лампочка_green_MouseEnter(object sender, MouseEventArgs e)
        {
            Shadow_light.Opacity = 0;
        }

        private void Лампочка_green_MouseLeave(object sender, MouseEventArgs e)
        {
            Shadow_light.Opacity = 0.50;
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
           
            if (style == "ThemesLight")
            {
                style = "ThemesDark";
                Text_box_password_text.Foreground = (Brush)this.TryFindResource("MainGreen");
                Text_box_Login_text.Foreground = (Brush)this.TryFindResource("MainGreen");
                Main_grid.Background = (Brush)this.TryFindResource("MainGreen");
                LogIn_button_text.Foreground = (Brush)this.TryFindResource("MainGreen");
                Log_In_Button.Fill = (Brush)this.TryFindResource("SecondGreen");
                Little_1.Fill = (Brush)this.TryFindResource("SecondGreen");
                Little_2.Fill = (Brush)this.TryFindResource("SecondGreen");
                Text_box_Login.Fill = (Brush)this.TryFindResource("SecondGreen");
                Text_box_password.Fill = (Brush)this.TryFindResource("SecondGreen");
                Button_close.Fill = (Brush)this.TryFindResource("SecondGreen");
                Button_svernut.Fill = (Brush)this.TryFindResource("SecondGreen");
                Button_resize_window.Fill = (Brush)this.TryFindResource("SecondGreen");
                Main_label.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Language_button.Change_style();

            }
            else
            {
                style = "ThemesLight";
                Text_box_password_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Text_box_Login_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Main_grid.Background = (Brush)this.TryFindResource("SecondGreen");
                LogIn_button_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Log_In_Button.Fill = (Brush)this.TryFindResource("MainGreen");
                Little_1.Fill = (Brush)this.TryFindResource("MainGreen");
                Little_2.Fill = (Brush)this.TryFindResource("MainGreen");
                Text_box_Login.Fill = (Brush)this.TryFindResource("MainGreen");
                Text_box_password.Fill = (Brush)this.TryFindResource("MainGreen");
                Button_close.Fill = (Brush)this.TryFindResource("MainGreen");
                Button_svernut.Fill = (Brush)this.TryFindResource("MainGreen");
                Button_resize_window.Fill = (Brush)this.TryFindResource("MainGreen");
                Main_label.Foreground = (Brush)this.TryFindResource("MainGreen");
                Language_button.Change_style();
            }
        }
        private void Language_MouseRightButtonUp(object sender, MouseButtonEventArgs e) //изменение языка
        {
            if (lang == "ENG")
            {
                lang = "RUS";
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary_rus.xaml") };
            }
            else
            {
                lang = "ENG";
                this.Resources = new ResourceDictionary() { Source = new Uri("pack://application:,,,/Dictionary_eng.xaml") };

            }
        }
        private void Button_svernut_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Language_button_Loaded(object sender, RoutedEventArgs e) //загрузка пользовательского ЭУ
        {

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

    
    }
}