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
using System.Data.SqlClient;

namespace SaveMyMoney
{

    public partial class FirstWindow : Window
    {
        #region Variables
        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";
        string bufer;
        string lang;
        UserModel User;
        int Jar;
        UI.Visibility visibility;
        #endregion
        #region Add In List
        private List<Grid> AddToListShadowEffect()
        {
            List<Grid> ListShadowEffect = new List<Grid>();
            ListShadowEffect.Add(Button_close_grid);
            ListShadowEffect.Add(Button_svernut_grid);
            ListShadowEffect.Add(Income_name_grid);
            ListShadowEffect.Add(Income_money_grid);
            ListShadowEffect.Add(Income_period_grid);
            ListShadowEffect.Add(Income_description_grid);
            ListShadowEffect.Add(Income_button_Add);
            ListShadowEffect.Add(Income_button_History);
            ListShadowEffect.Add(Expense_History);
            ListShadowEffect.Add(Expense_Planner);
            ListShadowEffect.Add(Expense_Add);
            ListShadowEffect.Add(Expense_Name);
            ListShadowEffect.Add(Expense_Money);
            ListShadowEffect.Add(Expense_Period);
            ListShadowEffect.Add(Expense_Description);
            return ListShadowEffect;
        }
        private List<Grid> AddToListTriggerEffect()
        {
            List<Grid> ListTriggerEffect = new List<Grid>();
            ListTriggerEffect.Add(Menu1);
            ListTriggerEffect.Add(Menu2);
            ListTriggerEffect.Add(Menu3);
            ListTriggerEffect.Add(Menu4);
            ListTriggerEffect.Add(Menu5);
            ListTriggerEffect.Add(Menu6);
            ListTriggerEffect.Add(Menu7);
            ListTriggerEffect.Add(Creator);
            ListTriggerEffect.Add(Language_grid);
            ListTriggerEffect.Add(Settings_grid);
            ListTriggerEffect.Add(LogOut_grid);
            return ListTriggerEffect;
        }
        private List<Grid> AddToListVisibilityEffect()
        {
            List<Grid> ListVisibilityEffect = new List<Grid>();
            ListVisibilityEffect.Add(SettingsMenu);
            ListVisibilityEffect.Add(Expense_Grid);
            ListVisibilityEffect.Add(Income_grid);
            ListVisibilityEffect.Add(Label_Jar1);
            ListVisibilityEffect.Add(Label_Jar2);
            ListVisibilityEffect.Add(Label_Jar3);
            ListVisibilityEffect.Add(Label_Jar4);
            ListVisibilityEffect.Add(Label_Jar5);
            ListVisibilityEffect.Add(Label_Jar6);
            return ListVisibilityEffect;
        }
        private void AddEventsToMenuItems()
        {
            Menu1.MouseUp += Income;
            Menu2.MouseUp += Jar1;
            Menu3.MouseUp += Jar2;
            Menu4.MouseUp += Jar3;
            Menu5.MouseUp += Jar4;
            Menu6.MouseUp += Jar5;
            Menu7.MouseUp += Jar6;
            Menu2.MouseUp += SetExpenseVisible;
            Menu3.MouseUp += SetExpenseVisible;
            Menu4.MouseUp += SetExpenseVisible;
            Menu5.MouseUp += SetExpenseVisible;
            Menu6.MouseUp += SetExpenseVisible;
            Menu7.MouseUp += SetExpenseVisible;
        }
        #endregion
        #region Income
        private void AddIncome(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ValidateIncome();
                IncomeModel income = new IncomeModel()
                {
                    Date = DateTime.Today.ToString(),
                    Money = float.Parse(Income_MoneyT.Text.ToString()),
                    Name = Income_nameT.Text.ToString(),
                    Description = Income_DescT.Text.ToString(),
                    Period = int.Parse(Income_PeriodT.Text.ToString())
                };
                income.Work(User);
                income.Id = GetLastId("Income");
                RestartIncome();
                CreatePlanner(User, "Income", null, income);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void ValidateIncome()
        {
            Income_MoneyT.Text = Income_MoneyT.Text.Replace('.', ',');

            if (float.TryParse(Income_MoneyT.Text, out float a))
            {
                if (int.TryParse(Income_PeriodT.Text.ToString(), out int b))
                {
                    if (b < 0) throw new Exception("Invalid Period");
                }
                else throw new Exception("Invalid Period");
            }
            else throw new Exception("Invalid Money Amount");

        }
        private void RestartIncome()
        {
            Income_MoneyT.Text = TryFindResource("Money_amount") as string;
            Income_nameT.Text = TryFindResource("income_name") as string;
            Income_DescT.Text = TryFindResource("Description") as string;
            Income_PeriodT.Text = TryFindResource("Period") as string;
        }
        #endregion
        #region Mouse Click
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
        private void OpenIncomeHistoryWindow(object sender, MouseButtonEventArgs e)
        {
            History history = new History(User, "Income", lang);
            history.Show();
        }
        private void SettingsMenuAppear(object sender, MouseButtonEventArgs e)
        {
            if (SettingsMenu.Visibility == Visibility.Visible)
            {
                SettingsMenu.Visibility = Visibility.Hidden;
            }
            else SettingsMenu.Visibility = Visibility.Visible;
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
        private void OpenCreatorWindow(object sender, MouseButtonEventArgs e)
        {
            Creator creat = new Creator();
            creat.ShowDialog();
        }
        private void LogOut(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void OpenPlanner(object sender, MouseButtonEventArgs e)
        {
            Planner planner = new Planner(lang, User);
            planner.Show();
        }

        #endregion
        #region Pages
        private void Jar1(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 1;
            visibility.SetHiddenVisibility();
            Label_Jar1.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar2(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 2;
            visibility.SetHiddenVisibility();
            Label_Jar2.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar3(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 3;
            visibility.SetHiddenVisibility();
            Label_Jar3.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar4(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 4;
            visibility.SetHiddenVisibility();
            Label_Jar4.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar5(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 5;
            visibility.SetHiddenVisibility();
            Label_Jar5.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar6(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 6;
            visibility.SetHiddenVisibility();
            Label_Jar6.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Income(object sender, MouseButtonEventArgs e)
        {
            visibility.SetHiddenVisibility();
            Income_grid.Visibility = Visibility.Visible;
        }
        private void SetExpenseVisible(object sender, MouseButtonEventArgs e)
        {
            Expense_Grid.Visibility = Visibility.Visible;
        }
        private void UseSelectedJar()
        {
            string sqlExpression = $"Select * from Jars where Id_user='{User.Id}' and jar='{Jar}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(0) != null)
                        {
                            Lab_Amount.Text = reader.GetValue(2).ToString();
                        }
                    }
                }
            }
        }
        #endregion
        #region Expense
        private void AddExpense(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ValidateExpense();
                ExpenseModel expense = new ExpenseModel()
                {
                    Date = DateTime.Today.ToString(),
                    Money = float.Parse(Expense_moneyT.Text.ToString()),
                    Name = Expense_nameT.Text.ToString(),
                    Description = Expense_DescT.Text.ToString(),
                    Period = int.Parse(Expense_PeriodT.Text.ToString())
                };
                expense.Work(User,Jar);
                expense.Id = GetLastId("Expense");
                RestartExpense();
                CreatePlanner(User, "Expense", expense, null);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void ValidateExpense()
        {
            Expense_moneyT.Text = Expense_moneyT.Text.Replace('.', ',');

            if (float.TryParse(Expense_moneyT.Text, out float a))
            {
                if (int.TryParse(Expense_PeriodT.Text.ToString(), out int b))
                {
                    if (b < 0) throw new Exception("Invalid Period");
                }
                else throw new Exception("Invalid Period");
            }
            else throw new Exception("Invalid Money Amount");

        }
        private void RestartExpense()
        {
            Expense_moneyT.Text = TryFindResource("Money_amount") as string;
            Expense_nameT.Text = TryFindResource("ExpenceName") as string;
            Expense_DescT.Text = TryFindResource("Description") as string;
            Expense_PeriodT.Text = TryFindResource("Period") as string;
        }
        private void UpdateGrafic(object sender, TextChangedEventArgs e)
        {
            if (float.TryParse(Expense_moneyT.Text, out float result))
            {
                Lab_Amount.Text = Lab_Amount.Text.Replace('.', ',');
                float a = float.Parse(Lab_Amount.Text);
                Grafic.Height = (Grafic_Main.Height/100)*(result * 100)/a;
                Grafic_Amount.Text = result.ToString();
                if (Grafic.Height > Grafic_Main.Height)
                {
                    Grafic_Amount.Foreground = Brushes.Red;
                }
                else Grafic_Amount.Foreground = (Brush)TryFindResource("SecondBlue");
            }
            else
            {
                Expense_moneyT.Text = Expense_moneyT.Text.Replace('.', ',');
            }
        }
        private void OpenExpenseHistoryWindow(object sender, MouseButtonEventArgs e)
        {
            History history = new History(User, "Expense", lang);
            history.Show();
        }
        #endregion
        #region Other Func
        private void CreatePlanner(UserModel user,string mod,ExpenseModel expense, IncomeModel income)
        {
            string sqlExpression;
            if (mod == "Expense")
            {
                sqlExpression = $"INSERT INTO Planner (Id_user,Expense,Date,Period) values('{user.Id}', '{expense.Id}', GETDATE(), '{expense.Period}'); ";
            }
            else
            {
                sqlExpression = $"INSERT INTO Planner (Id_user,Income,Date,Period) values('{user.Id}', '{income.Id}', GETDATE(), '{income.Period}'); ";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int a = command.ExecuteNonQuery();
            }
        }
        private int GetLastId(string mod)
        {
            string sqlExpression;
            if (mod == "Expense")
            {
                sqlExpression = $"Select Max(Id) from Expense";
            }
            else
            {
                sqlExpression = $"Select Max(Id) from Income";
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader.GetValue(0).ToString());
                    }
                }
            }
            return 0;
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
        private void Text_box_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == "")
                textBox.Text = bufer;
        }
        private void Text_box_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            bufer = textBox.Text;
            if (textBox.Text == bufer)
                textBox.Text = "";
        }
        #endregion
        public FirstWindow(string lang, UserModel User)
        {
            this.lang = lang;
            this.User = User;
            SetLanguage(lang);
            InitializeComponent();
            UI.Trigger trigger = new UI.Trigger(AddToListTriggerEffect());
            UI.Shadow shadow = new UI.Shadow(AddToListShadowEffect());
            visibility = new UI.Visibility(AddToListVisibilityEffect());
            Income_grid.Visibility = Visibility.Visible;
            AddEventsToMenuItems();
        }
    }
}
