using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Xamarin
{
    internal interface IPrismLazyViewModel
    {
        void LazyLoadInitialize(INavigationParameters parameters);
    }
}
