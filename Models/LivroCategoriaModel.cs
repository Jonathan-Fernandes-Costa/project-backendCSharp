using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BibliotecaAPI.Models
{
    [Table("LivroCategorias")]
    public class LivroCategoriaModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; } = string.Empty;

        [Column("ativo")]
        public bool Ativo { get; set; }

        [Column("data_cadastro")]
        public string? DataCadastro { get; set; }

        [Column("usuario_cadastro")]
        public string? UsuarioCadastro { get; set; }

        [Column("data_edicao")]
        public int DataEdicao { get; set; }

        [Column("usuario_edicao")]
        public string? UsuarioEdicao { get; set; }

        [JsonIgnore]
        public ICollection<LivroModel> Livros { get; set; } = new List<LivroModel>(); 
    }
}
