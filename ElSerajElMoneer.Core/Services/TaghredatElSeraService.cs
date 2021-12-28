using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Core.Repositories;
using ElSerajElMoneer.Data.Dtos;
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

        public async Task<PagedList<TaghredatElSera>> GetAllPagedTaghredatAsync(TaghredatParametersDto taghredatParametersDto)
        {
            return await _taghredatElSeraRepository.GetAllPagedAsync(taghredatParametersDto);
        }

        public async Task<TaghredatElSera> GetTaghredaByIdAsync(string id)
        {
            return await _taghredatElSeraRepository.GetById(id);
        }
        public async Task<TaghredatElSera> CreateTaghredaAsync(TaghredatElSeraCreateInputDto taghredatElSeraCreateInputDto)
        {
            return await _taghredatElSeraRepository.CreateTaghredaAsync(taghredatElSeraCreateInputDto);
        }
        public async Task UpdateCounterAsync(string counterType, string id)
        {
            Counter counter = GetTypeOfCounter(counterType);

            if (counter == Counter.DownloadCounter)
                await _taghredatElSeraRepository.UpdateNumberOfDownloadsByIdAsync(id);
            else if (counter == Counter.WatchCounter)
                await _taghredatElSeraRepository.UpdateNumberOfWatchesByIdAsync(id);
        }
        private Counter GetTypeOfCounter(string counter)
        {
            return counter.ToLower().Equals("download") ? Counter.DownloadCounter : Counter.WatchCounter;
        }

        public async Task UpdateTaghredaAsync(TaghredatElSera oldTaghreda, TaghredatElSeraCreateInputDto updatedTaghreda)
        {
            await _taghredatElSeraRepository.UpdateTaghredaAsync(oldTaghreda, updatedTaghreda);
        }
    }
}
