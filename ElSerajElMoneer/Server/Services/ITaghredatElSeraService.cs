using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using ElSerajElMoneer.Shared;

namespace ElSerajElMoneer.Core.Services
{
    public interface ITaghredatElSeraService
    {
        Task<PagedList<TaghredatElSera>> GetAllTaghredatAsync(TaghredatParametersDto taghredatParametersDto);
        Task<TaghredatElSera> GetTaghredaById(string id);
        Task UpdateCounter(Counter counter, string id);
    }
}
