using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.ComponentModel.Design;

enum UserKey
{
    None,
    SpaceBar,
    Left,
    Right,
    Up,
    Down
}

namespace ConsoleSoloProject
{
    class Program
    {
        public void Start()
        {

        }
        public static void Main()
        {
            // 콘솔 초기 세팅
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "강화 디펜스";
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            string[] MapContents = Map.LoadStage();


            int playerX = 44;
            int playerY = 3;

            int playerWeaponX = 43;
            int playerWeaponY = 3;
            int WeaponDamage = 5;

            int playerFire = 42;
            int playerFireStart = playerFire;

            int maxMonsterX = 12;
            int monsterX = 13;
            int monsterX2 = 0;
            int monsterY = 3;
            int monsterY2 = 0;

            Monster monster = new Monster();
            int monsterHp = 4;
            int monsterUnit = 30;
            string monsterUi = "o";
            int count = 0;
            bool fireswitch = false;
            int lastTick = 0;
            const int WAIT_TICK = 1000 / 5;
            const int DELAY_TIME = 200;

            List<Bullet> bullets = new List<Bullet>();

            ConsoleKey key;
            key = Console.ReadKey().Key;

            while (true)
            {
                Console.Clear();

                //--------------------- 랜  더 ---------------------------
                //스테이지 파일 불러오기
                for (int i = 0; i < MapContents.Length; i++)
                {
                    Console.WriteLine(MapContents[i]);
                }
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("P");
                Console.SetCursorPosition(playerWeaponX, playerWeaponY);
                Console.Write("=");

                

                //---------------------사용자 입력------------------------
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;


                if (key == ConsoleKey.Spacebar)
                {

                    Bullet bullet = new Bullet
                    {
                        X = playerFire , Y = playerWeaponY
                    };

                    bullets.Add(bullet);
                    
                    key = ConsoleKey.Clear; 

                }

                for (int i = 0; i < bullets.Count; i++)
                {
                    bullets[i].BulletMove(bullets[i].X--, bullets[i].Y);
                }
                //---------------------업데이트 --------------------------


                Thread.Sleep(WAIT_TICK);



                if (monsterHp > 0)
                {
                    monsterX = Math.Min(playerX - 3, ++maxMonsterX);
                    Console.SetCursorPosition(++monsterX, monsterY);
                    Console.Write(monsterUi);

                }
                else
                {

                    maxMonsterX = 13; monsterY = 3;
                    monsterX = Math.Min(playerX - 3, ++maxMonsterX);
                    Console.SetCursorPosition(++monsterX, monsterY);
                    Console.Write(monsterUi);
                    monsterHp = 4;
                }
                //++count;

                //if (count == 3)
                //{


                //    Console.SetCursorPosition(++monsterX2, monsterY);
                //    Console.Write(" ");
                //    Console.SetCursorPosition(++monsterX2, monsterY);
                //    Console.Write(" ");
                //    Console.SetCursorPosition(++monsterX2, monsterY);
                //    Console.Write(" ");


                //    count = 0;
                //}





                Thread.Sleep(WAIT_TICK);


            }// 게임 루프 끝

        }
    }
}

