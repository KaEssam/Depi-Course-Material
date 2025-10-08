using Day1.Services.LifeCycle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;

namespace Day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeCycleController : ControllerBase
    {
        private readonly ISingletonService _singleton;
        private readonly IScopedService _scoped1;
        private readonly IScopedService _scoped2;
        private readonly ITransientService _transient1;
        private readonly ITransientService _transient2;


        public LifeCycleController(
            ISingletonService singleton,
            ITransientService transient1,
            ITransientService transient2,
            IScopedService scoped1,
            IScopedService scoped2)
        {
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton = singleton;
            _transient1 = transient1;
            _transient2 = transient2;
        }

        [HttpGet]
        public object get()
        {
            return new
            {
                Singleton = _singleton.id,
                Scoped1 = _scoped1.id,
                Scoped2 = _scoped2.id,
                Transient1 = _transient1.id,
                Transient2 = _transient2.id
            };
        }
    }
}
