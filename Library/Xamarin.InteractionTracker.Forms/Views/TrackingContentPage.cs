using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.InteractionTracker.Forms.Views
{
    public class TrackingContentPage : ContentPage
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            TrackerService.Current.OnInteractionDetected += Current_OnInteractionDetected;
            TrackerService.Current.ScanPage(this);
        }

        private async void Current_OnInteractionDetected(object sender, Events.InteractionEventArgs e)
        {
            await DisplayAlert("Gesture Detected", e.Interaction.Gesture.ToString(), "ok");
        }
    }
}
