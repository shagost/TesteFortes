using Microsoft.AspNetCore.Mvc;
using TesteFortes.Application.Interfaces;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService produtoService)
        {
            this._pedidoService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pedidoService.Get());
        }

        [HttpPost]
        public IActionResult Post(PedidoCreateViewModel pedidoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_pedidoService.Post(pedidoViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pedidoService.GetById(id));
        }

        [HttpPut]
        public IActionResult Update(PedidoViewModel pedidoViewModel)
        {
            return Ok(_pedidoService.Put(pedidoViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_pedidoService.Delete(id));
        }
    }
}
