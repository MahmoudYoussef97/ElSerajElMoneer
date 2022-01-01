using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Core.Repositories;
using ElSerajElMoneer.Data.Dtos;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using ElSerajElMoneer.Data.Models;

namespace ElSerajElMoneer.Core.Services
{
    public class TaghredatElSeraService : ITaghredatElSeraService
    {
        private readonly ITaghredatElSeraRepository _taghredatElSeraRepository;
        public TaghredatElSeraService(ITaghredatElSeraRepository taghredatElSeraRepository)
        {
            _taghredatElSeraRepository = taghredatElSeraRepository;
        }

        public async Task<PagedResponse<TaghredatElSera>> GetAllPagedTaghredatAsync(TaghredatParametersDto taghredatParametersDto)
        {
            var result = await _taghredatElSeraRepository.GetAllPagedAsync(taghredatParametersDto);
            return new PagedResponse<TaghredatElSera> { MetaData = result.Item1, Items = result.Item2 };
        }
        public async Task<IEnumerable<TaghredatElSera>> GetAllAsync()
        {
            return await _taghredatElSeraRepository.GetAllAsync();
        }
        public async Task<TaghredatElSera> GetTaghredaByIdAsync(string id)
        {
            return await _taghredatElSeraRepository.GetById(id);
        }
        public async Task<TaghredatElSera> CreateTaghredaAsync(TaghredatElSeraCreateInputDto taghredatElSeraCreateInputDto)
        {
            var newTaghreda = new TaghredatElSera
            {
                Title = taghredatElSeraCreateInputDto.Title,
                Description = taghredatElSeraCreateInputDto.Description,
                DownloadUrl = taghredatElSeraCreateInputDto.DownloadUrl,
                WatchUrl = taghredatElSeraCreateInputDto.WatchUrl,
                Duration = taghredatElSeraCreateInputDto.Duration,
                NumberOfDownloads = 0,
                NumberOfWatches = 0
            };
            return await _taghredatElSeraRepository.CreateTaghredaAsync(newTaghreda);
        }
        public async Task UpdateCounterAsync(Counter counter, string id)
        {
            var taghreda = await _taghredatElSeraRepository.GetById(id);

            if (counter == Counter.DownloadCounter)
                taghreda.NumberOfDownloads += 1;
            else if (counter == Counter.WatchCounter)
                taghreda.NumberOfWatches += 1;

            await _taghredatElSeraRepository.UpdateTaghredaAsync(id, taghreda);
        }
        public async Task DeleteTaghredaAsync(TaghredatElSera taghreda)
        {
            await _taghredatElSeraRepository.DeleteTaghredaAsync(taghreda);
        }
        public async Task UpdateTaghredaAsync(TaghredatElSera oldTaghreda, TaghredatElSeraCreateInputDto updatedTaghredaInput)
        {
            var updatedTaghreda = new TaghredatElSera
            {
                Id = oldTaghreda.Id,
                Description = updatedTaghredaInput.Description,
                DownloadUrl = updatedTaghredaInput.DownloadUrl,
                WatchUrl = updatedTaghredaInput.WatchUrl,
                Duration = updatedTaghredaInput.Duration,
                Title = updatedTaghredaInput.Title,
                NumberOfDownloads = oldTaghreda.NumberOfDownloads,
                NumberOfWatches = oldTaghreda.NumberOfWatches
            };
            await _taghredatElSeraRepository.UpdateTaghredaAsync(oldTaghreda.Id, updatedTaghreda);
        }

        private Counter GetTypeOfCounter(string counter)
        {
            return counter.ToLower().Equals("download") ? Counter.DownloadCounter : Counter.WatchCounter;
        }
    }
}
