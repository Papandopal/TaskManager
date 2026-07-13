using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UseCase.ProjectServices.MediatR.Enums
{
    [Flags]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FindFlags
    {
        UseFuzzySearch = 1,
        CaseInsensitive = 1 << 1
    }
}
