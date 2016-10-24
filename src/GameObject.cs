using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{	
	/// <summary>
	/// Game object.
	/// Base class for all game objects
	/// </summary>
	public abstract class GameObject
	{
		protected double _xLocation;
		protected double _yLocation;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.GameObject"/> class.
		/// </summary>
		/// <param name="aXLocation">Object X location.</param>
		/// <param name="aYLocation">Object Y location.</param>
		public GameObject (double aXLocation, double aYLocation)
		{
			_xLocation = aXLocation;
			_yLocation = aYLocation;

		}
		/// <summary>
		/// Draw this instance.
		/// Abstract method.
		/// </summary>
		public abstract void Draw ();


		public double XLocation 
		{
			get {
				return _xLocation;
			}

			set {
				_xLocation = value;
			}
		}

		public double YLocation 
		{
			get {
				return _yLocation;
			}

			set {
				_yLocation = value;
			}
		}
	}
}

