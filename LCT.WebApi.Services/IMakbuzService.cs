using LCT.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCT.WebApi.Services
{
    public interface IMakbuzService
    {
        public Task<IList<MakbuzDto>> Get();
        public Task<bool> Add(MakbuzAddDto makbuz);
        public Task<MakbuzDetailDto> GetById(int Id);
        public Task<string> SaveImageAsync(IFormFile file );
       
    }
}
