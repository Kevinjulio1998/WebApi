using Aranda.Domain.Models;
using Aranda.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aranda.Test
{
    public class CatalogueFake : ICatalogueServices
    {

        private readonly List<Catalogue> _catalogue;
        public CatalogueFake() =>
            _catalogue = new List<Catalogue>()
            {
                new Catalogue() { Id = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                    Name = "Orange Juice", Category= "Orange Tree", Description = "Prueba" },
                new Catalogue() { Id = new Guid("815accac-fd5b-478a-a9d6-f171a2f6ae7f"),
                    Name = "Diary Milk", Category= "Cow", Description = "Prueba"  },
                new Catalogue() { Id = new Guid("33704c4a-5b87-464c-bfb6-51971b4d18ad"),
                    Name = "Frozen Pizza", Category= "Uncle Mickey", Description = "Prueba" }
            };


        public IEnumerable<Catalogue> GetTicketall()
        {
            return _catalogue;
        }
        public Catalogue CreateEmployeeAsync(Catalogue newItem)
        {
            newItem.Id = Guid.NewGuid();
            _catalogue.Add(newItem);
            return newItem;
        }
        public Catalogue Update(Catalogue newItem)
        {
            newItem.Id = Guid.NewGuid();
            _catalogue.(newItem);
            return newItem;
        }
        public Catalogue GetByValue(string value)
        {
            return _catalogue.FirstOrDefault(a => a.Name == value || a.Category == value || a.Description == value);
        }
        public void Remove(Guid id)
        {
            var existing = _catalogue.First(a => a.Id == id);
            _catalogue.Remove(existing);
        }

    }
}
