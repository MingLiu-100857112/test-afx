using System;
namespace MyGame
{
	public class EnemyCircular : Enemy
	{
		private double _angle;
		private double _centreX;
		private double _centreY;
		private double _radiusY;
		private double _radiusX;

		public EnemyCircular (double aXLocation, double aYLocation, double aSpeed, int aHp)
			: base (aXLocation, aYLocation, aSpeed, aHp)
		{
			
		}

		public override void MovePattern(double aCentreX, double aCentreY, double aRadiusX, double aRadiusY){
			_angle = 0;

			_radiusX = aRadiusX;
			_radiusY = aRadiusY;
			_centreX = aCentreX;
			_centreY = aCentreY;
		}
		public override void MovePattern (int aPeriod, int aStartDirection){
			//not need to be overriden
		}
			

		//Circular moving

		public override void Move ()
		{
			XLocation = CentreX + RadiusX * Math.Sin (Angle)*Speed;
			YLocation = CentreY + RadiusY * Math.Cos (Angle)*Speed;
			Angle += Speed/1000;
		}




		public double Angle {
			get {
				return _angle;
			}

			set {
				_angle = value;
			}
		}

		public double CentreX {
			get {
				return _centreX;
			}

			set {
				_centreX = value;
			}
		}
		public double CentreY {
			get {
				return _centreY;
			}

			set {
				_centreY = value;
			}
		}

		public double RadiusY {
			get {
				return _radiusY;
			}

			set {
				_radiusY = value;
			}
		}
		public double RadiusX {
			get {
				return _radiusX;
			}

			set {
				_radiusX = value;
			}
		}

	}
}

