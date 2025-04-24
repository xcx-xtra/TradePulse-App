let connection;

window.startSignalR = (dotNetObj) => {
  connection = new signalR.HubConnectionBuilder().withUrl("/markethub").build();

  connection.on("ReceiveMarketEvent", (data) => {
    dotNetObj.invokeMethodAsync("ReceiveMarketEvent", data);
  });

  connection.start().catch((err) => console.error(err.toString()));
};
