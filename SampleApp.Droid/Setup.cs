using MvvmCross;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Logging;
using SampleApp.Core;
using SampleApp.Core.Services.Interfaces;

namespace SampleApp.Droid
{
    public class Setup : MvxAppCompatSetup<App>
    {
        protected override void InitializeLastChance()
        {
            Mvx.IoCProvider.RegisterSingleton<ISqliteDataService>(new AndroidSqliteDataService());
            base.InitializeLastChance();
        }

        public override MvxLogProviderType GetDefaultLogProviderType()
            => MvxLogProviderType.Console;
    }
}