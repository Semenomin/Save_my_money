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
    /// Логика взаимодействия для Language.xaml
    /// </summary>
    public partial class Language : UserControl
    {
        string lang = "ENG";
        string style = "Dark";

        public Language()
        {
            InitializeComponent();
          
        }

        private void Language_button_MouseEnter(object sender, MouseEventArgs e)
        {
            Language_button_shadow.Opacity = 0;
        }

        private void Language_button_MouseLeave(object sender, MouseEventArgs e)
        {
            Language_button_shadow.Opacity = 0.50;
        }

        private void Language_button_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        public void Change_style()
        {
            if (style == "Light")
            {
                style = "Dark";
                Ret_1.Fill = (Brush)this.TryFindResource("SecondGreen");
                Ret_2.Fill = (Brush)this.TryFindResource("SecondGreen");
                Ret_3.Fill = (Brush)this.TryFindResource("SecondGreen");
                Label1.Foreground = (Brush)this.TryFindResource("MainGreen");

            }
            else
            {
                style = "Light";
                Ret_1.Fill = (Brush)this.TryFindResource("MainGreen");
                Ret_2.Fill = (Brush)this.TryFindResource("MainGreen");
                Ret_3.Fill = (Brush)this.TryFindResource("MainGreen");
                Label1.Foreground = (Brush)this.TryFindResource("SecondGreen");
            }
        }
    }
}
