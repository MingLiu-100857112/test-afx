using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public abstract class Enemy : FlyingObject

	{
		

		public Enemy(double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation, aSpeed, aHp)
		{
			

		}


		//three types of fire: single bullet, double, and penta
		//can add more (extension)
		public override void Fire ()
		{
			switch (BulletType) {
			case 1:
				if (TimerCount++ == FireRate) {
					TimerCount = 0;
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation, YLocation, BulletSpeed, FirePower));
				}
				break;

			case 2:
				if (TimerCount++ == FireRate) {
					TimerCount = 0;
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation + 15, YLocation, BulletSpeed, FirePower));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation - 15, YLocation, BulletSpeed, FirePower));
				}
				break;

			case 3:
				if (TimerCount++ == FireRate) {
					TimerCount = 0;
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation, YLocation - 10, BulletSpeed, FirePower));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation + 15, YLocation - 5, BulletSpeed, FirePower));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation - 15, YLocation - 5, BulletSpeed, FirePower));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation + 25, YLocation, BulletSpeed, FirePower));
					InGameBullets.GameEnemyWeapon.Add (new Weapon (XLocation - 25, YLocation, BulletSpeed, FirePower));
				}
				break;
			}
		}

		//2 different types of moving pattern for 2 types of enemy. Each override both but leave one of them empty
		public abstract void MovePattern (int aPeriod, int aStartDirection);
		public abstract void MovePattern (double aCentreX, double aCentreY, double aRadiusX, double aRadiusY);

		//draw the player
		//size is hardcoded (radius = 20)
		public override void Draw (Color aColor)
		{

			SwinGame.DrawCircle (aColor, (float)XLocation, (float)YLocation, 20);
		
		}
	}
}

