function showContent() {
    // Ukryj wszystkie pola
    document.querySelectorAll('.content').forEach(function (div) {
        div.style.display = 'none';
    });

// Pobierz wybraną opcję
const selectedValue = document.getElementById('select-option').value;

// Pokaż odpowiednie pole
if (selectedValue !== "none") {
    document.getElementById(selectedValue).style.display = 'block';
            }
        }
