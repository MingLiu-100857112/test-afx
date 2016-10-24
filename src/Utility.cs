using System;
using SwinGameSDK;
namespace MyGame
{
	/// <summary>
	/// Utility.
	/// Combines Controller class's functions to smaller ones. 
	/// </summary>
	public static class Utility
	{
		private static Controller gameController;

        public static Controller GameController
        {
            get
            {
                return gameController;
            }

            set
            {
                gameController = value;
            }
        }

        public static void DefaultScreen()
		{
			SwinGame.OpenGraphicsWindow ("GameMain", 1200, 800);
			SwinGame.ProcessEvents ();
			SwinGame.ClearScreen (Color.White);
		}
		public static void MenuScreen ()
		{
			SwinGame.ProcessEvents ();
			SwinGame.ClearScreen (Color.White);
			GameController.DrawMenu ();
			SwinGame.RefreshScreen (60);
		}

		public static void EndScreen ()
		{
			SwinGame.ProcessEvents ();
			SwinGame.ClearScreen (Color.White);
			GameController.DrawResult ();
			SwinGame.RefreshScreen (60);
		}

		public static void ClearGame(){
			GameController.CleanObjects ();
		}

		public static void InitiliseGameController()
		{
			GameController = new Controller ();
			GameController.LoadResources ();
			GameController.LoadHighScore ();
		}

		public static void CreateObjects()
		{
			SwinGame.ProcessEvents ();
			SwinGame.ClearScreen (Color.White);
			GameController.DeployedObjects ();
			GameController.EquipObjects ();
		}

		public static void CheckCollision()
		{
			GameController.CollisionPlayerVsEnemy ();
			GameController.CollisionEnemyVsBullet ();
			GameController.CollisionPlayerVsBullet ();
			GameController.CheckItemCollsion ();
		}

		public static void DrawGame()
		{
			SwinGame.ProcessEvents ();
			SwinGame.ClearScreen (Color.White);
			GameController.MoveObjects ();
			GameController.DrawObjects ();
			GameController.DrawHUD ();
			GameController.FireObjects ();

		}

		public static bool CheckGameStatus()
		{
			GameController.UpdateScore ();
			GameController.CheckAlive ();
			bool isEnd = GameController.CheckEndGame ();
			return isEnd;
		}

		public static void GameControl()
		{
			SwinGame.ProcessEvents ();
			if (GameController.Player0.Count != 0)
				GameController.ControlWASD ();
			if (GameController.Player1.Count != 0)
				GameController.ControlUDLR ();
		}




	}
}

