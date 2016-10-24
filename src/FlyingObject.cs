using System;
using SwinGameSDK;
namespace MyGame
{
	/// <summary>
	/// Flying object.
	/// Inherites GameObject
	/// Abstract Base Class for Player and Enemy
	/// </summary>
	public abstract class FlyingObject:GameObject
	{
		protected const float PLAYER_BITMAP_CENTRE_Y = 30;
		protected const float PLAYER_BITMAP_CENTRE_X = 30;
		protected const float ENEMY_BITMAP_CENTRE_X = 35;
		protected const float ENEMY_BITMAP_CENTRE_Y = 35;

		protected int _hp;
		protected int _timerCount;
		protected int _fireRate;
		protected double _bulletSpeed;
		protected int _bulletType;
		protected int _firePower;
		protected double _speed;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.FlyingObject"/> class.
		/// </summary>
		/// <param name="aXLocation">Ship's X location.</param>
		/// <param name="aYLocation">Ship's Y location.</param>
		/// <param name="aSpeed">Ship's Speed.</param>
		/// <param name="aHp">Ship's HP.</param>
		public FlyingObject (double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation)
		{
			_hp = aHp;
			_timerCount = 0;
			_speed = aSpeed;
		}

		/// <summary>
		/// Equip ship's weapons.
		/// </summary>
		/// <param name="aBulletType">Ship's bullet type.</param>
		/// <param name="aFireRate">Ship's fire rate.</param>
		/// <param name="aBulletSpeed">Ship's bullet speed.</param>
		/// <param name="aFirePower">Ship's fire power.</param>
		public void Equip (int aBulletType, int aFireRate, double aBulletSpeed, int aFirePower)
		{
			_fireRate = aFireRate;
			_bulletSpeed = aBulletSpeed;
			_bulletType = aBulletType;
			_firePower = aFirePower;
		}

		/// <summary>
		/// Fire Bullets.
		/// Abstract method.
		/// </summary>
		/// <param name="belongTo">Player '0' or '1' or '2'.</param>
		public abstract void Fire (int belongTo);

		/// <summary>
		/// Move this ship.
		/// Abstract method.
		/// </summary>
		public abstract void Move ();

		public int FireRate 
		{
			get {
				return _fireRate;
			}
		}

		public int Hp 
		{
			get {
				if (_hp <= 0)
					_hp = 0;
				return _hp;
			}
			set {
				_hp = value;
			}
		}

		public double BulletSpeed 
		{
			get {
				return _bulletSpeed;
			}
		}

		public int FirePower
		{
			get {
				return _firePower;
			}
		}

		public double Speed 
		{
			get {
				return _speed;
			}

		}
	}
}

