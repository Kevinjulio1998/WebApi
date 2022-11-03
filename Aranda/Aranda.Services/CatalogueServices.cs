using Aranda.Domain.Dto;
using Aranda.Domain.Models;
using Aranda.Infraestructure.Repository;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aranda.Services
{
    public class CatalogueServices : ICatalogueServices
    {
        private readonly IRepository<Catalogue> _catalogue;
        private readonly IMapper _iMapper;

        public CatalogueServices(IRepository<Catalogue> catalogue, IMapper iMapper)
        {
            _catalogue = catalogue;
            _iMapper = iMapper;
        }

        public async Task<bool> Create(CatalogueDto catalogue)
        {
            var entity = _iMapper.Map<Catalogue>(catalogue);
            entity.Img = UploadFile.Upload(catalogue.Img);
            return await _catalogue.CreateAsync(entity); ;
        }

        public async Task<bool> Update(Dto dtoUpdate)
        {
            var getInfo = await _catalogue.GetAsync(a => a.Id == dtoUpdate.Id);

            var info = _iMapper.Map<Catalogue>(dtoUpdate);


            var resultUpdate = info != null &&
                               await _catalogue.Update(info,
                                   info.Id);
            return resultUpdate;
        }

        public bool Delete(Dto deleteDto)
        {
            var entity = _iMapper.Map<Catalogue>(deleteDto);
            var resultUpdate =  _catalogue.Delete(entity);
            return resultUpdate;
        }
        public async Task<IEnumerable<object>> GetAll(int page, int pageindex)
        {

            var getAll = await _catalogue.GetAsync();
            var getOrderByDescending = getAll.OrderByDescending(x => x.Category);
            var skip = (page - 1) * pageindex;
            var returnList = getOrderByDescending.Skip(skip).Take(pageindex).ToList();
            return returnList;
        }

        public async Task<IEnumerable<object>> GetAllByValue(string value)
        {

            var getAll = await _catalogue.GetAsync();
            var getOrderByDescending = getAll.Where(x => x.Name == value || x.Category == value || x.Description == value);
            return getOrderByDescending;
        }

    }
}
