    document.addEventListener('DOMContentLoaded', function () {
        const sections = document.querySelectorAll('.content-section');
    const sectionId = window.location.hash.substring(1); // Pobierz fragment z URL
    console.log(sectionId)
    // Domyślnie pokaż sekcję "team", jeśli nie ma hash w URL
    let activeSectionId = sectionId || 'team';

        // Usuń klasę ukrywającą po załadowaniu strony
        sections.forEach(section => {
            if (section.id === activeSectionId) {
        section.classList.add('active'); // Ustaw aktywną sekcję
            } else {
        section.classList.remove('active');
            }
    section.classList.remove('hidden-before-load'); // Usuń ukrywanie
        });

    // Scroll do sekcji, jeśli fragment jest w URL
        if (sectionId) {
            history.replaceState(null, null, ' ');
            const section = document.getElementById(sectionId);
            if (section) {
                showSection(sectionId); // Ustaw aktywną sekcję
            }
        }
    });


function showSection(sectionId) {
    const sections = document.querySelectorAll('.content-section');
    const buttons = document.querySelectorAll('.nav-button');

    sections.forEach(section => {
        if (section.id === sectionId) {
            section.classList.add('active');
        } else {
            section.classList.remove('active');
        }
    });

    buttons.forEach(button => {
        if (button.getAttribute('onclick').includes(sectionId)) {
            button.classList.add('active');
        } else {
            button.classList.remove('active');
        }
    });
}
