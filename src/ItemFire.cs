using System;
using SwinGameSDK;

namespace MyGame
{
	/// <summary>
	/// Item fire.
	/// Inherites GameObject.
	/// Allow the players to switch their weapon.
	/// Contains three kinds of weapons.
	/// Double, Triple, Quintuple
	/// </summary>
	public class ItemFire : GameObject
	{
		private int _type;

		/// <summary>
		/// Initializes a new instance of the <see cref="T:MyGame.ItemFire"/> class.
		/// </summary>
		/// <param name="aXLocation">Item's X Location.</param>
		/// <param name="aYLocation">Item's Y Location.</param>
		/// <param name="aType">Item's type.</param>
		public ItemFire(double aXLocation, double aYLocation, int aType) : base (aXLocation, aYLocation)
		{
			_type = aType;
		}

		/// <summary>
		/// Draw the item.
		/// Depends item's _type.
		/// </summary>
		public override void Draw ()
		{
			switch (_type) 
			{
				case 1:
					SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.ItemFire1), (float)XLocation, (float)YLocation);
					break;
				case 2:
					SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.ItemFire2), (float)XLocation, (float)YLocation);
					break;
				case 3:
					SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.ItemFire3), (float)XLocation, (float)YLocation);
					break;
				default:
					SwinGame.DrawBitmap (Controller.GetBitMap (BitmapKind.ItemFire1), (float)XLocation, (float)YLocation);
					break;
			}
		}

		public int Type 
		{
			get {
				return _type;
			}
		}
	}
}

