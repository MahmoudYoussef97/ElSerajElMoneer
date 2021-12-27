using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Core.Repositories;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using ElSerajElMoneer.Shared;

namespace ElSerajElMoneer.Core.Services
{
    public class TaghredatElSeraService : ITaghredatElSeraService
    {
        private readonly ITaghredatElSeraRepository _taghredatElSeraRepository;
        public TaghredatElSeraService(ITaghredatElSeraRepository taghredatElSeraRepository)
        {
            _taghredatElSeraRepository = taghredatElSeraRepository;
        }

        public async Task<PagedList<TaghredatElSera>> GetAllTaghredatAsync(TaghredatParametersDto taghredatParametersDto)
        {
            return await _taghredatElSeraRepository.GetAllPagedAsync(taghredatParametersDto);
        }

        public async Task<TaghredatElSera> GetTaghredaById(string id)
        {
            return await _taghredatElSeraRepository.GetById(id);
        }
        public async Task UpdateCounter(Counter counter, string id)
        {
            if (counter == Counter.DownloadCounter)
                await _taghredatElSeraRepository.UpdateNumberOfDownloadsByIdAsync(id);
            else if (counter == Counter.WatchCounter)
                await _taghredatElSeraRepository.UpdateNumberOfWatchesByIdAsync(id);
        }
    }
}
