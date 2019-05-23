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
    /// <summary>
    /// Логика взаимодействия для Planner.xaml
    /// </summary>
    public partial class Planner : Window
    {
        private readonly string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";
        UserModel user;
        public Planner(string lang, UserModel user)
        {
            this.user = user;
            SetLanguage(lang);
            InitializeComponent();
            UI.Effect effect = new UI.Effect();
            effect.Effectable = new UI.ShadowEffect();
            effect.SetEffect(AddToListShadowEffect());
            StockPlanner stock = new StockPlanner(user, ref stockGrid);
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
            ListShadowEffect.Add(Null_button);
            ListShadowEffect.Add(Update_button);
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
        private void NullPeriod(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sqlExpression = $"Update Planner set Period = 0 where {GetSelectedType()} = {GetSelectedIndex()}";
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
                    sqlCommand.ExecuteNonQuery();
                    string sqlExpression2 = $"Update {GetSelectedType()} set Period = 0 where Id={GetSelectedIndex()}";
                    SqlCommand sqlCommand2 = new SqlCommand(sqlExpression2, connection);
                    sqlCommand2.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Choose string");
            }
        }
        private void Update(object sender, MouseButtonEventArgs e)
        {
            StockPlanner stock = new StockPlanner(user, ref stockGrid);
        }
    }
}
