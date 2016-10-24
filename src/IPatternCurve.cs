using System;
namespace MyGame
{
	public interface IPatternCurve
	{
		void MovePattern (double aCentreX, double aCentreY, double aRadiusX, double aRadiusY, int directionX, int directionY);
	}
}

