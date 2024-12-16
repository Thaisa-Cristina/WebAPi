using System.Text.Json.Serialization;
using WebApiCSharp.Enums;

namespace WebApiCSharp.Models
{
    public class EstoqueModel
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public string? Nome { get; set; }
        public string? Tamanho { get; set; }
        public StatusEstoque Status { get; set; }

        public int? ProdutoId { get; set; }

        [JsonIgnore]
        public virtual ProdutoModel? Produto { get; set; }
    }
}


