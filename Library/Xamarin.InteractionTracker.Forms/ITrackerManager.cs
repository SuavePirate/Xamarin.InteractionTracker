using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.InteractionTracker.Forms.Events;
using Xamarin.InteractionTracker.Forms.Models;

namespace Xamarin.InteractionTracker.Forms
{
    /// <summary>
    /// Definition of a tracker
    /// </summary>
    public interface ITrackerManager
    {
        IList<UIEvent> EventCache { get; }
        event EventHandler<InteractionEventArgs> OnInteractionDetected;
        void ScanPage(ContentPage page, bool clearViewCache = false, bool includeLayouts = false);
    }
}
