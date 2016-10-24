using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		/// <summary>
		/// The entry point of the program.
		/// Draws Menu, Main Gameplay and EndGame layouts
		/// Press Spacebar to go to next layout.
		/// </summary>
		public static void Main ()
		{
			bool isEnd = false;
			Utility.DefaultScreen ();
			Utility.InitiliseGameController ();

			while (!SwinGame.WindowCloseRequested ()) 
			{
				while (!SwinGame.KeyTyped (KeyCode.vk_SPACE) && (false == SwinGame.WindowCloseRequested ())) 
				{
					Utility.MenuScreen ();
				}

				Utility.CreateObjects ();

				while (!isEnd && (false == SwinGame.WindowCloseRequested ())) 
				{
					Utility.DrawGame ();
					Utility.CheckCollision ();
					Utility.CheckGameStatus ();
					Utility.GameControl ();
					isEnd = Utility.CheckGameStatus ();
					SwinGame.RefreshScreen (60);
				}

				while (!SwinGame.KeyTyped (KeyCode.vk_SPACE) && (false == SwinGame.WindowCloseRequested ()))
				{
					Utility.EndScreen ();
				}
				Utility.ClearGame ();
				isEnd = false;
				SwinGame.ClearScreen (Color.White);
				SwinGame.RefreshScreen (60);
			}
		}
	}
}