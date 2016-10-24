using System;
using System.Collections.Generic;
using SwinGameSDK;
namespace MyGame

{
	/// <summary>
	/// Enemy circular.
	/// Inherites Enemy.
	/// Model for enemies that move on a curve pattern.
	/// </summary>
	public class EnemyCircular : Enemy, IPatternCurve
	{
		private double _angle;
		private double _centreX;
		private double _centreY;
		private double _radiusY;
		private double _radiusX;
		private double _directionX;
		private double _directionY;

        public double Angle
        {
            get
            {
                return _angle;
            }

            set
            {
                _angle = value;
            }
        }

        public double CentreX
        {
            get
            {
                return _centreX;
            }

            set
            {
                _centreX = value;
            }
        }

        public double CentreY
        {
            get
            {
                return _centreY;
            }

            set
            {
                _centreY = value;
            }
        }

        public double RadiusY
        {
            get
            {
                return _radiusY;
            }

            set
            {
                _radiusY = value;
            }
        }

        public double RadiusX
        {
            get
            {
                return _radiusX;
            }

            set
            {
                _radiusX = value;
            }
        }

        public double DirectionX
        {
            get
            {
                return _directionX;
            }

            set
            {
                _directionX = value;
            }
        }

        public double DirectionY
        {
            get
            {
                return _directionY;
            }

            set
            {
                _directionY = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyGame.EnemyCircular"/> class.
        /// </summary>
        /// <param name="aXLocation">Enemy's X Location.</param>
        /// <param name="aYLocation">Enemy's A Y Location.</param>
        /// <param name="aSpeed">Enemy's speed.</param>
        /// <param name="aHp">Enemy's hp.</param>
        public EnemyCircular (double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation, aSpeed, aHp)
		{
		}
		/// <summary>
		/// Ship moves on a curve.
		/// Interface's methods
		/// </summary>
		/// <param name="aCentreX">Curve centre x.</param>
		/// <param name="aCentreY">Curve centre y.</param>
		/// <param name="aRadiusX">Curve radius x.</param>
		/// <param name="aRadiusY">Curve radius y.</param>
		/// <param name="directionX">Horizontal Direction.</param>
		/// <param name="directionY">Vertical Direction.</param>
		public void MovePattern(double aCentreX, double aCentreY, double aRadiusX, double aRadiusY, int directionX, int directionY)
		{
			Angle = 0;
			RadiusX = aRadiusX;
			RadiusY = aRadiusY;
			CentreX = aCentreX;
			CentreY = aCentreY;
			DirectionX = directionX;
			DirectionY = directionY;
		}



		/// <summary>
		/// Update enemy position.
		/// Elliptical movement.
		/// </summary>
		public override void Move ()
		{
			XLocation = CentreX + DirectionX *RadiusX * Math.Sin (Angle)*Speed;
			YLocation = CentreY + DirectionY * RadiusY * Math.Cos (Angle)*Speed;
			Angle += Speed/1000;
		}

		/// <summary>
		/// Draw this enemy.
		/// </summary>
		public override void Draw ()
		{
			SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.EnemyCir), (float)XLocation, (float)YLocation);
		}

	}
}

