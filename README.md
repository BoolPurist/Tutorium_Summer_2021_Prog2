# Tutorium_Prog2

Hier befinden sich alle Aufgabenstellungen und deren jeweiligen Lösungen zu dem Tutorium in Prog 2 für den Studiengang Informatik. 
Diese Materiellen sind das Ergebnis aus einem Tutorium im Sommersemester in 2021.

## Aufgabenblätter

Alle Aufgabenblätter befinden sich unter dem Ordner ["Exercises"](./Exercises)

- [1. Übung](./Exercises/Exercise_1_Wiederholung_Prog1.md)
- [2. Übung](./Exercises/Exercise_2_ClassPractice.md)
- [3. Übung](./Exercises/Exercise_3_Operator_Overloading.md)
- [4. Übung](./Exercises/Exercise_4_Erweiterbare_Listen.md)
- [5. Übung](./Exercises/Exercise_5_Sortierung_Queue.md)
- [6. Übung](./Exercises/Exercise_6_Binary_Tree.md)
- [7. Übung](./Exercises/Exercise_7_Vererbung_Exceptions.md)
- [8. Übung](./Exercises/Exercise_8_Interfaces.md)
- [9. Übung](./Exercises/Exercise_9_Interfaces_and_Generics.md)
- [10. Übung](./Exercises/Exercise_10_Generic_Stack_and_Delegates.md)
- [11. Übung](./Exercises/Exercise_11_Events.md)

Im Unterordner ["png"](./Exercises/png) befinden sich Bildmateriellen. Manche sind direkt in einem Aufgabenblatt eingebunden.
Andere dienen eher zur zusätzlichen Erklärung zu gewissen Themen. 

Diese Bilder enstanden aus den Diagrammen im Unterordner ["draw_io_diagramms"](./Exercises/draw_io_diagramms)

## Lösungen zu den Aufgabenblättern

Lösungen liegen als Code bereit unter dem Ordner ["Code_As_Solution"](./Code_As_Solution)

## Themen mit den man sich nach Prog2 beschäftigen kann

Unit Tests: Unglaublich wichtig für die Praxis.

[Was sind Unit Tests](https://www.guru99.com/unit-testing-guide.html)

Am besten lernt man Unit tests durch das Anwenden eines Frameworks für Unit Tests.

2 Sehr beliebte Frameworks dafür sind

1. [NUnit](https://nunit.org/)
2. [XUnit](https://xunit.net/)

## Aufzeigen von Fehlern/Bugs

Sollte du einen Fehler/Bug in den Materiellen gefunden haben.
Kannst du ein Issue dazu aufmachen, damit ich dann darauf den Fehler beheben kann.

## Scripts als Hilfe zur Erstellung der Unterlagen.

Im Ordner ["js_helper_scripts"](./js_helper_scripts) finden sich js Dateien, welche
leere Template md Files erstellen und auch die Markdown Files als Aufgabenblätter in pdf Files umwandeln.

Diese js Files werden über npm commands in der Node Environment ausgeführt.

Folgende Commands stehen zur Verfügung:

- mdToPdf
- createMdFile
- appendToMdFile

---

### mdToPdf

Syntax:

npm run mdToPdf

Wandelt alle md Files im Ordner "Excises" in pdf Files um und platziert sie in einen Ordner namens pdf

---

### createMdFile

Syntax: \
npm run createMdFile \< Name von neuen Markdown File \>

Beispiel: \
npm run createMdFile newMDFile

Wirkung: \
Erstellt einen neuen Markdown file mit in einer typische Vorlage für eine 1. Aufgabe des Aufgabenblatt

---

### appendToMdFile

Syntax: \
npm run appendToMdFile \< Name von Markdown File + .md \>

Beispiel: \
npm run appendToMdFile mdFile.md

Fügt eine Vorlage für einen weitere Aufgabe am Ende des Aufgabenblattes hinzu.
