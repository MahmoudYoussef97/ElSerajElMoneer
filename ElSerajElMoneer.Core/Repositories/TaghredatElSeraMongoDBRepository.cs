using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Data.Dtos;
using ElSerajElMoneer.Data.Models;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using MongoDB.Driver;

namespace ElSerajElMoneer.Core.Repositories
{
    public class TaghredatElSeraMongoDBRepository : ITaghredatElSeraRepository
    {
        private readonly IMongoCollection<TaghredatElSera> _taghredat;
        public TaghredatElSeraMongoDBRepository(IElSerajElMoneerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _taghredat = database.GetCollection<TaghredatElSera>(settings.TaghredatCollectionName);
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
            await _taghredat.InsertOneAsync(newTaghreda);
            return newTaghreda;
        }

        public Task DeleteTaghredaAsync(TaghredatElSera taghreda)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaghredatElSera>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<TaghredatElSera>> GetAllPagedAsync(TaghredatParametersDto taghredatParametersDto)
        {
            throw new NotImplementedException();
        }

        public Task<TaghredatElSera> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNumberOfDownloadsByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateNumberOfWatchesByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTaghredaAsync(TaghredatElSera oldTaghreda, TaghredatElSeraCreateInputDto updatedTaghreda)
        {
            throw new NotImplementedException();
        }
    }
}
