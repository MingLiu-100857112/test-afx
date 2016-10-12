using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Controller
	{
		private List<Player> _player;
		private List<Enemy> _enemies;

		//add player and enemies
		public Controller ()
		{
			_player = new List<Player> ();
			Players.Add ( new Player (SwinGame.ScreenWidth () / 2, SwinGame.ScreenHeight () - 30, 10, 3));

			_enemies = new List<Enemy> ();
			Enemies.Add (new EnemyCircular (300,100, 3, 2));

			Enemies.Add (new EnemyLinear (100, 200, 4, 3));
		}

		// add player's and enemies' weapon & moving pattern
		public void EquipObjects(){
			Players[0].Equip (3, 70, -5, 2);
			
			Enemies [0].Equip (1, 50, 10, 1);
			Enemies [0].MovePattern (100, 100, 50, 50);

			Enemies [1].Equip (1, 70, 10, 2);
			Enemies [1].MovePattern (100,1);
		}

		//draw player, enemies ad bullets
		public void DrawObjects ()
		{

			foreach (Player pl in Players)
				pl.Draw (Color.Red);

			foreach (Enemy ene in Enemies)
				ene.Draw (Color.Blue);
			

			foreach (Weapon pW in InGameBullets.GamePlayerWeapon)
				pW.Draw (Color.Red);
			
			foreach (Weapon eW in InGameBullets.GameEnemyWeapon) 
				eW.Draw (Color.Blue);
			
		}

		//let them fire their bullets
		public void FireObjects ()
		{
			foreach (Player pl in Players)
				pl.Fire ();

			foreach (Enemy ene in Enemies) 
				ene.Fire ();
			
			InGameBullets.MoveBullet ();
			InGameBullets.CleanBullet ();

		}

		//give player and enemies  new X, Y location
		public void MoveObjects ()
		{
			foreach (Player pl in Players)
				pl.Move ();
			foreach (Enemy ene in Enemies) 
				ene.Move ();
			
		}

		//check collision
		//maybe a bug here
		public void CheckCollision ()
		{
			//enemies vs player's bullet
			for (int i = 0; i < InGameBullets.GamePlayerWeapon.Count; i++){
				for (int j = 0; j < Enemies.Count; j++){
					if ((InGameBullets.GamePlayerWeapon[i].XLocation >= Enemies[j].XLocation - 20)
						&&(InGameBullets.GamePlayerWeapon [i].XLocation <= Enemies [j].XLocation +20)
						&&(InGameBullets.GamePlayerWeapon [i].YLocation >= Enemies [j].YLocation - 20)
					    &&(InGameBullets.GamePlayerWeapon [i].YLocation <= Enemies [j].YLocation + 20))
							{
								
								Enemies [j].Hp -= InGameBullets.GamePlayerWeapon [i].BulletPower;
								InGameBullets.GamePlayerWeapon.RemoveAt (i);
							}
				}
			}

			//player vs enemy's bullet
			for (int i = 0; i < InGameBullets.GameEnemyWeapon.Count; i++) {
				
					for (int j = 0; j < Players.Count; j++) {
						if ((InGameBullets.GameEnemyWeapon [i].XLocation >= Players[j].XLocation - 20)
							&& (InGameBullets.GameEnemyWeapon [i].XLocation <= Players [j].XLocation + 20)
							&& (InGameBullets.GameEnemyWeapon [i].YLocation >= Players [j].YLocation - 20)
							&& (InGameBullets.GameEnemyWeapon [i].YLocation <= Players [j].YLocation + 20)) 
								{

									Players [j].Hp -= InGameBullets.GameEnemyWeapon [i].BulletPower;
									InGameBullets.GameEnemyWeapon.RemoveAt (i);

								}
					}

			}
		}

		// check whether their hps < 0
		public void CheckAlive ()
		{
			for (int i = 0; i < Enemies.Count; i++) {
				if (Enemies [i].Hp <= 0)
					Enemies.RemoveAt (i);
			}
			for (int j = 0; j < Players.Count; j++) {
				if (Players [j].Hp <= 0)
					Players.RemoveAt (j);
			}
		}
		public void CheckEndGame(){
			if (Players.Count != 0){
				SwinGame.DrawText ("GAME OVER!", Color.Red, "gameover", 100, 200,400 ); // bug here/ message not shown
			}
		}



		//basic properties

		public List<Enemy> Enemies {
			get {
				return _enemies;
			}

			set {
				_enemies = value;
			}
		}

		public List<Player> Players {
			get {
				return _player;
			}

			set {
				_player = value;
			}
		}

	}
}

