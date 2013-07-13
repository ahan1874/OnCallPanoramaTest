using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OnCallPanoramaTest.ViewModels;
using Microsoft.Phone.Tasks;

namespace OnCallPanoramaTest
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
        }

        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void TextBlock_Tap_1(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock b = (TextBlock)sender;
            ItemViewModel vm = b.DataContext as ItemViewModel;

            PhoneCallTask task = new PhoneCallTask();
            task.PhoneNumber = vm.Phone;
            task.DisplayName = vm.Name;
            task.Show();
        }

        private void TextBlock_Tap_2(object sender, System.Windows.Input.GestureEventArgs e)
        {
            TextBlock b = (TextBlock)sender;
            ItemViewModel vm = b.DataContext as ItemViewModel;

            EmailComposeTask ect = new EmailComposeTask();
            ect.To = vm.Email;
            ect.Subject = "Hey buddy, you got some shit";
            ect.Show();

        }
    }
}