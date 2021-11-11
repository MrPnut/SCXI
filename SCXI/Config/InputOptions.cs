using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SCXI.Config
{
    public class InputOptions
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public DPadMode DPadMode { get; set; } = DPadMode.Touch;
    }

    public enum DPadMode { Click, Touch }
}
