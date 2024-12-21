function showContent() {
    // Ukryj wszystkie pola
    document.querySelectorAll('.content').forEach(function (div) {
        div.style.display = 'none';
    });

    // Pobierz wybraną opcję
    const selectedValue = document.getElementById('select-option').value;

    // Zmień nagłówek i pokaż odpowiednie pole
    if (selectedValue === "cala-runda") {
        document.getElementById('cala-runda').style.display = 'block';
    } else if (selectedValue === "cala-runda-fdr") {
        document.getElementById('cala-runda-fdr').style.display = 'block';
    }
    else if (selectedValue === "kolejki") {
        document.getElementById('kolejki').style.display = 'block';
    }
}

// Funkcja do parsowania pliku i tworzenia obiektu z danymi
function parseFixtures(data) {
    const fixtures = {};
    const sections = data.split(/\n(?=\d+\. kolejka)/);  // Rozdziel kolejki na podstawie numeru kolejki

    sections.forEach(section => {
        const lines = section.trim().split('\n');
        const header = lines.shift();  // Pierwsza linia to nagłówek, np. "19. kolejka (1-2 lutego)"

        // Używamy wyrażenia regularnego do wyciągnięcia numeru kolejki
        const matchday = header.match(/(\d+)\. kolejka/);
        if (matchday) {
            const matchdayNumber = matchday[1];
            fixtures[matchdayNumber] = lines.join('<br>'); // Przypisujemy mecze danej kolejki
        }
    });

    return fixtures;
}

// Funkcja do uzupełnienia selecta z kolejnymi opcjami
function populateKolejkaOptions(fixtures) {
    const select = document.getElementById('select-kolejka');
    // Dodajemy opcję "Wybierz kolejkę"
    const defaultOption = document.createElement('option');
    defaultOption.value = 'none';
    defaultOption.text = 'Wybierz kolejkę';
    select.appendChild(defaultOption);

    // Dodajemy opcje dla każdej kolejki
    for (const matchday in fixtures) {
        const option = document.createElement('option');
        option.value = `kolejka-${matchday}`;  // wartość opcji, np. "kolejka-19"
        option.text = `${matchday}. kolejka`;  // Tekst wyświetlany w opcji, np. "19. kolejka"
        select.appendChild(option);
    }
}

// Funkcja do wczytywania danych z pliku i populowania selecta
function loadFixtures() {
    fetch('/Pliki_terminarz/terminarz_poszczegolne.txt')
        .then(response => response.text())  // Odczytaj zawartość pliku
        .then(data => {
            const fixtures = parseFixtures(data);  // Parsuj dane
            populateKolejkaOptions(fixtures);  // Wypełnij opcje w selekcie
        })
        .catch(error => {
            console.error('Błąd wczytywania danych:', error);
        });
}

// Funkcja do wyświetlania meczów wybranej kolejki
function showKolejkaContent() {
    const selectedKolejka = document.getElementById('select-kolejka').value;
    const fixturesDiv = document.getElementById('fixtures');

    // Wyczyszczenie starej zawartości
    fixturesDiv.innerHTML = '';

    if (selectedKolejka !== "none") {
        const selectedMatchday = selectedKolejka.replace('kolejka-', '');  // Usuń "kolejka-" z wartości

        // Załaduj zawartość z pliku tekstowego
        fetch('/Pliki_terminarz/terminarz_poszczegolne.txt')
            .then(response => response.text())  // Odczytaj zawartość pliku
            .then(data => {
                const fixtures = parseFixtures(data);  // Parsuj dane
                const selectedFixture = fixtures[selectedMatchday];  // Wyciągnij mecze dla wybranej kolejki
                if (selectedFixture) {
                    fixturesDiv.innerHTML = `<pre>${selectedFixture}</pre>`; // Wyświetl mecze wybranej kolejki
                } else {
                    fixturesDiv.innerHTML = `<p>Nie znaleziono danych dla tej kolejki. Może numer kolejki jest nieprawidłowy lub dane nie zostały załadowane poprawnie.</p>`;
                }
            })
            .catch(error => {
                fixturesDiv.innerHTML = `<p>Błąd wczytywania danych: ${error}</p>`;
            });
    }
}

// Inicjalizacja
document.addEventListener("DOMContentLoaded", function () {
    loadFixtures();
});
