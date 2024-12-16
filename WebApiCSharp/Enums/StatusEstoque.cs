using System.ComponentModel;

namespace WebApiCSharp.Enums
{
    public enum StatusEstoque
    {
        [Description("Disponível")]
        Disponivel = 1,
        [Description("Reservado")]
        Reservado = 2,
        [Description("Em Falta")]
        EmFalta = 3

    }
}
