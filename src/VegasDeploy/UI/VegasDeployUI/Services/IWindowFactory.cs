using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FF.Vegas.Deploy.UI
{
    public interface IWindowFactory
    {
        Window? Create<TWindows>() where TWindows : Window;
    }
}
