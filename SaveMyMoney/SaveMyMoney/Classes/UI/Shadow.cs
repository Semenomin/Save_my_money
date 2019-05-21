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
    public class Shadow
    {
        private readonly DropShadowEffect Shadow_Enter = new DropShadowEffect()
        {
            BlurRadius = 6,
            Direction = 315,
            Opacity = 0,
            ShadowDepth = 5
        };
        private readonly DropShadowEffect Shadow_Leave = new DropShadowEffect()
        {
            BlurRadius = 6,
            Direction = 315,
            Opacity = 0.5,
            ShadowDepth = 5
        };
        private readonly List<Grid> ListShadowEffect = new List<Grid>();

        public Shadow(List<Grid> a)
        {
            ListShadowEffect = a;
            AddEventsToListShadowEffect();
            SetShadow();
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
    }
}
