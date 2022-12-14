using API.DataBaseQueries;
using API.Models;

namespace API.RequestFromDatabase; 

public class ManageProviders {
    

    private DataBaseManager dataBaseManager= new DataBaseManager();
    
    /**
     * Returns the provider of the specified cedulaJuridica
     */
    public Provider getProvider(string cedulaJuridica) {
        
        List<List<String>> proveedor =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                    "FROM Proveedor " +
                                                                    "WHERE cedulaJuridica={0}",cedulaJuridica));
        
        List<List<String>> productos_por_proveedor =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                    "FROM Producto_por_Proveedor " +
                                                                    "WHERE cedula_proveedor ={0}",cedulaJuridica));

        Provider provider = new Provider();

        if (proveedor.Count!=0) {
            if (!proveedor[0][1].Equals("0")) {
                provider.nombre = proveedor[0][0];
                provider.cedulaJuridica  = Convert.ToInt32(proveedor[0][1]);
                provider.direccion = proveedor[0][2];
                provider.correo = proveedor[0][3];
                provider.contacto = proveedor[0][4];

                // Uncomment when the Provider class has productList 
                for (int i = 0; i < productos_por_proveedor.Count; i++) {
                    provider.productList.Add(productos_por_proveedor[i][0]);
                }
                
            }
        }

        return provider;

    }
    
    /**
     * Returns all the providers from the database in a list of providers
     */
    public List<Provider> getAllProviders() {
        
        List<List<String>> proveedor =  dataBaseManager.ReadOrderData(String.Format(
            "SELECT * " +
            "FROM Proveedor"));
        
        List<List<String>> productos_por_proveedor =  dataBaseManager.ReadOrderData(String.Format(
            "SELECT * " +
            "FROM Producto_por_Proveedor "));

        List<Provider> providerList = new List<Provider>();
        Provider provider = new Provider();

        for (int i = 0; i < proveedor.Count; i++) {
            
            if (!proveedor[i][1].Equals('0')) {
                provider.nombre = proveedor[i][0];
                provider.cedulaJuridica  = Convert.ToInt32(proveedor[i][1]);
                provider.direccion = proveedor[i][2];
                provider.correo = proveedor[i][3];
                provider.contacto = proveedor[i][4];

                //Uncomment when the Provider class has productList 
                for (int j = 0; j < productos_por_proveedor.Count; j++)
                    if(productos_por_proveedor[j][0].Equals(provider.cedulaJuridica.ToString()))
                        provider.productList.Add(productos_por_proveedor[j][1]);

            }

            providerList.Add(provider);
            provider = new Provider();

        }
        
        return providerList;
    }

    /**
     *  Adds a new provider to the database
     */
    public bool addProvider(Provider newProvider) {
        
        if (!getProvider(newProvider.cedulaJuridica.ToString()).cedulaJuridica.Equals('0')) {

            string queryString = string.Format(
                "INSERT INTO Proveedor (nombre, cedulaJuridica, direccion, correo, contacto)" +
                " VALUES ('{0}', {1} , '{2}' , '{3}' , '{4}' )",
                newProvider.nombre, newProvider.cedulaJuridica, newProvider.direccion,
                newProvider.correo, newProvider.contacto);


                for (int i = 0; i < newProvider.productList.Count; i++) {
                queryString += string.Format(
                    "\n INSERT INTO Producto_por_Proveedor(cedula_proveedor, nombre_producto)" +
                    " VALUES ({0},'{1}')",
                    newProvider.cedulaJuridica, newProvider.productList[i]);
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
    
    /**
     * Deletes the specified provider
     */
    public bool deleteProvider(string cedulaJuridica) {

        if (!getProvider(cedulaJuridica).cedulaJuridica.Equals("0")) {

            dataBaseManager.ExecuteQuery(String.Format("DELETE FROM Producto_por_Proveedor " + 
                                                        "WHERE cedula_proveedor = {0} "+
                                                        "DELETE FROM Proveedor " + 
                                                        "WHERE cedulaJuridica = {0} ",cedulaJuridica));
            return true;
        }

        return false;

    }
    
    /**
     * Updates the information from the provider
     */
        public bool updateProvider(Provider newProvider) {

        Provider updatedProvider = getProvider(newProvider.cedulaJuridica.ToString());

        if (updatedProvider.cedulaJuridica.ToString().Equals("0"))
            return false;

        if (!newProvider.nombre.Equals(""))
                dataBaseManager.ExecuteQuery(String.Format("UPDATE Proveedor " +
                                                        "SET nombre = '{0}' " +
                                                        "WHERE cedulaJuridica = {1};", 
                                                        newProvider.nombre, newProvider.cedulaJuridica));
        
        if (!newProvider.direccion.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Proveedor " +
                                                       "SET direccion = '{0}' " +
                                                       "WHERE cedulaJuridica = {1};", 
                                                        newProvider.direccion, newProvider.cedulaJuridica));

        if (!newProvider.correo.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Proveedor " +
                                                       "SET correo = '{0}' " +
                                                       "WHERE cedulaJuridica = {1};", 
                                                        newProvider.correo, newProvider.cedulaJuridica));
        if (!newProvider.contacto.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Proveedor " +
                                                       "SET contacto = '{0}' " +
                                                       "WHERE cedulaJuridica = {1};", 
                                                        newProvider.contacto, newProvider.cedulaJuridica));

        return true;

    }
    
    
    
}