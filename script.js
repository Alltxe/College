document.addEventListener('DOMContentLoaded', function() {
    const alertButton = document.getElementById('alertButton');
    if (alertButton) {
        alertButton.addEventListener('click', function() {
            alert('Button clicked!');
        });
    }

    const buyButtons = document.querySelectorAll('[id^="buyButton"]');
    buyButtons.forEach(button => {
        button.addEventListener('click', function() {
            alert('Product purchased!');
        });
    });

    const feedbackForm = document.getElementById('feedbackForm');
    if (feedbackForm) {
        feedbackForm.addEventListener('submit', function(event) {
            event.preventDefault();
            alert('Form submitted!');
        });
    }

    const aboutImage = document.getElementById('aboutImage');
    if (aboutImage) {
        aboutImage.addEventListener('click', function() {
            alert('Image clicked!');
        });
    }
});