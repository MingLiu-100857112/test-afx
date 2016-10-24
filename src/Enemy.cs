using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	/// <summary>
	/// Enemy.
	/// Inherites FlyingObject.
	/// Base class for all types of enemies.
	/// </summary>
	public abstract class Enemy : FlyingObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Enemy"/> class.
		/// </summary>
		/// <param name="aXLocation">Enemy's X Location.</param>
		/// <param name="aYLocation">Enemy's A Y Location.</param>
		/// <param name="aSpeed">Enemy's speed.</param>
		/// <param name="aHp">Enemy's hp.</param>
		public Enemy(double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation, aSpeed, aHp){}

		/// <summary>
		/// Fire the bullets.
		/// Enemies have 3 types of weapon depends on equiped _bulletType.
		/// '1' - single. '1' - double. '2' - triple.
		/// Each enemy has 1 bullet color depends on belongTo.
		/// '2' - Yellow. 
		/// </summary>
		/// <param name="belongTo">Enemy bullet bitmap, '2' is default.</param>
		public override void Fire (int belongTo)
		{
			switch (_bulletType) 
			{
			case 1:
				if (_timerCount++ == FireRate) 
				{
					_timerCount = 0;
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation, YLocation+ ENEMY_BITMAP_CENTRE_X, _bulletSpeed, _firePower, BitmapKind.BulletC, belongTo));
				}
				break;

			case 2:
				if (_timerCount++ == FireRate) 
				{
					_timerCount = 0;
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation, YLocation + ENEMY_BITMAP_CENTRE_X + 15, _bulletSpeed, _firePower, BitmapKind.BulletC,  belongTo));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation, YLocation + ENEMY_BITMAP_CENTRE_X - 15, _bulletSpeed, _firePower, BitmapKind.BulletC, belongTo));
				}
				break;

			case 3:
				if (_timerCount++ == FireRate) 
				{
					_timerCount = 0;
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation-10, YLocation+ ENEMY_BITMAP_CENTRE_X, _bulletSpeed, _firePower, BitmapKind.BulletC,  belongTo));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation - 5, YLocation+ ENEMY_BITMAP_CENTRE_X + 25, _bulletSpeed, _firePower, BitmapKind.BulletC,  belongTo));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation - 5, YLocation + ENEMY_BITMAP_CENTRE_X - 25, _bulletSpeed, _firePower, BitmapKind.BulletC,  belongTo));
				}
				break;
			}
		}
	}
}

