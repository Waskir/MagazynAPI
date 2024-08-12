using AutoMapper;
using MagazynAPI.Entities;
using MagazynAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagazynAPI.Service
{
    public interface IStorageService
    {
        StorageDto GetById(int id);
        IEnumerable<StorageDto> GetAll();
        int Create(CreateStorageDto dto);
        bool Delete(int id);
    }

    public class StorageService : IStorageService
    {
        private readonly StorageDbContext _dbContext;
        private readonly IMapper _mapper;

        public StorageService(StorageDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Delete(int id) 
        {
            var storage = _dbContext
                .Storages
                .FirstOrDefault(s => s.Id == id);

            if (storage is null) return false;

            _dbContext.Storages.Remove(storage);
            _dbContext.SaveChanges();
             
            return true;
        }

        public StorageDto GetById(int id)
        {
            var storage = _dbContext
                .Storages
                .Include(r => r.Address)
                .Include(r => r.Itemes)
                .FirstOrDefault(s => s.Id == id);

            if (storage is null) return null;

            var result = _mapper.Map<StorageDto>(storage);
            return result;
        }

        public IEnumerable<StorageDto> GetAll()
        {
            var storages = _dbContext
                .Storages
                .Include(r => r.Address)
                .Include(r => r.Itemes)
                .ToList();

            var storagesDtos = _mapper.Map<List<StorageDto>>(storages);

            return storagesDtos;
        }

        public int Create(CreateStorageDto dto)
        {
            var storage = _mapper.Map<Storage>(dto);
            _dbContext.Storages.Add(storage);
            _dbContext.SaveChanges();

            return storage.Id;
        }
    }
}
