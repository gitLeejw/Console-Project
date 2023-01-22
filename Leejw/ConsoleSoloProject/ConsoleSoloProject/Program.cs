using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Linq.Expressions;
using System;

enum UserKey
{
    None,
    SpaceBar,
    Left,
    Right,
    Up,
    Down,
    G,
    R

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

            //씬 불러오기
            Scene scene = new Scene();

            // 텍스트 위치
            TextPosition text = new TextPosition();

            // 총알 배열 불러오기
            List<Bullet> bullets = new List<Bullet>();
            List<Bullet> bullets2 = new List<Bullet>();

            // 몬스터 배열 불러오기
            List<Monster> monsters = new List<Monster>();

            //몬스터 클래스 불러오기
            Monster monster = new Monster();

            // 업그레이드
            Upgrade upGrade = new Upgrade();

            // 플레이어
            Player player = new Player();

            //스테이지실패 시간 측정
            Stopwatch sw = new Stopwatch();
            sw.Start();

            //공격 딜레이 시간측정
            Stopwatch bulletSw = new Stopwatch();
            bulletSw.Start();

            Random random = new Random();
            int random1;

            bool itemFirst = false;
            int playerWeaponX2 = 13;
            int playerWeaponY2 = 9;

            int playerWeaponX = 43;
            int playerWeaponY = 3;

            int playerFire = 42;


            const int WAIT_TICK = 1000 / 15;


            ConsoleKey key;
            key = Console.ReadKey().Key;

            scene.TitleScene(key);

            //scene.gameScene = true;


            while (scene.gameScene)
            {
                Console.Clear();

                //---------------------사용자 입력------------------------
                if (Console.KeyAvailable)
                    key = Console.ReadKey().Key;
                if (key == ConsoleKey.R)
                {
                    goto gameExit;

                }




                //--------------------- 랜  더 ---------------------------
                //랜더 불러오기
                StageBulider();

                Console.SetCursorPosition(text.timeX, text.timeY);
                Console.WriteLine($"제한 시간 : {30 - sw.Elapsed.Seconds} ");
                if (sw.Elapsed.Seconds > 30)
                {
                    goto gameExit;
                }

                // 아이템 뽑기
                if (key == ConsoleKey.D)
                {
                    random1 = random.Next(250);

                    if (random1 > 2)
                    {
                        itemFirst = true;
                    }
                }
                //몬스터 출력
                if (monster.count < monster.unit)
                {

                    Monster monsterStatus = new Monster
                    {
                        X = monster.X,
                        Y = monster.Y,
                        Hp = monster.Hp
                    };
                    monsters.Add(monsterStatus);
                    monster.count++;
                    monster.deathCount = monster.count;

                }

                // 총알 생성
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

                            // 아이템 획득시 총알 생성
                            if (itemFirst)
                            {
                                Bullet bullet2 = new Bullet();
                                bullet2.X = playerWeaponX2;
                                bullet2.Y = playerWeaponY2;
                                bullet2.Damage = upGrade.Damage;
                                bullets2.Add(bullet2);


                            }
                        }

                    }
                }

               
                //---------------------업데이트 --------------------------


                if (monsters.Count == 0)
                {
                    monster.count = 0;
                    monster.Hp += 2;
                    sw.Restart();
                }
                // 총알 업그레이드
                if (key == ConsoleKey.G)
                {
                    if (upGrade.Gold >= 10)
                    {
                        upGrade.Gold -= 10;
                        upGrade.Damage++;

                        text.Position(text.damageTextX, text.damageTextY, upGrade.damageUpgradeText);

                    }
                    else
                    {
                        text.Position(text.goldTextX, text.goldTextY, upGrade.goldErrorText);
                    }
                    key = ConsoleKey.Clear;
                }

                // 총알 진행 로직
                for (int i = 0; i < bullets.Count; i++)
                {
                    if (bullets[i].X > 12)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        bullets[i].BulletMove(bullets[i].X--, bullets[i].Y, "<");
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                }
                // 아이템 생성시 총알 진행 로직
                if (itemFirst)
                {
                    for (int i = 0; i < bullets2.Count; i++)
                    {
                        if (bullets2[i].X < 43)
                        {

                            Console.ForegroundColor = ConsoleColor.White;
                            bullets2[i].BulletMove(bullets2[i].X++, bullets2[i].Y, ">");
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
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
                            bullets.RemoveAt(bulletId);
                        }
                        else if (monsters[monsterId].X == bullets[bulletId].X - 1 && monsters[monsterId].Y == bullets[bulletId].Y)
                        {
                            monsters[monsterId].Hp -= bullets[bulletId].Damage;
                            bullets.RemoveAt(bulletId);


                        }
                        // 몬스터 HP 0미만일때 몬스터 삭제
                        if (monsters[monsterId].Hp <= 0)
                        {

                            monsters.RemoveAt(monsterId);
                            upGrade.Gold += 5;
                            monster.deathCount--;
                            break;
                        }


                    }

                }

                // 아이템 획득시 충돌처리
                for (int monsterId = 0; monsterId < monsters.Count; monsterId++)
                {

                    for (int bulletId = 0; bulletId < bullets2.Count; bulletId++)
                    {
                        if (monsters[monsterId].X == bullets2[bulletId].X && monsters[monsterId].Y == bullets2[bulletId].Y)
                        {
                            monsters[monsterId].Hp -= bullets2[bulletId].Damage;
                            bullets2.RemoveAt(bulletId);
                        }
                        else if (monsters[monsterId].X == bullets2[bulletId].X + 1 && monsters[monsterId].Y == bullets2[bulletId].Y)
                        {
                            monsters[monsterId].Hp -= bullets2[bulletId].Damage;
                            bullets2.RemoveAt(bulletId);


                        }
                        // 몬스터 HP 0미만일때 몬스터 삭제
                        if (monsters[monsterId].Hp <= 0)
                        {

                            monsters.RemoveAt(monsterId);
                            upGrade.Gold += 5;
                            monster.deathCount--;
                            break;
                        }


                    }

                }

                Thread.Sleep(WAIT_TICK);

            }// 게임 루프 끝





        gameExit:
            scene.EndScene();
            void StageBulider()
            {

                // 맵 그리기.
                for (int i = 0; i < MapContents.Length; i++)
                {
                    Console.WriteLine(MapContents[i]);
                }


                text.Position(player.firstPlayerX, player.firstPlayerY, player.Icon);
                text.Position(player.secondPlayerX, player.secondPlayerY, player.Icon);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(playerWeaponX, playerWeaponY);
                Console.Write("=");
                Console.ForegroundColor = ConsoleColor.Blue;
                text.Position(22, 5, "스테이지 : 1");

                text.Position(text.monsterNumberX, text.monsterHpY, $"몬스터 체력 : {monster.Hp}");
                text.Position(text.goldX, text.goldY, $"골드 : {upGrade.Gold}");
                // 데미지 출력
                text.Position(text.damageX, text.damageY, $"공격력 : {upGrade.Damage}");

                text.Position(text.monsterNumberX, text.monsterNumberY, $"몬스터 : {monster.deathCount}");

                if (itemFirst)
                {
                    text.Position(player.secondPlayerX + 2, player.secondPlayerY, "=");
                }


            }

        }

    }
}