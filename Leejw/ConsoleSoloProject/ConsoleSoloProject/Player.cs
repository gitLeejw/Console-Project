using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleSoloProject
{
    internal class Player
    {


        public int X = 44;
        public int Y = 3;
        public string Icon = "P";
        public UserKey userkey;
       
        public void PlayerPosition()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Icon);
        }
    }

}
