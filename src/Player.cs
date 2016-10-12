using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Player : FlyingObject
	{
		
	
	
		public Player (double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation, aSpeed, aHp)
		{
			

		}



		//keyboard control
		public override void Move ()
		{
			if (SwinGame.KeyDown (KeyCode.vk_a))
				XLocation -= Speed;
			if (SwinGame.KeyDown (KeyCode.vk_d))
				XLocation += Speed;
			if ((SwinGame.KeyDown (KeyCode.vk_w)&&(YLocation>=SwinGame.ScreenHeight ()-200))) 
				YLocation -= Speed;
			if ((SwinGame.KeyDown (KeyCode.vk_s) && (YLocation <= SwinGame.ScreenHeight () - 25)))
				YLocation += Speed;

		}

		//three types of fire: single bullet, double, and penta
		//can add more (extension)
		public override void Fire ()
		{
			switch (BulletType) {
			case 1:
				if (TimerCount++ == FireRate) {
					TimerCount = 0;
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation, YLocation, BulletSpeed,FirePower));
				}
				break;

			case 2:
				if (TimerCount++ == FireRate) {
					TimerCount = 0;
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + 15, YLocation, BulletSpeed, FirePower));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation - 15, YLocation, BulletSpeed, FirePower));
				}
				break;

			case 3:
				if (TimerCount++ == FireRate) {
					TimerCount = 0;
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation, YLocation - 10, BulletSpeed, FirePower));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + 15, YLocation - 5, BulletSpeed, FirePower));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation - 15, YLocation - 5, BulletSpeed, FirePower));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + 25, YLocation, BulletSpeed, FirePower));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation - 25, YLocation, BulletSpeed, FirePower));
				}
				break;
			}
		}


		//draw the player
		//size is hardcoded (radius = 20)
		public override void Draw (Color aColor)
		{
			SwinGame.DrawCircle (aColor,(float)XLocation,(float)YLocation,20 );
		}

	}
}

