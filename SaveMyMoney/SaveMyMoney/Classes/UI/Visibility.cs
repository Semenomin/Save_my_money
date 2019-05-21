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

namespace SaveMyMoney.UI
{
    class Visibility
    {
        private readonly List<Grid> ListVisibilityEffect = new List<Grid>();

        public Visibility(List<Grid> a)
        {
            ListVisibilityEffect = a;
            SetHiddenVisibility();
        }

        public void SetHiddenVisibility()
        {
            foreach (Grid a in ListVisibilityEffect)
            {
                a.Visibility = System.Windows.Visibility.Hidden;
            }
        }

    }
}
