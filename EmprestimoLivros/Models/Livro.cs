using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.Models
{
    [Table("livros", Schema = "public")]
    public class Livro
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("autor")]
        public string? Autor { get; set; }

        [Column("status")]
        public string? Status { get; set; }
    }
}