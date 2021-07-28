using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise
{
  public class ChatUser
  {
    public ChatUser(string name) => Name = name;

    // Name des Nutzers.
    public string Name { get; private set; }

    // Gedächtnis aller eingegebenen Nachrichten, Dazu braucht man static
    private static string _allMessage = String.Empty;

    // Eingeben einer Nachricht.
    // Eine neue Zeile wird sich in _allMessage gemerkt mit Name des Nutzers und die eingebende Nachricht
    public void TypeMessage(string message) => _allMessage += $"{Name}: {message}\n";

    // Gebe alle Nachrichten aus, die sich gemerkt wurden.
    public static string GetAllMessages() => _allMessage;

  }
}
