namespace API.RequestFromDatabase;

using API.DataBaseQueries;
using API.Models;


public class ManageClients {
    
    private DataBaseManager dataBaseManager= new DataBaseManager();
    
    public Client getClient(string cedula) {
        
        List<List<String>> data =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                            "FROM Cliente " +
                                            "WHERE cedula='{0}'",cedula));
        
        List<List<String>> numberData =  dataBaseManager.ReadOrderData(String.Format("SELECT telefono " +
                                            "FROM Telefonos_por_Cliente " +
                                            "WHERE cliente='{0}'",cedula));
        

        Client client = new Client();

        if (data.Count!=0) {
            if (!data[0][0].Equals("")) {
                client.cedula = data[0][0];
                client.nombreCompleto  = data[0][1];

                try { client.puntos = Convert.ToInt32(data[0][2]); }
                catch (Exception e) { client.puntos = 0; }
        
                client.contrasena = data[0][3];
                client.correo = data[0][4];
                client.usuario = data[0][5];
                client.direccion = data[0][6];

                for (int i = 0; i < numberData.Count; i++) {
                    client.telefonos.Add( Convert.ToInt32(numberData[i][0]) );
                }
                
            }
        }

        return client;

    }
    
    public List<Client> getAllClients() {
        
        List<List<String>> data =  dataBaseManager.ReadOrderData("SELECT * " +
                                                                 "FROM Cliente;");

        List<Client> clientList = new List<Client>();
        Client client = new Client();

        for (int i = 0; i < data.Count; i++) {
            if (!data[i][0].Equals("")) {
                client.cedula = data[i][0];
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

    public bool addClient(Client newClient) {

        if (!getClient(newClient.cedula).cedula.Equals("0")) {

            string queryString = string.Format(
                "INSERT INTO Cliente (cedula, nombreCompleto, puntos, contrasena, correo, usuario, direccion)" +
                " VALUES ('{0}','{1}',{2},'{3}','{4}','{5}','{6}')",
                newClient.cedula, newClient.nombreCompleto, newClient.puntos.ToString(), newClient.contrasena,
                newClient.correo, newClient.usuario, newClient.direccion);
            
            
            for (int i = 0; i < newClient.telefonos.Count; i++) {
                queryString += string.Format(
                    "\nINSERT INTO Telefonos_por_Cliente (cliente, telefono)" +
                    " VALUES ('{0}',{1})",
                    newClient.cedula, newClient.telefonos[i]);
            }
            
            Console.WriteLine(queryString);

            try {
                dataBaseManager.ExecuteQuery(queryString);
                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }

        }
        
        return false;
    }
    
    
    public bool addClientMobile(Client newClient) {

        if (!getClient(newClient.cedula).cedula.Equals("0")) {

            string queryString = string.Format(
                "INSERT INTO Cliente (cedula, nombreCompleto, puntos, contrasena, correo, usuario, direccion)" +
                " VALUES ('{0}','{1}',{2},'{3}','{4}','{5}','{6}')",
                newClient.cedula, newClient.nombreCompleto, newClient.puntos.ToString(), newClient.contrasena,
                newClient.correo, newClient.usuario, newClient.direccion);
            
            
            for (int i = 0; i < newClient.telefonos.Count; i++) {
                queryString += string.Format(
                    "\nINSERT INTO Telefonos_por_Cliente (cliente, telefono)" +
                    " VALUES ('{0}',{1})",
                    newClient.cedula, newClient.telefonos[i]);
            }
            
            Console.WriteLine(queryString);

            try {
                dataBaseManager.ExecuteQuery(queryString);
                return true;
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return false;
            }

        }
        
        return false;
    }
    
    
    
    public bool deleteClient(string cedula) {

        if (!getClient(cedula).cedula.Equals("")) {

            dataBaseManager.ExecuteQuery(String.Format("DELETE FROM Citas_por_Cliente " +
                                                       "WHERE cedula_cliente ='{0}' " +
                                                       "DELETE FROM Telefonos_por_Cliente " +
                                                       "WHERE cliente= '{0}' " +
                                                       "DELETE FROM Cliente " + 
                                                       "WHERE cedula = '{0}' ",cedula));
                                                       
            return true;
        }

        return false;

    }

    public bool updateClient(Client newClient) {

        Client updatedClient = getClient(newClient.cedula.ToString());

        if (updatedClient.cedula.Equals(""))
            return false;

        if (!newClient.nombreCompleto.Equals(""))
                dataBaseManager.ExecuteQuery(String.Format("UPDATE Cliente " +
                                                        "SET nombreCompleto = '{0}' " +
                                                        "WHERE cedula = '{1}';", 
                                                        newClient.nombreCompleto, newClient.cedula));
        if (newClient.puntos!=0)
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Cliente " +
                                                       "SET puntos = {0} " +
                                                       "WHERE cedula = '{1}';", 
                                                        newClient.puntos, newClient.cedula));
        
        if (!newClient.contrasena.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Cliente " +
                                                       "SET contrasena = '{0}' " +
                                                       "WHERE cedula = '{1}';", 
                                                        newClient.contrasena, newClient.cedula));
        
        if (!newClient.correo.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Cliente " +
                                                       "SET correo = '{0}' " +
                                                       "WHERE cedula = '{1}';", 
                                                        newClient.correo, newClient.cedula));
        
        if (!newClient.usuario.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Cliente " +
                                                       "SET usuario = '{0}' " +
                                                       "WHERE cedula = '{1}';", 
                                                        newClient.usuario, newClient.cedula));
        if (!newClient.direccion.Equals(""))    
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Cliente " +
                                                       "SET direccion = '{0}' " +
                                                       "WHERE cedula = '{1}';", 
                                                        newClient.direccion, newClient.cedula));

        return true;

    }

    public Client loginClient(string correo, string contrasena) {

        List<List<String>> data = dataBaseManager.ReadOrderData(String.Format(
            "SELECT * FROM Cliente " +
            "WHERE correo='{0}' AND contrasena='{1}';", correo, contrasena));

        Client client = new Client();

        if (data.Count != 0) {
            if (!data[0][0].Equals("")) {
                client.cedula = data[0][0];
                client.nombreCompleto = data[0][1];

                try {
                    client.puntos = Convert.ToInt32(data[0][2]);
                }
                catch (Exception e) {
                    client.puntos = 0;
                }

                client.contrasena = data[0][3];
                client.correo = data[0][4];
                client.usuario = data[0][5];
                client.direccion = data[0][6];
            }
        }

        return client;
    }
    
    public PointsManager getClientPoints(string ID)
    {
        List<List<String>> data =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                               "FROM Cliente " +
                                                                               "WHERE cedula='{0}'",ID));
        
        PointsManager pointsManager = new PointsManager();
        if (data.Count != 0)
        {
            pointsManager.cedula = data[0][0];
            try
            {
                pointsManager.puntos = data[0][2];
            }
            catch (Exception e)
            {
                pointsManager.puntos = "";
            }
            
        }

        return pointsManager;
    }
    
    
    
    
    
}