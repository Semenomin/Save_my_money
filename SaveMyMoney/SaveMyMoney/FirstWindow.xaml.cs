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

        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";
        string bufer;
        string lang;
        UserModel User;
        int Jar;
        List<Grid> ListShadowEffect = new List<Grid>();
        List<Grid> ListTriggerEffect = new List<Grid>();
        List<Grid> ListVisibilityEffect = new List<Grid>();

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

        private void TriggerEffect_Enter(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Opacity = 0.5;
        }
        private void TriggerEffect_Leave(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Opacity = 1;
        }
        private void AddToListTriggerEffect()
        {
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

        }
        private void AddEventsToListTriggerEffect()
        {
            foreach (Grid a in ListTriggerEffect)
            {
                a.MouseEnter += TriggerEffect_Enter;
                a.MouseLeave += TriggerEffect_Leave;
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
        private void AddToListShadowEffect()
        {
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

        private void AddToListVisibilityEffect()
        {
            ListVisibilityEffect.Add(SettingsMenu);
            ListVisibilityEffect.Add(Expense_Grid);
            ListVisibilityEffect.Add(Income_grid);
            ListVisibilityEffect.Add(Label_Jar1);
            ListVisibilityEffect.Add(Label_Jar2);
            ListVisibilityEffect.Add(Label_Jar3);
            ListVisibilityEffect.Add(Label_Jar4);
            ListVisibilityEffect.Add(Label_Jar5);
            ListVisibilityEffect.Add(Label_Jar6);
        }
        private void SetHiddenVisibility()
        {
            foreach (Grid a in ListVisibilityEffect)
            {
                a.Visibility = Visibility.Hidden;
            }
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
                List<float> ListJarsMoney = DivideIncome(income);
                AddMoneyInJars(ListJarsMoney);
                AddIncomeInDatabase(income);
                income.Id = GetLastId("Income");
                RestartIncome();
                CreatePlanner(User, "Income", null, income);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private List<float> DivideIncome(IncomeModel income)
        {
            List<float> ListJarsMoney = new List<float>();
            ListJarsMoney.Add(0);
            ListJarsMoney.Add((income.Money / 100) * 55);
            ListJarsMoney.Add((income.Money / 100) * 10);
            ListJarsMoney.Add((income.Money / 100) * 10);
            ListJarsMoney.Add((income.Money / 100) * 10);
            ListJarsMoney.Add((income.Money / 100) * 10);
            ListJarsMoney.Add((income.Money / 100) * 5);
            return ListJarsMoney;
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
        private void AddMoneyInJars(List<float> ListJarsMoney)
        {
            for (int i = 1; i < 7; i++)
            {
                string money = $"{ListJarsMoney[i]}";
                money = money.Replace(',', '.');
                string sqlExpression = $"Update jars set Money = Money+{money} where Id_User = '{User.Id}' and Jar = '{i}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int a = command.ExecuteNonQuery();
                }
            }
        }
        private void AddIncomeInDatabase(IncomeModel income)
        {
            string money = income.Money.ToString();
            money = money.Replace(',', '.');
            string sqlExpression2 = $"INSERT INTO Income (Id_user,Name,Money,Description,Period,Date) values('{User.Id}','{income.Name}','{money}','{income.Description}','{income.Period}',GETDATE());";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                int a = command.ExecuteNonQuery();
            }
        }
        private void RestartIncome()
        {
            Income_MoneyT.Text = TryFindResource("Money_amount") as string;
            Income_nameT.Text = TryFindResource("income_name") as string;
            Income_DescT.Text = TryFindResource("Description") as string;
            Income_PeriodT.Text = TryFindResource("Period") as string;
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

        private void Jar1(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 1;
            SetHiddenVisibility();
            Label_Jar1.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar2(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 2;
            SetHiddenVisibility();
            Label_Jar2.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar3(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 3;
            SetHiddenVisibility();
            Label_Jar3.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar4(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 4;
            SetHiddenVisibility();
            Label_Jar4.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar5(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 5;
            SetHiddenVisibility();
            Label_Jar5.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Jar6(object sender, MouseButtonEventArgs e)
        {
            this.Jar = 6;
            SetHiddenVisibility();
            Label_Jar6.Visibility = Visibility.Visible;
            UseSelectedJar();
        }
        private void Income(object sender, MouseButtonEventArgs e)
        {
            SetHiddenVisibility();
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
                ChangeMoneyInJars(expense);
                AddExpenseInDatabase(expense);
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
        private void AddExpenseInDatabase(ExpenseModel expense)
        {
            string money = expense.Money.ToString();
            money = money.Replace(',', '.');
            string sqlExpression2 = $"INSERT INTO Expense (Id_user,Name,Money,Description,Period,Date,Jar) values('{User.Id}','{expense.Name}','{money}','{expense.Description}','{expense.Period}',GETDATE(),'{Jar}');";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                int a = command.ExecuteNonQuery();
            }
        }
        private void RestartExpense()
        {
            Expense_moneyT.Text = TryFindResource("Money_amount") as string;
            Expense_nameT.Text = TryFindResource("ExpenceName") as string;
            Expense_DescT.Text = TryFindResource("Description") as string;
            Expense_PeriodT.Text = TryFindResource("Period") as string;
        }
        private void ChangeMoneyInJars(ExpenseModel expense)
        {
            string money = Expense_moneyT.Text.Replace(',', '.');
            string sqlExpression = $"Update jars set Money = Money-{money} where Id_User = '{User.Id}' and Jar = '{Jar}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }
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







        public FirstWindow(string lang, UserModel User)
        {
            this.lang = lang;
            this.User = User;
            SetLanguage(lang);
            InitializeComponent();
            AddToListTriggerEffect();
            AddEventsToListTriggerEffect();
            AddToListVisibilityEffect();
            SetHiddenVisibility();
            Income_grid.Visibility = Visibility.Visible;
            AddToListShadowEffect();
            AddEventsToListShadowEffect();
            SetShadow();
            AddEventsToMenuItems();
        }

    }
}
