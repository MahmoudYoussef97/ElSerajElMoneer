using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using ElSerajElMoneer.Shared;

namespace ElSerajElMoneer.Core.Repositories
{
    public interface ITaghredatElSeraRepository
    {
        public Task<IEnumerable<TaghredatElSera>> GetAllAsync();
        public Task<PagedList<TaghredatElSera>> GetAllPagedAsync(TaghredatParametersDto taghredatParametersDto);
        public Task<TaghredatElSera> GetById(string id);
        public Task UpdateNumberOfDownloadsByIdAsync(string id);
        public Task UpdateNumberOfWatchesByIdAsync(string id);
    }
}
