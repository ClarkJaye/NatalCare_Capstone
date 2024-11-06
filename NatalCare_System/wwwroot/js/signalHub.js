//Create Connection
var connectionQueueHub = new signalR.HubConnectionBuilder().withUrl("/NatalCare.DataAccess/hubs/natalCareHub").build();


connectionQueueHub.on("LoadPatients", function () {
    LoadAllPatientsComponent();
});

function fulfilled() {
    console.log("Connection Successful");
}

function rejected() {
    console.log("Connection failed");
}

// Start connection
connectionQueueHub.start().then(fulfilled, rejected);