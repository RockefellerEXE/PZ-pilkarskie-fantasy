function loadTableData(section, page) {
    console.log(`Ładowanie danych dla sekcji: ${section}, strona: ${page}`);
    // Tutaj możesz dodać kod do pobrania danych np. z API za pomocą fetch()
    // Na razie tylko zmieniam treść tabeli jako przykład
    const table = document.querySelector(`.table-section.${section} img`);
    table.alt = `Załadowano dane dla strony ${page}`;
}
// Dodanie efektu hover dla przycisków
document.querySelectorAll('.pagination button').forEach(button => {
    button.addEventListener('mouseover', () => {
        button.style.backgroundColor = '#bbb';
    });
    button.addEventListener('mouseout', () => {
        button.style.backgroundColor = button.classList.contains('active') ? '#89c44a' : '#ddd';
    });
});
async function fetchData(endpoint) {
    try {
        const response = await fetch(endpoint);
        if (!response.ok) {
            throw new Error(`Błąd: ${response.statusText}`);
        }
        const data = await response.json();
        console.log('Dane pobrane:', data);
    } catch (error) {
        console.error('Wystąpił błąd:', error);
    }
}
