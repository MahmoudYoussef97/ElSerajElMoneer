using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Core.Extension;
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
        public async Task<TaghredatElSera> CreateTaghredaAsync(TaghredatElSera taghreda)
        {
            await _taghredat.InsertOneAsync(taghreda);
            return taghreda;
        }

        public async Task DeleteTaghredaAsync(TaghredatElSera taghreda)
        {
            await _taghredat.DeleteOneAsync(t => t.Id == taghreda.Id);
        }

        public async Task<IEnumerable<TaghredatElSera>> GetAllAsync()
        {
            return await _taghredat.Find<TaghredatElSera>(t => true).ToListAsync();
;        }

        public async Task<(MetaData, IEnumerable<TaghredatElSera>)> GetAllPagedAsync(TaghredatParametersDto taghredatParametersDto)
        {
            return await _taghredat.AggregateByPage(
                        Builders<TaghredatElSera>.Filter.Empty,
                        Builders<TaghredatElSera>.Sort.Ascending(t => t.Id),
                        page: taghredatParametersDto.PageNumber,
                        pageSize: taghredatParametersDto.PageSize);
        }

        public async Task<TaghredatElSera> GetById(string id)
        {
            return await _taghredat.Find(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateNumberOfDownloadsByIdAsync(string id)
        {
            var taghreda = await GetById(id);
            taghreda.NumberOfDownloads+=1;
            await _taghredat.ReplaceOneAsync(t => t.Id == id, taghreda);
        }

        public async Task UpdateNumberOfWatchesByIdAsync(string id)
        {
            var taghreda = await GetById(id);
            taghreda.NumberOfWatches += 1;
            await _taghredat.ReplaceOneAsync(t => t.Id == id, taghreda);
        }

        public async Task UpdateTaghredaAsync(string id, TaghredatElSera updatedTaghreda)
        { 
            await _taghredat.ReplaceOneAsync(t => t.Id == id, updatedTaghreda);
        }
    }
}
