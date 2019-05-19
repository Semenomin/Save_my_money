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

namespace SaveMyMoney
{
    /// <summary>
    /// Логика взаимодействия для Creator.xaml
    /// </summary>
    public partial class Creator : Window
    {
        public Creator()
        {
            InitializeComponent();
        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
