// Ensure this script is included in the layout

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

// Additional JavaScript logic can be added here as needed
