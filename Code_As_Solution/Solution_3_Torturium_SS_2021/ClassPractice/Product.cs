using System;
using System.Collections.Generic;
using System.Text;

namespace ClassPractice
{
  class Product
  {
    // Preis einer einzelnen Produktes
    private double _singlePrice = 0.0;

    // Wird gebraucht, damit eine neue Instance weiß welche nächste ID genommen werden kann.
    private static int nextId = 0;

    // Jeder Instance hat eine einzigartige id. Diese ID ist aufzählend.
    private int _id;

    // Getter in kompakter Schreibweise
    public double SinglePrice => _singlePrice;
    // Wie ein Produkt heißt
    public string Name { get; private set; } = "";
    // Wie oft ein Produkt in einer Instance vorkommt
    public int Number { get; set; }

    // ID welche eine Instance hat.
    public int ID
    {
      get
      {
        return _id;
      }
    }

    // Gesamte Summe aller Produkte in einer Instance
    public double WholePrice => SinglePrice * Number;

    public Product(string name, double singlePrice, int number)
    {
      // Bekommt nächste verfügbare einzigartige ID.
      _id = nextId;
      // Legt die nächste einzigartige verfügbare ID fest.
      nextId++;
      Name = name;
      Number = number;
      _singlePrice = singlePrice;
    }

    // Konstruieren einer Instance falls die Anzahle des Products nicht zur Verfügung steht.
    // Folgende Zeile
    // : this(name, singlePrice, 1) { } 
    // Ruft den oberen Konstruktor nochmal auf.
    public Product(string name, double singlePrice) : this(name, singlePrice, 1) { }

    // Gibt den gesamten Preis, aller Produkten aller Instance im Array, aus. 
    public static double GetWholePrice(params Product[] products)
    {
      double wholePrice = 0.0;
      foreach (Product elenment in products)
      {
        // Addiere den gesamten Preis aller Produkte aus einer Instance
        wholePrice += elenment.WholePrice;
      }

      return wholePrice;
    }

    // Gibt alle Produktarten zeilenweise aus und die letzte Zeile gibt den gesamten Preis, aller Produkten aller Instance im Array, aus. 
    public static string ProductTable(Product[] products)
    {
      string result = "";

      for (int i = 0; i < products.Length; i++)
      {       
        // Addiere die Informationen aus einer Instance
        result += $"{products[i].GetProductInfo()}\n";
      }

      // Addiere den gesamten Preis aller Produkte aus einer Instance
      result += $"Total Price: {GetWholePrice(products)}\n";

      return result;
    }

    // Ausgabe von Informationen aus einer Instance.
    public string GetProductInfo() => $"{Name}, Single price: {SinglePrice}$, x{Number} = {WholePrice}$ ";
    
  }
}
