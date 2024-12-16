using Microsoft.EntityFrameworkCore;
using WebApiCSharp.Data;
using WebApiCSharp.Models;

namespace WebApiCSharp.Repositorios.Interfaces
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly AppDbContext _dbContext;
        public ProdutoRepositorio(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produto.ToListAsync();
        }

        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContext.Produto.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id); 

            if(produtoPorId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }


            produtoPorId.Nome = produto.Nome;
            produtoPorId.Tamanho = produto.Tamanho;

            _dbContext.Produto.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);

            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Produto.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
       
    }
}
