using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Player.
	/// Inherites Flying Object.
	/// Model for both players.
	/// </summary>
	public class Player : FlyingObject
	{
		private int _controlDirection;
		private int _score;
		private int _playerNum;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Player"/> class.
		/// </summary>
		/// <param name="aXLocation">Player's X Location.</param>
		/// <param name="aYLocation">Player's Y Location.</param>
		/// <param name="aSpeed">Player's speed.</param>
		/// <param name="aHp">Player's hp.</param>
		/// <param name="aPlayerNum">Player number '0' or '1'.</param>
		public Player (double aXLocation, double aYLocation, double aSpeed, int aHp, int aPlayerNum)
			: base (aXLocation, aYLocation, aSpeed, aHp)
		{
			_score = 0;
			_controlDirection = 0;
			_playerNum = aPlayerNum;
		}
		/// <summary>
		/// Update players position.
		/// </summary>
		public override void Move ()
		{
			if (_controlDirection == 1) //left
				XLocation -= Speed;
			if (_controlDirection == 2) //right
				XLocation += Speed;
			if (_controlDirection == 3) //up
				YLocation -= Speed;
			if (_controlDirection == 4) // down
				YLocation += Speed;

			_controlDirection = 0;
		}
		/// <summary>
		/// Fire the bullets.
		/// Players have 4 types of weapon depends on equiped _bulletType.
		/// '0' - single. '1' - double. '2' - triple. '3' - quintuple
		/// Each player has different bullet color depends on belongTo
		/// '0' - Blue. '1' - Red. 
		/// </summary>
		/// <param name="belongTo">Player number, '0' or '1'.</param>
		public override void Fire (int belongTo)
		{
			BitmapKind bmk=BitmapKind.BulletA;
			if (belongTo == 1)
				bmk = BitmapKind.BulletB;
			
			switch (_bulletType) 
			{
			case 0:
				if (_timerCount++ == FireRate) 
				{
					_timerCount = 0;
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation+PLAYER_BITMAP_CENTRE_X*2, YLocation + PLAYER_BITMAP_CENTRE_Y, _bulletSpeed,_firePower, bmk, belongTo));
				}
				break;

			case 1:
				if (_timerCount++ == FireRate) 
				{
					_timerCount = 0;
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation+ PLAYER_BITMAP_CENTRE_X* 2, YLocation + PLAYER_BITMAP_CENTRE_Y +15, _bulletSpeed, _firePower,bmk, belongTo));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation+ PLAYER_BITMAP_CENTRE_X* 2, YLocation + PLAYER_BITMAP_CENTRE_Y -15, _bulletSpeed, _firePower,bmk, belongTo));
				}
				break;

			case 2:
				if (_timerCount++ == FireRate) 
				{
					_timerCount = 0;
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation+ PLAYER_BITMAP_CENTRE_X* 2 +20, YLocation + PLAYER_BITMAP_CENTRE_Y, _bulletSpeed, _firePower,bmk, belongTo));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation+ PLAYER_BITMAP_CENTRE_X* 2 , YLocation + PLAYER_BITMAP_CENTRE_Y +25, _bulletSpeed, _firePower,bmk, belongTo));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation+ PLAYER_BITMAP_CENTRE_X* 2 , YLocation + PLAYER_BITMAP_CENTRE_Y -25, _bulletSpeed, _firePower,bmk, belongTo));
				}
				break;
			case 3:
				if (_timerCount++ == FireRate) 
				{
					_timerCount = 0;
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + PLAYER_BITMAP_CENTRE_X * 2 + 20, YLocation + PLAYER_BITMAP_CENTRE_Y, _bulletSpeed, _firePower, bmk, belongTo));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + PLAYER_BITMAP_CENTRE_X * 2+10, YLocation + PLAYER_BITMAP_CENTRE_Y + 25, _bulletSpeed, _firePower, bmk, belongTo));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + PLAYER_BITMAP_CENTRE_X * 2+10, YLocation + PLAYER_BITMAP_CENTRE_Y - 25, _bulletSpeed, _firePower, bmk, belongTo));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + PLAYER_BITMAP_CENTRE_X * 2, YLocation + PLAYER_BITMAP_CENTRE_Y + 55, _bulletSpeed, _firePower, bmk, belongTo));
					InGameBullets.GamePlayerWeapon.Add (new Weapon (XLocation + PLAYER_BITMAP_CENTRE_X * 2, YLocation + PLAYER_BITMAP_CENTRE_Y - 55, _bulletSpeed, _firePower, bmk, belongTo));
				}
				break;
			}
		}

		/// <summary>
		/// Draw both players.
		/// Depends on _playerNum.
		/// '0' - Blue Ship. '1' - Red Ship.
		/// </summary>
		public override void Draw ()
		{
			if (_playerNum==0)
				SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.Player0), (float)XLocation, (float)YLocation);
			else
				SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.Player1), (float)XLocation, (float)YLocation);
		}

		public int ControlDirection 
		{
			get {
				return _controlDirection;
			}

			set {
				_controlDirection = value;
			}
		}

		public int Score 
		{
			get {
				//if (_score <= 0)
					//_score = 0;
				return _score;
			}

			set {
				_score = value;
			}
		}
	}
}

