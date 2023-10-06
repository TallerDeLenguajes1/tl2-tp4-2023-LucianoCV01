// using System.Text.Json;
// using EspacioCadeteria;
// using EspacioCadete;
// namespace EspacioAccesoADatos
// {
//     public abstract class AccesoADatos
//     {
//         public abstract List<Cadete> LeerArchivoCadetes(string nombreArchivo);
//         public abstract Cadeteria LeerArchivoCadeteria(string nombreArchivoCadeteria, string nombreArchivoCadetes);
//     }
//     public class AccesoCSV : AccesoADatos
//     {
//         private List<string[]> LeerCsv(string nombreDeArchivo)
//         {
//             FileStream MiArchivo = new FileStream(nombreDeArchivo, FileMode.Open);
//             StreamReader StrReader = new StreamReader(MiArchivo);

//             string? Linea = "";
//             List<string[]> LecturaDelArchivo = new List<string[]>();

//             while ((Linea = StrReader.ReadLine()) != null)
//             {
//                 string[] Fila = Linea.Split(',');
//                 LecturaDelArchivo.Add(Fila);
//             }

//             return LecturaDelArchivo;
//         }
//         public override List<Cadete> LeerArchivoCadetes(string nombreArchivo)
//         {
//             List<Cadete> MisCadetes = new List<Cadete>();
//             var Filas = LeerCsv(nombreArchivo);
//             foreach (string[] filas in Filas)
//             {
//                 Cadete cad = new Cadete(int.Parse(filas[0]), filas[1], filas[2], filas[3]);
//                 MisCadetes.Add(cad);
//             }
//             return MisCadetes;
//         }
//         public override Cadeteria LeerArchivoCadeteria(string nombreArchivoCadeteria, string nombreArchivoCadetes)
//         {
//             Cadeteria? MiCadeteria = null;
//             var Filas = LeerCsv(nombreArchivoCadeteria);
//             foreach (string[] filas in Filas)
//             {
//                 MiCadeteria = new Cadeteria(filas[0], filas[1], LeerArchivoCadetes(nombreArchivoCadetes));
//             }
//             if (MiCadeteria != null)
//             {
//                 return MiCadeteria;
//             }
//             else
//             {
//                 return MiCadeteria = new("", "0", null);
//             }
//         }
//     }
//     public class AccesoJSON : AccesoADatos
//     {
//         private string AbrirArchivoTexto(string nombreArchivo)
//         {
//             string documento;
//             using (var archivoOpen = new FileStream(nombreArchivo, FileMode.Open))
//             {
//                 using (var strReader = new StreamReader(archivoOpen))
//                 {
//                     documento = strReader.ReadToEnd();
//                     archivoOpen.Close();
//                 }
//             }
//             return documento;
//         }
//         public override List<Cadete> LeerArchivoCadetes(string nombreArchivo)
//         {
//             string jsonDocumento = AbrirArchivoTexto(nombreArchivo);
//             var listadoCadetes = JsonSerializer.Deserialize<List<Cadete>>(jsonDocumento);
//             return listadoCadetes;
//         }
//         public override Cadeteria LeerArchivoCadeteria(string nombreArchivoCadeteria, string nombreArchivoCadetes)
//         {
//             string jsonDocumento = AbrirArchivoTexto(nombreArchivoCadeteria);
//             var cadeteria = JsonSerializer.Deserialize<Cadeteria>(jsonDocumento);
//             var listadoCadetes = LeerArchivoCadetes(nombreArchivoCadetes);
//             cadeteria.AgregarCadetes(listadoCadetes);
//             return cadeteria;
//         }
//     }
// }