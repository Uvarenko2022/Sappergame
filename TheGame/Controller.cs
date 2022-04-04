using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;
using TheGame;


namespace TheGame
{
    internal class Controller
    {
        private Player player;

        public Controller(Player player)
        {
            this.player = player;
        }

        public void KeyEvent(object sender, KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.W:
                    
                    break;
            }
        }
    }
}
