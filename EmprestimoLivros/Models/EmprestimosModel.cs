namespace EmprestimoLivros.Models
{
    public class EmprestimosModel

    {  public int Id { get; set; } 
        public string Recebedor { get; set;}    

        public string fornecedor { get; set;}

       
        public string LivroEmprestado {  get; set;}

        public DateTime  dataUltimaAtualizaçao { get; set;} = DateTime.Now;
         

    }

}
