﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ElSerajElMoneer.Data.Dtos;
using ElSerajElMoneer.Server.Dtos;
using ElSerajElMoneer.Server.Extension;
using ElSerajElMoneer.Shared;

namespace ElSerajElMoneer.Core.Services
{
    public interface ITaghredatElSeraService
    {
        Task<PagedList<TaghredatElSera>> GetAllPagedTaghredatAsync(TaghredatParametersDto taghredatParametersDto);
        Task<TaghredatElSera> GetTaghredaByIdAsync(string id);
        Task<TaghredatElSera> CreateTaghredaAsync(TaghredatElSeraCreateInputDto taghredatElSeraCreateInputDto);
        Task UpdateTaghredaAsync(TaghredatElSera oldTaghreda, TaghredatElSeraCreateInputDto taghredatElSeraCreateInputDto);
        Task UpdateCounterAsync(string counter, string id);
    }
}