using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElSerajElMoneer.Data.Dtos;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using ElSerajElMoneer.Data.Models;

namespace ElSerajElMoneer.Core.Repositories
{
    public class TaghredatElSeraRepository : ITaghredatElSeraRepository
    {
        private List<TaghredatElSera> taghredatElSeras;
        public TaghredatElSeraRepository()
        {
            taghredatElSeras = new List<TaghredatElSera>()
            {
                new TaghredatElSera{Id="1",Title="الحلقة الأولى", Description="مولد ونشأة النبي", Duration= "2:30", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="2",Title="الحلقة الثانية", Description="مولد ونشأة النبي", Duration= "1:30", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="3",Title="الحلقة الثالثة", Description="مولد ونشأة النبي", Duration= "2:45", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="4",Title="الحلقة الرابعة", Description="مولد ونشأة النبي", Duration= "2:50", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="5",Title="الحلقة الخامسة", Description="مولد ونشأة النبي", Duration= "3:30", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="6",Title="الحلقة السادسة", Description="مولد ونشأة النبي", Duration= "1:15", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="7",Title="الحلقةالسابعة", Description="مولد ونشأة النبي", Duration= "2:30", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="8",Title="الحلقة الثامنة", Description="مولد ونشأة النبي", Duration= "1:30", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="9",Title="الحلقة التاسعة", Description="مولد ونشأة النبي", Duration= "2:45", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="10",Title="الحلقة العاشرة", Description="مولد ونشأة النبي", Duration= "2:50", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="11",Title="الحلقة الحادية عشرة", Description="مولد ونشأة النبي", Duration= "3:30", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"},
                new TaghredatElSera{Id="12",Title="الحلقة الثانية عشرة", Description="مولد ونشأة النبي", Duration= "1:15", WatchUrl="https://www.youtube.com/embed/494uqk2fEc0?list=PL93PwBX3YL93d4mUyROgKV9oSIQZI2noT", DownloadUrl="/Users/mahyoussef/projects/ElSerajElMoneer/ElSerajElMoneer/Client/wwwroot/taghredat/1.mp4"}
            };
        }

        public async Task<IEnumerable<TaghredatElSera>> GetAllAsync()
        {
            return taghredatElSeras;
        }
        public async Task<PagedList<TaghredatElSera>> GetAllPagedAsync(TaghredatParametersDto taghredatParametersDto)
        {
            return PagedList<TaghredatElSera>.ToPagedList(taghredatElSeras.AsQueryable(),
                taghredatParametersDto.PageNumber,
                taghredatParametersDto.PageSize);
        }
        public async Task<TaghredatElSera> GetById(string id)
        {
            return taghredatElSeras.Find(t => t.Id == id);
        }
        public async Task<TaghredatElSera> CreateTaghredaAsync(TaghredatElSera taghreda)
        {
            taghreda.Id = Guid.NewGuid().ToString();
            taghredatElSeras.Add(taghreda);
            return taghreda;
        }
        public async Task UpdateNumberOfDownloadsByIdAsync(string id)
        {
            var taghreda = taghredatElSeras.Find(t => t.Id == id);
            taghreda.NumberOfDownloads += 1;
        }
        public async Task UpdateNumberOfWatchesByIdAsync(string id)
        {
            var taghreda = taghredatElSeras.Find(t => t.Id == id);
            taghreda.NumberOfWatches+=1;
        }

        public async Task UpdateTaghredaAsync(TaghredatElSera oldTaghreda, TaghredatElSeraCreateInputDto updatedTaghreda)
        {
            oldTaghreda.Description = updatedTaghreda.Description;
            oldTaghreda.DownloadUrl = updatedTaghreda.DownloadUrl;
            oldTaghreda.WatchUrl = updatedTaghreda.WatchUrl;
            oldTaghreda.Duration = updatedTaghreda.Duration;
            oldTaghreda.Title = updatedTaghreda.Title;
        }

        public async Task DeleteTaghredaAsync(TaghredatElSera taghreda)
        {
            taghredatElSeras.Remove(taghreda);
        }
    }
}
