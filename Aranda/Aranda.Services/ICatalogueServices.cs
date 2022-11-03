using System;
using Aranda.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aranda.Services
{
    public interface ICatalogueServices
    {
        Task<bool> Create(CatalogueDto catalogue) => throw new NotImplementedException();
        Task<bool> Update(Dto dtoUpdate) => throw new NotImplementedException();

        Task<IEnumerable<object>> GetAll(int page, int pageindex) => throw new NotImplementedException();

        Task<IEnumerable<object>> GetAllByValue(string value) => throw new NotImplementedException();

        bool Delete(Dto deleteDto) => throw new NotImplementedException();
    }
}
