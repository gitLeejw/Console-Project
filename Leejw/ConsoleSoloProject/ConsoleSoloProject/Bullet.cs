using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSoloProject
{
    internal class Bullet
    {
        public int X;
        public int Y;
        public int Damage;
        public string Icon = "<";
        public string Icon2 = " > ";
        //public Bullet (int bulletStartTrX, int bulletStartTrY, int bulletDamage )
        //{
        //    this.StartTrX = bulletStartTrX;
        //    this.StartTrY = bulletStartTrY;
        //    this.Damage = bulletDamage;
        //}

        public void BulletMove(int X, int Y, string Icon)
        {   
                Console.SetCursorPosition(X, Y);
                Console.Write(Icon);

        }
    }
}
