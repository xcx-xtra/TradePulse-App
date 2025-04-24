let connection;

window.startSignalR = async function (dotNetObj) {
  connection = new signalR.HubConnectionBuilder().withUrl("/markethub").build();

  connection.on("ReceiveMarketEvent", (data) => {
    if (dotNetObj) {
      dotNetObj
        .invokeMethodAsync("ReceiveMarketEvent", data)
        .catch((err) => console.error("JS -> .NET call failed", err));
    }
  });

  connection.onclose(() => {
    console.warn("SignalR disconnected.");
  });

  await connection.start();
};

window.stopSignalR = async function () {
  if (connection) {
    await connection.stop();
    connection = null;
  }
};
