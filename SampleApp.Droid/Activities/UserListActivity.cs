using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using SampleApp.Core.ViewModels;

namespace SampleApp.Droid.Activities
{
    [MvxActivityPresentation]
    [Activity(Label = "UserListActivity")]
    public class UserListActivity : MvxActivity<UserViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_user_list);
        }
    }
}