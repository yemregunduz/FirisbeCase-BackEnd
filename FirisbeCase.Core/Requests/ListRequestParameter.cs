using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirisbeCase.Core.Requests
{
    public class ListRequestParameter
    {

        public int Page { get; set; } = 0;
        /// <summary>
        /// If the PageSize parameter is not provided, the default value is set to int.Max in order to prevent pagination from being applied.
        /// </summary>
        public int PageSize { get; set; } = int.MaxValue;
    }
}
