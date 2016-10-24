using System;
using SwinGameSDK;
namespace MyGame
{
	/// <summary>
	/// Explosion.
	/// Inherites GameObject.
	/// Model for explosions when players and enemies hit a bullet.
	/// </summary>
	public class Explosion : GameObject
	{
		private int _elapsedTime;
		private int _time;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.Explosion"/> class.
		/// </summary>
		/// <param name="aXLocation">Explosion's X Location.</param>
		/// <param name="aYLocation">Explosion's Y Location.</param>
		/// <param name="aTime">Time for explosion to remain on the screen.</param>
		public Explosion (double aXLocation, double aYLocation, int aTime) : base (aXLocation, aYLocation)
		{
			_elapsedTime = 0;
			_time = aTime;
		}

		/// <summary>
		/// Draw the explosion.
		/// </summary>
		public override void Draw ()
		{
				SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.Explosion), (float)XLocation, (float)YLocation);
				_elapsedTime++;
		}

		public int ElapsedTime {
			get {
				return _elapsedTime;
			}

			set {
				_elapsedTime = value;
			}
		}

		public int Time {
			get {
				return _time;
			}

			set {
				_time = value;
			}
		}
	}
}


