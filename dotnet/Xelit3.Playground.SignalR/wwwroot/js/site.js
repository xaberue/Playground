// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const initializeSignalRConnection = () => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/user-counter", {
            transport: signalR.HttpTransportType.WebSockets,
            skipNegotiation: true
            })
        .build();

    connection.on("UserClickReceived", ({ id, email, counter }) => {
        const rowId = id + "-row";
        const tr = document.getElementById(rowId);
        
        tr.classList.add("animate-highlight");
        setTimeout(() => tr.classList.remove("animate-highlight"), 2000);

        const currentCounter = document.getElementById(id + "-counter");
        currentCounter.innerHTML = counter;
    });


    connection.start().catch(err => console.error(err.toString()));

    return connection;
}

const connection = initializeSignalRConnection();

const clickAction = (userId) => {
    fetch("/users/" + userId + "/new-click", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        }
    });

    //No longer required to reload the page since SignalR will refresh the data in a smoother way
    //location.reload();

    connection.invoke("NotifyClick", userId);
}

