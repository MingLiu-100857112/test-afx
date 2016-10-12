using System;
using SwinGameSDK;
namespace MyGame
{
	//this class has common properties for both Player and Enemy classes
	public abstract class FlyingObject:GameObject
	{
		private int _hp;
		private int _timerCount;
		private int _fireRate;
		private double _bulletSpeed;
		private int _bulletType;
		private int _firePower;


		public FlyingObject (double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation, aSpeed)
		{
			_hp = aHp;
			_timerCount = 0;
		}

		//Determine what weapon it has based on given parameters
		//bullet speed: negative (goes upward) is for player, positive is for enemies
		public void Equip (int aBulletType, int aFireRate, double aBulletSpeed, int aFirePower)
		{
			FireRate = aFireRate;
			BulletSpeed = aBulletSpeed;
			BulletType = aBulletType;
			FirePower = aFirePower;
		}

		//Both player and enemy need to fire their bullets
		public abstract void Fire ();


		//basic properties
		public int TimerCount {
			get {
				return _timerCount;
			}

			set {
				_timerCount = value;
			}
		}

		public int FireRate {
			get {
				return _fireRate;
			}

			set {
				_fireRate = value;
			}
		}

		public int Hp {
			get {
				return _hp;
			}

			set {
				_hp = value;
			}
		}

		public double BulletSpeed {
			get {
				return _bulletSpeed;
			}

			set {
				_bulletSpeed = value;
			}
		}

		public int BulletType {
			get {
				return _bulletType;
			}

			set {
				_bulletType = value;
			}
		}

		public int FirePower {
			get {
				return _firePower;
			}

			set {
				_firePower = value;
			}
		}
	}
}

