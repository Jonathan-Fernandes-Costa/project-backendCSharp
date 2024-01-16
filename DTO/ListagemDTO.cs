namespace BibliotecaAPI.DTO
{
    public class ListagemDTO
    {
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string Pesquisa { get; set; } = string.Empty;
        public int? LivroCategoriaId { get; set; }
    }
}
