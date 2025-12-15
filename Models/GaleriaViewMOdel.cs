using RoleSP.Models;

namespace RoleSP.Models
{
    public class galeriaViewModel
    {
        public string nomeLocal {get;set;}
        public string avaliacaoPost {get;set;}
        public string Endereco {get;set;}
        public int IdPosts {get;set;}
        public string FotoUsuarioBase64 {get;set;}
        public string FotoPostBase64 {get;set;}
        public string nomeUser {get;set;}
        public int visitados {get;set;}
        public int favoritos {get;set;}
        public int destino {get;set;}
    }
}