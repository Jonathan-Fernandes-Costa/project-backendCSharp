using BibliotecaAPI.Models;

namespace BibliotecaAPI.DTO
{
    public class ResultListagemDTO
    {
        public List<LivroModel> Dados { get; set; } = new List<LivroModel>();
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRegister { get; set; }
    }
}
