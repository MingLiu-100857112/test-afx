using System;
using NUnit.Framework;
using MyGame;
using SwinGameSDK;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestFixture]
    public class UnitTest1
    {
        Player p = new Player(10, 10, 10, 10, 1);
        EnemyCircular ec = new EnemyCircular(20, 20, 20, 20);
        EnemyLinear el = new EnemyLinear(30, 30, 30, 30);
        Controller c1 = new Controller();
        ItemFire i = new ItemFire(1, 1, 1);
        Explosion espl = new Explosion(1, 1, 1);
        Weapon wp = new Weapon(1, 1, 1, 1, BitmapKind.BulletA, 1);

        [Test]
        public void Test_New_Player_X()
        {
            Assert.AreEqual(p.XLocation, 10);
            Assert.AreNotEqual(p.XLocation, 11);
        }

        [Test]
        public void Test_New_Player_Y()
        {
            Assert.AreEqual(p.YLocation, 10);
            Assert.AreNotEqual(p.YLocation, 11);
        }

        [Test]
        public void Test_New_Player_Speed()
        {
            Assert.AreEqual(p.Speed, 10);
            Assert.AreNotEqual(p.Speed, 11);
        }

        [Test]
        public void Test_New_Player_Hp()
        {
            Assert.AreEqual(p.Hp, 10);
            Assert.AreNotEqual(p.Hp, 11);
        }

        [Test]
        public void Test_Player_Equip_FirePower()
        {
            Player p = new Player(5,5,5,5,1);
            p.Equip(1, 1, 1, 1);
            Assert.AreEqual(p.FirePower, 1);
            Assert.AreNotEqual(p.FirePower, 0);
        }

        [Test]
        public void Test_Player_Equip_FireRate()
        {
            Player p = new Player(5, 5, 5, 5, 1);
            p.Equip(1, 1, 1, 1);
            Assert.AreEqual(p.FireRate, 1);
            Assert.AreNotEqual(p.FireRate, 0);
        }

        [Test]
        public void Test_Player_MoveLeft()
        {
            Player p1 = new Player(10, 10, 1, 10, 1);
            p1.ControlDirection = 1;
            p1.Move();
            Assert.AreEqual(p1.XLocation, 9);
            Assert.AreNotEqual(p1.XLocation, 10);
            
        }

        [Test]
        public void Test_Player_MoveRight()
        {
            Player p1 = new Player(10, 10, 1, 10, 1);
            p1.ControlDirection = 2;
            p1.Move();
            Assert.AreEqual(p1.XLocation, 11);
            Assert.AreNotEqual(p1.XLocation, 10);
        }

        [Test]
        public void Test_Player_MoveUp()
        {
            Player p1 = new Player(10, 10, 1, 10, 1);
            p1.ControlDirection = 3;
            p1.Move();
            Assert.AreEqual(p1.YLocation, 9);
            Assert.AreNotEqual(p1.YLocation, 10);
        }

        [Test]
        public void Test_Player_MoveDown()
        {
            Player p1 = new Player(10, 10, 1, 10, 1);
            p1.ControlDirection = 4;
            p1.Move();
            Assert.AreEqual(p1.YLocation, 11);
            Assert.AreNotEqual(p1.YLocation, 10);
        }

        [Test]
        public void Test_Player_Fire()
        {
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 0);
            Assert.AreNotEqual(InGameBullets.GamePlayerWeapon.Count, 1);
            Player p1 = new Player(10, 10, 1, 10, 1);
            p1.Equip(0, 1, 1, 1);
            p1.Fire(1);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 0);
            Assert.AreNotEqual(InGameBullets.GamePlayerWeapon.Count, 1);
            InGameBullets.GameEnemyWeapon.Clear();
            InGameBullets.GamePlayerWeapon.Clear();
        }

        [Test]
        public void Test_Player_Equip_BulletSpeed()
        {
            Player p1 = new Player(10, 10, 1, 10, 1);
            p1.Equip(0, 1, 1, 1);
            Assert.AreEqual(p1.BulletSpeed, 1);
            Assert.AreNotEqual(p1.BulletSpeed, 0);
        }

        [Test]
        public void Test_New_EnemyCircular()
        {
            Assert.AreEqual(ec.XLocation, 20);
            Assert.AreEqual(ec.YLocation, 20);
            Assert.AreEqual(ec.Speed, 20);
            Assert.AreEqual(ec.Hp, 20);
        }

        [Test]
        public void Test_New_EnemyCircular_X()
        {
            Assert.AreEqual(ec.XLocation, 20);
            Assert.AreNotEqual(ec.XLocation, 21);
        }

        [Test]
        public void Test_New_EnemyCircular_Y()
        {
            Assert.AreEqual(ec.YLocation, 20);
            Assert.AreNotEqual(ec.YLocation, 21);
        }

        [Test]
        public void Test_New_EnemyCircular_Speed()
        {
            Assert.AreEqual(ec.Speed, 20);
            Assert.AreNotEqual(ec.Speed, 21);
        }

        [Test]
        public void Test_New_EnemyCircular_Hp()
        {
            Assert.AreEqual(ec.Speed, 20);
            Assert.AreNotEqual(ec.Hp, 21);
        }

        [Test]
        public void Test_EnemyCircular_Move_X()
        {
            EnemyCircular ec = new EnemyCircular(20, 20, 2, 20);
            ec.MovePattern(2,2,2,2,2,2);
            ec.Move();
            Assert.AreEqual(ec.XLocation, 2 + 2 * 2 * Math.Sin(0) * 2);
            Assert.AreNotEqual(ec.XLocation, 2 + 2 * 2 * Math.Sin(1) * 2);
        }

        [Test]
        public void Test_EnemyCircular_Move_Y()
        {
            EnemyCircular ec = new EnemyCircular(20, 20, 2, 20);
            ec.MovePattern(2, 2, 2, 2, 2, 2);
            ec.Move();
            Assert.AreEqual(ec.YLocation, 2 + 2 * 2 * Math.Cos(0) * 2);
            Assert.AreNotEqual(ec.YLocation, 2 + 2 * 2 * Math.Cos(1) * 2);
        }

        [Test]
        public void Test_New_EnemyLinear_X()
        {
            Assert.AreEqual(el.XLocation, 30);
            Assert.AreNotEqual(el.XLocation, 31);
        }

        [Test]
        public void Test_New_EnemyLinear_Y()
        {
            Assert.AreEqual(el.YLocation, 30);
            Assert.AreNotEqual(el.YLocation, 31);
        }

        [Test]
        public void Test_New_EnemyLinear_Speed()
        {
            Assert.AreEqual(el.Speed, 30);
            Assert.AreNotEqual(el.Speed, 31);
        }

        [Test]
        public void Test_New_EnemyLinear_Hp()
        {
            Assert.AreEqual(el.Hp, 30);
            Assert.AreNotEqual(el.Hp, 31);
        }

        /// <summary>
        /// You should add XLocation += _direction * Speed; in another version of game!!
        /// </summary>
        [Test]
        public void Test_EnemyLinear_Move_X()
        {
            EnemyLinear el = new EnemyLinear(5, 5, 2, 5);
            el.MovePattern(2, 1);
            el.Move();
            Assert.AreEqual(el.XLocation, 7);
            Assert.AreNotEqual(el.XLocation, 8);
            el.Move();
            Assert.AreEqual(el.XLocation, 9);
            Assert.AreNotEqual(el.XLocation, 8);
            el.Move();
            Assert.AreEqual(el.XLocation, 7);
            Assert.AreNotEqual(el.XLocation, 8);
        }

        [Test]
        public void Test_EnemyLinear_Move_Y()
        {
            EnemyLinear el = new EnemyLinear(5, 5, 2, 5);
            el.MovePattern(2, 1);
            el.Move();
            Assert.AreEqual(el.YLocation, 7);
            Assert.AreNotEqual(el.YLocation, 8);
            el.Move();
            Assert.AreEqual(el.YLocation, 9);
            Assert.AreNotEqual(el.YLocation, 8);
            el.Move();
            Assert.AreEqual(el.YLocation, 7);
            Assert.AreNotEqual(el.YLocation, 8);
        }

        [Test]
        public void Test_New_Controller_Player0_Count()
        {
            Assert.AreEqual(c1.Player0.Count, 0);
            Assert.AreNotEqual(c1.Player0.Count, 1);
        }

        [Test]
        public void Test_New_Controller_Player1_Count()
        {
            Assert.AreEqual(c1.Player1.Count, 0);
            Assert.AreNotEqual(c1.Player1.Count, 1);
        }

        [Test]
        public void Test_Controller_DeployedObjects_Player0()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            Assert.IsNotNull(c1.Player0[0]);
            Assert.AreEqual(c1.Player0.Count, 1);
            Assert.AreNotEqual(c1.Player0.Count, 0);
            Assert.AreEqual(c1.Player0[0].XLocation, 100);
            Assert.AreNotEqual(c1.Player0[0].XLocation, 99);
            Assert.AreEqual(c1.Player0[0].YLocation, 200);
            Assert.AreNotEqual(c1.Player0[0].YLocation, 199);
            Assert.AreEqual(c1.Player0[0].Speed, 10);
            Assert.AreNotEqual(c1.Player0[0].Speed, 9);
            Assert.AreEqual(c1.Player0[0].Hp, 5);
            Assert.AreNotEqual(c1.Player0[0].Hp, 4);
        }

        [Test]
        public void Test_Controller_DeployedObjects_Player1()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            Assert.IsNotNull(c1.Player1[0]);
            Assert.AreEqual(c1.Player1.Count, 1);
            Assert.AreNotEqual(c1.Player1.Count, 0);
            Assert.AreEqual(c1.Player1[0].XLocation, 100);
            Assert.AreNotEqual(c1.Player1[0].XLocation, 99);
            Assert.AreEqual(c1.Player1[0].YLocation, 600);
            Assert.AreNotEqual(c1.Player1[0].YLocation, 599);
            Assert.AreEqual(c1.Player1[0].Speed, 10);
            Assert.AreNotEqual(c1.Player1[0].Speed, 9);
            Assert.AreEqual(c1.Player1[0].Hp, 5);
            Assert.AreNotEqual(c1.Player1[0].Hp, 4);
        }

        [Test]
        public void Test_Controller_DeployedObjects_EnemiesCircular()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            Assert.IsNotNull(c1.EnemiesCircular[0]);
            Assert.IsNotNull(c1.EnemiesCircular[1]);
            Assert.IsNotNull(c1.EnemiesCircular[2]);
            Assert.AreEqual(c1.EnemiesCircular.Count, 3);
            Assert.AreNotEqual(c1.EnemiesCircular.Count, 2);
            Assert.LessOrEqual(c1.EnemiesCircular[0].XLocation, 1100);
            Assert.GreaterOrEqual(c1.EnemiesCircular[0].XLocation, 500);
            Assert.AreNotEqual(c1.EnemiesCircular[0].XLocation, 499);
            Assert.LessOrEqual(c1.EnemiesCircular[0].YLocation, 750);
            Assert.AreNotEqual(c1.EnemiesCircular[0].YLocation, 499);
            Assert.GreaterOrEqual(c1.EnemiesCircular[0].YLocation, 50);
            Assert.AreEqual(c1.EnemiesCircular[0].Speed, 4);
            Assert.AreNotEqual(c1.EnemiesCircular[0].Speed, 2);
            Assert.AreEqual(c1.EnemiesCircular[0].Hp, 3);
            Assert.AreNotEqual(c1.EnemiesCircular[0].Hp, 4);

            Assert.GreaterOrEqual(c1.EnemiesCircular[1].XLocation, 500);
            Assert.GreaterOrEqual(c1.EnemiesCircular[1].YLocation, 50);

            Assert.LessOrEqual(c1.EnemiesCircular[1].XLocation, 1100);
            Assert.AreNotEqual(c1.EnemiesCircular[1].XLocation, 499);
            Assert.LessOrEqual(c1.EnemiesCircular[1].YLocation, 750);
            Assert.AreNotEqual(c1.EnemiesCircular[1].YLocation, 499);
            Assert.AreEqual(c1.EnemiesCircular[1].Speed, 6);
            Assert.AreNotEqual(c1.EnemiesCircular[1].Speed, 2);
            Assert.AreEqual(c1.EnemiesCircular[1].Hp, 5);
            Assert.AreNotEqual(c1.EnemiesCircular[1].Hp, 4);

            Assert.GreaterOrEqual(c1.EnemiesCircular[2].XLocation, 500);
            Assert.GreaterOrEqual(c1.EnemiesCircular[2].YLocation, 50);

            Assert.LessOrEqual(c1.EnemiesCircular[2].XLocation, 1100);
            Assert.AreNotEqual(c1.EnemiesCircular[2].XLocation, 499);
            Assert.LessOrEqual(c1.EnemiesCircular[2].YLocation, 750);
            Assert.AreNotEqual(c1.EnemiesCircular[2].YLocation, 499);
            Assert.AreEqual(c1.EnemiesCircular[2].Speed, 4);
            Assert.AreNotEqual(c1.EnemiesCircular[2].Speed, 2);
            Assert.AreEqual(c1.EnemiesCircular[2].Hp, 3);
            Assert.AreNotEqual(c1.EnemiesCircular[2].Hp, 4);
        }

        [Test]
        public void Test_Controller_DeployedObjects_EnemiesLinear()
        {
            Controller c2 = new Controller();
            c2.DeployedObjects();
            Assert.IsNotNull(c2.EnemiesLinear[0]);
            Assert.IsNotNull(c2.EnemiesLinear[1]);
            Assert.IsNotNull(c2.EnemiesLinear[2]);
            Assert.AreEqual(c2.EnemiesLinear.Count, 3);
            Assert.AreNotEqual(c2.EnemiesLinear.Count, 2);
            Assert.LessOrEqual(c2.EnemiesLinear[0].XLocation, 1100);
            Assert.AreNotEqual(c2.EnemiesLinear[0].XLocation, 499);
            Assert.LessOrEqual(c2.EnemiesLinear[0].YLocation, 650);
            Assert.AreNotEqual(c2.EnemiesLinear[0].YLocation, 499);
            Assert.AreEqual(c2.EnemiesLinear[0].Speed, 1);
            Assert.AreNotEqual(c2.EnemiesLinear[0].Speed, 2);
            Assert.AreEqual(c2.EnemiesLinear[0].Hp, 3);
            Assert.AreNotEqual(c2.EnemiesLinear[0].Hp, 4);

            Assert.LessOrEqual(c2.EnemiesLinear[1].XLocation, 1100);
            Assert.AreNotEqual(c2.EnemiesLinear[1].XLocation, 499);
            Assert.LessOrEqual(c2.EnemiesLinear[1].YLocation, 700);
            Assert.AreNotEqual(c2.EnemiesLinear[1].YLocation, 499);
            Assert.AreEqual(c2.EnemiesLinear[1].Speed, 2);
            Assert.AreNotEqual(c2.EnemiesLinear[1].Speed, 3);
            Assert.AreEqual(c2.EnemiesLinear[1].Hp, 4);
            Assert.AreNotEqual(c2.EnemiesLinear[1].Hp, 5);

            Assert.LessOrEqual(c2.EnemiesLinear[2].XLocation, 1100);
            Assert.AreNotEqual(c2.EnemiesLinear[2].XLocation, 499);
            Assert.LessOrEqual(c2.EnemiesLinear[2].YLocation, 650);
            Assert.AreNotEqual(c2.EnemiesLinear[2].YLocation, 499);
            Assert.AreEqual(c2.EnemiesLinear[2].Speed, 5);
            Assert.AreNotEqual(c2.EnemiesLinear[2].Speed, 2);
            Assert.AreEqual(c2.EnemiesLinear[2].Hp, 7);
            Assert.AreNotEqual(c2.EnemiesLinear[2].Hp, 4);
        }

        [Test]
        public void Test_Controller_DeployedObjects_ItemsF()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            Assert.IsNotNull(c1.ItemsF[0]);
            Assert.IsNotNull(c1.ItemsF[1]);
            Assert.IsNotNull(c1.ItemsF[2]);
            Assert.AreEqual(c1.ItemsF.Count, 3);
            Assert.AreNotEqual(c1.ItemsF.Count, 2);
            Assert.LessOrEqual(c1.ItemsF[0].XLocation, 1100);
            Assert.AreNotEqual(c1.ItemsF[0].XLocation, 1);
            Assert.LessOrEqual(c1.ItemsF[0].YLocation, 700);
            Assert.AreNotEqual(c1.ItemsF[0].YLocation, 1);
            Assert.AreEqual(c1.ItemsF[0].Type, 1);
            Assert.AreNotEqual(c1.ItemsF[0].Type, 2);

            Assert.LessOrEqual(c1.ItemsF[1].XLocation, 1100);
            Assert.AreNotEqual(c1.ItemsF[1].XLocation, 1);
            Assert.LessOrEqual(c1.ItemsF[1].YLocation, 700);
            Assert.AreNotEqual(c1.ItemsF[1].YLocation, 1);
            Assert.AreEqual(c1.ItemsF[1].Type, 2);
            Assert.AreNotEqual(c1.ItemsF[1].Type, 3);

            Assert.LessOrEqual(c1.ItemsF[2].XLocation, 1100);
            Assert.AreNotEqual(c1.ItemsF[2].XLocation, 1);
            Assert.LessOrEqual(c1.ItemsF[2].YLocation, 700);
            Assert.AreNotEqual(c1.ItemsF[2].YLocation, 1);
            Assert.AreEqual(c1.ItemsF[2].Type, 3);
            Assert.AreNotEqual(c1.ItemsF[2].Type, 2);

            Assert.GreaterOrEqual(c1.ItemsF[0].XLocation, 400);
            Assert.GreaterOrEqual(c1.ItemsF[0].YLocation, 100);
            Assert.GreaterOrEqual(c1.ItemsF[1].XLocation, 400);
            Assert.GreaterOrEqual(c1.ItemsF[1].YLocation, 100);
            Assert.GreaterOrEqual(c1.ItemsF[2].XLocation, 400);
            Assert.GreaterOrEqual(c1.ItemsF[2].YLocation, 100);
        }

        [Test]
        public void Test_Controller_EquipObjects_Player()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.EquipObjects();
            Assert.AreEqual(c1.Player0[0].FireRate, 40);
            Assert.AreNotEqual(c1.Player0[0].FireRate, 39);
            Assert.AreEqual(c1.Player0[0].FirePower, 1);
            Assert.AreNotEqual(c1.Player0[0].FirePower, 2);
            Assert.AreEqual(c1.Player1[0].FireRate, 40);
            Assert.AreNotEqual(c1.Player1[0].FireRate, 39);
            Assert.AreEqual(c1.Player1[0].FirePower, 1);
            Assert.AreNotEqual(c1.Player1[0].FirePower, 2);
        }

        [Test]
        public void Test_Controller_EquipObjects_Enemies()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.EquipObjects();
            Assert.AreEqual(c1.EnemiesLinear[0].FireRate, 100);
            Assert.AreNotEqual(c1.EnemiesLinear[0].FireRate, 99);
            Assert.AreEqual(c1.EnemiesLinear[0].FirePower, 2);
            Assert.AreNotEqual(c1.EnemiesLinear[0].FirePower, 3);
            Assert.AreEqual(c1.EnemiesLinear[1].FireRate, 80);
            Assert.AreNotEqual(c1.EnemiesLinear[1].FireRate, 79);
            Assert.AreEqual(c1.EnemiesLinear[1].FirePower, 2);
            Assert.AreNotEqual(c1.EnemiesLinear[1].FirePower, 3);
            Assert.AreEqual(c1.EnemiesLinear[2].FireRate, 80);
            Assert.AreNotEqual(c1.EnemiesLinear[2].FireRate, 79);
            Assert.AreEqual(c1.EnemiesLinear[2].FirePower, 2);
            Assert.AreNotEqual(c1.EnemiesLinear[2].FirePower, 3);
            Assert.AreEqual(c1.EnemiesCircular[0].FireRate, 120);
            Assert.AreNotEqual(c1.EnemiesCircular[0].FireRate, 119);
            Assert.AreEqual(c1.EnemiesCircular[0].FirePower, 1);
            Assert.AreNotEqual(c1.EnemiesCircular[0].FirePower, 2);
            Assert.AreEqual(c1.EnemiesCircular[1].FireRate, 70);
            Assert.AreNotEqual(c1.EnemiesCircular[1].FireRate, 69);
            Assert.AreEqual(c1.EnemiesCircular[1].FirePower, 1);
            Assert.AreNotEqual(c1.EnemiesCircular[1].FirePower, 2);
            Assert.AreEqual(c1.EnemiesCircular[2].FireRate, 70);
            Assert.AreNotEqual(c1.EnemiesCircular[2].FireRate, 69);
            Assert.AreEqual(c1.EnemiesCircular[2].FirePower, 1);
            Assert.AreNotEqual(c1.EnemiesCircular[2].FirePower, 2);
        }

        [Test]
        public void Test_Controller_CheckAlive()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            Assert.AreEqual(c1.Player0.Count, 1);
            Assert.AreNotEqual(c1.Player0.Count, 2);
            Assert.AreEqual(c1.Player1.Count, 1);
            Assert.AreNotEqual(c1.Player1.Count, 2);
            Assert.AreEqual(c1.EnemiesLinear.Count, 3);
            Assert.AreNotEqual(c1.EnemiesLinear.Count, 2);
            Assert.AreEqual(c1.EnemiesCircular.Count, 3);
            Assert.AreNotEqual(c1.EnemiesCircular.Count, 2);
            c1.EnemiesCircular[0].Hp = 0;
            c1.EnemiesLinear[0].Hp = 0;
            c1.Player0[0].Hp = 0;
            c1.Player1[0].Hp = 0;
            c1.CheckAlive();
            Assert.AreEqual(c1.Player0.Count, 0);
            Assert.AreNotEqual(c1.Player0.Count, 1);
            Assert.AreEqual(c1.Player1.Count, 0);
            Assert.AreNotEqual(c1.Player1.Count, 1);
            Assert.AreEqual(c1.EnemiesLinear.Count, 2);
            Assert.AreNotEqual(c1.EnemiesLinear.Count, 3);
            Assert.AreEqual(c1.EnemiesCircular.Count, 2);
            Assert.AreNotEqual(c1.EnemiesCircular.Count, 3);
        }

        [Test]
        public void Test_Controller_MoveObjects()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.Player0[0] = new Player(10, 10, 1, 10, 1);
            c1.Player0[0].ControlDirection = 4;
            c1.Player1[0] = new Player(10, 10, 1, 10, 1);
            c1.Player1[0].ControlDirection = 4;
            c1.EnemiesCircular[0] = new EnemyCircular(20, 20, 2, 20);
            c1.EnemiesCircular[0].MovePattern(2, 2, 2, 2, 2, 2);
            c1.EnemiesCircular[1] = new EnemyCircular(20, 20, 2, 20);
            c1.EnemiesCircular[1].MovePattern(2, 2, 2, 2, 2, 2);
            c1.EnemiesCircular[2] = new EnemyCircular(20, 20, 2, 20);
            c1.EnemiesCircular[2].MovePattern(2, 2, 2, 2, 2, 2);
            c1.EnemiesLinear[0] = new EnemyLinear(5, 5, 2, 5);
            c1.EnemiesLinear[0].MovePattern(2, 1);
            c1.EnemiesLinear[1] = new EnemyLinear(5, 5, 2, 5);
            c1.EnemiesLinear[1].MovePattern(2, 1);
            c1.EnemiesLinear[2] = new EnemyLinear(5, 5, 2, 5);
            c1.EnemiesLinear[2].MovePattern(2, 1);
            c1.MoveObjects();
            Assert.AreEqual(c1.Player0[0].YLocation, 11);
            Assert.AreNotEqual(c1.Player0[0].YLocation, 10);
            Assert.AreEqual(c1.Player1[0].YLocation, 11);
            Assert.AreNotEqual(c1.Player1[0].YLocation, 10);
            Assert.AreEqual(c1.EnemiesCircular[0].XLocation, 2 + 2 * 2 * Math.Sin(0) * 2);
            Assert.AreNotEqual(c1.EnemiesCircular[0].XLocation, 2 + 2 * 2 * Math.Sin(1) * 2);
            Assert.AreEqual(c1.EnemiesCircular[0].YLocation, 2 + 2 * 2 * Math.Cos(0) * 2);
            Assert.AreNotEqual(c1.EnemiesCircular[0].YLocation, 2 + 2 * 2 * Math.Cos(1) * 2);
            Assert.AreEqual(c1.EnemiesCircular[1].XLocation, 2 + 2 * 2 * Math.Sin(0) * 2);
            Assert.AreNotEqual(c1.EnemiesCircular[1].XLocation, 2 + 2 * 2 * Math.Sin(1) * 2);
            Assert.AreEqual(c1.EnemiesCircular[1].YLocation, 2 + 2 * 2 * Math.Cos(0) * 2);
            Assert.AreNotEqual(c1.EnemiesCircular[1].YLocation, 2 + 2 * 2 * Math.Cos(1) * 2);
            Assert.AreEqual(c1.EnemiesCircular[0].XLocation, 2 + 2 * 2 * Math.Sin(0) * 2);
            Assert.AreNotEqual(c1.EnemiesCircular[0].XLocation, 2 + 2 * 2 * Math.Sin(1) * 2);
            Assert.AreEqual(c1.EnemiesCircular[0].YLocation, 2 + 2 * 2 * Math.Cos(0) * 2);
            Assert.AreNotEqual(c1.EnemiesCircular[0].YLocation, 2 + 2 * 2 * Math.Cos(1) * 2);
            Assert.AreEqual(c1.EnemiesLinear[0].XLocation, 7);
            Assert.AreNotEqual(c1.EnemiesLinear[0].XLocation, 8);
            Assert.AreEqual(c1.EnemiesLinear[0].YLocation, 7);
            Assert.AreNotEqual(c1.EnemiesLinear[0].YLocation, 8);
            Assert.AreEqual(c1.EnemiesLinear[1].XLocation, 7);
            Assert.AreNotEqual(c1.EnemiesLinear[1].XLocation, 8);
            Assert.AreEqual(c1.EnemiesLinear[1].YLocation, 7);
            Assert.AreNotEqual(c1.EnemiesLinear[1].YLocation, 8);
            Assert.AreEqual(c1.EnemiesLinear[2].XLocation, 7);
            Assert.AreNotEqual(c1.EnemiesLinear[2].XLocation, 8);
            Assert.AreEqual(c1.EnemiesLinear[2].YLocation, 7);
            Assert.AreNotEqual(c1.EnemiesLinear[2].YLocation, 8);
        }

        [Test]
        public void Test_Controller_CleanObjects()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            Assert.AreEqual(c1.Explosions.Count, 0);
            Assert.AreNotEqual(c1.Explosions.Count, 1);
            c1.Explosions.Add(new Explosion(1, 1, 1));
            Assert.AreEqual(c1.Explosions.Count, 1);
            Assert.AreNotEqual(c1.Explosions.Count, 2);
            c1.ItemsF.Add(new ItemFire(1, 1, 1));
            c1.CleanObjects();
            Assert.AreEqual(c1.Explosions.Count, 0);
            Assert.AreNotEqual(c1.Explosions.Count, 1);
            Assert.AreEqual(c1.Player0.Count, 0);
            Assert.AreNotEqual(c1.Player0.Count, 1);
            Assert.AreEqual(c1.Player1.Count, 0);
            Assert.AreNotEqual(c1.Player1.Count, 1);
            Assert.AreEqual(c1.ItemsF.Count, 0);
            Assert.AreNotEqual(c1.ItemsF.Count, 1);
            Assert.AreEqual(c1.EnemiesCircular.Count, 0);
            Assert.AreNotEqual(c1.EnemiesCircular.Count, 1);
            Assert.AreEqual(c1.EnemiesLinear.Count, 0);
            Assert.AreNotEqual(c1.EnemiesLinear.Count, 1);
        }

        [Test]
        public void Test_Controller_CheckGameState_BothLose()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.CleanObjects();
            Assert.AreEqual(c1.CheckGameState(), GameState.BothLose);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothWin);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Continue);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player0Win);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player1Win);
        }

        [Test]
        public void Test_Controller_CheckGameState_BothWin()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.EnemiesCircular.Clear();
            c1.EnemiesLinear.Clear();
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothLose);
            Assert.AreEqual(c1.CheckGameState(), GameState.BothWin);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Continue);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player0Win);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player1Win);
        }

        [Test]
        public void Test_Controller_CheckGameState_Player1Win()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.Player0.Clear();
            c1.EnemiesLinear.Clear();
            c1.EnemiesCircular.Clear();
            Assert.AreEqual(c1.Player0.Count, 0);
            Assert.AreEqual(c1.Player1.Count, 1);
            Assert.AreEqual(c1.EnemiesLinear.Count, 0);
            Assert.AreEqual(c1.EnemiesCircular.Count, 0);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothLose);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothWin);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Continue);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player0Win);
            Assert.AreEqual(c1.CheckGameState(), GameState.Player1Win);
        }

        [Test]
        public void Test_Controller_CheckGameState_Player0Win()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.Player1.Clear();
            c1.EnemiesLinear.Clear();
            c1.EnemiesCircular.Clear();
            Assert.AreEqual(c1.Player1.Count, 0);
            Assert.AreEqual(c1.Player0.Count, 1);
            Assert.AreEqual(c1.EnemiesLinear.Count, 0);
            Assert.AreEqual(c1.EnemiesCircular.Count, 0);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothLose);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothWin);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Continue);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player1Win);
            Assert.AreEqual(c1.CheckGameState(), GameState.Player0Win);
        }

        [Test]
        public void Test_Controller_CheckGameState_Continue()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.Player1.Clear();
            c1.EnemiesCircular.Clear();
            Assert.AreEqual(c1.Player1.Count, 0);
            Assert.AreEqual(c1.Player0.Count, 1);
            Assert.AreEqual(c1.EnemiesCircular.Count, 0);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothLose);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.BothWin);
            Assert.AreEqual(c1.CheckGameState(), GameState.Continue);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player1Win);
            Assert.AreNotEqual(c1.CheckGameState(), GameState.Player0Win);
        }

        [Test]
        public void Test_Controller_CheckEndGame_false()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.Player1.Clear();
            c1.EnemiesCircular.Clear();
            Assert.AreEqual(c1.CheckGameState(), GameState.Continue);
            Assert.AreEqual(false, c1.CheckEndGame());
            Assert.AreNotEqual(true, c1.CheckEndGame());
        }

        [Test]
        public void Test_Controller_CheckEndGame_true_Player0Win()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.Player1.Clear();
            c1.EnemiesLinear.Clear();
            c1.EnemiesCircular.Clear();
            Assert.AreEqual(c1.CheckGameState(), GameState.Player0Win);
            Assert.AreEqual(true, c1.CheckEndGame());
            Assert.AreNotEqual(false, c1.CheckEndGame());
        }

        [Test]
        public void Test_Controller_CheckEndGame_true_Player1Win()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.Player0.Clear();
            c1.EnemiesLinear.Clear();
            c1.EnemiesCircular.Clear();
            Assert.AreEqual(c1.CheckGameState(), GameState.Player1Win);
            Assert.AreEqual(true, c1.CheckEndGame());
            Assert.AreNotEqual(false, c1.CheckEndGame());
        }

        [Test]
        public void Test_Controller_CheckEndGame_true_BothWin()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.EnemiesCircular.Clear();
            c1.EnemiesLinear.Clear();
            Assert.AreEqual(c1.CheckGameState(), GameState.BothWin);
            Assert.AreEqual(true, c1.CheckEndGame());
            Assert.AreNotEqual(false, c1.CheckEndGame());
        }

        [Test]
        public void Test_Controller_CheckEndGame_true_BothLose()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.CleanObjects();
            Assert.AreEqual(c1.CheckGameState(), GameState.BothLose);
            Assert.AreEqual(true, c1.CheckEndGame());
            Assert.AreNotEqual(false, c1.CheckEndGame());
        }

        [Test]
        public void Test_New_Explosion_X()
        {
            Assert.AreEqual(1, espl.XLocation);
            Assert.AreNotEqual(0, espl.XLocation);
        }

        [Test]
        public void Test_New_Explosion_Y()
        {
            Assert.AreEqual(1, espl.YLocation);
            Assert.AreNotEqual(0, espl.YLocation);
        }

        [Test]
        public void Test_New_Explosion_Time()
        {
            Assert.AreEqual(1, espl.Time);
            Assert.AreNotEqual(0, espl.Time);
        }

        [Test]
        public void Test_New_Explosion_ElapsedTime()
        {
            Assert.AreEqual(0, espl.ElapsedTime);
            Assert.AreNotEqual(1, espl.ElapsedTime);
        }

        [Test]
        public void Test_New_ItemFire_X()
        {
            Assert.AreEqual(i.XLocation, 1);
            Assert.AreNotEqual(i.XLocation, 2);
        }

        [Test]
        public void Test_New_ItemFire_Y()
        {
            Assert.AreEqual(i.YLocation, 1);
            Assert.AreNotEqual(i.YLocation, 2);
        }

        [Test]
        public void Test_New_ItemFire_Type()
        {
            Assert.AreEqual(i.Type, 1);
            Assert.AreNotEqual(i.Type, 2);
        }

        [Test]
        public void Test_New_Weapon_X()
        {
            Assert.AreEqual(wp.XLocation, 1);
            Assert.AreNotEqual(wp.XLocation, 2);
        }

        [Test]
        public void Test_New_Weapon_Y()
        {
            Assert.AreEqual(wp.YLocation, 1);
            Assert.AreNotEqual(wp.YLocation, 2);
        }

        [Test]
        public void Test_New_Weapon_BulletKind()
        {
            Assert.AreEqual(wp.BulletKind, BitmapKind.BulletA);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.BulletB);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.BulletC);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.EnemyCir);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.EnemyLin);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.Explosion);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.ItemFire1);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.ItemFire2);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.ItemFire3);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.Player0);
            Assert.AreNotEqual(wp.BulletKind, BitmapKind.Player1);
        }

        [Test]
        public void Test_New_Weapon_BulletPower()
        {
            Assert.AreEqual(wp.BulletPower, 1);
            Assert.AreNotEqual(wp.BulletPower, 2);
        }

        [Test]
        public void Test_New_Weapon_BelongTo()
        {
            Assert.AreEqual(wp.BelongTo, 1);
            Assert.AreNotEqual(wp.BelongTo, 2);
        }

        [Test]
        public void Test_Weapon_Move()
        {
            Weapon wpn = new Weapon(3, 3, 1, 1, BitmapKind.BulletA, 1);
            wpn.Move();
            Assert.AreEqual(wpn.XLocation, 2);
            Assert.AreNotEqual(wpn.XLocation, 3);
        }

        [Test]
        public void Test_InGameBullets_MoveBullet()
        {
            Weapon wpn1 = new Weapon(3, 3, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn2 = new Weapon(2, 2, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn3 = new Weapon(3, 3, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn4 = new Weapon(2, 2, 1, 1, BitmapKind.BulletA, 1);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon.Count, 0);
            InGameBullets.GameEnemyWeapon.Add(wpn1);
            InGameBullets.GameEnemyWeapon.Add(wpn2);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon.Count, 2);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 0);
            InGameBullets.GamePlayerWeapon.Add(wpn3);
            InGameBullets.GamePlayerWeapon.Add(wpn4);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 2);
            InGameBullets.MoveBullet();
            Assert.AreEqual(InGameBullets.GameEnemyWeapon[0].XLocation, 2);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon[1].XLocation, 1);
            Assert.AreNotEqual(InGameBullets.GameEnemyWeapon[0].XLocation, 0);
            Assert.AreNotEqual(InGameBullets.GameEnemyWeapon[1].XLocation, 0);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon[0].XLocation, 2);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon[1].XLocation, 1);
            Assert.AreNotEqual(InGameBullets.GamePlayerWeapon[0].XLocation, 0);
            Assert.AreNotEqual(InGameBullets.GamePlayerWeapon[1].XLocation, 0);
            InGameBullets.GameEnemyWeapon.Clear();
            InGameBullets.GamePlayerWeapon.Clear();
        }

        [Test]
        public void Test_InGameBullets_CleanBullets()
        {
            Weapon wpn1 = new Weapon(1201, 3, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn2 = new Weapon(-1, 2, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn3 = new Weapon(3, 801, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn4 = new Weapon(2, -1, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn5 = new Weapon(2, 2, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn6 = new Weapon(3, 3, 1, 1, BitmapKind.BulletA, 1);

            Weapon wpn7 = new Weapon(1201, 3, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn8 = new Weapon(-1, 2, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn9 = new Weapon(3, 801, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn10 = new Weapon(2, -1, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn11 = new Weapon(2, 2, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn12 = new Weapon(3, 3, 1, 1, BitmapKind.BulletA, 1);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon.Count, 0);
            InGameBullets.GameEnemyWeapon.Add(wpn1);
            InGameBullets.GameEnemyWeapon.Add(wpn2);
            InGameBullets.GameEnemyWeapon.Add(wpn3);
            InGameBullets.GameEnemyWeapon.Add(wpn4);
            InGameBullets.GameEnemyWeapon.Add(wpn5);
            InGameBullets.GameEnemyWeapon.Add(wpn6);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon.Count, 6);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 0);
            InGameBullets.GamePlayerWeapon.Add(wpn7);
            InGameBullets.GamePlayerWeapon.Add(wpn8);
            InGameBullets.GamePlayerWeapon.Add(wpn9);
            InGameBullets.GamePlayerWeapon.Add(wpn10);
            InGameBullets.GamePlayerWeapon.Add(wpn11);
            InGameBullets.GamePlayerWeapon.Add(wpn12);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 6);
            InGameBullets.CleanBullet();
            Assert.AreEqual(InGameBullets.GameEnemyWeapon.Count, 2);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 2);
            Assert.AreNotEqual(InGameBullets.GameEnemyWeapon.Count, 1);
            Assert.AreNotEqual(InGameBullets.GamePlayerWeapon.Count, 1);
            InGameBullets.GameEnemyWeapon.Clear();
            InGameBullets.GamePlayerWeapon.Clear();
        }

        [Test]
        public void Test_Utility_ClearGame()
        {
            Utility.GameController = new Controller();
            Utility.GameController.DeployedObjects();
            Assert.AreEqual(Utility.GameController.Explosions.Count, 0);
            Assert.AreNotEqual(Utility.GameController.Explosions.Count, 1);
            Utility.GameController.Explosions.Add(new Explosion(1, 1, 1));
            Assert.AreEqual(Utility.GameController.Explosions.Count, 1);
            Assert.AreNotEqual(Utility.GameController.Explosions.Count, 2);
            Utility.GameController.ItemsF.Add(new ItemFire(1, 1, 1));
            Utility.ClearGame();
            Assert.AreEqual(Utility.GameController.Explosions.Count, 0);
            Assert.AreNotEqual(Utility.GameController.Explosions.Count, 1);
            Assert.AreEqual(Utility.GameController.Player0.Count, 0);
            Assert.AreNotEqual(Utility.GameController.Player0.Count, 1);
            Assert.AreEqual(Utility.GameController.Player1.Count, 0);
            Assert.AreNotEqual(Utility.GameController.Player1.Count, 1);
            Assert.AreEqual(Utility.GameController.ItemsF.Count, 0);
            Assert.AreNotEqual(Utility.GameController.ItemsF.Count, 1);
            Assert.AreEqual(Utility.GameController.EnemiesCircular.Count, 0);
            Assert.AreNotEqual(Utility.GameController.EnemiesCircular.Count, 1);
            Assert.AreEqual(Utility.GameController.EnemiesLinear.Count, 0);
            Assert.AreNotEqual(Utility.GameController.EnemiesLinear.Count, 1);
            Utility.GameController.CleanObjects();
            Utility.GameController = null;
        }

        [Test]
        public void Test_Utility_CheckGameStatus_IsEnd_false_()
        {
            Utility.GameController = new Controller();
            Utility.GameController.DeployedObjects();
            Utility.GameController.Player1.Clear();
            Utility.GameController.EnemiesCircular.Clear();
            Assert.AreEqual(Utility.GameController.CheckGameState(), GameState.Continue);
            Assert.AreEqual(false, Utility.GameController.CheckEndGame());
            Assert.AreNotEqual(true, Utility.GameController.CheckEndGame());
            Assert.AreEqual(false, Utility.CheckGameStatus());
            Utility.GameController.CleanObjects();
            Utility.GameController = null;
        }

        [Test]
        public void Test_Utility_CheckGameStatus_IsEnd_true_Player0Win()
        {
            Utility.GameController = new Controller();
            Utility.GameController.DeployedObjects();
            Utility.GameController.Player1.Clear();
            Utility.GameController.EnemiesLinear.Clear();
            Utility.GameController.EnemiesCircular.Clear();
            Assert.AreEqual(Utility.GameController.CheckGameState(), GameState.Player0Win);
            Assert.AreEqual(true, Utility.GameController.CheckEndGame());
            Assert.AreNotEqual(false, Utility.GameController.CheckEndGame());
            Assert.AreEqual(true, Utility.CheckGameStatus());
            Utility.GameController.CleanObjects();
            Utility.GameController = null;
        }

        [Test]
        public void Test_Utility_CheckGameStatus_IsEnd_true_BothWin()
        {
            Utility.GameController = new Controller();
            Utility.GameController.DeployedObjects();
            Utility.GameController.EnemiesCircular.Clear();
            Utility.GameController.EnemiesLinear.Clear();
            Assert.AreEqual(Utility.GameController.CheckGameState(), GameState.BothWin);
            Assert.AreEqual(true, Utility.GameController.CheckEndGame());
            Assert.AreNotEqual(false, Utility.GameController.CheckEndGame());
            Utility.GameController.CleanObjects();
            Utility.GameController = null;
        }

        [Test]
        public void Test_Utility_CheckGameStatus_IsEnd_true_BothLose()
        {
            Utility.GameController = new Controller();
            Utility.GameController.DeployedObjects();
            Utility.GameController.CleanObjects();
            Assert.AreEqual(Utility.GameController.CheckGameState(), GameState.BothLose);
            Assert.AreEqual(true, Utility.GameController.CheckEndGame());
            Assert.AreNotEqual(false, Utility.GameController.CheckEndGame());
            Utility.GameController.CleanObjects();
            Utility.GameController = null;
        }

        [Test]
        public void Test_Controller_FireObjects()
        {
            Controller c1 = new Controller();
            c1.DeployedObjects();
            c1.FireObjects();
            InGameBullets.GameEnemyWeapon.Clear();
            InGameBullets.GamePlayerWeapon.Clear();
            Weapon wpn1 = new Weapon(3, 3, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn2 = new Weapon(2, 2, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn3 = new Weapon(3, 3, 1, 1, BitmapKind.BulletA, 1);
            Weapon wpn4 = new Weapon(2, 2, 1, 1, BitmapKind.BulletA, 1);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon.Count, 0);
            InGameBullets.GameEnemyWeapon.Add(wpn1);
            InGameBullets.GameEnemyWeapon.Add(wpn2);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon.Count, 2);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 0);
            InGameBullets.GamePlayerWeapon.Add(wpn3);
            InGameBullets.GamePlayerWeapon.Add(wpn4);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon.Count, 2);
            InGameBullets.MoveBullet();
            Assert.AreEqual(InGameBullets.GameEnemyWeapon[0].XLocation, 2);
            Assert.AreEqual(InGameBullets.GameEnemyWeapon[1].XLocation, 1);
            Assert.AreNotEqual(InGameBullets.GameEnemyWeapon[0].XLocation, 0);
            Assert.AreNotEqual(InGameBullets.GameEnemyWeapon[1].XLocation, 0);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon[0].XLocation, 2);
            Assert.AreEqual(InGameBullets.GamePlayerWeapon[1].XLocation, 1);
            Assert.AreNotEqual(InGameBullets.GamePlayerWeapon[0].XLocation, 0);
            Assert.AreNotEqual(InGameBullets.GamePlayerWeapon[1].XLocation, 0);
            InGameBullets.GameEnemyWeapon.Clear();
            InGameBullets.GamePlayerWeapon.Clear();
        }

        [Test]
        public void Test_IPatternCurve_MovePattern()
        {
            EnemyCircular ec = new EnemyCircular(20, 20, 2, 20);
            ec.MovePattern(2, 2, 2, 2, 2, 2);
            ec.Move();
            Assert.AreEqual(ec.XLocation, 2 + 2 * 2 * Math.Sin(0) * 2);
            Assert.AreNotEqual(ec.XLocation, 2 + 2 * 2 * Math.Sin(1) * 2);
        }

        [Test]
        public void Test_IPatternLinear_MovePattern()
        {
            EnemyLinear el = new EnemyLinear(5, 5, 2, 5);
            el.MovePattern(2, 1);
            el.Move();
            Assert.AreEqual(el.XLocation, 7);
            Assert.AreNotEqual(el.XLocation, 8);
            el.Move();
            Assert.AreEqual(el.XLocation, 9);
            Assert.AreNotEqual(el.XLocation, 8);
            el.Move();
            Assert.AreEqual(el.XLocation, 7);
            Assert.AreNotEqual(el.XLocation, 8);
        }
    }
}
