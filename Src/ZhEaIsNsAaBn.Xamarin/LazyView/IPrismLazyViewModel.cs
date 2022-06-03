using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZhEaIsNsAaBn.Xamarin
{
    public interface IPrismLazyViewModel
    {
        void LazyLoadInitialize(INavigationParameters parameters);
    }
}
