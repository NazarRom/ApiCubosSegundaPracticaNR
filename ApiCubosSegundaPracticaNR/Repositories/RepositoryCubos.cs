using ApiCubosSegundaPracticaNR.Data;
using ApiCubosSegundaPracticaNR.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCubosSegundaPracticaNR.Repositories
{
    public class RepositoryCubos
    {
        private CubosContext context;
        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }
        /* //////////////////////////////   SIN TOKREN  /////////////////////////////// */

        //metodo get todos los cubos
        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }
        //metodo buscar todos los cubos por marca
        public async Task<List<Cubo>> FindCubosByMarca(string marca)
        {
            return await this.context.Cubos.Where(x => x.Marca == marca).ToListAsync();
        }

        //metodo para insertar un nuevo usuario
        public async Task InsertNewUserAsync(string nombre, string email, string pass, string imagen)
        {
            Usuario usuario = new Usuario();
            usuario.Id_Usuario = this.GetMaxIdUser();
            usuario.Nombre = nombre;
            usuario.Email = email;
            usuario.Pass = pass;
            usuario.Imagen = imagen;
            await this.context.Usuarios.AddAsync(usuario);
            await this.context.SaveChangesAsync();
        }

        //metodo para insertar un nuevo cubo
        public async Task InsertNewCuboAsync(string nombre, string marca, string imagen, int precio)
        {
            Cubo cubo = new Cubo();
            cubo.Id_Cubo = this.GetMaxIdCubo();
            cubo.Nombre = nombre;
            cubo.Marca = marca;
            cubo.Imagen = imagen;
            cubo.Precio = precio;
            await this.context.Cubos.AddAsync(cubo);
            await this.context.SaveChangesAsync();
        }
        //max id user
        private int GetMaxIdUser()
        {
            return this.context.Usuarios.Max(x => x.Id_Usuario) + 1;
        }
        //max id pedidios
        private int GetMaxIdPedido()
        {
            return this.context.CompraCubos.Max(x => x.Id_Pedido) + 1;
        }
        //max id cubo
        private int GetMaxIdCubo()
        {
            return this.context.Cubos.Max(x => x.Id_Cubo) + 1;
        }

        //para comprobar al user
        public async Task<Usuario> ExisteUsuarioAsync(string email, string pass)
        {
            return await this.context.Usuarios.FirstOrDefaultAsync(x => x.Email == email && x.Pass == pass);
        }

        /* //////////////////////////////   CON TOKREN  /////////////////////////////// */

        //metodo pedidos usuario
        public async Task<List<CompraCubo>> GetCompraCubosAsync(int iduser)
        {
            return await this.context.CompraCubos.Where(x => x.Id_Usario == iduser).ToListAsync();
        }

        //metodo realizar un pedido del user
        public async Task InsertPedidoAsync(int idcub, int iduser, DateTime fecha)
        {
            CompraCubo compra = new CompraCubo();
            compra.Id_Pedido = this.GetMaxIdPedido();
            compra.Id_Cubo = idcub;
            compra.Id_Usario = iduser;
            compra.FechaPedidio = fecha;
            await this.context.CompraCubos.AddAsync(compra);
            await this.context.SaveChangesAsync();
        }
        

    }
}
