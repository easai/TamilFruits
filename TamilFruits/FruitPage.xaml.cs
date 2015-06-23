using TamilFruits.Common;
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
using Windows.Storage;

namespace TamilFruits
{
    public sealed partial class FruitPage : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public FruitPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        private async void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
            FruitBrowser.Source = new Uri((string)e.NavigationParameter);
            // Get the local folder.
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            if (local != null)
            {
                // Create a new folder name MyFolder.
                var dataFolder = await local.CreateFolderAsync("MyFolder",
                    CreationCollisionOption.OpenIfExists);

                try
                {
                    // Get the file stream
                    var fileStream = await dataFolder.OpenStreamForReadAsync("memo.txt");

                    // Read the data.
                    using (StreamReader streamReader = new StreamReader(fileStream))
                    {
                        string s = streamReader.ReadToEnd();

                        this.tbMango.Text = s;
                    }
                }
                catch (Exception exception)
                {
                    exception.ToString();
                }

            }
        }


        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper の登録

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes(this.tbMango.Text.ToCharArray());

            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;

            var dataFolder = await local.CreateFolderAsync("MyFolder",
                CreationCollisionOption.OpenIfExists);

            var file = await dataFolder.CreateFileAsync("memo.txt",
            CreationCollisionOption.ReplaceExisting);

            using (var s = await file.OpenStreamForWriteAsync())
            {
                s.Write(fileBytes, 0, fileBytes.Length);
            }
        }

    }
}
