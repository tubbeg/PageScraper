"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/scraperHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ScrapeResult", function (message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    //var li = document.createElement("li");
    //li.textContent = msg;
    //document.getElementById("messagesList").appendChild(li);
    var img = document.createElement("img");
    img.src = msg;
    var src = document.getElementById("imageList");
    src.appendChild(img);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var message = document.getElementById("messageInput").value;
    connection.invoke("ReceiveUrl", message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});