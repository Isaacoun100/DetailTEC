namespace API.RequestFromDatabase;

using Microsoft.Data.SqlClient;
using API.DataBaseQueries;
using API.Models;


public class ManageClients {
    
    private DataBaseManager dataBaseManager = new DataBaseManager();
    
    public Client getClient(string cedula) {
        
        List<List<String>> data =  dataBaseManager.ReadOrderData("SELECT * " +
                                            "FROM Cliente " +
                                            "WHERE cedula="+cedula);

        Client client = new Client();

        if (data.Count!=0) {
            if (data[0][0].Contains("")) {
                client.cedula = Convert.ToInt32(data[0][0]);
                client.nombreCompleto  = data[0][1];

                try { client.puntos = Convert.ToInt32(data[0][2]); }
                catch (Exception e) { client.puntos = 0; }
        
                client.contrasena = data[0][3];
                client.correo = data[0][4];
                client.usuario = data[0][5];
                client.direccion = data[0][6];
            }
        }

        return client;

    }
    
    public List<Client> getAllClients() {
        
        List<List<String>> data =  dataBaseManager.ReadOrderData("SELECT * " +
                                                                 "FROM Cliente");

        List<Client> clientList = new List<Client>();
        Client client = new Client();

        for (int i = 0; i < data.Count; i++) {
            if (data[i][0].Contains("")) {
                client.cedula = Convert.ToInt32(data[i][0]);
                client.nombreCompleto  = data[i][1];

                try { client.puntos = Convert.ToInt32(data[i][2]); }
                catch (Exception e) { client.puntos = 0; }
    
                client.contrasena = data[i][3];
                client.correo = data[i][4];
                client.usuario = data[i][5];
                client.direccion = data[i][6];
            }

            clientList.Add(client);
            client = new Client();

        }

        return clientList;

    }
    
    public bool addClient() {
        
        List<List<String>> data =  dataBaseManager.ReadOrderData("SELECT * " +
                                                                 "FROM Cliente");

        List<Client> clientList = new List<Client>();
        Client client = new Client();

        for (int i = 0; i < data.Count; i++) {
            if (data[i][0].Contains("")) {
                client.cedula = Convert.ToInt32(data[i][0]);
                client.nombreCompleto  = data[i][1];

                try { client.puntos = Convert.ToInt32(data[i][2]); }
                catch (Exception e) { client.puntos = 0; }
    
                client.contrasena = data[i][3];
                client.correo = data[i][4];
                client.usuario = data[i][5];
                client.direccion = data[i][6];
            }

            clientList.Add(client);
            client = new Client();

        }

        return clientList;

    }

}