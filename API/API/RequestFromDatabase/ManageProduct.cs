using API.DataBaseQueries;
using API.Models;

namespace API.RequestFromDatabase;

public class ManageProduct {
        private DataBaseManager dataBaseManager= new DataBaseManager();
    
    /**
     * Gets the specified product
     */
    public Product getProduct(string nombre) {
        
        List<List<String>> productList =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                    "FROM Producto " +
                                                                    "WHERE nombre='{0}'",nombre));
        
        List<List<String>> productos_por_proveedor =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                    "FROM Producto_por_Proveedor " +
                                                                    "WHERE nombre_producto ='{0}'",nombre ));

        Product product = new Product();

        if (productList.Count!=0) {
            if (!productList[0][0].Equals("")) {
                product.nombre = productList[0][0];
                product.marca  = productList[0][1];
                product.costo = Convert.ToInt32(productList[0][2]);

                // Uncomment when the Provider class has productList 
                for (int i = 0; i < productos_por_proveedor.Count; i++) {
                    product.proveedores.Add(productos_por_proveedor[i][0]);
                }
            }
        }

        return product;

    }
    
    /**
     * Returns all of the products
     */
    public List<Product> getAllProducts() {
        
        List<List<String>> productList =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                        "FROM Producto "));
        
        List<List<String>> productos_por_proveedor =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                        "FROM Producto_por_Proveedor "));

        List<Product> allProducts = new List<Product>();
        Product product = new Product();

        for (int i = 0; i < productList.Count; i++) {
            
            if (!productList[i][0].Equals("")) {
                product.nombre = productList[i][0];
                product.marca  = productList[i][1];
                product.costo = Convert.ToInt32(productList[i][2]);

                // Uncomment when the Provider class has productList 
                for (int j = 0; j < productos_por_proveedor.Count; j++)
                    if(productos_por_proveedor[j][1].Equals(product.nombre))
                        product.proveedores.Add(productos_por_proveedor[j][0]);

            }

            allProducts.Add(product);
            product = new Product();

        }
        
        return allProducts;
    }

    /**
     * Adds a new product
     */
    public bool addProduct(Product newProduct) {
        
        if (getProduct(newProduct.nombre).nombre.Equals("")) {

            string queryString = string.Format(
                "INSERT INTO Producto (nombre, marca, costo)" +
                " VALUES ('{0}', '{1}' , {2})",
                newProduct.nombre, newProduct.marca, newProduct.costo);
            
            for (int i = 0; i < newProduct.proveedores.Count; i++) { 
                queryString += String.Format(
                "\n INSERT INTO Producto_por_Proveedor(cedula_proveedor, nombre_producto)" +
                " VALUES ({0},'{1}')",
                newProduct.proveedores[i], newProduct.nombre); 
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
     * Deletes the specified product
     */
    public bool deletePrduct(string nombre) {

        if (!getProduct(nombre).nombre.Equals("")) {

            dataBaseManager.ExecuteQuery(String.Format("DELETE FROM Producto_por_Proveedor " + 
                                                        "WHERE nombre_producto = '{0}'" +
                                                        "DELETE FROM Producto_por_Factura " +
                                                        "WHERE nombre_producto='{0}'" +
                                                        "DELETE FROM Productos_por_Lavado " +
                                                        "WHERE nombre_producto = '{0}'"+
                                                        "DELETE FROM Producto " + 
                                                        "WHERE nombre = '{0}' ",nombre));
            return true;
        }

        return false;

    }
    
    /**
     * Updated the database with the information of the product
     */
    public bool updateProduct(Product newProduct) {

        Product updatedProduct = getProduct(newProduct.nombre);

        if (updatedProduct.nombre.Equals(""))
            return false;

        if (!newProduct.marca.Equals(""))
                dataBaseManager.ExecuteQuery(String.Format("UPDATE Producto " +
                                                        "SET marca = '{0}' " +
                                                        "WHERE nombre = '{1}';", 
                                                        newProduct.marca, newProduct.nombre));
        
        if (newProduct.costo!=0)
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Producto " +
                                                       "SET costo = {0} " +
                                                       "WHERE nombre = '{1}';", 
                                                        newProduct.costo, newProduct.nombre));

        return true;

    }
}