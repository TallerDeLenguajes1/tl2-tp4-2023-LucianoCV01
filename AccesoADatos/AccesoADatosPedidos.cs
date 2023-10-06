using System.Text.Json;
using EspacioPedido;
namespace EspacioAccesoADatos
{
    public class AccesoADatosPedidos
    {
        public List<Pedido> Obtener()
        {
            string nombreArchivo = "/Users/lucianocosentino/Documents/Repositorios/TallerII/tl2-tp4-2023-LucianoCV01/Pedidos.json";
            string jsonDocumento;
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    jsonDocumento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            var listadoPedidos = JsonSerializer.Deserialize<List<Pedido>>(jsonDocumento);
            return listadoPedidos;
        }
        public void Guardar(List<Pedido> Pedidos)
        {
            string pedidosJson = JsonSerializer.Serialize(Pedidos);
            string nombreArchivo = "/Users/lucianocosentino/Documents/Repositorios/TallerII/tl2-tp4-2023-LucianoCV01/Pedidos.json";
            File.WriteAllText(nombreArchivo, pedidosJson);
        }
    }
}
