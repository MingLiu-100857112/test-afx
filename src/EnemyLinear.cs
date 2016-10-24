using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame
{
	/// <summary>
	/// Enemy linear.
	/// Inherites Enemy.
	/// Model for enemies that move on a straight line pattern.
	/// </summary>
	public class EnemyLinear : Enemy,IPatternLinear
	{
		private int _period;
		private int _direction;

        public int Period
        {
            get
            {
                return _period;
            }

            set
            {
                _period = value;
            }
        }

        public int Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyGame.Enemy"/> class.
        /// </summary>
        /// <param name="aXLocation">Enemy's X Location.</param>
        /// <param name="aYLocation">Enemy's A Y Location.</param>
        /// <param name="aSpeed">Enemy's speed.</param>
        /// <param name="aHp">Enemy's hp.</param>
        public EnemyLinear (double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation, aSpeed, aHp)
		{
			
		}
		/// <summary>
		/// Ship moves on a straight line.
		/// Interface's method
		/// </summary>
		/// <param name="aPeriod">Movement period.</param>
		/// <param name="aDirection">Movement direction.</param>
		public void MovePattern (int aPeriod, int aDirection)
		{
			Period = aPeriod;
			Direction = aDirection;
		}

		/// <summary>
		/// Update enemy position.
		/// Ship patrons periodically on a straight line.
		/// </summary>
		public override void Move ()
		{
			_timerCount++;
			if (_timerCount > Period) 
			{
				_timerCount = 0;
				Direction = - Direction;
			}
			YLocation += Direction * Speed;
            XLocation += Direction * Speed;
        }
		/// <summary>
		/// Draw this enemy.
		/// </summary>
		public override void Draw ()
		{
			SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.EnemyLin), (float)XLocation, (float)YLocation);
		}
	
	}
}

