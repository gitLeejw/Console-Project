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
            //스테이지 로드
            string[] MapContents = Map.LoadStage();


            int playerX = 44;
            int playerY = 3;

            int playerWeaponX = 43;
            int playerWeaponY = 3;

            int playerFire = 42;
            int playerFireStart = playerFire;

            int maxMonster = 4;


            int count = 0;
            bool fireswitch = false;
            int lastTick = 0;
            const int WAIT_TICK = 1000 / 10;




            List<Bullet> bullets = new List<Bullet>();
            List<Monster> monsters = new List<Monster>();


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

                //몬스터 출력
                if (monsters.Count < 5)
                {
                    Monster monsterUnit = new Monster
                    {
                        X = 13,
                        Y = 3,
                        Hp =5
                    };
                    monsters.Add(monsterUnit);
                }

                // 총알 출력
                if (key == ConsoleKey.Spacebar)
                {
                    Bullet bullet = new Bullet();
                    bullet.X = playerFire;
                    bullet.Y = playerWeaponY;

                    bullets.Add(bullet);

                    key = ConsoleKey.Clear;

                }
                //---------------------사용자 입력------------------------
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;


                //---------------------업데이트 --------------------------

                // 총알 진행 로직
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].X > 12)
                    {
                        bullets[i].BulletMove(bullets[i].X--, bullets[i].Y);
                    }
                }



                // 몬스터 이동
                for (int i = 0; i < monsters.Count; i++)
                {

                    monsters[i].MonsterMove();
                }

                // 몬스터 , 총알 충돌처리
                for (int monsterId = 0; monsterId < monsters.Count; monsterId++)
                {
                    for (int bulletId = 0; bulletId < bullets.Count; bulletId++)
                    {
                        if (monsters[monsterId].X == bullets[bulletId].X && monsters[monsterId].Y == bullets[bulletId].Y)
                        {
                            monsters[monsterId].Hp -= bullets[bulletId].Damage;
                            bullets[bulletId].Icon = " ";
                            bullets.RemoveAt(bulletId);

                            // 몬스터 HP 0미만일때 몬스터 삭제
                            if (monsters[monsterId].Hp < 0)
                            {
                                monsters[monsterId].Icon = " ";
                                monsters.RemoveAt(monsterId);
                                

                                break;
                            }


                        }
                    }
                }



                Thread.Sleep(WAIT_TICK);
                


            }// 게임 루프 끝

        }
    }
}

