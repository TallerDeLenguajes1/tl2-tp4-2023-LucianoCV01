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
        public const int pagoPorPedido = 500;
        public const int error = -9999;
        // Atributos
        string? nombre;
        string telefono;
        List<Cadete>? cadetes;
        List<Pedido>? pedidos;

        // Propiedades
        public string? Nombre { get => nombre; }
        public string Telefono { get => telefono; }
        internal List<Cadete>? Cadetes { get => cadetes; set => cadetes = value; }
        public List<Pedido>? Pedidos { get => pedidos; set => pedidos = value; }

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
        public Pedido DarAltaPedido(int numero, string observacion, Estado estado, Cadete? cadete , string nombre, string direccion, int telefono, string datosReferenciaDireccion){
            Pedido pedidoNuevo = new(numero,observacion, estado, cadete, nombre, direccion, telefono, datosReferenciaDireccion);
            return pedidoNuevo;
        }
        public int EnviosEntregadosPorCadete(int idCadete){
            int cantidadEnvios = error;
            if (pedidos != null)
            {
                var pedidosEntregados = pedidos.Where(p => p.Estado == Estado.Entregado);
                var pedidosCadete = pedidosEntregados.Where(p => p.Cadete.Id == idCadete);
                cantidadEnvios = pedidosCadete.Count();
            }
            return cantidadEnvios;
        }
        public float JornalACobrar(int idCadete){
            float monto = error;
            if (Cadetes != null)
            {
                monto =  pagoPorPedido * EnviosEntregadosPorCadete(idCadete);
            }
            return monto;
        }
        public Pedido AsignarCadeteAPedido(int idCadete, int idPedido){
            Cadete? encontrado = Cadetes.FirstOrDefault(c => c.Id == idCadete);
            Pedido? buscado = Pedidos.FirstOrDefault(p => p.Numero == idPedido);
            buscado.Cadete = encontrado;
            return buscado;
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

        public Pedido CambiarEstadoDePedido(int numPedido, Estado estadoNuevo){
            Pedido? encontrado = null;
            if (Pedidos != null)
            {
                encontrado = Pedidos.FirstOrDefault(p => p.Numero == numPedido);
                if (encontrado != null)
                {                    
                    encontrado.Estado = estadoNuevo; 
                }            
            }
            return encontrado;
        }
        public Pedido ReasignarPedido(int numPedido, int idCadeteNuevo){
            Pedido? pedidoEncontrado = null;
            if (Cadetes != null)
            {
                pedidoEncontrado = Pedidos.FirstOrDefault(p => p.Numero == numPedido);
                Cadete? encontradoNuevo = Cadetes.FirstOrDefault(c => c.Id == idCadeteNuevo);
                pedidoEncontrado.Cadete = encontradoNuevo;
            }
            return pedidoEncontrado;
        }
    }
}