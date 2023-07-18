#region Libraries
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = Host.CreateApplicationBuilder(e.Args);
            ConfigureService(builder);
            using (var app = builder.Build()) 
            {
                using (var scope = app.Services.CreateScope()) 
                {
                   var sp = scope.ServiceProvider;
                   var mainWindow = sp.GetRequiredService<MainWindow>();
                    mainWindow?.Show();
                }
            }
        }

        private void ConfigureService(HostApplicationBuilder builder) 
        {
            builder.Services.AddSingleton<IWindowFactory>((sp)=> new DefaultWindowFactory(sp));
            builder.Services.AddScoped((sp)=>new MainWindow(sp.GetService<IWindowFactory>()));
        }
    }
}
