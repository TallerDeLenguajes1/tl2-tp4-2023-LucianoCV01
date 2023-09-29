using EspacioCadete;
using EspacioCliente;
namespace EspacioPedido
{
    public class Pedido
    {
        // Atributos
        int numero;
        string? observacion;
        Cliente? cliente;
        Estado estado;
        Cadete? cadete;

        // Propiedades
        public int Numero { get => numero; set => numero = value; }
        public string? Observacion { get => observacion; set => observacion = value; }
        public Cliente? Cliente { get => cliente; }   
        internal Estado Estado { get => estado; set => estado = value; }
        public Cadete? Cadete { get => cadete; set => cadete = value; }

        // Constructores
        public Pedido(int numero, string observacion, Estado estado, Cadete? cadete , string nombre, string direccion, int telefono, string datosReferenciaDireccion)
        {
            this.numero = numero;
            this.observacion = observacion;
            cliente = new(nombre, direccion, telefono, datosReferenciaDireccion);
            this.estado = estado;
            this.Cadete = cadete;
        }
        public Pedido(){

        }

        // Metodos
        public string VerDireccionCliente(){
            if (cliente != null)
            {
                return cliente.Direccion + " - " + cliente.DatosReferenciaDireccion;
            } else
            {
                return "Error - Cliente es Null";
            }
        }
        public string VerDatosCliente(){
            if (cliente != null)
            {
                return cliente.Nombre + ", " + cliente.Telefono;
            } else
            {
                return "Error - Cliente es Null";
            }
        }
    }
    public enum Estado
    {
        Pendiente = 0,
        Entregado = 1,
        Cancelado = 2,
    }
}