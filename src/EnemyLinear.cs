using System;
namespace MyGame
{
	public class EnemyLinear : Enemy
	{
		private int _period;
		private int _direction;

		public EnemyLinear (double aXLocation, double aYLocation, int aHp, double aSpeed)
			: base (aXLocation, aYLocation, aSpeed, aHp)
		{
			
		}

		public override void MovePattern (int aPeriod, int aStartDirection)
		{
			_period = aPeriod;
			_direction = aStartDirection;
		}
		public override void MovePattern (double aCentreX, double aCentreY, double aRadiusX, double aRadiusY)
		{
			//not need to be overriden
		}



		public override void Move ()
		{
			TimerCount++;
			if (TimerCount == Period) {
				Direction = - Direction;
				TimerCount = 0;
			}
			XLocation += Direction * Speed;
		}



		public int Period {
			get {
				return _period;
			}

			set {
				_period = value;
			}
		}


		public int Direction {
			get {
				return _direction;
			}

			set {
				_direction = value;
			}
		}

	
	}
}

