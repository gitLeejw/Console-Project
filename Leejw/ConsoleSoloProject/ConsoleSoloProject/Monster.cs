using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class Monster
    {
        public int X;
        public int Y;
        public int Hp;
        public int MonsterUnit = 5;
        public string Icon = "o";



        public void MonsterMove()
        {
            if (X < 43)
            {
                Console.SetCursorPosition(X++, Y);
                Console.Write(Icon);
            }  
        }
    }

}
