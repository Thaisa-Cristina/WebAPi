using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCSharp.Enums;
using WebApiCSharp.Models;
using WebApiCSharp.Repositorios.Interfaces;

namespace WebApiCSharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IEstoqueRepositorio _estoqueRepositorio; // Adicionando repositório de estoque

        public ProdutoController(IProdutoRepositorio produtoRepositorio, IEstoqueRepositorio estoqueRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _estoqueRepositorio = estoqueRepositorio; // Inicializando repositório de estoque
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            List<ProdutoModel> produtos = await _produtoRepositorio.BuscarTodosProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ProdutoModel produto = await _produtoRepositorio.BuscarPorId(id);
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
        {
            // Cadastrando o produto
            ProdutoModel produto = await _produtoRepositorio.Adicionar(produtoModel);

            // Criando um novo estoque para o produto
            EstoqueModel estoqueModel = new EstoqueModel
            {
                Quantidade = 0, 
                Status = StatusEstoque.Disponivel,
                Nome = produto.Nome,
                Tamanho = produto.Tamanho,
                ProdutoId = produto.Id,
                //Produto = produto 
            };

            // Adicionando o estoque ao repositório
            await _estoqueRepositorio.Adicionar(estoqueModel);

            return Ok(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProdutoModel>> Atualizar([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.Id = id;
            ProdutoModel produto = await _produtoRepositorio.Atualizar(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            bool apagado = await _produtoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
