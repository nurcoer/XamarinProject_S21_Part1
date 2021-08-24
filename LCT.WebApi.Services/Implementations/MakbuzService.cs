using LCT.Dtos;
using LCT.EF;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SixLabors.ImageSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace LCT.WebApi.Services.Implementations
{
  
    public class MakbuzService : IMakbuzService
    {

        LCTContext _context;
        
        public MakbuzService(LCTContext context )
        {
            _context = context;
        }

        public async Task<bool> Add(MakbuzAddDto makbuz)
        {
            try
            {

                _context.Makbuzlar.Add(new EF.Models.Makbuz()
                {
                    Name = makbuz.Name,
                    Description = makbuz.Description,
                    Image = makbuz.Image,
                    Date = makbuz.Date,
                    Amount = makbuz.Amount,
                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }


        }
        public async Task<IList<MakbuzDto>> Get()
        {

            var item =  await _context.Makbuzlar.Select(x => new MakbuzDto()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            }).ToListAsync();
            return item;
        }

        public async Task<MakbuzDetailDto> GetById(int Id)
        {
            return await _context.Makbuzlar.Select(x => new MakbuzDetailDto()
            {

                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Amount = x.Amount,
                Date = x.Date,
                Image = x.Image
            }).FirstOrDefaultAsync(x => x.Id == Id);

        }


        public async Task<string> SaveImageAsync(IFormFile file)
        {

            using var image = Image.Load(file.OpenReadStream());
            var filename = file.FileName;
            var folder = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\uploads"}";
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            };
            var path = Path.Join(folder, filename);

            await image.SaveAsync(path);

            return  "/uploads/" + filename;
        }

       
    }
    }

