# ChildSpeaker

Program konwertuje dany wyraz na wyraz mówiony przez dziecko. Program wylicza takich samych brzmiących wyrazów jest u dziecka jak dane słowo.
np `mapa` i `mama` dziecko wymawia tak samo `mama`.

## Algorytm

Algorym posiada 5 zasady
1. Zamienia wszystkie spółgłoski na pierwsza napotkaną spółgłoslke np: `muzyka` -> `mumyma'
2. Jesli wyraz zaczyn się na samogłoske to bierze na początek pierwsza spółgloske np: `aga` -> `gaga`
3. Ciąg spółgłosek zamienia na jedną pierwszą spółgloske. np: `lajdak` -> `lala` czyli w tym przypadku mamy `jd` to powinna byc tylko `j` a nastepnie `j` zamienia się na `l` (zasada pierwsza)
4. Ciąg samogłosek zamienia się na jedną ostanią samogłoskę. np `naomi` -> `noni`, czyli tutaj mamy `ao` i to zamiaenia sie na `o`
5. Wszystkie spółgloski wylatują z konca wyrazu. np `grater` -> `gage` czyli  mamy tutaj zasade 3 `gr` zamieniamy to na `g`, nastepnie zasade 1 zamieniamy to na `gageg` i usuwamy ostatnia spółgloske czyli ostatnie `g`

## kod
Program składa się z 3 klas.
1. `ChildSpeaker` - jest to klasa strikte związana z rozwiązaniem algorytmu
2. `CharacterMerger` - klasa pomocnicza która łączy spółgłoski i samogłoski (zasada 3 i 4) 
3. `ChildSpeakerSover` - klasa która rozwiązuje problem i aggreguje wszystkie wyniki oraz je sumuje w odpowiedni format

## Dizałanie

Na wejsciu nalezy podac sciezke do pliku json z wyrazami `example.json` albo `input.json` 
na wejsciu powinien wygenerowac plik z odpowiedzia `output.out` 

Zwracane wyrazy powinny byc posorotwane oraz bez duplikatow

### Załozenia
uzywany jest tylko angielski alfabet `abcdefghijklmnopqrstuvwxyz`, wyrazy zawsza sa pisane małymi znakami, maksymalnie w tablicy bedzie 10000 rekordów.

### przyklad

#### input
```
mapa
mama
alan
island
lajdak
aba
alan
```

#### output
```
alan 2
aba 0
island 2
lajdak 2
mama 1
mapa 1
```

#### wyjasnienie

alan jest z duplikowany, wiec jeden alan jest usuniety, `alan`, `island`, `lajdak` maja taka sama wymowe czyli `lala` 
wiec kazdy z nich otrzymuje po 2 te same wyrazy w kolekcji sa tak samo wymawiane. `aba` jest unikalna, 
zadne wyrazenie nie ma takiego samego wymowy. `mama` i `mapa` wymawia sie tak samo czyli kazdy ma po jednej takiej samej wymowie.