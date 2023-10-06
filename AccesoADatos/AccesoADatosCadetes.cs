using System.Text.Json;
using EspacioCadete;
namespace EspacioAccesoADatos
{
    public class AccesoADatosCadetes
    {
        public List<Cadete> Obtener()
        {
            string nombreArchivo = "/Users/lucianocosentino/Documents/Repositorios/TallerII/tl2-tp4-2023-LucianoCV01/Cadetes.json";
            string jsonDocumento;
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    jsonDocumento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            var listadoCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonDocumento);
            return listadoCadetes;
        }
    }
}