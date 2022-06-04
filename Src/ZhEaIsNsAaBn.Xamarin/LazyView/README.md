# ZhEaIsNsAaBn.Xamarin.PrismLazyView

This code solves the issue when using prism forms and Xamarin.CommunityToolkit

# How to use it

in the header of the view add 
```xaml
<ContentPage 
....
             xmlns:zh="clr-namespace:ZhEaIsNsAaBn.Xamarin;assembly=ZhEaIsNsAaBn.Xamarin"
....
>
....
                           <zh:PrismLazyView  x:TypeArguments="local:TheView" />
....

</ContentPage>
```

if you want to pass parameters to the ViewModel 
```xaml
  <zh:PrismLazyView  x:TypeArguments="local:TheView" NavigationParameters="{Binding NavigationParameters}"/>
```
and the its ViewModel have to implement the ``IPrismLazyViewModel`` interface and handle the passed parameters from ``LazyLoadInitialize`` method



# First prism & communityToolkit issue 
 use the Navigation region inside TabViewItem return error
```xaml
<xct:TabViewItem>
     <xct:TabViewItem.Content>
        <CollectionView prism:RegionManager.RegionName="FirstRegion" />
     </xct:TabViewItem.Content>
</xct:TabViewItem>
```
will return 
````
Prism regions not found
````

# Second using  communityToolkit Lazyview will set the BindingContext not with prism ViewModel
```
<xct:LazyView  x:TypeArguments="local:TheView" />
```
it will work but it will set the BindingContext of this view to the parent 