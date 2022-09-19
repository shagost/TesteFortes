using Microsoft.AspNetCore.Mvc;
using TesteFortes.Application.Interfaces;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensPedidoController : ControllerBase
    {
        private readonly IItensPedidoService _itensPedidoService;
        private readonly IPedidoService _pedidoService;

        public ItensPedidoController(IItensPedidoService itensPedidoService, IPedidoService pedidoService)
        {
            _itensPedidoService = itensPedidoService;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_itensPedidoService.Get());
        }

        [HttpPost]
        public IActionResult Post(ItensPedidoViewModel itensPedidoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok(_itensPedidoService.Post(itensPedidoViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_itensPedidoService.GetById(id));
        }

        [HttpPut]
        public IActionResult Update(ItensPedidoViewModel itensPedidoViewModel)
        {
            return Ok(_itensPedidoService.Put(itensPedidoViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_itensPedidoService.Delete(id));
        }
    }
}
