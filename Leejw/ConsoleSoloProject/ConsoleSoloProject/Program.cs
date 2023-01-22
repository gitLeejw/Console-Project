using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

enum UserKey
{
    None,
    SpaceBar,
    Left,
    Right,
    Up,
    Down,
    G

}

namespace ConsoleSoloProject
{
    class Program
    {

        public static void Main()
        {
            // 콘솔 초기 세팅
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.Title = "강화 디펜스";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Clear();

            //스테이지 로드
            string[] MapContents = Map.LoadStage();


            // 텍스트 위치
            TextPosition text = new TextPosition();

            // 총알 배열 불러오기
            List<Bullet> bullets = new List<Bullet>();

            // 몬스터 배열 불러오기
            List<Monster> monsters = new List<Monster>();

            //몬스터 클래스 불러오기
            Monster monster = new Monster();

            // 업그레이드
            Upgrade upGrade = new Upgrade();

            // 플레이어
            Player player = new Player();

            //시간 측정
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Stopwatch bulletSw = new Stopwatch();
            bulletSw.Start();

            int playerWeaponX = 43;
            int playerWeaponY = 3;

            int playerFire = 42;



            const int WAIT_TICK = 1000 / 15;

            ConsoleKey key;
            key = Console.ReadKey().Key;

        
            while (false)
            {
                Console.Clear();


                //--------------------- 랜  더 ---------------------------
                //랜더 불러오기
                StageBulider();

                Console.SetCursorPosition(text.timeX, text.timeY);
                Console.WriteLine($"제한 시간 : {30 - sw.Elapsed.Seconds} ");
                if (sw.Elapsed.Seconds > 30)
                {
                    //  goto Run;
                }

                //몬스터 출력
                if (monster.Count < monster.Unit)
                {

                    Monster monsterStatus = new Monster
                    {
                        X = 13,
                        Y = 3,
                        Hp = 5
                    };
                    monsters.Add(monsterStatus);
                    monster.Count++;

                }

                // 총알 출력
                if (bulletSw.Elapsed.TotalMilliseconds > 0)
                {
                    if (key == ConsoleKey.Spacebar)
                    {
                        if (bulletSw.Elapsed.Milliseconds > 480)
                        {
                            Bullet bullet = new Bullet();
                            bullet.X = playerFire;
                            bullet.Y = playerWeaponY;
                            bullet.Damage = upGrade.Damage;
                            bullets.Add(bullet);

                            key = ConsoleKey.Clear;
                            bulletSw.Restart();
                        }
                    }
                }


                //---------------------사용자 입력------------------------
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;
               
                //---------------------업데이트 --------------------------

                // 총알 업그레이드
                if (key == ConsoleKey.G)
                {
                    if (upGrade.Gold >= 10)
                    {
                        upGrade.Gold -= 10;
                        upGrade.Damage++;

                        upGrade.DamageText(text.damageTextX, text.damageTextY);

                    }
                    else
                    {
                        upGrade.GoldError(text.goldTextX, text.goldTextY);
                    }
                    key = ConsoleKey.Clear;
                }
                if (key == ConsoleKey.R)
                {
                    goto Run; 
                }


                // 총알 진행 로직
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].X > 12)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        bullets[i].BulletMove(bullets[i].X--, bullets[i].Y);
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }

                // 몬스터 이동
                for (int i = 0; i < monsters.Count; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    monsters[i].MonsterMove();
                    Console.ForegroundColor = ConsoleColor.Blue;
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
                        }
                        else if (monsters[monsterId].X == bullets[bulletId].X - 1 && monsters[monsterId].Y == bullets[bulletId].Y)
                        {
                            monsters[monsterId].Hp -= bullets[bulletId].Damage;
                            bullets[bulletId].Icon = " ";
                            bullets.RemoveAt(bulletId);


                        }
                        // 몬스터 HP 0미만일때 몬스터 삭제
                        if (monsters[monsterId].Hp <= 0)
                        {
                            monsters[monsterId].Icon = " ";
                            monsters.RemoveAt(monsterId);
                            upGrade.Gold += 5;

                            break;
                        }


                    }
                }



                Thread.Sleep(WAIT_TICK);
                
            }// 게임 루프 끝
            
            void StageBulider()
            {   // 맵 그리기.
                for (int i = 0; i < MapContents.Length; i++)
                {
                    Console.WriteLine(MapContents[i]);
                }


                player.PlayerPosition();

                Console.SetCursorPosition(playerWeaponX, playerWeaponY);
                Console.Write("=");

                upGrade.GoldPosition(text.goldX, text.goldY);
                // 데미지 출력
                upGrade.DamagePosition(text.damageX, text.damageY);

                monster.MonsterNumber(text.monsterNumberX, text.monsterNumberY, monsters.Count);
            }
        Run:
            Console.Clear();

            
        }
    }
}




