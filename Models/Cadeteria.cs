using EspacioCadete;
using EspacioPedido;
namespace EspacioCadeteria
{
    public class Cadeteria
    {
        private static Cadeteria cadeteria;
        public static Cadeteria GetCadeteria()
        {
            if (cadeteria == null)
            {
            cadeteria = new Cadeteria();
            }
            return cadeteria;
        }
        // Atributos
        string nombre;
        string telefono;
        List<Pedido>? pedidos;
        List<Cadete>? cadetes;

        private static Cadeteria? instance;

        // public static Cadeteria GetInstance(){
        //     if(instance == null){
        //         instance = new Cadeteria();
        //         Random random
        //     }
        // }

        // Propiedades
        // public string? Nombre { get => nombre; }
        // public string Telefono { get => telefono; }
        // internal List<Cadete>? Cadetes { get => cadetes; set => cadetes = value; }
        // public List<Pedido>? Pedidos { get => pedidos; set => pedidos = value; }

        // Constructores
        public Cadeteria(string? nombre, string telefono, List<Cadete>? cadetes)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.cadetes = cadetes;
        }

        public Cadeteria()
        {
            pedidos = new List<Pedido>();
            cadetes = new List<Cadete>();
            nombre = "Cadeteria la prueba";
            pedidos.Add(new Pedido
            {
                Numero = 1,
                Observacion = " Es el primer pedido"
            });
            pedidos.Add(new Pedido
            {
                Numero = 2,
                Observacion = " Es el segundo pedido"
            });
            pedidos.Add(new Pedido
            {
                Numero = 3,
                Observacion = " Es el tercer pedido"
            });

            cadetes.Add(new Cadete
            {
                Id = 1,
                Nombre = "cadete 1",
            });
            cadetes.Add(new Cadete
            {
                Id = 2,
                Nombre = "cadete 2",
            });
        }

        // // Metodos
        private Pedido BuscarPedido(int idPedido){
            Pedido buscado = pedidos.FirstOrDefault(p => p.Numero == idPedido);
            return buscado;
        }
        private Cadete BuscarCadete(int idCadete){
            Cadete buscado = cadetes.FirstOrDefault(c => c.Id == idCadete);
            return buscado;
        }
        public Pedido AsignarCadeteAPedido(int idCadete, int idPedido){
            Pedido buscado = BuscarPedido(idPedido);
            buscado.AgregarCadete(BuscarCadete(idCadete));
            return buscado; 
        }
        public Pedido DarAltaPedido(int numPed, string obsPed, Estado estPed, string nomCli, string direcCli, string telCli, string datosRefCli, Cadete cadete){
            Pedido pedidoNuevo = new(numPed,obsPed, estPed, nomCli, direcCli, telCli, datosRefCli);
            pedidoNuevo.AgregarCadete(cadete);
            return pedidoNuevo;
        }
        private Pedido CambiarEstadoDePedido(int numPed, Estado nuevoEst){
            Pedido buscado = BuscarPedido(numPed);
            buscado.CambiarEstado(nuevoEst);
            return buscado;
        }
        public Pedido ReasignarPedido(int numPedido, int idCadeteNuevo){
            Pedido buscado = BuscarPedido(numPedido);
            buscado.AgregarCadete(BuscarCadete(idCadeteNuevo));
            return buscado;
        }
        public int EnviosEntregadosPorCadete(int idCadete){
            var pedidosEntregados = pedidos.Where(p => p.Estado == Estado.Entregado && p.Cadete.Id == idCadete);
            int cantEntregas = pedidosEntregados.Count();
            return cantEntregas;
        }
        public float JornalACobrar(int idCadete){
            float monto = EnviosEntregadosPorCadete(idCadete) * 500;
            return monto;
        }


        public List<Pedido> DevolverPedidos(){
            return pedidos;
        }
        public List<Cadete> DevolverCadetes(){
            return cadetes;
        }
        public Pedido AgregarPedido(Pedido pedido){
            pedidos.Add(pedido);
            pedido.Numero = pedidos.Count;
            return pedido;
        }

    }
}