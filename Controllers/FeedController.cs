// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using RoleSP.Data;
// using RoleSP.Models;
// using System.Linq;
// using System.Threading.Tasks;

// namespace RoleSP.Controllers
// {
//     public class FeedController : Controller
//     {
//         private readonly AppDbContext _context;

//         public FeedController(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<IActionResult> Index()
//         {
//             int? userIdLogado = HttpContext.Session.GetInt32("UsuarioId");

//             if (userIdLogado == null)
//             {
//                 return RedirectToAction("Index", "Login");
//             }

//             var usuario = await _context.Usuarios
//                 .FirstOrDefaultAsync(u => u.IdUsuario == userIdLogado.Value);

//             if (usuario == null)
//             {
//                 HttpContext.Session.Clear();
//                 return RedirectToAction("Index", "Login");
//             }

//             var Posts = await _context.Posts
//             .Include(p => p.ID_LocalNavigation)
//                   .ThenInclude(l => l.ID_EnderecoNavigation)
//             .Include(p => p.ID_LocalNavigation)
//                     .ThenInclude(l => l.ID_FiltroNavigation)
//             .Include(p => p.DataPostagem)
//             .Take(10)
//             .ToListAsync();

//             var filtros = await _context.Filtros.ToListAsync();

//             var FeedViwModel = new FeedViwModel
//             {
//                 UsuarioLogado = MapToUsuarioLogadoViewModel(usuario),

//                 FiltrosDisponiveis = filtros.Select(f => new FiltroViewModel
//                 {
//                     ID_Filtro = f.ID_Filtro,
//                     Nome = f.Nome,
//                     //! Caminho pode estar errado
//                     //! Caminho pode estar errado
//                     //! Caminho pode estar errado
//                     //! Caminho pode estar errado
//                     IconeUrl = $"~/assests/Feed/{f.Nome}.svg"
//                 }).ToList(),

//                 PostsDoFeed = Posts.Select(MapToPostCardViewModel)
//                                           .Where(vm => vm != null)
//                                           .ToList(),

//                 RecomedacoesMensais = Posts.Take(5).Select(MapToPostCardViewModel)
//                                           .Where(vm => vm != null)
//                                           .ToList()
//             };
//             return View(FeedViwModel);
//         }
        
//         private UsuarioLogadoViewModel MapToUsuarioLogadoViewModel(Usuario usuario)
//         {
//             byte[] fotoBytes = usuario.Foto ?? new byte[0];

//             string base64String = Convert.ToBase64String(fotoBytes);
//             string dataUri = $"data:image/png;base64,{base64String}";

//             return new UsuarioLogadoViewModel
//             {
//                 NomeDoUsuario = usuario.NomeUsuario,
//                 NomeCompleto = usuario.NomeCompleto,
//                 UrlFotoPerfil = dataUri
//             };
//         }

//         private PostCardViewModel MapToPostCardViewModel(Post post)
//         {
//             var Avaliacao = post.ID_AvaliacaoNavigation;
//             var local = post.ID_LocalNavigation;
//             var endereco = local?.ID_EnderecoNavigation;

//             if (Avaliacao == null || local == null || endereco == null)
//             {
//                 return null;
//             }

//             Byte[] postImageBytes = post.Url_Image ?? new byte[0];
//             string postImageBase64 = Convert.ToBase64String(postImageBytes);
//             string postImageDataUri = $"data:image/jpeg;base64,{postImageBase64}";

//             return new PostCardViewModel
//             {
//                 ID_Post = post.ID_Post,
//                 Url_Image = postImageDataUri,
//                 DataPostagem = post.DataPostagem,

//                 NomeLocal = local.Nome,
//                 TipoFiltro = local.ID_FiltroNavigation.Nome,

//                 Rua = endereco.Rua,
//                 Bairro = endereco.Bairro,
//                 Cidade = endereco.Cidade,
//                 EnderecoCompleto = $"{endereco.Rua}, {endereco.Bairro} - {endereco.Cidade}, {endereco.CEP}",

//                 NotaDoAutor = Avaliacao.Nota,
//                 ComentarioDoAutor = Avaliacao.Comentario
//             };
//         }
//      }
// }