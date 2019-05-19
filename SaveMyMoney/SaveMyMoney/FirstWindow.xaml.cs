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
        List<Grid> ListShadowEffect     = new List<Grid>();
        List<Grid> ListTriggerEffect    = new List<Grid>();
        List<Grid> ListVisibilityEffect = new List<Grid>();

        string lang;

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

        private void TriggerEffect_Enter (object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Opacity = 0.5;
        }
        private void TriggerEffect_Leave (object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Opacity = 1;
        }

        private void SettingsMenuAppear(object sender, MouseButtonEventArgs e)
        {
            if (SettingsMenu.Visibility == Visibility.Visible)
            {
                SettingsMenu.Visibility = Visibility.Hidden;
            }
            else SettingsMenu.Visibility = Visibility.Visible;
        }
        private void ChangeLang        (object sender, MouseButtonEventArgs e)
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
        private void OpenCreatorWindow (object sender, MouseButtonEventArgs e)
        {
            Creator creat = new Creator();
            creat.ShowDialog();
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

        private void AddToListShadowEffect()
        {
            ListShadowEffect.Add(Button_close_grid);
            ListShadowEffect.Add(Button_svernut_grid);
           

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

        private void Close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Svernut(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }














        List<Grid> grids_menu = new List<Grid>();
        List<Grid> grids = new List<Grid>(); //массив гридов для эффектов
        string bufer;
        int jar;
        object id;
        List<Label> jar_lab = new List<Label>();
        public FirstWindow(string lang, UserModel User, IncomeModel Income, ExpenseModel Expense, DebtModel Debt)
        {
            this.lang = lang;
            SetLanguage(lang);
            InitializeComponent();
            AddToListTriggerEffect();
            AddEventsToListShadowEffect();
            AddToListVisibilityEffect();
            SetHiddenVisibility();
            AddToListShadowEffect();
            AddEventsToListShadowEffect();
            SetShadow();





            grids.Add(Grid_moneyIn_menu_button_1);
            grids.Add(Grid_moneyIn_menu_button_2);
            grids.Add(Grid_moneyIn_menu_button_3);
            grids.Add(Grid_text_box_1_Copy);
            grids.Add(Grid_text_box_2_Copy);
            grids.Add(Grid_text_box_3_Copy);
            grids.Add(Grid_text_box_3_Copy1);
            grids.Add(Expense_Name_t);
            grids.Add(Expense_Money_t);
            grids.Add(Expense_Desc_t);
            grids.Add(Expense_Hist_btn);
            grids.Add(Expense_Plan_btn);
            grids.Add(Expense_Add_btn);
            grids.Add(Expense_Period);


            jar_lab.Add(jar1_lab);
            jar_lab.Add(jar2_lab);
            jar_lab.Add(jar3_lab);
            jar_lab.Add(jar4_lab);
            jar_lab.Add(jar5_lab);
            jar_lab.Add(jar6_lab);


            foreach (Grid item in grids) //события изменения эффекта тени для всех гридов в массиве
            {
                item.MouseEnter += Grid_Menu_Button_1_MouseEnter;
                item.MouseLeave += Grid_Menu_Button_1_MouseLeave;
                //item.Effect = Shadow_50;
            }

            grids_menu.Add(Settings_grid);
            grids_menu.Add(LogOut_grid);
            grids_menu.Add(Language_grid);
            grids_menu.Add(Onceamonth);
            grids_menu.Add(Onceaweek);
            grids_menu.Add(Onceayear);
            grids_menu.Add(Onceaday1);
            grids_menu.Add(Onceamonth1);
            grids_menu.Add(Onceaweek1);
            grids_menu.Add(Onceayear1);
            grids_menu.Add(None);
            grids_menu.Add(None1);



            foreach (Grid item in grids_menu) //события изменения эффекта тени для всех гридов в массиве
            {
                item.MouseEnter += Settings_grid_MouseEnter;
                item.MouseLeave += Settings_grid_MouseLeave;
            }


        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void Main_center_button_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_Menu_Button_1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MoneyIn.Visibility = Visibility.Hidden;
            Bottle.Visibility = Visibility.Visible;
        }

        private void Jar1_switch(object sender, MouseButtonEventArgs e)
        {
            jar = 1;
            foreach (Label a in jar_lab)
            {
                a.Visibility = Visibility.Hidden;
            }
            jar1_lab.Visibility = Visibility.Visible;
            string sqlExpression = $"Select * from Jars where Id_user='{id}' and jar_num='1'";
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
                            Lab_Amount.Content = reader.GetValue(2);
                        }

                    }
                }
            }
        }

        private void Jar2_switch(object sender, MouseButtonEventArgs e)
        {
            jar = 2;
            foreach (Label a in jar_lab)
            {
                a.Visibility = Visibility.Hidden;
            }
            jar2_lab.Visibility = Visibility.Visible;
            string sqlExpression = $"Select * from Jars where Id_user='{id}' and jar_num='2'";
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
                            Lab_Amount.Content = reader.GetValue(2);
                        }

                    }
                }
            }
        }

        private void Jar3_switch(object sender, MouseButtonEventArgs e)
        {
            jar = 3;
            foreach (Label a in jar_lab)
            {
                a.Visibility = Visibility.Hidden;
            }
            jar3_lab.Visibility = Visibility.Visible;
            string sqlExpression = $"Select * from Jars where Id_user='{id}' and jar_num='3'";
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
                            Lab_Amount.Content = reader.GetValue(2);
                        }

                    }
                }
            }
        }

        private void Jar4_switch(object sender, MouseButtonEventArgs e)
        {
            jar = 4;
            foreach (Label a in jar_lab)
            {
                a.Visibility = Visibility.Hidden;
            }
            jar4_lab.Visibility = Visibility.Visible;
            string sqlExpression = $"Select * from Jars where Id_user='{id}' and jar_num='4'";
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
                            Lab_Amount.Content = reader.GetValue(2);
                        }

                    }
                }
            }
        }

        private void Jar5_switch(object sender, MouseButtonEventArgs e)
        {
            jar = 5;
            foreach (Label a in jar_lab)
            {
                a.Visibility = Visibility.Hidden;
            }
            jar5_lab.Visibility = Visibility.Visible;
            string sqlExpression = $"Select * from Jars where Id_user='{id}' and jar_num='5'";
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
                            Lab_Amount.Content = reader.GetValue(2);
                        }

                    }
                }
            }
        }

        private void Jar6_switch(object sender, MouseButtonEventArgs e)
        {
            jar = 6;
            foreach (Label a in jar_lab)
            {
                a.Visibility = Visibility.Hidden;
            }
            jar6_lab.Visibility = Visibility.Visible;
            string sqlExpression = $"Select * from Jars where Id_user='{id}' and jar_num='6'";
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
                            Lab_Amount.Content = reader.GetValue(2);
                        }

                    }
                }
            }
        }

        private void Grid_Menu_Button_1_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            //grid.Effect = Shadow_none;
        }

        private void Grid_Menu_Button_1_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            //grid.Effect = Shadow_50;
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

        private void TextBox_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Settings_grid_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            grid.Background = (Brush)TryFindResource("Trigger");
        }

        private void Settings_grid_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            grid.Background = default(Brush);
        }
        bool settings = false;


        private void Language_grid_MouseUp(object sender, MouseButtonEventArgs e)
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

        private void Grid_text_box_3_Copy1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PeriodT.Content = "";
            Period.Visibility = Visibility.Visible;

        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            PeriodT.Content = label.Content;
            Period.Visibility = Visibility.Hidden;
        }

        private void Main_center_button_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MoneyIn.Visibility = Visibility.Visible;
            Bottle.Visibility = Visibility.Hidden;
        }

        private void Expense_Period_MouseUp(object sender, MouseButtonEventArgs e)
        {
            PeriodT1.Content = "";
            Period_expense.Visibility = Visibility.Visible;
        }

        private void Label1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            PeriodT1.Content = label.Content;
            Period_expense.Visibility = Visibility.Hidden;
        }

        private void Label_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        string connectionString = @"Data Source=.\SQLSERVER;Initial Catalog=Save_My_Money;Integrated Security=True";

        private void Grid_moneyIn_menu_button_3_MouseUp(object sender, MouseButtonEventArgs e)
        {

            Income_amountT.Text = Income_amountT.Text.Replace('.', ',');

            float[] mon = new float[7];
            string s;
            if (float.TryParse(Income_amountT.Text, out float parsed))
            {
                mon[1] = (parsed / 100) * 55;
                mon[2] = (parsed / 100) * 10;
                mon[3] = (parsed / 100) * 10;
                mon[4] = (parsed / 100) * 10;
                mon[5] = (parsed / 100) * 10;
                mon[6] = (parsed / 100) * 5;
                MessageBox.Show("good");
            }
            for (int i = 1; i < 7; i++)
            {
                s = $"{mon[i]}";
                s = s.Replace(',', '.');
                string sqlExpression = $"use Save_My_Money Update jars set Money_in_jar = Money_in_jar+{s} where Id_User = '{id}' and Jar_num = '{i}'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int a = command.ExecuteNonQuery();
                }
            }
            string sqlExpression2 = $"INSERT INTO Income (Id_user,Name_income,Money_amount,Desc_income,Period_income,Date_income) values('{id}','{Income_nameT.Text}','{Income_amountT.Text}','{Income_DescT.Text}','{PeriodT.Content}',GETDATE());";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression2, connection);
                int a = command.ExecuteNonQuery();
            }
            Income_amountT.Text = TryFindResource("Money_amount") as string;
            Income_nameT.Text = TryFindResource("income_name") as string;
            Income_DescT.Text = TryFindResource("Description") as string;
            PeriodT.Content = TryFindResource("Period") as string;
        }

        private void Grid_moneyIn_menu_button_1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            History history = new History(id);
            history.Show();
        }

        private void Income_amountT_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Expense_Add_btn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Expense_monT.Text = Expense_monT.Text.Replace(',', '.');
            string sqlExpression = $"Update jars set Money_in_jar = Money_in_jar-{Expense_monT.Text} where Id_User = '{id}' and Jar_num = '{jar}'";
            string sqlExpression2 = $"Select * from Jars where Id_user='{id}' and jar_num='{jar}'";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
                SqlCommand command2 = new SqlCommand(sqlExpression2, connection);
                SqlDataReader reader = command2.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    while (reader.Read()) // построчно считываем данные
                    {
                        if (reader.GetValue(0) != null)
                        {
                            Lab_Amount.Content = reader.GetValue(2);
                        }

                    }
                }
            }
            Expense_monT.Text = TryFindResource("Money_amount") as string;
            Expense_nameT.Text = TryFindResource("ExpenceName") as string;
            Expense_DescT.Text = TryFindResource("Description") as string;
            PeriodT1.Content = TryFindResource("Period") as string;


        }

        private void Expense_monT_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

  
    }
}
