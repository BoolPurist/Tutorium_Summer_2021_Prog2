# Debug.Assert

## Problem
Oft muss man Testen ob der Code funktioniert, den man geschrieben hat.
Dabei muss man dann oft die Ausgabe im Konsolenfenster kontrollieren.
Das ist ausgesprochen langweilig und auch unnötig !

## Lösung
Man kann eine Funktion nutzen, welche die Kontrolle der Ergebnisse übernimmt.
Diese Funktion heißt Debug.Assert. Diese Funktion nimmt einen bool Parameter an.
Ist dieser false, dann bricht das Programm ab mit der Meldung, dass diese Prüfung nicht
erfolgreich war.

Link zur mehr [Infos](https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.debug.assert?view=net-5.0)


## Wie es funktioniert

Wichtig: Man muss noch einen Namespace einbinden mit "using System.Diagnostics;".

Ein Beispiel mit Abbruch wegen fehlerhaften Code.
```Csharp
int number = 3;

// Das Program wird hier abbrechen, da number mit Wert 3 nicht gerade ist.
Debug.Assert((number % 2) == 0);

Console.WriteLine("Alle tests bestanden.");
```

Ein Beispiel ohne Abbruch, da Code korrekt ist.
```Csharp
int number = 2;

// Hat bei erfolgreicher Prüfung keine Auswirkung auf den Ablauf des Programms
Debug.Assert((number % 2) == 0);

Console.WriteLine("Alle tests bestanden.");
```

<div class="page"/>

## Wie man es anwendet

### Mit Debug.Assert arbeiten.

Anwendung von Debug.Assert. Füge diesen Code in die Klasse Program ein.
Dieses Program wird nicht komplett durchlaufen. Ändere IsEven so ab, dass das Program komplett durchläuft.

```Csharp
// Code zur mit einen Fehler.
using System.Diagnostics;


public class Program
{

    public static void Main()
    {
        // Funktion IsEven scheint noch nicht korrekt zu sein.
        // Fixe die Funktion
        // Soll true zurück geben sobald der Parameter eine gerade Zahl ist.
        Debug.Assert(IsEven(3) == false);
        Debug.Assert(IsEven(2) == true);
        Debug.Assert(IsEven(7) == false);
        Console.WriteLine("All tests passed");
        Console.ReadKey();
    }

    public static bool IsEven(int number)
    {
        return false;
    }
}
```
<div class="page"/>

### Selber Debug.Assert schreiben

```C#
using System.Diagnostics;


public class Program
{
    public static void Main()
    {
        // Die Funktion Fill ist fehlerhaft.
        // Bisher sieht man das fehlerhafte Verhalten der Funktion 
        // In dem man auf die Konsole schaut ob es stimmt.
        // ======================================
        // Die Funktion Fill soll ein Array mit einer gewissen Länge zurück geben.
        // Diese Länge wird durch den 1. Parameter angeben.
        // Der Wert jedes arrays Felds soll den Wert von dem 2. Parameter haben.
        
        // 1. Ändere die Konsolen Ausgabe auf Asserts mit Debug.Asserts um.
        // 2. Verbessere die Funktion Fill, so das es das korrekte array zurück gibt.
        
        
        string[] array = Fill(100, "*");
        Console.WriteLine($"array.Length = {array.Length}");

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"array[{i}] = {array[i]}");
        }

        // Das muss man nicht ändern
        Console.ReadLine();
    }

    public static string[] Fill(int number, string content)
    {
        string[] result = new string[10];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = "Fehler";
        }

        return result;
    }
}
```

<div class="page"/>

## Summary

Zusammenfassung: Anstatt immer die Ausgaben in der Konsole anzuschauen zum testen, sollte man immer Debug.Assert verwenden. Grund: Man muss nicht selber kontrollieren ob der Code richtig ist. Das spart Zeit und vermeidet Fehler bei der Kontrolle der Ausgabe für die Ergebnis.