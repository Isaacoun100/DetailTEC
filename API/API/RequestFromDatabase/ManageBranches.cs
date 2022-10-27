using API.Models;
using API.DataBaseQueries;

namespace API.RequestFromDatabase; 

public class ManageBranches {
    
    private DataBaseManager dataBaseManager= new DataBaseManager();

    public Branch getBranch(string nombre) {


        List<List<String>> data =  dataBaseManager.ReadOrderData(String.Format("SELECT * " +
                                                                               "FROM Sucursal " +
                                                                               "WHERE nombre='{0}'",nombre));
        Branch branch = new Branch();

        return branch;
    }
    
}