using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UseCase.ProjectServices.MediatR.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum FilterComparer
    {
        Equal, NotEqual, Greate, GreateEqual, Less, LessEqual
    }
}
