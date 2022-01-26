using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Twerkle.Behaviours
{
	public class CustomBehavior : Behavior<View>
	{
		protected override void OnAttachedTo(View bindable)
		{
			base.OnAttachedTo(bindable);
			// Perform setup
		}

		protected override void OnDetachingFrom(View bindable)
		{
			base.OnDetachingFrom(bindable);
			// Perform clean up
		}

		// Behavior implementation
	}
}
