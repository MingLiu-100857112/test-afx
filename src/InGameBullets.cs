using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	/// <summary>
	/// In game bullets.
	/// Static class.
	/// Keeps the bullets on the screen even when
	/// a player or enemy instance is destroyed.
	/// </summary>
	public static class InGameBullets
	{
		private static List<Weapon> _gamePlayerWeapon = new List<Weapon> ();
		private static List<Weapon> _gameEnemyWeapon = new List<Weapon> ();

		/// <summary>
		/// Updates the postions of all bullets on the screen.
		/// </summary>
		public static void MoveBullet()
		{
			for (int i = 0; i < InGameBullets.GamePlayerWeapon.Count; i++)
				InGameBullets.GamePlayerWeapon [i].Move ();
			for (int i = 0; i < InGameBullets.GameEnemyWeapon.Count; i++)
				InGameBullets.GameEnemyWeapon [i].Move ();
		}

		/// <summary>
		/// Cleans the bullet when they are out of screen.
		/// </summary>
		public static void CleanBullet ()
		{
			for (int i = 0; i < GamePlayerWeapon.Count; i++)
			{
				if( (GamePlayerWeapon[i].XLocation < 0 )
				   ||(GamePlayerWeapon [i].XLocation >1200)
				   ||(GamePlayerWeapon [i].YLocation < 0)
				   || (GamePlayerWeapon [i].YLocation > 800))
				{
					GamePlayerWeapon.RemoveAt (i);
                    --i;
				}
			}
			for (int i = 0; i < GameEnemyWeapon.Count; i++) 
			{
				if ((GameEnemyWeapon [i].XLocation < 0)
				   || (GameEnemyWeapon [i].XLocation > 1200)
				   || (GameEnemyWeapon [i].YLocation < 0)
				   || (GameEnemyWeapon [i].YLocation > 800)) 
				{
					GameEnemyWeapon.RemoveAt (i);
                    --i;
				}
			}
		}

		public static List<Weapon> GamePlayerWeapon 
		{
			get {
				return _gamePlayerWeapon;
			}

			set {
				_gamePlayerWeapon = value;
			}
		}

		public static List<Weapon> GameEnemyWeapon 
		{
			get {
				return _gameEnemyWeapon;
			}

			set {
				_gameEnemyWeapon = value;
			}
		}
	}
}

