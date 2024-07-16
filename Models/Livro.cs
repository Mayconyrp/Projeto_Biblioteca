namespace ProjetoBiblioteca.Models
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string? ImagemUrl { get; set; }
        public string? Nome { get; set; }
        public string? DataLancamento { get; set; }
        public decimal Preco {  get; set; }
        public int Estoque { get; set; }
        public string? Autor { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }

    }
}
