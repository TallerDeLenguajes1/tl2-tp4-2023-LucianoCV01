using EspacioAccesoADatos;
using EspacioCadete;
using EspacioPedido;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        // Atributos
        string? nombre;
        string? telefono;
        List<Pedido>? pedidos;
        List<Cadete>? cadetes;
        // Constructores
        public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.cadetes = cadetes;
            pedidos = new();
        }
        private Cadeteria()
        {

        }
        // Singleton
        private static Cadeteria cadeteria;


        public static Cadeteria GetCadeteria()
        {
            if (cadeteria == null)
            {
                AccesoJSON accesoADatos = new();
                cadeteria = accesoADatos.LeerArchivoCadeteria("/Users/lucianocosentino/Documents/Repositorios/TallerII/tl2-tp4-2023-LucianoCV01/Cadeteria.json", "/Users/lucianocosentino/Documents/Repositorios/TallerII/tl2-tp4-2023-LucianoCV01/Cadetes.json");
            }
            return cadeteria;
        }

        // Propiedades
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Telefono { get => telefono; set => telefono = value; }
        public List<Pedido>? Pedidos { get => pedidos; set => pedidos = value; }
        public List<Cadete>? Cadetes { get => cadetes; set => cadetes = value; }


        // // Metodos
        public Pedido BuscarPedido(int idPedido)
        {
            Pedido buscado = pedidos.FirstOrDefault(p => p.Numero == idPedido);
            return buscado;
        }
        public Cadete BuscarCadete(int idCadete)
        {
            Cadete buscado = cadetes.FirstOrDefault(c => c.Id == idCadete);
            return buscado;
        }
        public Pedido AsignarCadeteAPedido(int idCadete, int idPedido)
        {
            Pedido buscado = BuscarPedido(idPedido);
            buscado.Cadete = idCadete;
            return buscado;
        }
        // public Pedido DarAltaPedido(int numPed, string obsPed, Estado estPed, string nomCli, string direcCli, string telCli, string datosRefCli, Cadete cadete)
        // {
        //     Pedido pedidoNuevo = new(numPed, obsPed, estPed, nomCli, direcCli, telCli, datosRefCli);
        //     pedidoNuevo.AgregarCadete(cadete);
        //     return pedidoNuevo;
        // }
        public Pedido CambiarEstadoDePedido(int numPed, Estado nuevoEst)
        {
            Pedido buscado = BuscarPedido(numPed);
            buscado.CambiarEstado(nuevoEst);
            return buscado;
        }
        public Pedido ReasignarPedido(int numPedido, int idCadeteNuevo)
        {
            Pedido buscado = BuscarPedido(numPedido);
            buscado.Cadete = idCadeteNuevo;
            return buscado;
        }
        public int EnviosEntregadosPorCadete(int idCadete)
        {
            var pedidosEntregados = pedidos.Where(p => p.Estado == Estado.Entregado && p.Cadete == idCadete);
            int cantEntregas = pedidosEntregados.Count();
            return cantEntregas;
        }
        public float JornalACobrar(int idCadete)
        {
            float monto = EnviosEntregadosPorCadete(idCadete) * 500;
            return monto;
        }
        public List<Pedido> DevolverPedidos()
        {
            return pedidos;
        }
        public List<Cadete> DevolverCadetes()
        {
            return cadetes;
        }
        public Pedido AgregarPedido(Pedido pedido)
        {
            pedido.Numero = pedidos.Count();
            pedidos.Add(pedido);
            return pedido;
        }
        public Cadete AgregarCadete(Cadete cadete)
        {
            cadetes.Add(cadete);
            cadete.AumentarNumero(cadetes.Count());
            return cadete;
        }
        public void AgregarCadetes(List<Cadete> cadetes){
            this.cadetes = cadetes;
        }
    }
}