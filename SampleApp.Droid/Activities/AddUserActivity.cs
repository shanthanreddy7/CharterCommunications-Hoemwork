
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using SampleApp.Core.ViewModels;

namespace SampleApp.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "AddUserActivity")]
    public class AddUserActivity : MvxActivity<AddUserViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_user);
        }
       
    }
}