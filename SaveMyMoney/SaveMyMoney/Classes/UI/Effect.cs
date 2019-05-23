using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;

namespace SaveMyMoney.UI
{
    class Effect
    {
        public IEffectable Effectable { private get; set; }
        public void SetEffect(List<Grid> ListGrids)
        {
            foreach (Grid a in ListGrids)
            {
                Effectable.AddEvent(a);
                Effectable.SetEffect(a);
            }
        }
        public void SetEffect(Grid Grids)
        {
            Effectable.AddEvent(Grids);
            Effectable.SetEffect(Grids);
        }
    }

    interface IEffectable
    {
        void AddEvent(Grid Grid);
        void SetEffect(Grid Grid);
        void Enter(object sender, MouseEventArgs e);
        void Leave(object sender, MouseEventArgs e);
    }

    class ShadowEffect : IEffectable
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
        public void AddEvent(Grid Grid)
        {
            Grid.MouseEnter += Enter;
            Grid.MouseLeave += Leave;
        }
        public void Enter(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Effect = Shadow_Enter;
        }
        public void Leave(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Effect = Shadow_Leave;
        }
        public void SetEffect(Grid Grid)
        {

                Grid.Effect = Shadow_Leave;
        }
    }

    class TriggerEffect : IEffectable
    {
        public void AddEvent(Grid Grid)
        {
            Grid.MouseEnter += Enter;
            Grid.MouseLeave += Leave;
        }
        public void Enter(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Opacity = 0.5;
        }
        public void Leave(object sender, MouseEventArgs e)
        {
            Grid a = sender as Grid;
            a.Opacity = 1;
        }
        public void SetEffect(Grid Grid)
        {
        }
    }

    class VisibilityEffect : IEffectable
    {
        public void AddEvent(Grid Grid)
        {
        }
        public void Enter(object sender, MouseEventArgs e)
        {
        }
        public void Leave(object sender, MouseEventArgs e)
        {
        }
        public void SetEffect(Grid Grid)
        {
            Grid.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
