namespace RoleSP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using RoleSP.Data;
    using RoleSP.Models;
    using System.Linq;

    public class GaleriaController : Controller
    {
        private readonly AppDbContext _context;

        public GaleriaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == usuarioId);

            var todasAsPostagens = _context.Posts.Where(p => p.IdUsuario == usuarioId)
            .Include(p => p.IdLocaisNavigation)
            .ThenInclude(p => p.IdEnderecoNavigation)
            .Include(p => p.IdUsuarioNavigation)
            .ToList();


            GaleriaViewModel viewModel = new GaleriaViewModel
            {
                UsuarioLogado = usuario,
                Posts = todasAsPostagens,
                Nome = usuario.NomeUsuario ?? "Usuário",
                Foto = usuario.Foto != null
                    ? Convert.ToBase64String(usuario.Foto)
                    : null,
                TotalVisitados = 0,
                TotalFavoritos = 0,
                TotalDestinos = 0
            };
            return View(viewModel);
        }


       [HttpPost]
public IActionResult Postar(int select, string nomeLocal, int cep, string bairro, string rua, string cidade, string comentario, IFormFile imgLocal)
{
    int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

    if (usuarioId == null)
    {
        return RedirectToAction("Index", "Login");
    }

    var usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == usuarioId);
    var locais = _context.Locais.FirstOrDefault(l => l.NomeLocal.ToLower() == nomeLocal.ToLower());
    

    if (select == 0 || string.IsNullOrWhiteSpace(nomeLocal)
        || cep == 0 || string.IsNullOrWhiteSpace(bairro) || string.IsNullOrWhiteSpace(rua)
        || string.IsNullOrWhiteSpace(cidade) || string.IsNullOrWhiteSpace(comentario) || imgLocal == null)
    {
        return Json(new { sucesso = false, mensagem = "Preencha todos os campos" });
    }

    if (locais == null)
    {
        var novoEndereco = new Endereco
        {
            Rua = rua,
            Bairro = bairro,
            Cidade = cidade,
            Cep = cep
        };

        _context.Enderecos.Add(novoEndereco);
        _context.SaveChanges();

        int enderecoId = novoEndereco.IdEndereco;

        var novoLocal = new Locai
        {
            NomeLocal = nomeLocal,
            IdEndereco = enderecoId,
            IdFiltro = select
        };

        _context.Locais.Add(novoLocal);
        _context.SaveChanges();

        locais = novoLocal;
    }

    byte[] imagemBytes = null;
    if (imgLocal != null && imgLocal.Length > 0)
    {
        using (var memoryStream = new MemoryStream())
        {
            imgLocal.CopyTo(memoryStream);
            imagemBytes = memoryStream.ToArray();
        }
    }

    // 3. Criação do Post
    var novoPost = new Post
    {
        IdUsuario = usuario.IdUsuario,
        IdLocais = locais.IdLocais,
        Imagem = imagemBytes,
        
        Avaliacao = comentario 
    };

    _context.Posts.Add(novoPost);
    _context.SaveChanges();


    return Json(new { sucesso = true, mensagem = "Postagem realizada com sucesso!" });
}

        [HttpPost]
        public IActionResult Excluir (int id)
        {
            var postId = _context.Posts.FirstOrDefault(e => e.IdPost == id);

            if(postId == null)
            {
                return NotFound();
            }

            _context.Posts.Remove(postId);
            _context.SaveChanges();

            return Json(new { sucesso = true, mensagem = "Postagem apagada com sucesso" });
        }

        // [HttpGet]
        // public IActionResult Editar(int id)
        // {
        //     int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

        //     if(usuarioId == null)
        //     {
        //         return Json(new { sucesso = false, mensagem = "Usuario não encontrado" });
        //     }
        
        //     var postUsuario = _context.Posts.FirstOrDefault(p => p.IdPost == id);
            
        //     if(postUsuario == null)
        //     {
                
        //     }

        // }
    }
}