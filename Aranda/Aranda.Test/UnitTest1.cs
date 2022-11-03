using Aranda.Controllers;
using Aranda.Services;
using Xunit;

namespace Aranda.Test
{
    public class UnitTest1
    {

        private readonly CatalogueController _controller;
        private readonly ICatalogueServices _service;
        public UnitTest1()
        {
            _service = new CatalogueFake();
            _controller = new CatalogueController(_service);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
