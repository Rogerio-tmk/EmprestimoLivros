using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmprestimoLivros.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Genero { get; set; } = "";
        public DateTime DataCompra { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Em andamento";

        [NotMapped]
        public string Titulo
        {
            get => Nome;
            set => Nome = value ?? "";
        }

        [NotMapped]
        public string Autor
        {
            get => Genero;
            set => Genero = value ?? "";
        }
    }
}