using Microsoft.EntityFrameworkCore;
using WebApiCSharp.Data;
using WebApiCSharp.Models;

namespace WebApiCSharp.Repositorios.Interfaces
{
    public class EstoqueRepositorio : IEstoqueRepositorio
    {
        private readonly AppDbContext _dbContext;
        public EstoqueRepositorio(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<EstoqueModel> BuscarPorId(int id)
        {
            return await _dbContext.Estoque.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EstoqueModel>> BuscarTodosProdutosEstoque()
        {
            return await _dbContext.Estoque.ToListAsync();
        }

        public async Task<EstoqueModel> Adicionar(EstoqueModel estoque)
        {
            await _dbContext.Estoque.AddAsync(estoque);
            await _dbContext.SaveChangesAsync();

            return estoque;
        }

        public async Task<EstoqueModel> Atualizar(EstoqueModel estoque, int id)
        {
            EstoqueModel estoquePorId = await BuscarPorId(id);

            if (estoquePorId == null)
            {
                throw new Exception($"Produto do Estoque para o ID: {id} não foi encontrado no banco de dados.");
            }


            estoquePorId.Quantidade = estoque.Quantidade;
            estoquePorId.Status = estoque.Status;
            estoquePorId.ProdutoId = estoque.ProdutoId;

            _dbContext.Estoque.Update(estoquePorId);
            await _dbContext.SaveChangesAsync();

            return estoquePorId;
        }

        public async Task<bool> Apagar(int id)
        {
            EstoqueModel estoquePorId = await BuscarPorId(id);

            if (estoquePorId == null)
            {
                throw new Exception($"Produto do Estoque para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Estoque.Remove(estoquePorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
