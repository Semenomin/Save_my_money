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
using System.Windows.Media.Effects;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace SaveMyMoney
{
    public class RegistrationModel
    {

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Rep_Password { get; set; }
        public string Name { get; set; }
    }
}
