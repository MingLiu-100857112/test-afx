using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	public class Weapon:GameObject
	{


		private int _bulletPower;

		public Weapon (double aXLocation, double aYLocation, double aSpeed, int aBulletPower)
			:base(aXLocation, aYLocation, aSpeed)
		{
			_bulletPower = aBulletPower;
		}


		//draw bullet, radius =10
		public override void Draw (Color aColor)
		{
			SwinGame.DrawCircle (aColor, (float)XLocation, (float)YLocation, 10);
		}

		//bullet speed: negative (goes upward) is for player, positive is for enemies
		public override void Move ()
		{
				YLocation += Speed;
		}

		
		public int BulletPower {
			get {
				return _bulletPower;
			}

			set {
				_bulletPower = value;
			}
		}
	}
}

