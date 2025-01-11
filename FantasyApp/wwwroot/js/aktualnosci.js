document.querySelectorAll('.pagination button').forEach(button => {
    button.addEventListener('click', (event) => {
        // Usuwanie klasy "active" z wszystkich przycisków
        document.querySelectorAll('.pagination button').forEach(btn => btn.classList.remove('active'));

        // Dodanie klasy "active" do klikniętego przycisku
        event.target.classList.add('active');

        // Przykładowa logika: wyświetlenie komunikatu o zmianie strony
        const page = event.target.textContent;
        console.log(`Przełączono na stronę ${page}`);
    });
});