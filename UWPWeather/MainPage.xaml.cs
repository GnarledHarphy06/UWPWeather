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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPWeather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            RootObject myWeather = await OpenWeatherMapProxy.GetWeather( -6.966667, 110.416667);
            
            ResultTextBlock.Text = $"{myWeather.name} - {myWeather.main.temp} - {myWeather.weather[0].description}";
            //string icon = $"http://openweathermap.org/img/w/{myWeather.weather[0].icon}.png";
            //ResultImage.Source = new BitmapImage(new Uri(icon, UriKind.Absolute));
            ResultImage.Source = new BitmapImage(new Uri($"http://openweathermap.org/img/w/{myWeather.weather[0].icon}.png", UriKind.Absolute));
        }
    }
}
