using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.InteractionTracker.Forms;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace Xamarin.InteractionTracker.Examples
{
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TrackerService.Current.ScanPage(this);
            TrackerService.Current.OnInteractionDetected += Current_OnInteractionDetected;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            TrackerService.Current.OnInteractionDetected -= Current_OnInteractionDetected;
        }

        private void Current_OnInteractionDetected(object sender, Forms.Events.InteractionEventArgs e)
        {
            
            //var objectData = JsonConvert.SerializeObject(e.Interaction.ViewObject, Formatting.Indented, new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            //    PreserveReferencesHandling = PreserveReferencesHandling.None
            //});
            //LogLabel.Text += $"\n Event tracked: {e.Interaction.EventTime} | {e.Interaction.Gesture}: \n {objectData}";
        }
    }
}
