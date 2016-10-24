using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	/// <summary>
	/// Weapon.
	/// Inherites GameObject.
	/// Model for all bullets.
	/// </summary>
	public class Weapon:GameObject
	{
		private int _bulletPower;
		private BitmapKind _bulletKind;
		private int _belongTo;
		private double _speed;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Weapon"/> class.
		/// </summary>
		/// <param name="aXLocation">Bullet's X Location.</param>
		/// <param name="aYLocation">Bullet's Y Location.</param>
		/// <param name="aSpeed">Bullet's speed.</param>
		/// <param name="aBulletPower">Bullet's bullet power.</param>
		/// <param name="aBitmapKind">Bullet's bitmap kind.</param>
		/// <param name="aBelongTo">Bullet's belong to.</param>
		public Weapon (double aXLocation, double aYLocation, double aSpeed, int aBulletPower, BitmapKind aBitmapKind, int aBelongTo)
			:base(aXLocation, aYLocation)
		{
			_bulletPower = aBulletPower;
			_bulletKind = aBitmapKind;
			_belongTo = aBelongTo;
			_speed = aSpeed;
		}

		/// <summary>
		/// Draw the bullet.
		/// </summary>
		public override void Draw ()
		{
			SwinGame.DrawBitmap (Controller.GetBitMap (_bulletKind), (float)XLocation, (float)YLocation);
		}

		/// <summary>
		/// Update bullet position.
		/// </summary>
		public void Move ()
		{
				XLocation -= _speed;
		}

		public int BulletPower {
			get {
				return _bulletPower;
			}
		}

		public BitmapKind BulletKind {
			get {
				return _bulletKind;
			}
		}

		public int BelongTo {
			get {
				return _belongTo;
			}
		}


	}
}

