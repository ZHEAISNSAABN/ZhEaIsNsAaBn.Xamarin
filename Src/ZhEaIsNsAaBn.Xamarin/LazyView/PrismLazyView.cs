
using Prism;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace ZhEaIsNsAaBn.Xamarin
{
    public class PrismLazyView<TView> : BaseLazyView
        where TView : View, new()
    {
        public static readonly BindableProperty NavigationParametersProperty = BindableProperty.Create(
            nameof(NavigationParameters), typeof(INavigationParameters), typeof(PrismLazyView<TView>));



        public INavigationParameters NavigationParameters
        {
            get => (INavigationParameters)GetValue(NavigationParametersProperty);
            set
            {
                SetValue(NavigationParametersProperty, value);
                if(Content != null)
                    try
                    {
                        ((IPrismLazyViewModel)Content.BindingContext).LazyLoadInitialize(NavigationParameters);
                    }
                    catch { }

            }
        }



        public override ValueTask LoadViewAsync()
        {
            var view = (TView)PrismApplicationBase.Current.Container.Resolve(typeof(TView));

            try
            {
                ((IPrismLazyViewModel)Content.BindingContext).LazyLoadInitialize(NavigationParameters);
            }
            catch { }

            Content = view;

            SetIsLoaded(true);
            return new ValueTask(Task.FromResult(true));
        }
    }
}
