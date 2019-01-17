using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using OnlineShoppingTracker.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("OnlineShoppingTracker")]
[assembly: ExportEffect(typeof(LowercaseButtonEffect), "LowercaseButtonEffect")]
namespace OnlineShoppingTracker.Droid.Effects
{
    public class LowercaseButtonEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var button = Control as AppCompatButton;

                if (button != null)
                {
                    button.SetAllCaps(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: ", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}