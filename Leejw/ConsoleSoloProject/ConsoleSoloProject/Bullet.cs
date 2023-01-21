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
        public int Damage = 4;
        public string Icon = "<";
        //public Bullet (int bulletStartTrX, int bulletStartTrY, int bulletDamage )
        //{
        //    this.StartTrX = bulletStartTrX;
        //    this.StartTrY = bulletStartTrY;
        //    this.Damage = bulletDamage;
        //}

        public void BulletMove(int X, int Y)
        {   
                Console.SetCursorPosition(X, Y);
                Console.Write(Icon);

        }
    }
}
