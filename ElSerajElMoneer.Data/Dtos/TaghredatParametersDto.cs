using System;
namespace ElSerajElMoneer.Server.Dtos
{
    public class TaghredatParametersDto
    {
        const int maxPageSize = 49;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 9;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
