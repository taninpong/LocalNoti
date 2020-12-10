using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SorryNoti
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SendNotification(object sender, EventArgs e)
        {
            //await Task.Delay(5000);
            DependencyService.Get<INotification>().CreateNotification("SPTutorials", message.Text);
        }
    }
}
