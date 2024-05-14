// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const initializeSignalRConnection = (accessToken) => {
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/user-counter", {
            accessTokenFactory: () => accessToken,
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

    connection.on("UserMessageReceived", (message) => {
        debugger;
        console.log(message);
    });

    connection.on("UserClickAlreadyReceived", ({ id, email, counter }) => {
        const tr = document.getElementById(id + "-row");

        if (!tr.classList.contains("already-clicked"))
            tr.classList.add("already-clicked");
    });

    connection.start().catch(err => console.error(err.toString()));

    return connection;
}

var connection = null;

const connectUser = async (userEmail) => {

    const response = await fetch("/auth/token/", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            userId: userEmail,
            password: "Test.1234!"
        })
    });

    const result = await response.json();
    const accessToken = result.accessToken;
    this.connection = initializeSignalRConnection(accessToken);
}


const clickAction = (userId) => {
    const tr = document.getElementById(userId + "-row");
    tr.classList.remove("already-clicked");

    //fetch("/users/" + userId + "/new-click", {
    //    method: "POST",
    //    headers: {
    //        'Content-Type': 'application/json'
    //    }
    //});

    //No longer required to reload the page since SignalR will refresh the data in a smoother way
    //location.reload();

    //No longed need if we directly notify from the hub of the server when the POST is done
    connection.invoke("NotifyClick", userId);
}

