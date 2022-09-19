using Microsoft.AspNetCore.Mvc;
using TesteFortes.Application.Interfaces;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            this._produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtoService.Get());
        }

        [HttpPost]
        public IActionResult Post(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_produtoService.Post(produtoViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_produtoService.GetById(id));
        }

        [HttpPut]
        public IActionResult Update(ProdutoViewModel produtoViewModel)
        {
            return Ok(_produtoService.Put(produtoViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_produtoService.Delete(id));
        }
    }
}
