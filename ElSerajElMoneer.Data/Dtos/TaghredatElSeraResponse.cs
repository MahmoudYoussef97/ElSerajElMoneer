using System;
namespace ElSerajElMoneer.Data.Dtos
{
    public class TaghredatElSeraResponse
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string DownloadUrl { get; set; }
        public string WatchUrl { get; set; }
        public int NumberOfDownloads { get; set; }
        public int NumberOfWatches { get; set; }
        public MetaDataResponse MetaData { get; set; }
    }
    public class MetaDataResponse
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
    }
}
