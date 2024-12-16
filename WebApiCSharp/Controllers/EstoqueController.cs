using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCSharp.Models;
using WebApiCSharp.Repositorios.Interfaces;

namespace WebApiCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueRepositorio _estoqueRepositorio;

        public EstoqueController(IEstoqueRepositorio estoqueRepositorio)
        {
            _estoqueRepositorio = estoqueRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EstoqueModel>>> BuscarTodosProdutosEstoque()
        {
            List<EstoqueModel> estoque = await _estoqueRepositorio.BuscarTodosProdutosEstoque();
            return Ok(estoque);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<EstoqueModel>> BuscarPorId(int id)
        {
            EstoqueModel estoque = await _estoqueRepositorio.BuscarPorId(id);
            return Ok(estoque);
        }

        /*[HttpPost]
        public async Task<ActionResult<EstoqueModel>> Cadastrar([FromBody] EstoqueModel estoqueModel)
        {
            EstoqueModel estoque = await _estoqueRepositorio.Adicionar(estoqueModel);

            return Ok(estoque);
        }*/

        [HttpPut("{id}")]
        public async Task<ActionResult<EstoqueModel>> Atualizar([FromBody] EstoqueModel estoqueModel, int id)
        {
            estoqueModel.Id = id;
            EstoqueModel estoque = await _estoqueRepositorio.Atualizar(estoqueModel, id);
            return Ok(estoque);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EstoqueModel>> Apagar(int id)
        {
            bool apagado = await _estoqueRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
