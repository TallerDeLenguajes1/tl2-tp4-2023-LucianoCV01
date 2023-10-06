using System.Text.Json;
using EspacioCadeteria;
namespace EspacioAccesoADatos
{
    public class AccesoADatosCadeteria
    {
        public Cadeteria Obtener()
        {
            string nombreArchivo = "/Users/lucianocosentino/Documents/Repositorios/TallerII/tl2-tp4-2023-LucianoCV01/Cadeteria.json";
            string jsonDocumento;
            using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
            {
                using (var strReader = new StreamReader(archivoOpen))
                {
                    jsonDocumento = strReader.ReadToEnd();
                    archivoOpen.Close();
                }
            }
            var cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonDocumento);
            return cadeteria;
        }
    }
}