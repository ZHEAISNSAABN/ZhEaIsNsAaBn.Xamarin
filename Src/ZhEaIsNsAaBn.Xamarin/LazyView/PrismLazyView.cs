
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
            nameof(NavigationParameters), typeof(INavigationParameters), typeof(PrismLazyView<TView>), BindingMode.TwoWay);

        private void OnNavigationParametersChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((IPrismLazyViewModel)Content.BindingContext).LazyLoadInitialize(NavigationParameters);
        }

        public INavigationParameters NavigationParameters
        {
            get => (INavigationParameters)GetValue(NavigationParametersProperty);
            set
            {
                SetValue(NavigationParametersProperty, value);
                ((IPrismLazyViewModel)Content.BindingContext).LazyLoadInitialize(NavigationParameters);
            }
        }


        public override ValueTask LoadViewAsync()
        {
            var Content = (TView)PrismApplicationBase.Current.Container.Resolve(typeof(TView));

            ((IPrismLazyViewModel)Content.BindingContext).LazyLoadInitialize(NavigationParameters);

            SetIsLoaded(true);
            return new ValueTask(Task.FromResult(true));
        }
    }
}
