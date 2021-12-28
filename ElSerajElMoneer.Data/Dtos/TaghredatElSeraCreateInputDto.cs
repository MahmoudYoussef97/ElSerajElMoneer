using System;
using System.ComponentModel.DataAnnotations;

namespace ElSerajElMoneer.Data.Dtos
{
    public class TaghredatElSeraCreateInputDto
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(5)]
        public string Duration { get; set; }
        [MaxLength(180)]
        public string Description { get; set; }
        public string DownloadUrl { get; set; }
        public string WatchUrl { get; set; }
    }
}
