function showContent() {
    const selectedOption = document.getElementById('select-option').value;

    // Ukryj wszystkie elementy z klasą 'content'
    document.querySelectorAll('.content').forEach(div => {
        div.classList.add('hidden'); // Dodaj klasę ukrywającą
    });

    // Pokaż odpowiedni element, jeśli istnieje
    if (selectedOption !== "none") {
        const selectedDiv = document.getElementById(selectedOption);
        if (selectedDiv) {
            selectedDiv.classList.remove('hidden'); // Usuń klasę ukrywającą
        }
    }
}

// TERMINARZ POSZCZEGÓLNE KOLEJKI
document.addEventListener("DOMContentLoaded", function () {
    const kolejkiSelect = document.getElementById('select-kolejka');
    for (let i = 1; i <= 10; i++) { // Załaduj 10 kolejek
        let option = document.createElement('option');
        option.value = `kolejka-${i}`;
        option.textContent = `Kolejka ${i}`;
        kolejkiSelect.appendChild(option);
    }
});

// Funkcja do parsowania danych z pliku
function parseFixtures(data) {
    const fixtures = {};
    const sections = data.split('---');

    sections.forEach(section => {
        const lines = section.trim().split('\n');
        const header = lines.shift();  // Pierwsza linia to nagłówek, np. "1. kolejka"
        const matchday = header.match(/(\d+)\. kolejka/);  // Wyciągamy numer kolejki
        if (matchday) {
            fixtures[matchday[1]] = lines.join('<br>');
        }
    });

    return fixtures;
}

// Funkcja do wypełniania opcji w selekcie
function populateKolejkaOptions(fixtures) {
    const select = document.getElementById('select-kolejka');
    for (const matchday in fixtures) {
        const option = document.createElement('option');
        option.value = `kolejka-${matchday}`;  // wartość opcji, np. "kolejka-1"
        option.text = `${matchday}. kolejka`;  // Tekst wyświetlany w opcji, np. "1. kolejka"
        select.appendChild(option);
    }
}

// Funkcja do wyświetlania zawartości dla wybranej kolejki
function showKolejkaContent() {
    const selectedKolejka = document.getElementById('select-kolejka').value;
    const fixturesDiv = document.getElementById('fixtures');

    // Wyczyszczenie starej zawartości
    fixturesDiv.innerHTML = '';

    if (selectedKolejka !== "none") {
        // Przykładowe dane - tutaj możesz wczytać dane z serwera przez AJAX
        fixturesDiv.innerHTML = `<p>Wybrano kolejkę: ${selectedKolejka}</p>`;
    }
}

