namespace EspacioCliente
{
    public class Cliente
    {
        // Atributos
        string? nombre;
        string? direccion;
        int telefono;
        string? datosReferenciaDireccion;

        //Propiedades
        public string? Nombre { get => nombre;  }
        public string? Direccion { get => direccion; }
        public int Telefono { get => telefono;  }
        public string? DatosReferenciaDireccion { get => datosReferenciaDireccion;  }
        
        // Constructores
        public Cliente(string nombre, string direccion, int telefono, string datosReferenciaDireccion)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.datosReferenciaDireccion = datosReferenciaDireccion;
        }
    }
}