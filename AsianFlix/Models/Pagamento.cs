using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsianFlix.Models
{
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        [Display(Name = "Data de Pagamento")]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Valor do Pagamento")]
        public decimal ValorPagamento { get; set; }

        [Display(Name = "Forma de Pagamento")]
        public string? FormaPagamento { get; set; }

        [Display(Name = "Status do Pagamento")]
        public string? StatusPagamento { get; set; }

    }
}
