﻿using System.Windows;

namespace NavigationSampleApp
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new Bootstrapper().Run();
        }
    }
}
