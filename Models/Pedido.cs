using EspacioCadete;
using EspacioCliente;
namespace EspacioPedido
{
    public class Pedido
    {
        // Atributos
        int numero;
        string observacion;
        Estado estado;
        Cliente cliente;
        Cadete? cadete;

        // Propiedades

        // Constructores
        public Pedido(int numPedido, string obsPedido, Estado estPedido, string nomCliente, string direcCliente, string telCliente, string datosRefCliente)
        {
            numero = numPedido;
            observacion = obsPedido;
            estado = estPedido;
            cliente = new(nomCliente, direcCliente, telCliente, datosRefCliente);
            this.cadete = null;
        }

        // Metodos
        public void AgregarCadete(Cadete c)
        {
            this.cadete = c;
        }
        public void CambiarEstado(Estado estado)
        {
            this.estado = estado;
        }
        public string VerDireccionCliente()
        {
            return cliente.Direccion + " - " + cliente.DatosReferenciaDireccion;
        }
        public string VerDatosCliente()
        {
            return cliente.Nombre + ", " + cliente.Telefono;
        }
    }
    public enum Estado
    {
        Pendiente,
        Entregado,
        Cancelado
    }
}