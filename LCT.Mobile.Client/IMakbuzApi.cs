using LCT.Dtos;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LCT.Mobile.Client
{
   
    public interface IMakbuzApi
    {
        [Get("/makbuz/get")]
        public Task<List<MakbuzDto>> Get();
        //http request
        [Get("/makbuz/getById/{Id}")]
        public Task<MakbuzDetailDto> GetById(int Id);

        [Post("/makbuz/Add")]
        public Task<bool> Add( MakbuzAddDto makbuz);
        [Multipart]
        [Post("/makbuz/UploadImage")]
        Task<string> UploadImage([AliasAs("image")] StreamPart streamPart);



    }
}
