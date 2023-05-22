using Spectre.Console;
using Students.Code;
using Students.Code.StudentLayer;

namespace Students.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            // Setzt den Pfad in der die CSV Datei abgelegt ist
            CsvHandler._csvPath = @"C:\Users\kaar\Downloads\SchuelerListe.csv";


            // Ruft die Studentendaten asynchron ab
            List<StudentDto>? students = await StudentAccessLayer.GetStudentsAsync();

            // Überprüft, ob die Studentendaten vorhanden sind
            if (students is null)
                throw new Exception("CSV konnte nicht geladen werden");


            

            // Erstellt eine Tabelle zur Darstellung der Studentendaten
            Table table = new();

            // Fügt Spalten zur Tabelle hinzu
            table.AddColumn("Klasse");
            table.AddColumn("Vorname");
            table.AddColumn("Nachname");

            // Fügt für jeden Studenten eine Zeile zur Tabelle hinzu
            foreach (StudentDto student in students)
            {
                table.AddRow(student.Klasse, student.Vorname, student.Nachname);
                
            }

            // Gibt die Tabelle mit den Studentendaten aus
            AnsiConsole.Write(table);
            Console.WriteLine();

            // Ruft die Anzahl der Studenten pro Klasse ab und gibt sie aus
            Dictionary<string, int> studentsInClass = await StudentAccessLayer.GetStudentsInClass();
            foreach (var classStudentPair in studentsInClass)
            {
                AnsiConsole.WriteLine($"Klasse: {classStudentPair.Key} Schüleranzahl: {classStudentPair.Value}");
            }
            Console.WriteLine();

            // Ruft die Gesamtzahl der Klassen ab und gibt sie aus
            int classCount = await StudentAccessLayer.GetClassCountAsync();
            AnsiConsole.WriteLine($"Klassen Gesamt: {classCount}\n");

            // Ruft die durchschnittliche Anzahl von Schülern pro Klasse ab und gibt sie aus
            int avgStudentsInClass = await StudentAccessLayer.GetAvgStudentsInClassAsync();
            AnsiConsole.WriteLine($"Avg. Schüler pro Klasse: {avgStudentsInClass}");

            // Serialisiert die Daten als XML und speichert sie in den eingebeben Pfad
            await StudentAccessLayer.SerializeXml(@"C:\Temp\SchuelerListe.xml");

            // Serialisiert die Daten als JSON und speichert sie in den angegebenen Pfad
            await StudentAccessLayer.SerializeJson(@"C:\Temp\SchuelerListe.json");
        }
    }
}
