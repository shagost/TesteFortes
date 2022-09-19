using Microsoft.AspNetCore.Mvc;
using TesteFortes.Application.Interfaces;
using TesteFortes.Application.ViewModels;

namespace TesteFortes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService produtoService)
        {
            this._fornecedorService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_fornecedorService.Get());
        }

        [HttpPost]
        public IActionResult Post(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(_fornecedorService.Post(fornecedorViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_fornecedorService.GetById(id));
        }

        [HttpPut]
        public IActionResult Update(FornecedorViewModel fornecedorViewModel)
        {
            return Ok(_fornecedorService.Put(fornecedorViewModel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_fornecedorService.Delete(id));
        }
    }
}
