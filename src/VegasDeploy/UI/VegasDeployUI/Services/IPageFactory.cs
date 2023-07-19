﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FF.Vegas.Deploy.UI
{
    public interface IPageFactory
    {
        Page? Create<TPage>() where TPage : Page;
    }
}
