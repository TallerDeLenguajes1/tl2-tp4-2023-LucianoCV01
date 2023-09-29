using EspacioPedido;
namespace EspacioCadete
{
    public class Cadete
    {
        // Atributos
        int id;
        string? nombre;
        string? direccion;
        string? telefono;

        // Propiedades
        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value;}
        public string? Direccion { get => direccion; }
        public string? Telefono { get => telefono; }

        // Constructores
        public Cadete(int id, string? nombre, string? direccion, string? telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public Cadete(){

        }

        //Metodos


        // public void AgregarPedido(Pedido p){
        //     Pedidos?.Add(p);
        // }
    }
}