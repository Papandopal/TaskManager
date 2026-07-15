using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase.GeneralServices.Enums;

namespace UseCase.GeneralServices.DTOs
{
    public class FindItemsDTO
    {
        public string PropertyName { get; set; } = string.Empty;
        public string PropertyValue { get; set; } = string.Empty;
        public FindFlags FindFlags { get; set; }
    }
}
