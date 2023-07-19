#region Libraries
using FF.Vegas.Deploy.UI.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows; 
#endregion

namespace FF.Vegas.Deploy.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = Host.CreateApplicationBuilder(e.Args);
            ConfigureService(builder);
            using (var app = builder.Build()) 
            {
                var mainWindow = app.Services.GetRequiredService<MainWindow>();
                mainWindow?.Show();     
                await app.RunAsync();
            }
        }

        private void ConfigureService(HostApplicationBuilder builder) 
        {
            builder.Services.AddSingleton<IWindowFactory>((sp)=> new DefaultWindowFactory(sp));
            builder.Services.AddScoped<IPageFactory>((sp) => new DefaultPageFactory(sp));
            builder.Services.AddScoped((sp)=>new MainWindow(sp.GetService<IWindowFactory>(),
                                                            sp.GetService<IPageFactory>()));

            builder.Services.AddScoped((sp) => new CommitPage());
            builder.Services.AddScoped((sp) => new SettingsPage());
            builder.Services.AddScoped((sp) => new DeployPage());
        }
    }
}
