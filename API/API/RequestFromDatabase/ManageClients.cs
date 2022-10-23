namespace API.RequestFromDatabase;

using Microsoft.Data.SqlClient;
using API.DataBaseQueries;
using API.Models;


public class ManageClients {
    
    private DataBaseManager dataBaseManager = new DataBaseManager();
    
    public Client getClient(string cedula) {

        SqlDataReader data = null;
        data = dataBaseManager.ReadOrderData("SELECT * " +
                                             "FROM Cliente " +
                                             "WHERE cedula=" + cedula);

        Client client = new Client();
        
        client.cedula = Convert.ToInt32(data[0]);
        client.nombreCompleto = data[1].ToString();
        client.puntos = Convert.ToInt32(data[2]);
        client.contrasena = data[3].ToString();
        client.correo = data[4].ToString();
        client.usuario = data[5].ToString();
        client.direccion = data[6].ToString();

        return client;

    }
    
}