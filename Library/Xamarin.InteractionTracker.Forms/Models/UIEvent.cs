using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.InteractionTracker.Forms.Models
{
    /// <summary>
    /// Record of an event on an element
    /// </summary>
    public class UIEvent
    {
        public Guid Id { get; set; }
        public string ElementName { get; set; }
        public GestureType Gesture { get; set; }
        public DateTime EventTime { get; set; }
    }
}
