const xValues = ["PAID", "PARTIAL", "PENDING"];
const yValues = [0, 0, 0]; // Initialize with zeros or default values
const barColors = [
    "#4CAF50", // Color for PAID
    "#FF9800", // Color for PARTIAL
    "red"      // Color for PENDING
];

const myChart = new Chart("myChart", {
    type: "pie",
    data: {
        labels: xValues,
        datasets: [{
            backgroundColor: barColors,
            data: yValues
        }]
    },
    options: {
        title: {
            display: true,
            text: "PAYMENT STATUS STATISTICS"
        }
    }
});

const xValues1 = ["Italy", "France", "Spain", "USA", "Argentina"];
const yValues1 = [55, 49, 44, 24, 15];
const barColors1 = ["red", "green", "blue", "orange", "brown"];

new Chart("myChart1", {
    type: "bar",
    data: {
        labels: xValues1,
        datasets: [{
            backgroundColor: barColors1,
            data: yValues1
        }]
    },
    options: {
        legend: { display: false },
        title: {
            display: true,
            text: "World Wine Production 2018"
        }
    }
});

$(document).ready(function () {
    $.ajax({
        url: '/Billing/GetPaymentStatusStatistics',
        type: 'GET',
        dataType: 'json', // Specify the expected response type
        success: function (response) {

            yValues[0] = response.paid;
            yValues[1] = response.partial;
            yValues[2] = response.pending;

            // Update the chart with new data
            myChart.data.datasets[0].data = yValues;
            myChart.update();

        },
        error: function (xhr, status, error) {
            console.error("AJAX Error:", status, error);
            alert("An error occurred while fetching data: " + error);
        }
    });
});