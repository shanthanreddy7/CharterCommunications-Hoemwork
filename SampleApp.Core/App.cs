using MvvmCross.IoC;
using MvvmCross.ViewModels;
using SampleApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
               .Where(x => x.Name.EndsWith("Service", StringComparison.Ordinal) || x.Name.EndsWith("Repository", StringComparison.Ordinal))
               .AsInterfaces()
               .RegisterAsLazySingleton();
            RegisterAppStart<LoginViewModel>();
        }
    }
}
