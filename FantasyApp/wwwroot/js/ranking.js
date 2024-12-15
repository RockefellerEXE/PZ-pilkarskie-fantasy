    function showContent() {
        // Ukryj wszystkie pola
        document.querySelectorAll('.content').forEach(function (div) {
            div.style.display = 'none';
        });

    // Pobierz wybraną opcję
    const selectedValue = document.getElementById('select-option').value;

    // Zmień nagłówek i pokaż odpowiednie pole
    const mainHeading = document.getElementById('main-heading');
    if (selectedValue === "ranking-ogolny") {
        mainHeading.textContent = "Ranking ogólny";
    document.getElementById('ranking-ogolny').style.display = 'block';
            } else if (selectedValue === "ligi-prywatne") {
        mainHeading.textContent = "Ranking lig prywatnych";
    document.getElementById('ligi-prywatne').style.display = 'block';
            }
        }