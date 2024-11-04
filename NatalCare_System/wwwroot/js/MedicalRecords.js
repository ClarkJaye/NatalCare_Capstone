document.addEventListener('DOMContentLoaded', function () {
    // Get the current patient ID
    var currentPatientID = document.getElementById('patID').value;
    // Get the stored from localStorage
    var storedPatientID = localStorage.getItem('currentPatientID');
    var activeTab = localStorage.getItem('activeTab');

    // Check if the patient has changed
    if (currentPatientID !== storedPatientID) {
        // Reset the tab to Prenatal if the patient is different
        localStorage.removeItem('activeTab');
        localStorage.setItem('currentPatientID', currentPatientID);
        activeTab = '#prenatal';
    }
    // Show the active tab
    if (activeTab) {
        var tab = new bootstrap.Tab(document.querySelector(`a[href="${activeTab}"]`));
        tab.show();
    }
    // Save the active tab and patient ID to localStorage when a tab is clicked
    var tabLinks = document.querySelectorAll('.nav-tabs .nav-link');
    tabLinks.forEach(function (tabLink) {
        tabLink.addEventListener('shown.bs.tab', function (event) {
            var activeTab = event.target.getAttribute('href');
            localStorage.setItem('activeTab', activeTab);
            localStorage.setItem('currentPatientID', currentPatientID);
        });
    });

});