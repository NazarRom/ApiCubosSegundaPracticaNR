using ApiCubosSegundaPracticaNR.Models;
using ApiCubosSegundaPracticaNR.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ApiCubosSegundaPracticaNR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubosController : ControllerBase
    {
        private RepositoryCubos repo;
        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        //metodo para todos los cubos
        [HttpGet]
        public async Task<ActionResult<List<Cubo>>> GetAllCubosAsync()
        {
            return await this.repo.GetCubosAsync(); ;
        }
        //metodo para cubos por marca
        [HttpGet("{marca}")]
        public async Task<ActionResult<List<Cubo>>> GetAllCubosByMarca(string marca)
        {
            return await this.repo.FindCubosByMarca(marca);
        }
        //metodo para insertar un nuevo user
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertUser(Usuario user)
        {
            await this.repo.InsertNewUserAsync(user.Nombre, user.Email, user.Pass, user.Imagen);
            return Ok();
        }

        //metodo para insertar un nuevo cubo
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> InsertCubo(Cubo cubo)
        {
            await this.repo.InsertNewCuboAsync(cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return Ok();
        }

        //metodo para ver los pedidos
        [HttpGet]
        [Authorize]
        [Route("[action]")]
        public async Task<ActionResult<List<CompraCubo>>> GetPedidosByUser()
        {
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");
            string jsonUsuario = claim.Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonUsuario);
            return await this.repo.GetCompraCubosAsync(usuario.Id_Usuario);
        }

        //metodo para el perfil del usuario
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult<Usuario>> PerfilUser()
        {
            //DEBEMOS BUSCAR EL CLAIM DEL Usuario
            Claim claim = HttpContext.User.Claims.SingleOrDefault(x => x.Type == "UserData");
            string jsonUsuario = claim.Value;
            Usuario usuario = JsonConvert.DeserializeObject<Usuario>(jsonUsuario);
            return usuario;
        }
        //metodo realizar un pedido del user
        [HttpPost]
        [Authorize]
        [Route("[action]")]
        public async Task<ActionResult> InsertPedido(CompraCubo compra)
        {
            await this.repo.InsertPedidoAsync(compra.Id_Cubo, compra.Id_Usario, compra.FechaPedidio);
            return Ok();
        }

    }
}
