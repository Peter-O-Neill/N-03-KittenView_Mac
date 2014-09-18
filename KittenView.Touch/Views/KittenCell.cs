﻿
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using KittenView.Core.Services;

namespace KittenView.Touch
{
	public partial class KittenCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("KittenCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("KittenCell");

		public KittenCell (IntPtr handle) : base (handle)
		{
			this.DelayBind (() => {
				var set = this.CreateBindingSet<KittenCell, Kitten>();
				var imageLoader = new MvxImageViewLoader(() => this.MainImage);
				set.Bind(NameLabel).To(kitten => kitten.Name);
				set.Bind(PriceLabel).To(kitten => kitten.Price);
				set.Bind(imageLoader).To(kitten => kitten.ImageUrl);
				set.Apply();
			});
		}

		public static KittenCell Create ()
		{
			return (KittenCell)Nib.Instantiate (null, null) [0];
		}
	}
}

