using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operator_Overloading
{
  public class Euro
  {
    // Geld Betrag komplett in Cent umgerechnet
    public long TotalCents { get; private set; }

    // Cent Betrag hinter dem Komma beim Geld
    public long Cents => TotalCents % 100L;

    // Euro Betrag vor dem Komma beim Geld
    public long EuroAmount => TotalCents / 100L;

    // euro = Euro Betrag vor dem Komma beim Geld
    // cents = Cent Betrag hinter dem Komma beim Geld
    public Euro(long euro,long cents)
    {
      TotalCents = cents + euro * 100L;
    }

    // Nützlich beim Overloading von + und - , da man leicht die totale Anzahl von Cents verrechnen kann.
    public Euro(long totalCents)
    {
      TotalCents = totalCents;
    }

    // Für textuelle Representation eines Euros Betrag
    public override string ToString() => $"Euro: {EuroAmount}, Cents: {Cents}";

    // Für Addition von 2 Euro Beträgen.
    public static Euro operator +(Euro amount, Euro anotherAmount) => new Euro(amount.TotalCents + anotherAmount.TotalCents);

    // Für Addition von 1 Euro Betrag und einen Integer Wert. Demonstriert das Overloading von einen Operator mit 2 verschieden Datentypen.
    public static Euro operator +(Euro amount, int anotherAmount) => new Euro(amount.TotalCents + anotherAmount);
    // Für Addition mit 2 verschieden Datentypen muss auch in die andere Reihenfolge gegeben sein damit es einwandfrei funktioniert.
    public static Euro operator +(int anotherAmount, Euro amount) => new Euro(anotherAmount + amount.TotalCents);
    // Für unary Addition ++x
    public static Euro operator ++(Euro amount) => new Euro(amount.TotalCents + 1);
    // Für unary Subtraktion --x
    public static Euro operator --(Euro amount) => new Euro(amount.TotalCents - 1);
    // Für Subtraktion von 2 Euro Beträgen.
    public static Euro operator -(Euro amount, Euro anotherAmount) => new Euro(amount.TotalCents - anotherAmount.TotalCents);
    // Für Subtraktion von 1 Euro Betrag und einen Integer Wert. Demonstriert das Overloading von einen Operator mit 2 verschieden Datentypen.
    public static Euro operator -(Euro amount, int anotherAmount) => new Euro(amount.TotalCents - anotherAmount);
    // Für Subtraktion mit 2 verschieden Datentypen muss auch in die andere Reihenfolge gegeben sein damit es einwandfrei funktioniert.
    public static Euro operator -(int anotherAmount, Euro amount) => new Euro(anotherAmount - amount.TotalCents);

    // Ermöglicht das konvertieren eines Euro Betrag in einen long Wert. Das implicit Schlüsselwort sorgt dafür, dass keine Cast Angabe notwendig, also kein (long)euro.
    public static implicit operator long(Euro amount) => amount.TotalCents;
    // Ermöglicht das konvertieren eines Euro Betrag in einen bool Wert. Das explicit Schlüsselwort sorgt dafür, dass eine Cast Angabe notwendig, also ein  (bool)euro nötig.
    public static explicit operator bool(Euro amount) => amount.TotalCents >= 0;
  }
}
