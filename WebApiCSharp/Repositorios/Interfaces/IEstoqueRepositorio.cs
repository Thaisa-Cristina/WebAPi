using WebApiCSharp.Models;

namespace WebApiCSharp.Repositorios.Interfaces
{
    public interface IEstoqueRepositorio
    {
        Task<List<EstoqueModel>> BuscarTodosProdutosEstoque();
        Task<EstoqueModel> BuscarPorId(int id);
        Task<EstoqueModel> Adicionar(EstoqueModel estoque);
        Task<EstoqueModel> Atualizar(EstoqueModel estoque, int id);
        Task<bool> Apagar(int id);

    }
}
