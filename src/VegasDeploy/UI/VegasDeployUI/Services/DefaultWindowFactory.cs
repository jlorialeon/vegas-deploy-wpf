using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FF.Vegas.Deploy.UI
{
    public class DefaultWindowFactory : IWindowFactory
    {
        private readonly IServiceProvider serviceProvider;

        public DefaultWindowFactory(IServiceProvider serviceProvider) 
        {
            ArgumentNullException.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            this.serviceProvider = serviceProvider;
        }

        public Window? Create<TWindows>() where TWindows : Window
        {
            return serviceProvider.GetService<TWindows>();
        }
    }
}
