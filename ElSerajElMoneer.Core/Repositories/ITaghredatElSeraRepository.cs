using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Data.Dtos;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using ElSerajElMoneer.Shared;

namespace ElSerajElMoneer.Core.Repositories
{
    public interface ITaghredatElSeraRepository
    {
        Task<IEnumerable<TaghredatElSera>> GetAllAsync();
        Task<PagedList<TaghredatElSera>> GetAllPagedAsync(TaghredatParametersDto taghredatParametersDto);
        Task<TaghredatElSera> GetById(string id);
        Task<TaghredatElSera> CreateTaghredaAsync(TaghredatElSeraCreateInputDto taghredatElSeraCreateInputDto);
        Task UpdateTaghredaAsync(TaghredatElSera oldTaghreda, TaghredatElSeraCreateInputDto updatedTaghreda);
        Task UpdateNumberOfDownloadsByIdAsync(string id);
        Task UpdateNumberOfWatchesByIdAsync(string id);
    }
}
