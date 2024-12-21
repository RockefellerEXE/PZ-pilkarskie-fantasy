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

// zmiana dla brancha
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
    const fixtures = document.getElementById('fixtures');
    const selectedKolejka = document.getElementById('select-kolejka').value;

    // Przykład testowy - dynamiczne ładowanie zawartości
    fixtures.innerHTML = `<p>Wybrano kolejkę: ${selectedKolejka}</p>`;
}

