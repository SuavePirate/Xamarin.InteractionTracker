using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.InteractionTracker.Forms.Models;

namespace Xamarin.InteractionTracker.Forms.Events
{
    public class InteractionEventArgs : EventArgs
    {
        public UIEvent Interaction { get; set; }
        public InteractionEventArgs()
        {
        }

        public InteractionEventArgs(UIEvent interaction)
        {
            Interaction = interaction;
        }
    }
}
