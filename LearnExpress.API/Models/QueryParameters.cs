using System.ComponentModel.DataAnnotations;

namespace LearnExpress.API.Models
{
    public class QueryParameters
    {
		private int _pageSize = 25;

		public int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = (value > 25 || value < 2)? 25 : value; }
		}

		public int PageNumber { get; set; } = 1;
    }
}
