namespace BibliotecaAPI.Models
{
    public class LivroCategoriaModel
    {
        public required string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int Id { get; set; }
        public string? DataCadastro { get; set; }
        public string? UsuarioCadastro { get; set; }
        public int DataEdicao { get; set; }
        public string? UsuarioEdicao { get; set; }





    }
}
