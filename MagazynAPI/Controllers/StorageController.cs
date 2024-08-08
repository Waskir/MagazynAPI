using AutoMapper;
using MagazynAPI.Entities;
using MagazynAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazynAPI.Controllers
{
    [Route("api/storage")]
    public class StorageController : ControllerBase
    {
        private readonly StorageDbContext _dbContext;
        private readonly IMapper _mapper;

        public StorageController(StorageDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StorageDto>> Getall()
        {
            var storages = _dbContext
                .Storages
                .Include(r => r.Address)
                .Include(r => r.Itemes)
                .ToList();

            var storagesDto = _mapper.Map<List<StorageDto>>(storages);

            return Ok(storagesDto);

        }

        [HttpGet("{id}")]
        public ActionResult<StorageDto> Get([FromRoute] int id)
        {
            var storage = _dbContext
                .Storages
                .Include(r => r.Address)
                .Include(r => r.Itemes)
                .FirstOrDefault(s => s.Id == id);

            if (storage is null)
            {
                return NotFound();
            }

            var storageDto = _mapper.Map<StorageDto>(storage);

            return Ok(storageDto);
        }
    }
}
 