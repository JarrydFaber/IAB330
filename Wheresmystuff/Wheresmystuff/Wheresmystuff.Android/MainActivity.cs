using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using SQLite.Net.Interop;
using SQLite.Net.Platform.XamarinAndroid;

namespace Wheresmystuff.Droid
{
	[Activity(Label = "Wheresmystuff", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);
            DependencyService.Register<FileHelperDroid>();
            DependencyService.Register<ISQLitePlatform, SQLitePlatformAndroid>();
			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}
	}
}

