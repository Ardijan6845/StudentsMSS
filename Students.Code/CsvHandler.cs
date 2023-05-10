using CsvHelper;
using CsvHelper.Configuration;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace Students.Code;

public static class CsvHandler
{
    private static string _csvPath = @"C:\Users\kaar\Downloads\SchuelerListe.csv";

    // Methode zum Abrufen von Daten aus einer CSV-Datei
    public static async Task<List<T>?> GetData<T>()
    {
        // Verwenden von Task.Factory.StartNew, um eine asynchrone Aufgabe zu erstellen
        return await Task.Factory.StartNew(() =>
        {
            // Konfiguration für das CSV-Handling erstellen
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) { Delimiter = ";", Encoding = Encoding.UTF8 };




            // StreamReader und CsvReader verwenden, um die CSV-Datei zu lesen
            using StreamReader reader = new(_csvPath, Encoding.UTF8);
            using CsvReader csvReader = new(reader, config);

            // Die erste Zeile überspringen (Header)
            csvReader.Read();
            csvReader.ReadHeader();

            // Die Datensätze aus der CSV-Datei lesen und in eine Liste von Typ T konvertieren
            List<T>? data = csvReader.GetRecords<T>().ToList();
            return data;
        });
    }
}
