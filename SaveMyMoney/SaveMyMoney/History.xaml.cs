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
    public partial class History : Window
    {
        public History(UserModel user, string Database, string lang)
        {
            SetLanguage(lang);
            InitializeComponent();
            UI.Shadow shadow = new UI.Shadow(AddToListShadowEffect());
            StockCharacteristic stock = new StockCharacteristic(user, Database, ref stockGrid);
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
        private List<Grid> AddToListShadowEffect()
        {
            List<Grid> ListShadowEffect = new List<Grid>();
            ListShadowEffect.Add(Button_close_grid);
            ListShadowEffect.Add(Button_svernut_grid);
            ListShadowEffect.Add(Delete_button);
            return ListShadowEffect;
        }

        private int GetSelectedIndex()
        {
            int selectedColumn = 0;
            var selectedCell = stockGrid.SelectedCells[selectedColumn];
            var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
            if (cellContent is TextBlock)
            {
                return int.Parse((cellContent as TextBlock).Text);
            }
            throw new Exception("Bad Trip");
        }
        private string GetSelectedType()
        {
            int selectedColumn = 1;
            var selectedCell = stockGrid.SelectedCells[selectedColumn];
            var cellContent = selectedCell.Column.GetCellContent(selectedCell.Item);
            if (cellContent is TextBlock)
            {
                return ((cellContent as TextBlock).Text);
            }
            throw new Exception("Bad Trip");
        }


    }
}