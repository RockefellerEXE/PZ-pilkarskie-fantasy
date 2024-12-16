function showSection(sectionId) {
    // Ukrywamy wszystkie sekcje
    const sections = document.querySelectorAll('.content-section');
    sections.forEach(section => section.classList.remove('active'));

    // Deaktywujemy przyciski
    const buttons = document.querySelectorAll('.nav-button');
    buttons.forEach(button => button.classList.remove('active'));

    // Wyświetlamy odpowiednią sekcję
    document.getElementById(sectionId).classList.add('active');

    // Aktywujemy odpowiedni przycisk
    const activeButton = Array.from(buttons).find(button => button.onclick.toString().includes(sectionId));
    if (activeButton) activeButton.classList.add('active');
}
