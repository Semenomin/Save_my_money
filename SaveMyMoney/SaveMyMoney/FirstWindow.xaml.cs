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

namespace SaveMyMoney
{
    /// <summary>
    /// Логика взаимодействия для FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        List<Grid> grids = new List<Grid>(); //массив гридов для эффектов
        public FirstWindow(string style,string lang)
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

            if (style == "ThemesLight")
            {

                Rec1.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec1.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec2.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec2.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec3.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec3.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec4.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec4.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec5.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec5.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec6.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec6.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec7.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec7.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec8.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec8.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec9.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec9.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec10.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec10.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec11.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec11.Stroke = (Brush)this.TryFindResource("MainGreen");
                Rec12.Fill = (Brush)this.TryFindResource("MainGreen");
                Rec12.Stroke = (Brush)this.TryFindResource("MainGreen");
                Main_grid.Background = (Brush)this.TryFindResource("SecondGreen");
                Rec1_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Rec2_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Rec3_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Rec4_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Rec5_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Rec6_text.Foreground = (Brush)this.TryFindResource("SecondGreen");
                Tool_grid.Background = (Brush)this.TryFindResource("SecondGreen");
            } //смена стиля
            DropShadowEffect Shadow_50_ = Shadow_50;
            DropShadowEffect Shadow_none_ = Shadow_none;
            grids.Add(Grid_Menu_Button_1);
            grids.Add(Grid_Menu_Button_2);
            grids.Add(Grid_Menu_Button_3);
            grids.Add(Grid_Menu_Button_4);
            grids.Add(Grid_Menu_Button_5);
            grids.Add(Grid_Menu_Button_6);
            foreach (Grid item in grids) //события изменения эффекта тени для всех гридов в массиве
            {
                    item.MouseEnter += Grid_Menu_Button_1_MouseEnter;
                    item.MouseLeave += Grid_Menu_Button_1_MouseLeave;
                    item.Effect = Shadow_50;
            }
        }

        private void Main_center_button_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Menu_Button_1_MouseUp(object sender, MouseButtonEventArgs e)
        {
         
           
        }

        private void Grid_Menu_Button_1_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            grid.Effect = Shadow_none;
        }

        private void Grid_Menu_Button_1_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            grid.Effect = Shadow_50;
        }
    }
}
