using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace BibliotecaAPI.Models
{
    public class LivroModel
    {
        //Titulo, subtitulo, categoria, editora, autor, sinopse, ano edição, qtdReservas
        public int id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Subtitulo { get; set; } = string.Empty;
        public string Editora { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public int AnoEdicao { get; set; }
        public int QtdReservas { get; set; }
        public int Codigo { get; set; }
        public  int livroCategoriaId { get; set; }
        public  LivroCategoriaModel? livroCategoria { get; set; }
        public string? FotoPath { get; set; }
        [NotMapped]
        [JsonIgnore]
        public IFormFile? Foto { get; set; }
    }
}
