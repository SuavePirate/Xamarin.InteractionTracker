using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.InteractionTracker.Examples
{
    public class WritablePropertiesResolver : DefaultContractResolver
    {
        private readonly IEnumerable<string> IgnoredProperties;
        public WritablePropertiesResolver(IEnumerable<string> ignoredProperties)
        {
            IgnoredProperties = ignoredProperties.Select(p => p.ToLower());
        }
        public WritablePropertiesResolver()
        {
            IgnoredProperties = new List<string>();
        }
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> props = base.CreateProperties(type, memberSerialization);
            return props.Where(p => p.Writable)
                .Where(p => !IgnoredProperties.Contains(p.PropertyName.ToLower()))
                .ToList();
        }
    }
}
