using Students.Data.Model;
using System.Globalization;
using System.Xml.Serialization;

namespace Students.Code.StudentLayer;

public class StudentAccessLayer
{
    // Methode, um Studenten asynchron abzurufen
    public static async Task<List<StudentDto>?> GetStudentsAsync()
    {

        // Ruft die Studenten ab
        List<Student>? students = await GetStudents();

        // Konvertiert die Studenten in StudentDto-Objekte und gibt eine Liste mit Dem zusätzlichen attribut Email zurück
        return students.Select(student => new StudentDto()
        {
            Klasse = student.Klasse,
            Vorname = student.Vorname,
            Nachname = student.Nachname,
            Email = $"{student.Vorname}.{student.Nachname}@tsn.at",
        }).ToList(); ;
    }


    // Methode, um die Anzahl der Klassen asynchron abzurufen

    public static async Task<int> GetClassCountAsync()
    {
        // Ruft die Studenten ab

        List<Student>? students = await GetStudents();

        // Zählt die eindeutigen Klassen und gibt die Anzahl zurück

        int count = students.Select(x => x.Klasse).Distinct().Count();
        return count;
    }

    // Methode, um die durchschnittliche Anzahl von Studenten pro Klasse asynchron abzurufen

    public static async Task<int> GetAvgStudentsInClassAsync()
    {
        // Ruft die Studenten ab

        List<Student>? students = await GetStudents();

        // Berechnet die durchschnittliche Anzahl von Studenten pro Klasse

        int avgStudentsInClass = students.Count / await GetClassCountAsync();
        return avgStudentsInClass;
    }

    public static async Task<Dictionary<string, int>> GetStudentsInClass()
    {
        List<Student>? students = await GetStudents();

        // Erstellt ein Dictionary, um die Anzahl der Studenten pro Klasse zu speichern
        Dictionary<string, int> studentsInClass = new();
        List<string> classNames = students.Select(x => x.Klasse).Distinct().ToList();

        // Durchläuft jede Klasse und zählt die Anzahl der Studenten in der Klasse
        foreach (string className in classNames)
        {
            int studentCount = students.Where(x => x.Klasse == className).Count();
            studentsInClass[className] = studentCount;
        }

        return studentsInClass;
    }

    public static async Task<List<Student>?> GetStudents()
    {
        // Ruft die Daten der Studenten ab
        List<Student>? students = await CsvHandler.GetData<Student>();

        // Überprüft, ob die Studentendaten vorhanden sind, andernfalls gibt eine leere Liste zurück
        if (students is null)
            return new();

        return students;
    }

    public static async Task SerializeXml(string path)
    {
        // Schreibt die Daten als XML
        await XmlHandler.WriteData(path);
    }

    public static async Task SerializeJson(string path)
    {
        // Schreibt die Daten als JSON
        await JsonHandler.WriteData(path);
    }




}