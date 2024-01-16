using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace BibliotecaAPI.Models
{
    [Table("Livros")]
    public class LivroModel
    {
        //Titulo, subtitulo, categoria, editora, autor, sinopse, ano edição, qtdReservas
        [Column("id")]
        public int id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; } = string.Empty;

        [Column("subtitulo")]
        public string Subtitulo { get; set; } = string.Empty;

        [Column("editora")]
        public string Editora { get; set; } = string.Empty;

        [Column("autor")]
        public string Autor { get; set; } = string.Empty;

        [Column("ano_edicao")]
        public int AnoEdicao { get; set; }
        [Column("sinopse")]
        public string Sinopse {  get; set; } = string.Empty;

        [Column("qtd_reservas")]
        public int QtdReservas { get; set; }

        [Column("codigo")]
        public int Codigo { get; set; }

        [Column("id_livro_categoria")]
        public  int LivroCategoriaId { get; set; }
        public LivroCategoriaModel? LivroCategoria { get; set; }

        [Column("usuario_cadastro")]
        public string UsuarioCadastro { get; set; } = string.Empty;

        [Column("data_cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("usuario_edicao")]
        public string UsuarioEdicao {  get; set; } = string.Empty;

        [Column("data_edicao")]
        public DateTime DataEdicao { get; set; }

        [Column("foto_path")]
        public string? FotoPath { get; set; }

        [NotMapped]
        [JsonIgnore]
        public IFormFile? Foto { get; set; }
    }
}
