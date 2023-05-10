using CsvHelper;
using Students.Code.StudentLayer;
using Students.Data.Model;
using System.Xml.Serialization;

namespace Students.Code
{
    public static class XmlHandler
    {
        // Methode zum Schreiben von Daten als XML
        public static async Task WriteData()
        {
            // Ruft die Studentendaten asynchron ab
            var studentsxml = await StudentAccessLayer.GetStudentsAsync();

            // Erstellt eine Instanz des XmlSerializer für den Typ List<StudentDto>
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<StudentDto>));

            // Schreibt die Studentendaten als XML in die angegebene Datei
            using (TextWriter writer = new StreamWriter(@"C:\Temp\SchuelerListe.xml"))
            {
                xmlSerializer.Serialize(writer, studentsxml);
            }
        }
    }
}
