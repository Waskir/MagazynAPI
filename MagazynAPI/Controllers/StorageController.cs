using AutoMapper;
using MagazynAPI.Entities;
using MagazynAPI.Models;
using MagazynAPI.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagazynAPI.Controllers
{
    [Route("api/storage")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageService _storageService;


        public StorageController(IStorageService storageService)
        {
            _storageService = storageService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
           var isDeleted = _storageService.Delete(id);

           if (isDeleted)
           {
               return NoContent();
           }

           return NotFound();
        }

        [HttpPost]
        public ActionResult CreateStorage([FromBody] CreateStorageDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _storageService.Create(dto);

            return Created($"/api/storage/{id}", null);


        }

        [HttpGet]
        public ActionResult<IEnumerable<StorageDto>> Getall()
        {
            var storagesDto = _storageService.GetAll();

            return Ok(storagesDto);

        }

        [HttpGet("{id}")]
        public ActionResult<StorageDto> Get([FromRoute] int id)
        {
            var storage = _storageService.GetById(id);

            if (storage is null)
            {
                return NotFound();
            }

            return Ok(storage);

        }
    }
}

 