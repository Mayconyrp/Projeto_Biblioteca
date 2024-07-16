using System.Collections.ObjectModel;

namespace ProjetoBiblioteca.Models
{
    public class Categoria
    {
        public Categoria() {

            Livros = new Collection<Livro>();
        }

        public int CategoriaId { get; set; }
        public string? UrlImagem { get; set; }
        public string? Nome { get; set; }

        public ICollection<Livro> Livros { get; set; }

    }
}
