Der Auftraggeber benötigt ein Program zum Bewerten von Sortieralgorithmen.
 Anhand der Geschwindigkeit und des Speicherverbrauchs.

# Anforderungen
  - Ermitteln des performantesten Sortieralgorithmus
  - Test mit unterschiedlicher Art und Größe der Collection (Typ: Ganzzahlen) 
  - Auswertung der Geschwindigkeit und des Speicherbedarfs
  - Ausgabe der Performancewerte in einer Konsole
  - Konfigurierbarkeit der getesteten Listengröße

# Entwurf

## Testdaten

Können mit Zufallsgenerator erzeugt werden.

Pro Durchlauf muss eine identische Liste der konfigurierten Größe für alle Sortieralgorithmen benutzt werden.

Um verschiedene Arten von Collections testen zu können, wird das Interface `IPopulatedCollectionProvider<CollectionType>` definiert. Es gibt eine Methode `Generate(int size)` vor.

Implementationen für Collection-Arten:

```
PopulatedArrayProvider
PopulatedListProvider
```

Die implementierenden Klassen instanziieren den jeweiligen Sammlungstypen, generieren `Size` zufällige Elemente, fügen sie hinzu und geben die Collection zurück.


## Sortieralgorithmen

Um mehrere Collection-Arten sortieren zu können, wird ein Interface `ISorter<CollectionType>` angelegt, welches je eine Methode für die Sortieralgorithmen bereitstellt.
Diese nehmen eine Instanz der Collection-Art an und geben sie sortiert zurück.

Somit ergeben sich die Klassen: `ArraySorter` und `ListSorter`.

## Benchmark

Es wird eine Benchmark-Klasse `SortingBenchmark<CollectionType>` angelegt.

- Sie enthält eine `Setup`-Methode
- Ein `Size` Feld, welches benutzt wird, um die Collectiongröße zu konfigurieren.
- Methoden für die eigentlichen Aufrufe der Sortieralgorithmen.

Die Setup Methode findet und instanziiert mit Reflection Implementierungen von IPopulatedCollectionProvider<CollectionType> und von ISorter<CollectionType>.
Die Instanz von IPopulatedCollectionProvider<CollectionType> wird verwendet, um eine mit `Size` Elementen gefüllte Collection zu erhalten.

## Tests

Es werden Unit Tests angefertigt, die prüfen, ob die Sortieralgorithmen korrekt funktionieren.