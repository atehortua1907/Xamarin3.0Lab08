using Android.App;
using Android.Widget;
using Android.OS;
using System;
using SALLab08;

namespace Xamarin3._0Lab08
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Acceder a recursos Programáticamente (por código)
            /*var ViewGroup = (Android.Views.ViewGroup)
                Window.DecorView.FindViewById(Android.Resource.Id.Content);
            var MainLayout = ViewGroup.GetChildAt(0) as LinearLayout;
            var HeaderImage = new ImageView(this);
            HeaderImage.SetImageResource(Resource.Drawable.Xamarin_Diplomado_30);
            MainLayout.AddView(HeaderImage);
            var UserNametTextView = new TextView(this);
            UserNametTextView.Text = GetString(Resource.String.UserName);
            MainLayout.AddView(UserNametTextView);*/

            Validate();

        }

        private async void Validate()
        {
            string StudentEmail = "atehortua1907@hotmail.com";
            string Password = "51pegasib";
            var UserName = FindViewById<TextView>(Resource.Id.UserNameValue);
            var Status = FindViewById<TextView>(Resource.Id.StatusValue);
            var Token = FindViewById<TextView>(Resource.Id.TokenValue);
            ServiceClient ServiceClient = new ServiceClient();
            string myDevice = Android.Provider.Settings.Secure.GetString(
                ContentResolver, Android.Provider.Settings.Secure.AndroidId);
            ResultInfo Result = await ServiceClient.ValidateAsync(StudentEmail, Password, myDevice);
            UserName.Text = Result.Fullname;
            Status.Text = Result.Status.ToString();
            Token.Text = Result.Token;

        }
    }
}

