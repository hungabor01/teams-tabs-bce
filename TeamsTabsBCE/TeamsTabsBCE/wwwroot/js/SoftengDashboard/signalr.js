setupConnection();

function setupConnection() {
    var connection = new signalR.HubConnectionBuilder()
        .withUrl("/softeng-dashboard-hub")
        .build();

    connection.on("RefreshDashboard", function () {
        location.reload();
    });

    connection.start();
}