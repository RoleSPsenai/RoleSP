namespace RoleSP.Models
{
    public class GaleriaViewModel
    {
        public Usuario UsuarioLogado { get; set; }
        // Usuario
        public int IdUsuario { get; set; }
        public string Nome { get; set; } = null!;
        public string Foto { get; set; }
        public string Apelido { get; set; } = null!;

        // Post
        public byte[] Imagem { get; set; } = null!;
        public string NomeLocal { get; set; } = null!;
        public int IdPost { get; set; }

        // Avaliação
        public int IdAvaliacao { get; set; }
        public string TextoAvaliacao { get; set; } = null!;

        // Contadores
        public int TotalVisitados { get; set; }
        public int TotalFavoritos { get; set; }
        public int TotalDestinos { get; set; }

        // Endereço
        public List<Endereco> Enderecos { get; set; } = new();
        public List<Post> Posts { get; set; } 
    
    }
}