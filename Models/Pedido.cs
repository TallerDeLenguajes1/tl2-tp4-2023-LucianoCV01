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
        int cadete;

        // Propiedades
        public int Numero { get => numero; set => numero = value;}
        public string Observacion { get => observacion; set => observacion = value; }
        public Estado Estado { get => estado; set => estado = value;}
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public int Cadete { get => cadete; set => cadete = value; }

        // Constructores
        public Pedido(int numPedido, string obsPedido, Estado estPedido, string nomCliente, string direcCliente, string telCliente, string datosRefCliente)
        {
            numero = numPedido;
            observacion = obsPedido;
            estado = estPedido;
            cliente = new(nomCliente, direcCliente, telCliente, datosRefCliente);
            this.cadete = -9999;
        }
        public Pedido(){
            
        }
        // Metodos
        public void AgregarCadete(int c)
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
        // public void AumentarNumero(int num){
        //     this.numero = num;
        // }
    }
    public enum Estado
    {
        Pendiente,
        Entregado,
        Cancelado
    }
}