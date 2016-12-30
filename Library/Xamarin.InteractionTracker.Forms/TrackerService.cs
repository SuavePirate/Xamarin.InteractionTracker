using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.InteractionTracker.Forms.Models;

namespace Xamarin.InteractionTracker.Forms
{
    /// <summary>
    /// Service for tracking events in the UI
    /// </summary>
    public static class TrackerService
    {
        public static ITrackerManager Current;

        public static void Init(GestureType gestures, bool useCache)
        {
            Current = new TrackerManager(gestures, useCache);
        }

        public static void Init()
        {
            Init(GestureType.Tap, true);
        }
    }
}
