using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace TamilFruits
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Grapes_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FruitPage), "https://ta.wikipedia.org/wiki/%E0%AE%A4%E0%AE%BF%E0%AE%B0%E0%AE%BE%E0%AE%9F%E0%AF%8D%E0%AE%9A%E0%AF%88");
        }

        private void Mango_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FruitPage),"http://ta.wikipedia.org/wiki/%E0%AE%AE%E0%AE%BE");
        }

        private void Tamrind_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FruitPage), "http://ta.wikipedia.org/wiki/%E0%AE%AA%E0%AF%81%E0%AE%B3%E0%AE%BF");
        }

        private void Papaya_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FruitPage),"http://ta.wikipedia.org/wiki/%E0%AE%AA%E0%AE%AA%E0%AF%8D%E0%AE%AA%E0%AE%BE%E0%AE%B3%E0%AE%BF");
        }

        private void Coconuts_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FruitPage),"http://ta.wikipedia.org/wiki/%E0%AE%A4%E0%AF%87%E0%AE%99%E0%AF%8D%E0%AE%95%E0%AE%BE%E0%AE%AF%E0%AF%8D");
        }
    }
}
