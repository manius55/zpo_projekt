## Jak uruchomi� projekt
* utworzy� pusty plik alcohols.db w projekcie
* Uruchomi� aplikacj� i w ustawieniach poda� �cie�k� do bazy (np C:\Users\test\test2\ZPO\alcohols.db) oraz zapisa�.
* Z poziomu VS nale�y uruchomi� komend� `Update-Database` kt�ra wykona niezb�dne migracje.

Uwaga: Je�li nie b�dzie znajdowa� pliku configu, to mo�na ustawi� ConfigFilePath w klasie Config.cs gdzie poda si� �cie�k� bezwgl�dn� do pliku.


## Wymagania
* .NET 8.0 +