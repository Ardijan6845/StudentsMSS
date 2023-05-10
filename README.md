# StudentsMSS

Das programm ist in 3 Layer aufgeteilt UI,Code,Data 
Der CsvHandler liest die Daten aus einer CSV Datei und konvertiert sie in eine Generische Liste vom Typ <T>  
Mit dieser Liste werden im AccessLayer operationen Durchgeführt z.b. Klassen,menge an schülern, durchschnitt der Schüler pro Klasse,anzahl der klassen etc. 
mit der methode GetStudentsAsync wird das attribut Email hinzugefügt und in einer Liste mit dem Typ StudentDto gespeichert.
Der JsonHandler wie auch der XmlHandler nutzen die schon eingelesene Liste Students und serialisieren sie und speichern sie in dem angegebenen pfad.
  
  
