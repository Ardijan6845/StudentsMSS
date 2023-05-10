using Students.Code.StudentLayer;
using System.IO;
using System.Text.Json;

namespace Students.Code
{
    internal class JsonHandler
    {
        // Methode zum Schreiben von Daten als JSON
        public static async Task WriteData()
        {
            string path = @"C:\Temp\SchuelerListe.json";

            // Ruft die Studentendaten asynchron ab und serialisiert sie als JSON
            var jsonString = JsonSerializer.Serialize(await StudentAccessLayer.GetStudentsAsync());

            // Schreibt den JSON-String in eine Datei
            File.WriteAllText(path, jsonString);
        }
    }
}
