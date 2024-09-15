using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donut.Core.Pagination;

public class PaginatedRequest
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
