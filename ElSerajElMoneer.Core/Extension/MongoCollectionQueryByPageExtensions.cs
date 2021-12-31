using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElSerajElMoneer.Server.Dtos;
using MongoDB.Driver;

namespace ElSerajElMoneer.Core.Extension
{
    public static class MongoCollectionQueryByPageExtensions
    {
        public static async Task<(MetaData metaData, IReadOnlyList<TDocument> data)> AggregateByPage<TDocument>(
        this IMongoCollection<TDocument> collection,
        FilterDefinition<TDocument> filterDefinition,
        SortDefinition<TDocument> sortDefinition,
        int page = 1,
        int pageSize= 1 )
        {
            var countFacet = AggregateFacet.Create("count",
                PipelineDefinition<TDocument, AggregateCountResult>.Create(new[]
                {
                PipelineStageDefinitionBuilder.Count<TDocument>()
                }));

            var dataFacet = AggregateFacet.Create("data",
                PipelineDefinition<TDocument, TDocument>.Create(new[]
                {
                PipelineStageDefinitionBuilder.Sort(sortDefinition),
                PipelineStageDefinitionBuilder.Skip<TDocument>((page - 1) * pageSize),
                PipelineStageDefinitionBuilder.Limit<TDocument>(pageSize),
                }));


            var aggregation = await collection.Aggregate()
                .Match(filterDefinition)
                .Facet(countFacet, dataFacet)
                .ToListAsync();

            var count = aggregation.First()
                .Facets.First(x => x.Name == "count")
                .Output<AggregateCountResult>()
                ?.FirstOrDefault()
                ?.Count;

            var totalPages = (int)Math.Ceiling((double)count / pageSize);

            var data = aggregation.First()
                .Facets.First(x => x.Name == "data")
                .Output<TDocument>();

            var metaData = new MetaData
            {
                PageSize = pageSize,
                CurrentPage = page,
                TotalCount = (Int32) count,
                TotalPages = totalPages
            };
            return (metaData, data);
        }
    }
}
