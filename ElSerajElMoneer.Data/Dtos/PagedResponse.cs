using System;
using System.Collections.Generic;
using ElSerajElMoneer.Data.Models;
using ElSerajElMoneer.Server.Dtos;

namespace ElSerajElMoneer.Data.Dtos
{
    public class PagedResponse<T>
    {
        public MetaData MetaData { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
