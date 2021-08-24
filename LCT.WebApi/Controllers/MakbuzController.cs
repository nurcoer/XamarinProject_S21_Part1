using LCT.Dtos;
using LCT.WebApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LCT.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]/{id?}")]

    public class MakbuzController : ControllerBase
    {
        public IMakbuzService _makbuzService;

        public MakbuzController(IMakbuzService makbuzService )
        {
            _makbuzService = makbuzService;
        }
        
        public async Task<IEnumerable<MakbuzDto>> Get()
        
        {
            var makbuz = await _makbuzService.Get();
            return makbuz;
        }
        public async Task<MakbuzDetailDto> GetById(int Id)
        {
            var makbuz = await _makbuzService.GetById(Id);
            return makbuz;
        }
        public async Task<bool> Add(MakbuzAddDto makbuz)
        { 
            return await _makbuzService.Add(makbuz);
        }
        [HttpPost]
        public async Task<string> UploadImage(IFormFile image )
        {
            var path = await _makbuzService.SaveImageAsync(image);
            
            return path;
        }
        

    }

}
