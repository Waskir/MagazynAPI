using System.Reflection.Metadata;
using MagazynAPI.Entities;
using Microsoft.IdentityModel.Tokens;

namespace MagazynAPI
{
    public class StorageSeeder
    {
        public readonly StorageDbContext _dbContext;

        public StorageSeeder(StorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Storages.Any())
                {
                    var storages = GetStorages();
                    _dbContext.Storages.AddRange(storages);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Storage> GetStorages()
        {
            var storages = new List<Storage>()
            {
                new Storage()
                {
                    Name = "BlumPL",
                    Category = "Elektrical",
                    ContactEmail = "contact@Blum.pl",
                    Itemes = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Mega pf",
                            Price = 10.40M,
                            Type = "ELE",
                            Description = "ncxbvnmxc",


                        },

                        new Item()
                        {
                            Name = "Elektar",
                            Price = 4.98M,
                            Type = "ELE",
                            Description = "fjgopdiopewr",


                        },
                    },
                    Address = new Address()
                    {
                        City = "Katowice",
                        Street = "Karola Miarki 4",
                        PostalCode = "40-250"
                    },
                },
                new Storage()
                {
                    Name = "BlumInz",
                    Category = "Elektrical",
                    ContactEmail = "contact@Blum.com",
                    Itemes = new List<Item>()
                    {
                        new Item()
                        {
                            Name = "Hadw",
                            Price = 100.40M,
                            Type = "ELE",
                            Description = "jkjdflsglk",


                        },

                        new Item()
                        {
                            Name = "Arm",
                            Price = 40.98M,
                            Type = "ELE",
                            Description = "dasdasdasd",

                        },
                    },
                    Address = new Address()
                    {
                        City = "Sosnowiec",
                        Street = "Katowicka 4",
                        PostalCode = "45-095"
                    },
                },
            };

            return storages;
        }
    }
}
