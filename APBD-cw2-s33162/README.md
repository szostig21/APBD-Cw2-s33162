# APBD-cw2-s33162

## Opis projektu

Projekt przedstawia prosty system wypożyczalni sprzętu edukacyjnego, stworzony w języku C# jako aplikacja konsolowa.

Aplikacja oferuje możliwość:
- rejestracji użytkowników,
- dodawania sprzętu do bazy,
- wypożyczania sprzętu,
- zwracania sprzętu.
- naliczanie kary za spóźnienie,
- oznaczanie sprzętu jako niedostępny,
- wyświetlanie raportów.

W projekcie zostały zaimplementowane:
- klasa bazowa `Equipment`,
- klasy dziedziczące `Laptop`, `Projector`, `Camera`,
- klasa bazowa `User`,
- klasy dziedziczące `Student`, `Employee`,
- klasa `Rental`,
- klasa `RentalService`,
- plik `Program.cs` z scenariuszem działania programu.

## Podział projektu

Projekt został podzielony foldery:
- `Enums` – przechowuje typy wyliczeniowe, np. status sprzętu i typ użytkownika,
- `Models` – przechowuje klasy opisujące obiekty,
- `Services` – przechowuje klasę odpowiedzialną za logikę działania programu,
- `Program.cs` – zawiera jedynie uruchomienie programu i przykładowe wywołania metod.

Taki podział został wybrany, ponieważ jest czytelny i wszystko znajduje sie w miejscach o łatwym dostępie.

## Uzasadnienie decyzji projektowych

Zdecydowałem sie na podział na klasy bazowe i klasy dziedziczące, ponieważ w projekcie występują obiekty, które mają wspólne cechy.
Dzięki temu nie trzeba powtarzać tych samych pól w wielu klasach, a kod jest prostszy.

Dodatkowo każdy typ sprzętu ma swoje własne cechy:
- `Laptop` posiada procesor i ilość RAM,
- `Projector` posiada jasność i rozdzielczość,
- `Camera` posiada liczbe pikseli i informację czy jest dostepna opcja nagrywania wideo.

Podobnie użytkownicy zostali rozdzieleni na:
- `Student`,
- `Employee`.

## Kohezja, coupling i odpowiedzialność klas

W projekcie starałem się zadbać o to, aby każda klasa miała jedno główne zadanie.

### Kohezja
Kohezja jest widoczna w tym, że klasy mają spójne odpowiedzialności:
- `Equipment` i klasy pochodne opisują tylko sprzęt,
- `User` i klasy pochodne opisują tylko użytkowników,
- `Rental` opisuje pojedyncze wypożyczenie,
- `RentalService` zajmuje się operacjami na danych.

Dzięki temu każda klasa odpowiada za jeden konkretny obszar.

### Coupling
Starałem się ograniczyć coupling poprzez oddzielenie logiki od warstwy uruchomieniowej.
`Program.cs` nie zawiera całej logiki biznesowej, tylko tworzy obiekty i wywołuje metody serwisu.

Najważniejsze operacje zostały umieszczone w RentalService, więc zmiany w logice programu nie wymagają przebudowy całego `Program.cs`.

### Odpowiedzialność klas
Podział odpowiedzialności wygląda następująco:
- `Models` przechowują dane,
- `Services` realizują logikę programu,
- `Program.cs` pokazuje scenariusz działania.

Taki układ jest prosty do zrozumienia i łatwo się w nim pracuje.

## Zasady działania programu

W programie zostały zaimplementowane podstawowe zasady:
- student może mieć maksymalnie 2 aktywne wypożyczenia,
- pracownik może mieć maksymalnie 5 aktywnych wypożyczeń,
- nie można wypożyczyć sprzętu, który nie jest dostępny,
- przy spóźnionym zwrocie naliczana jest kara,
- sprzęt może zostać oznaczony jako niedostępny.

## Uruchomienie programu

1. Otworzyć solution lub projekt w Riderze albo Visual Studio.
2. Uruchomić aplikację konsolową.
3. Program wykona przykładowy scenariusz działania zapisany w `Program.cs`.

---

## Autor

Jakub Szostak s33162