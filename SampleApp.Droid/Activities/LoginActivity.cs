using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Acr.UserDialogs;
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
    [Activity(Label = "LoginActivity", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LoginActivity : MvxActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Set Layout
            SetContentView(Resource.Layout.activity_login);

            //Initialize Xamarin.Essentials
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            UserDialogs.Init(this);
            AlertConfig.DefaultAndroidStyleId = Resource.Style.Theme_Dialog;
            ConfirmConfig.DefaultAndroidStyleId = Resource.Style.Theme_Dialog;
        }
    }
}