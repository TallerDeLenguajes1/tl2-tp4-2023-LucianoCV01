namespace EspacioCadete
{
    public class Cadete
    {
        // Atributos
        int id;
        string nombre;
        string direccion;
        string telefono;

        // Propiedades
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }


        // Constructores
        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        //Metodos
        public void AumentarNumero(int num){
            this.id = num;
        }
    }
}