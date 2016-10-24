using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Controller.
	/// Initilises and draws all game objects.
	/// Draws screens and HUDs.
	/// Checks for collisions and game status.
	/// Controls users' input.
	/// Loads needed resources.
	/// </summary>
	public class Controller
	{
		private List<Player> _player0;
		private List<Player> _player1;
		private List<EnemyCircular> _enemiesCircular;
		private List<EnemyLinear> _enemiesLinear;
		private List<Explosion> _explosions;
		private List<ItemFire> _itemsF;
		private Random _rand;
		private int _highscore;
		private int currentScore0;
		private int currentScore1;
		private int currentHp0;
		private int currentHp1;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Controller"/> class.
		/// </summary>
		public Controller ()
		{
 			_highscore = LoadHighScore ();
			_rand = new Random ();

			_explosions = new List<Explosion> ();
			_itemsF = new List<ItemFire> ();

			_player0 = new List<Player> ();
			_player1 = new List<Player> ();

			_enemiesCircular = new List<EnemyCircular> ();
			_enemiesLinear = new List<EnemyLinear> ();
			currentScore0 = 0;
			currentScore1 = 0;
			currentHp0 = 0;
			currentHp1 = 0;
		}

		/// <summary>
		/// Deployeds the objects.
		/// Add 2 players, 3 items and 6 enemies of both kinds.
		/// </summary>
		public void DeployedObjects(){
			Player0.Add (new Player (100, 200, 10, 5,0));
			Player1.Add (new Player (100, 600, 10, 5,1));

			EnemiesLinear.Add (new EnemyLinear (_rand.Next (500, 1100), _rand.Next (100, 650),1,3));
			EnemiesLinear.Add (new EnemyLinear (_rand.Next (500, 1100), _rand.Next (50, 700), 2, 4));
			EnemiesLinear.Add (new EnemyLinear (_rand.Next (500, 1100), _rand.Next (100, 650), 5, 7));

			EnemiesCircular.Add (new EnemyCircular (_rand.Next (500, 1100), _rand.Next (50, 750), 4, 3));
			EnemiesCircular.Add (new EnemyCircular (_rand.Next (500, 1100), _rand.Next (50, 750), 6,5));
			EnemiesCircular.Add (new EnemyCircular (_rand.Next (500, 1100), _rand.Next (50, 750), 4, 3));

			ItemsF.Add (new ItemFire(_rand.Next (400, 1100),_rand.Next (100, 700),1));
			ItemsF.Add (new ItemFire (_rand.Next (400, 1100), _rand.Next (100, 700), 2));
			ItemsF.Add (new ItemFire (_rand.Next (400, 1100), _rand.Next (100, 700), 3));
		}

		/// <summary>
		/// Equips the players and enemies' moving patterns and weapons.
		/// </summary>
		public void EquipObjects()
		{
			Player0[0].Equip (0, 40, -5,1);
			Player1 [0].Equip (0, 40, -5, 1);

			EnemiesLinear [0].Equip (2,100, 10, 2);
			EnemiesLinear [0].MovePattern (_rand.Next (60, 200), 1);
			EnemiesLinear [1].Equip (1, 80, 10, 2);
			EnemiesLinear [1].MovePattern (_rand.Next (60, 200), -1);
			EnemiesLinear [2].Equip (3, 80, 10, 2);
			EnemiesLinear [2].MovePattern (_rand.Next (80, 200), 1);

			EnemiesCircular [0].Equip (3, 120, 10, 1);
			EnemiesCircular [0].MovePattern (_rand.Next (500, 1000), _rand.Next (100, 500), 20, 70,1,1);
			EnemiesCircular [1].Equip (1, 70, 10, 1);
			EnemiesCircular [1].MovePattern (_rand.Next (600, 900), _rand.Next (200, 400), 40, 50,-1,-1);
			EnemiesCircular [2].Equip (1, 70, 10, 1);
			EnemiesCircular [2].MovePattern (_rand.Next (600, 900), _rand.Next (200, 400), 40, 50, -1, -1);
		}

		/// <summary>
		/// Draws all objects.
		/// </summary>
		public void DrawObjects ()
		{
			SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.Background), 0, 0);

			foreach (Player p0 in Player0)
				p0.Draw ();
			foreach (Player p1 in Player1)
				p1.Draw ();
			foreach (EnemyLinear ene in EnemiesLinear)
				ene.Draw ();
			foreach (EnemyCircular ene in EnemiesCircular)
				ene.Draw ();
			foreach (Weapon pW in InGameBullets.GamePlayerWeapon)
				pW.Draw ();
			foreach (Weapon eW in InGameBullets.GameEnemyWeapon) 
				eW.Draw ();
			foreach (ItemFire itf in ItemsF)
				itf.Draw ();
			for (int i = 0; i < Explosions.Count;i++){
				Explosions [i].Draw ();
				if (Explosions [i].ElapsedTime > Explosions [i].Time)
					Explosions.RemoveAt (i);	
			}
		}

		/// <summary>
		/// Lets players and enemies fire their bullets.
		/// </summary>
		public void FireObjects ()
		{
			foreach (Player p0 in Player0)
				p0.Fire (0);
			foreach (Player p1 in Player1)
				p1.Fire (1);
			foreach (EnemyLinear eneL in EnemiesLinear) 
				eneL.Fire (-1);
			foreach (EnemyCircular eneC in EnemiesCircular)
				eneC.Fire (-1);
		}

		public void MoveObjects ()
		{
			InGameBullets.MoveBullet ();
			InGameBullets.CleanBullet ();
			foreach (Player p0 in Player0)
				p0.Move ();
			foreach (Player p1 in Player1)
				p1.Move ();
			foreach (EnemyCircular eneC in EnemiesCircular ) 
				eneC.Move ();
			foreach (EnemyLinear eneL in EnemiesLinear)
				eneL.Move ();
		}

		/// <summary>
		/// Destroyed when its HP is less than 0.
		/// </summary>
		public void CheckAlive ()
		{
			if (Player0.Count != 0) 
			{
				if (Player0 [0].Hp <= 0) 
				{
					Player0 [0].Score -= 2;
					Player0.RemoveAt (0);
				}
			}
			if (Player1.Count != 0) {
				if (Player1 [0].Hp <= 0) 
				{
					Player1 [0].Score -= 2;
					Player1.RemoveAt (0);
				}
			}

			for (int i = 0; i < EnemiesLinear.Count;i++)
			{
				if (EnemiesLinear [i].Hp <= 0)
					EnemiesLinear.RemoveAt (i);
			}
			for (int i = 0; i < EnemiesCircular.Count; i++) 
			{
				if (EnemiesCircular [i].Hp <= 0)
					EnemiesCircular.RemoveAt (i);
			}
		}

		/// <summary>
		/// Checks if 1 of the players wins or both of them lose or win.
		/// Otherwise, continue game.
		/// </summary>
		/// <returns>The GameState.</returns>
		public GameState CheckGameState()
		{
			if ((EnemiesCircular.Count == 0) && (EnemiesLinear.Count == 0)) 
			{
				if ((Player0.Count != 0) && (Player1.Count == 0))
					return GameState.Player0Win;
				if ((Player0.Count == 0) && (Player1.Count != 0))
					return GameState.Player1Win;
				if ((Player0.Count != 0) && (Player1.Count != 0))
					return GameState.BothWin;
			} 
			if ((Player0.Count == 0) && (Player1.Count == 0))
				return GameState.BothLose;

			return GameState.Continue;
		}

		/// <summary>
		/// Checks the end game.
		/// Clears the remaining objects then update highscore.
		/// </summary>
		/// <returns><c>true</c>, if GameState is not Continue, <c>false</c> otherwise.</returns>
		public bool CheckEndGame ()
		{
			if (CheckGameState () != GameState.Continue) {
				ItemsF.Clear ();
				Explosions.Clear ();
				EnemiesCircular.Clear ();
				EnemiesLinear.Clear ();
				InGameBullets.GameEnemyWeapon.Clear ();
				InGameBullets.GamePlayerWeapon.Clear ();
				UpdateHighScore ();
				return true;
			}
			return false;
		}
		/// <summary>
		/// Clears the game.
		/// </summary>
		public void CleanObjects(){
			Player0.Clear ();
			Player1.Clear ();
			Explosions.Clear ();
			ItemsF.Clear ();
			EnemiesCircular.Clear ();
			EnemiesLinear.Clear ();
			InGameBullets.GameEnemyWeapon.Clear ();
			InGameBullets.GamePlayerWeapon.Clear ();
		}

		/// <summary>
		/// Checks if a player hits an item.
		/// </summary>
		public void CheckItemCollsion()
		{
			if (ItemsF.Count != 0){
				if (Player0.Count != 0){
					for (int i = 0; i < ItemsF.Count; i++) {
						if (SwinGame.BitmapCollision (Controller.GetBitMap (BitmapKind.ItemFire1), (int)ItemsF [i].XLocation, (int)ItemsF [i].YLocation,
													  Controller.GetBitMap (BitmapKind.Player0), (int)Player0 [0].XLocation, (int)Player0 [0].YLocation)) 
						{
							Player0 [0].Equip (ItemsF [i].Type, Player0 [0].FireRate, Player0 [0].BulletSpeed, Player0 [0].FirePower);
							ItemsF.RemoveAt (i);
						}
					}
				}
				if (Player1.Count != 0) {
					for (int i = 0; i < ItemsF.Count; i++) {
						if (SwinGame.BitmapCollision (Controller.GetBitMap (BitmapKind.ItemFire1), (int)ItemsF [i].XLocation, (int)ItemsF [i].YLocation,
													  Controller.GetBitMap (BitmapKind.Player1), (int)Player1 [0].XLocation, (int)Player1 [0].YLocation)) 
						{
							Player1 [0].Equip (ItemsF [i].Type, Player1 [0].FireRate, Player1 [0].BulletSpeed, Player1 [0].FirePower);
							ItemsF.RemoveAt (i);
						}
					}
				}
			}
		}

		/// <summary>
		/// Check for collisions between enemies and bullets.
		/// </summary>
		public void CollisionEnemyVsBullet()
		{
			for (int i = 0; i < InGameBullets.GamePlayerWeapon.Count; i++) {
				for (int j = 0; j < EnemiesCircular.Count; j++) {
					if (SwinGame.BitmapCollision (Controller.GetBitMap (InGameBullets.GamePlayerWeapon [i].BulletKind),(int)InGameBullets.GamePlayerWeapon [i].XLocation,(int)InGameBullets.GamePlayerWeapon [i].YLocation,
												  Controller.GetBitMap (BitmapKind.EnemyCir),(int)EnemiesCircular [j].XLocation,(int)EnemiesCircular [j].YLocation)) 
					{
						Explosions.Add (new Explosion (InGameBullets.GamePlayerWeapon [i].XLocation, InGameBullets.GamePlayerWeapon [i].YLocation, 40));
						SwinGame.PlaySoundEffect ("Bang");

						if (InGameBullets.GamePlayerWeapon [i].BelongTo ==0)
							if (Player0.Count != 0) 
								Player0[0].Score += 2;
						if (InGameBullets.GamePlayerWeapon [i].BelongTo == 1)
							if (Player1.Count != 0) 
								Player1[0].Score += 2;

						EnemiesCircular [j].Hp -= InGameBullets.GamePlayerWeapon [i].BulletPower;
						InGameBullets.GamePlayerWeapon.RemoveAt (i);
					}
				}
				for (int j = 0; j < EnemiesLinear.Count; j++) {
					if (SwinGame.BitmapCollision (Controller.GetBitMap (InGameBullets.GamePlayerWeapon [i].BulletKind),(int)InGameBullets.GamePlayerWeapon [i].XLocation,(int)InGameBullets.GamePlayerWeapon [i].YLocation,
												  Controller.GetBitMap (BitmapKind.EnemyLin),(int)EnemiesLinear [j].XLocation,(int)EnemiesLinear [j].YLocation)) 
					{
						Explosions.Add (new Explosion (InGameBullets.GamePlayerWeapon [i].XLocation, InGameBullets.GamePlayerWeapon [i].YLocation, 40));
						SwinGame.PlaySoundEffect ("Bang");

						if (InGameBullets.GamePlayerWeapon [i].BelongTo == 0)
							if (Player0.Count != 0)
								Player0 [0].Score += 2;
						if (InGameBullets.GamePlayerWeapon [i].BelongTo == 1)
							if (Player1.Count != 0)
								Player1 [0].Score += 2;

						EnemiesLinear [j].Hp -= InGameBullets.GamePlayerWeapon [i].BulletPower;
						InGameBullets.GamePlayerWeapon.RemoveAt (i);
					}
				}
			}
		}
		/// <summary>
		/// Check for collisions between players and bullets.
		/// </summary>
		public void CollisionPlayerVsBullet ()
		{
			if (Player0.Count != 0) {
				for (int i = 0; i < InGameBullets.GameEnemyWeapon.Count; i++) {
					if (SwinGame.BitmapCollision (Controller.GetBitMap (InGameBullets.GameEnemyWeapon [i].BulletKind),
					                              (int)InGameBullets.GameEnemyWeapon [i].XLocation,(int)InGameBullets.GameEnemyWeapon [i].YLocation,
					                              Controller.GetBitMap (BitmapKind.Player0), (int)Player0 [0].XLocation,(int)Player0 [0].YLocation)) 
					{
						Explosions.Add (new Explosion (InGameBullets.GameEnemyWeapon [i].XLocation, InGameBullets.GameEnemyWeapon [i].YLocation, 40));
						SwinGame.PlaySoundEffect ("Bang");

						Player0 [0].Score -= 1;
						Player0 [0].Hp -= InGameBullets.GameEnemyWeapon [i].BulletPower;
						InGameBullets.GameEnemyWeapon.RemoveAt (i);
					}
				}
			}
			if (Player1.Count != 0) {
				for (int i = 0; i < InGameBullets.GameEnemyWeapon.Count; i++) {
					if (SwinGame.BitmapCollision (Controller.GetBitMap (InGameBullets.GameEnemyWeapon [i].BulletKind),
					                              (int)InGameBullets.GameEnemyWeapon [i].XLocation, (int)InGameBullets.GameEnemyWeapon [i].YLocation,
											 	 Controller.GetBitMap (BitmapKind.Player1),(int)Player1 [0].XLocation,(int)Player1 [0].YLocation)) 
					{
						Explosions.Add (new Explosion (InGameBullets.GameEnemyWeapon [i].XLocation, InGameBullets.GameEnemyWeapon [i].YLocation, 40));
						SwinGame.PlaySoundEffect ("Bang");

						Player1 [0].Score -= 1;
						Player1 [0].Hp -= InGameBullets.GameEnemyWeapon [i].BulletPower;
						InGameBullets.GameEnemyWeapon.RemoveAt (i);
					}
				}
			}
		}
		/// <summary>
		/// Check for collisions between enemies and players.
		/// </summary>
		public void CollisionPlayerVsEnemy ()
		{
			for (int i = 0; i < EnemiesCircular.Count; i++) {
				if (Player0.Count != 0) {
					if (SwinGame.BitmapCollision (Controller.GetBitMap (BitmapKind.Player0), (int)Player0 [0].XLocation, (int)Player0 [0].YLocation,
												  Controller.GetBitMap (BitmapKind.EnemyCir), (int)EnemiesCircular [i].XLocation, (int)EnemiesCircular [i].YLocation)) 
					{
						EnemiesCircular [i].Hp -= 2;
						Player0 [0].Hp -= 1;
						Player0 [0].Score -= 2;
					}
				}
				if (Player1.Count != 0){
					if (SwinGame.BitmapCollision (Controller.GetBitMap (BitmapKind.Player1), (int)Player1 [0].XLocation, (int)Player1 [0].YLocation,
												  Controller.GetBitMap (BitmapKind.EnemyCir), (int)EnemiesCircular [i].XLocation, (int)EnemiesCircular [i].YLocation)) 
					{
						EnemiesCircular [i].Hp -= 2;
						Player1 [0].Hp -= 1;
						Player1 [0].Score -= 2;
					}
				}
			}

			for (int i = 0; i < EnemiesLinear.Count; i++) {
				if (Player0.Count != 0) {
					if (SwinGame.BitmapCollision (Controller.GetBitMap (BitmapKind.Player0), (int)Player0 [0].XLocation, (int)Player0 [0].YLocation,
												  Controller.GetBitMap (BitmapKind.EnemyLin), (int)EnemiesLinear [i].XLocation, (int)EnemiesLinear [i].YLocation))
					{
						EnemiesLinear [i].Hp -= 2;
						Player0 [0].Hp -= 1;
						Player0 [0].Score -= 2;
					}
				}
				if (Player1.Count != 0) {
					if (SwinGame.BitmapCollision (Controller.GetBitMap (BitmapKind.Player1), (int)Player1 [0].XLocation, (int)Player1 [0].YLocation,
												  Controller.GetBitMap (BitmapKind.EnemyLin), (int)EnemiesLinear [i].XLocation, (int)EnemiesLinear [i].YLocation)) 
					{
						EnemiesLinear [i].Hp -= 2;
						Player1 [0].Hp -= 1;
						Player1 [0].Score -= 2;
					}
				}
			}
		}
		/// <summary>
		/// Give Player 0 W-A-S-D control type
		/// </summary>
		public void ControlWASD ()
		{
			if (SwinGame.KeyDown (KeyCode.vk_a) && (Player0 [0].XLocation > 20))
				Player0 [0].ControlDirection = 1;
			if (SwinGame.KeyDown (KeyCode.vk_d) && (Player0 [0].XLocation <= 1100))
				Player0 [0].ControlDirection = 2;
			if ((SwinGame.KeyDown (KeyCode.vk_w) && (Player0 [0].YLocation >= 20)))
				Player0 [0].ControlDirection = 3;
			if ((SwinGame.KeyDown (KeyCode.vk_s) && (Player0 [0].YLocation <= 700)))
				Player0 [0].ControlDirection = 4;

			Player0 [0].Move ();
		}

		/// <summary>
		/// Give Player 1 Up-Down-Left-Right control type
		/// </summary>
		public void ControlUDLR ()
		{ 
			if (SwinGame.KeyDown (KeyCode.vk_LEFT) && (Player1 [0].XLocation > 20)) 
				Player1 [0].ControlDirection = 1;
			if (SwinGame.KeyDown (KeyCode.vk_RIGHT) && (Player1 [0].XLocation <= 1100)) 
				Player1 [0].ControlDirection = 2;
			if ((SwinGame.KeyDown (KeyCode.vk_UP) && (Player1 [0].YLocation >= 20))) 
				Player1 [0].ControlDirection = 3;
			if ((SwinGame.KeyDown (KeyCode.vk_DOWN) && (Player1 [0].YLocation <= 700))) 
				Player1 [0].ControlDirection = 4;
			
			Player1 [0].Move ();
		}

		/// <summary>
		/// Updates the high score.
		/// If one of the scores is higher 
		/// then saves that data to local file.
		/// </summary>
		public void UpdateHighScore ()
		{
			if (currentScore0 >= _highscore)
				_highscore = currentScore0;
			if (currentScore1 >= _highscore)
				_highscore = currentScore1;

			System.IO.StreamWriter file = new System.IO.StreamWriter ("highscore.txt");
			file.WriteLine (_highscore);
			file.Close ();
		}

		/// <summary>
		/// Loads the high score from local file if it exists.
		/// </summary>
		/// <returns>The high score.</returns>
		public int LoadHighScore()
		{
			int highscore;
			try 
			{
				System.IO.StreamReader file = new System.IO.StreamReader ("highscore.txt");
				highscore = Int16.Parse (file.ReadLine ());
				file.Close ();
			}
			catch(System.IO.FileNotFoundException)
			{
				return 0;
			}
			return highscore;
		}

		/// <summary>
		/// Draws each player's score and HP onto the screen.
		/// </summary>
		public void DrawHUD ()
		{
			String txtScore0 = "Player 1 score: " + currentScore0;
			String txtScore1 = "Player 2 score: " + currentScore1;
			SwinGame.DrawText (txtScore0, Color.Red, "arial.ttf", 30, 20, 10);
			SwinGame.DrawText (txtScore1, Color.Red, "arial.ttf", 30, 20, 60);

			String txtHp0 = "Player 1 HP: " + currentHp0;
			String txtHp1 = "Player 2 HP: " + currentHp1;
			SwinGame.DrawText (txtHp0, Color.Red, "arial.ttf", 30, 800, 10);
			SwinGame.DrawText (txtHp1, Color.Red, "arial.ttf", 30, 800, 60);
		}
		/// <summary>
		/// Keeps players' data even they are destroyed.
		/// </summary>
		public void UpdateScore ()
		{
			if (Player0.Count != 0) {
				currentScore0 = Player0 [0].Score;
				currentHp0 = Player0 [0].Hp;
			}
			if (Player1.Count != 0) {
				currentScore1 = Player1 [0].Score;
				currentHp1 = Player1 [0].Hp;
			}
		}

		/// <summary>
		/// Draws the result when the game ends.
		/// </summary>
		public void DrawResult ()
		{
			SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.Background), 0, 0);
			if (CheckGameState () == GameState.BothWin)
				SwinGame.DrawText ("Both Players Win!", Color.Yellow, "arial.ttf", 72, 250, 250);
			if (CheckGameState () == GameState.Player0Win)
				SwinGame.DrawText ("Player 1 Win!", Color.Yellow, "arial.ttf", 72, 300, 250);
			if (CheckGameState () == GameState.Player1Win)
				SwinGame.DrawText ("Player 2 Win!", Color.Yellow, "arial.ttf", 72, 300, 250);
			if (CheckGameState () == GameState.BothLose)
				SwinGame.DrawText ("Both Players Lose!", Color.Yellow, "arial.ttf", 72, 300, 250);

			SwinGame.DrawText ("GAME OVER!", Color.Red, "arial.ttf", 72, 300, 100);
			SwinGame.DrawText ("Player 1 Score: " + currentScore0, Color.Blue, "arial.ttf", 48, 320, 400);
			SwinGame.DrawText ("Player 2 Score: " + currentScore1, Color.Blue, "arial.ttf", 48, 320, 500);
			SwinGame.DrawText ("Highscore:" + _highscore, Color.Red, "arial.ttf", 60, 350, 600);
			SwinGame.DrawText ("Press Spacebar to play again!", Color.Red, "arial.ttf", 48, 250, 700);
		}

		/// <summary>
		/// Draws the entry menu.
		/// </summary>
		public void DrawMenu ()
		{
			SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.Background), 0, 0);
			SwinGame.DrawText ("Welcome", Color.Red, "arial.ttf", 200, 150, 200);
			SwinGame.DrawText ("Press Spacebar to play!", Color.Red, "arial.ttf", 60, 250, 700);
		}

		public List<Player> Player0 
		{
			get {
				return _player0;
			}
		}

		public List<Player> Player1 
		{
			get {
				return _player1;
			}
		}

		public List<EnemyCircular> EnemiesCircular 
		{
			get {
				return _enemiesCircular;
			}
		}

		public List<EnemyLinear> EnemiesLinear 
		{
			get {
				return _enemiesLinear;
			}
		}

		public List<Explosion> Explosions {
			get {
				return _explosions;
			}
		}

		public List<ItemFire> ItemsF {
			get {
				return _itemsF;
			}
		}
		/// <summary>
		/// Loads the resources.
		/// </summary>
		public void LoadResources ()
		{
			SwinGame.LoadFont ("arial.ttf", 72);
			SwinGame.LoadBitmapNamed ("BulletA", "bullet1.png");
			SwinGame.LoadBitmapNamed ("BulletB", "bullet2.png");
			SwinGame.LoadBitmapNamed ("BulletC", "bullet3.png");
			SwinGame.LoadBitmapNamed ("Player0", "player.png");
			SwinGame.LoadBitmapNamed ("Player1", "player1.png");
			SwinGame.LoadBitmapNamed ("EnemyCir", "enemycir.png");
			SwinGame.LoadBitmapNamed ("EnemyLin", "enemylin.png");
			SwinGame.LoadBitmapNamed ("Explosion", "explosion.png");
			SwinGame.LoadBitmapNamed ("Background", "background.png");
			SwinGame.LoadBitmapNamed ("ItemFire1", "item1.png");
			SwinGame.LoadBitmapNamed ("ItemFire2", "item2.png");
			SwinGame.LoadBitmapNamed ("ItemFire3", "item3.png");
			SwinGame.LoadSoundEffectNamed ("Bang", "bang.wav");
		}
		/// <summary>
		/// Gets the bitmap kind.
		/// </summary>
		/// <returns>The bitmap.</returns>
		/// <param name="aKind">Bitmap kind.</param>
		public static Bitmap GetBitMap (BitmapKind aKind)
		{
			switch (aKind) {
			case BitmapKind.BulletA:
				return SwinGame.BitmapNamed ("BulletA");
			case BitmapKind.BulletB:
				return SwinGame.BitmapNamed ("BulletB");
			case BitmapKind.BulletC:
				return SwinGame.BitmapNamed ("BulletC");
			case BitmapKind.Player0:
				return SwinGame.BitmapNamed ("Player0");
			case BitmapKind.Player1:
				return SwinGame.BitmapNamed ("Player1");
			case BitmapKind.EnemyCir:
				return SwinGame.BitmapNamed ("EnemyCir");
			case BitmapKind.EnemyLin:
				return SwinGame.BitmapNamed ("EnemyLin");
			case BitmapKind.Explosion:
				return SwinGame.BitmapNamed ("Explosion");
			case BitmapKind.Background:
				return SwinGame.BitmapNamed ("Background");
			case BitmapKind.ItemFire1:
				return SwinGame.BitmapNamed ("ItemFire1");
			case BitmapKind.ItemFire2:
				return SwinGame.BitmapNamed ("ItemFire2");
			case BitmapKind.ItemFire3:
				return SwinGame.BitmapNamed ("ItemFire3");
			default:
				return SwinGame.BitmapNamed ("BulletA");
			}
		}
	}
}

