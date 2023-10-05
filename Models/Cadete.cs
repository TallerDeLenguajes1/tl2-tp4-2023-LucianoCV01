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
        public int Id { get => id;}

        // Constructores
        public Cadete(int id, string nombre, string direccion, string telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        //Metodos

    }
}