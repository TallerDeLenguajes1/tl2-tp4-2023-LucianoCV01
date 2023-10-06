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
                cadeteria = accesoADatos.LeerArchivoCadeteria("../Cadeteria.json", "../Cadetes.json");
            }
            return cadeteria;
        }

        // Propiedades


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
            buscado.AgregarCadete(BuscarCadete(idCadete));
            return buscado;
        }
        public Pedido DarAltaPedido(int numPed, string obsPed, Estado estPed, string nomCli, string direcCli, string telCli, string datosRefCli, Cadete cadete)
        {
            Pedido pedidoNuevo = new(numPed, obsPed, estPed, nomCli, direcCli, telCli, datosRefCli);
            pedidoNuevo.AgregarCadete(cadete);
            return pedidoNuevo;
        }
        public Pedido CambiarEstadoDePedido(int numPed, Estado nuevoEst)
        {
            Pedido buscado = BuscarPedido(numPed);
            buscado.CambiarEstado(nuevoEst);
            return buscado;
        }
        public Pedido ReasignarPedido(int numPedido, int idCadeteNuevo)
        {
            Pedido buscado = BuscarPedido(numPedido);
            buscado.AgregarCadete(BuscarCadete(idCadeteNuevo));
            return buscado;
        }
        public int EnviosEntregadosPorCadete(int idCadete)
        {
            var pedidosEntregados = pedidos.Where(p => p.Estado == Estado.Entregado && p.Cadete.Id == idCadete);
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
            pedidos.Add(pedido);
            pedido.AumentarNumero(pedidos.Count());
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