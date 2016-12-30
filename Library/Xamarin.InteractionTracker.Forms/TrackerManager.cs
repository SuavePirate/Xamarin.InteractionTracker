using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.InteractionTracker.Forms.Models;

namespace Xamarin.InteractionTracker.Forms
{
    /// <summary>
    /// Implementation of tracker manager
    /// </summary>
    public class TrackerManager : ITrackerManager
    {
        public IList<UIEvent> EventCache { get; }
        public IList<View> ScannedViewsCache { get; }
        public GestureType GesturesTracked { get; }
        public bool IsUsingCache { get; }
        public TrackerManager(GestureType gesturesTracked, bool usingCache)
        {
            GesturesTracked = gesturesTracked;
            IsUsingCache = usingCache;
            if (usingCache)
            {
                EventCache = new List<UIEvent>();
            }
            ScannedViewsCache = new List<View>();
        }

        public void ScanPage(ContentPage page, bool clearViewCache = false, bool includeLayouts = false)
        {
            if (clearViewCache)
            {
                ScannedViewsCache.Clear();
            }
            var rootView = page.Content;

            if (rootView is Layout<View>)
            {
                foreach (var view in ((Layout<View>)rootView).Children)
                {
                    if (includeLayouts || !(view is Layout))
                    {
                        switch (GesturesTracked)
                        {
                            case GestureType.Tap:
                                view.GestureRecognizers.Add(new TapGestureRecognizer
                                {
                                    Command = new Command(() => TrackEvent(view, GestureType.Tap))
                                });
                                break;
                            case GestureType.Pan:
                                var panGesture = new PanGestureRecognizer();
                                panGesture.PanUpdated += (s, e) =>
                                {
                                    if (e.StatusType == GestureStatus.Completed)
                                        TrackEvent(view, GestureType.Pan);
                                };
                                view.GestureRecognizers.Add(panGesture);
                                break;
                            case GestureType.Pinch:
                                var pinchGesture = new PinchGestureRecognizer();
                                pinchGesture.PinchUpdated += (s, e) =>
                                {
                                    if (e.Status == GestureStatus.Completed)
                                        TrackEvent(view, GestureType.Pan);
                                };
                                view.GestureRecognizers.Add(pinchGesture);
                                break;
                        }
                        ScannedViewsCache.Add(view);
                    }
                }
            }
        }

        private void TrackEvent(View view, GestureType gesture)
        {

            var uiEvent = new UIEvent
            {
                Gesture = gesture,
                ElementName = "temp",
                Id = Guid.NewGuid(),
                EventTime = DateTime.UtcNow
            };
            if (IsUsingCache)
            {
                EventCache.Add(uiEvent);
            }
            // TODO: fire event
        }
    }
}
