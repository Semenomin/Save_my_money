using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Effects;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SaveMyMoney.UI
{
    class Trigger
    {
        private readonly List<Grid> ListTriggerEffect = new List<Grid>();
        public Trigger(List<Grid> grids)
        {
            ListTriggerEffect = grids;
            AddEventsToListTriggerEffect();
        }

        private void AddEventsToListTriggerEffect()
        {
            foreach (Grid a in ListTriggerEffect)
            {
                a.MouseEnter += TriggerEffect_Enter;
                a.MouseLeave += TriggerEffect_Leave;
            }
        }

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
    }
}
