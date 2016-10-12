using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{

	//this static class keep the bullets even when the player or enemies are destroyed
	public static class InGameBullets
	{
		private static List<Weapon> _gamePlayerWeapon = new List<Weapon> ();
		private static List<Weapon> _gameEnemyWeapon = new List<Weapon> ();

		//move the bullets on the screen
		public static void MoveBullet(){
			for (int i = 0; i < InGameBullets.GamePlayerWeapon.Count; i++)
				InGameBullets.GamePlayerWeapon [i].Move ();
			for (int i = 0; i < InGameBullets.GameEnemyWeapon.Count; i++)
				InGameBullets.GameEnemyWeapon [i].Move ();
		}

		//check whether they are out of bound
		public static void CleanBullet ()
		{
			for (int i = 0; i < GamePlayerWeapon.Count; i++)
			{
				if( (GamePlayerWeapon[i].XLocation < 0 )
				   ||(GamePlayerWeapon [i].XLocation >SwinGame.ScreenWidth ())
				   ||(GamePlayerWeapon [i].YLocation < 0)
				   || (GamePlayerWeapon [i].XLocation > SwinGame.ScreenHeight ()))
				{
					GamePlayerWeapon.RemoveAt (i);
				}
			}
		}


		//basic properties
		public static List<Weapon> GamePlayerWeapon {
			get {
				return _gamePlayerWeapon;
			}

			set {
				_gamePlayerWeapon = value;
			}
		}


		public static List<Weapon> GameEnemyWeapon {
			get {
				return _gameEnemyWeapon;
			}

			set {
				_gameEnemyWeapon = value;
			}
		}
	}
}

