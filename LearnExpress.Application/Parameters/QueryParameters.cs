using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnExpress.Application.Parameters
{
    public class QueryParameters
    {
        public QueryParameters(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;    
        }
        const int _maxPageSize = 25;
        private int _pageSize;

        public int PageSize
        {
            get { return _pageSize == 0 ? _maxPageSize : _pageSize; }
            set { _pageSize = value > _maxPageSize ? _maxPageSize : value; }
        }

        public int PageNumber { get; set; } = 1;
    }
}
