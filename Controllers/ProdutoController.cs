using FarmaciaPerformanceGo.Model;
using FarmaciaPerformanceGo.Service;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaPerformanceGo.Controllers
{


    [Route("~/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;
        private readonly IValidator<Produto> _produtoValidator;


        public ProdutoController(IProdutoService produtoService, IValidator<Produto> produtoValidator)

        {
            _produtoService = produtoService;
            _produtoValidator = produtoValidator;
        }

     
        [HttpGet]

        public async Task<ActionResult> GetAll()
        {
            return Ok(await _produtoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetbyId(long id)
        {
            var Resposta = await _produtoService.GetById(id);

            if (Resposta == null)
                return NotFound();

            return Ok(Resposta);
        }



        [HttpGet("nome/{nome}")]
        public async Task<ActionResult> GetByNome(string nome)

        {
            return Ok(await _produtoService.GetByNome(nome));
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Produto produtos)
        {
            var validarprodutos = await _produtoValidator.ValidateAsync(produtos);
            if (!validarprodutos.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarprodutos);
            }
            var Resposta = await _produtoService.Create(produtos);

            if (Resposta is null)
                return BadRequest("Produto não encontrado");

            return CreatedAtAction(nameof(GetbyId), new { id = produtos.Id }, produtos);

        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Produto produtos)
        {
            if (produtos.Id == 0)
                return BadRequest("Id do produto é invalido");

            var validarprodutos = await _produtoValidator.ValidateAsync(produtos);

            if (!validarprodutos.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, validarprodutos);
            }

            var Resposta = await _produtoService.Update(produtos);

            if (Resposta is null)
                return NotFound("Produto não Encontrado");

            return Ok(Resposta);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            var BuscaPostagem = await _produtoService.GetById(Id);


            if (BuscaPostagem is null)
                return NotFound("Produto não encontrado");

            await _produtoService.Delete(BuscaPostagem);
            return NoContent();

        }

    }
}


