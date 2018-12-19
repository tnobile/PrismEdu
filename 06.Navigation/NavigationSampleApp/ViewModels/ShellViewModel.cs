﻿using Microsoft.Practices.Unity;
using NavigationSampleApp.Views;
using Prism.Commands;
using Prism.Regions;

namespace NavigationSampleApp.ViewModels
{
    class ShellViewModel
    {
        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public DelegateCommand<string> AViewCommand { get; }
        public DelegateCommand BViewCommand { get; }

        public ShellViewModel()
        {
            this.AViewCommand = new DelegateCommand<string>(x =>
            {
                this.RegionManager.RequestNavigate("MainRegion", nameof(AView), new NavigationParameters($"id={x}"));
            });
            this.BViewCommand = new DelegateCommand(() =>
            {
                this.RegionManager.RequestNavigate("MainRegion", nameof(BView));
            });
        }
    }
}
