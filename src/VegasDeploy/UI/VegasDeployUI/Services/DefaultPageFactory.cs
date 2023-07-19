using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FF.Vegas.Deploy.UI
{
    public class DefaultPageFactory : IPageFactory
    {
        private readonly IServiceProvider serviceProvider;

        public DefaultPageFactory(IServiceProvider serviceProvider)
        {
            ArgumentNullException.ThrowIfNull(serviceProvider,nameof(serviceProvider));
            this.serviceProvider = serviceProvider;
        }

        public Page? Create<TPage>() where TPage : Page
        {
            return this.serviceProvider.GetService<TPage>() as Page;
        }
    }
}
