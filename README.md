## Jak uruchomiæ projekt
* utworzyæ pusty plik alcohols.db w projekcie
* Uruchomiæ aplikacjê i w ustawieniach podaæ œcie¿kê do bazy (np C:\Users\test\test2\ZPO\alcohols.db) oraz zapisaæ.
* Z poziomu VS nale¿y uruchomiæ komendê `Update-Database` która wykona niezbêdne migracje.

Uwaga: Jeœli nie bêdzie znajdowaæ pliku configu, to mo¿na ustawiæ ConfigFilePath w klasie Config.cs gdzie poda siê œcie¿kê bezwglêdn¹ do pliku.


## Wymagania
* .NET 8.0 +