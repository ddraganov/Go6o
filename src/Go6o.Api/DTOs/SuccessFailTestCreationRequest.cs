using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Go6o.Api.DTOs
{
    public class SuccessFailTestCreationRequest : TestCreationRequestBase
    {
        public int HitsCountRequiredForRecalculation { get; set; }
    }
}
