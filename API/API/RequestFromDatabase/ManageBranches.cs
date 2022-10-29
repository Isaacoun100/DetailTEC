using API.Models;
using API.DataBaseQueries;

namespace API.RequestFromDatabase; 

public class ManageBranches {
    
    private DataBaseManager dataBaseManager= new DataBaseManager();

    public Branch getBranch(string nombre)
    {

        List<List<String>> data = dataBaseManager.ReadOrderData(String.Format(
            "SELECT * FROM Sucursal " +
            "WHERE nombre ='{0}'", nombre));
        Branch branch = new Branch();
        List<string> ubicaciones = new List<string>();

        if (data.Count!=0)
        {
            if (!data[0][0].Equals(""))
            {
                branch.nombre = data[0][0];
                branch.fechaApertura = data[0][2];
                branch.fechaInicioGerente = data[0][1];
                branch.telefono = data[0][4];
                ubicaciones.Add(data[0][5]);
                ubicaciones.Add(data[0][6]);
                ubicaciones.Add(data[0][7]);
                branch.ubicacion = ubicaciones;
                try
                {

                    branch.gerente = Convert.ToInt32(data[0][3]);
                    
                }
                catch (Exception e)
                {
                    branch.gerente = 0;
                    
                }
            }
            
        }

        return branch;

    }
    
    public bool addBranch(Branch newBranch)
    {
        if (!getBranch(newBranch.nombre).nombre.Equals(newBranch.nombre))
        {
            string queryString = string.Format(
                "INSERT INTO Sucursal (nombre, fechaInicioGerente, fechaApertura, gerente, telefono, provincia, canton, distrito)" +
                "VALUES ('{0}' , convert(date,'{1}',103), convert(date, '{2}',103) , {3} , '{4}' , '{5}', '{6}' , '{7}')",
                newBranch.nombre, newBranch.fechaInicioGerente, newBranch.fechaApertura, newBranch.gerente,
                newBranch.telefono,
                newBranch.ubicacion[0], newBranch.ubicacion[1], newBranch.ubicacion[2]);
            
            Console.WriteLine(queryString);
            try
            {
                dataBaseManager.ExecuteQuery(queryString);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        return false;
    }
    
    
    public List<Branch> getAllBranches()
    {
        List<List<String>> data =  dataBaseManager.ReadOrderData("SELECT * " +
                                                                 "FROM Sucursal;");


        List<Branch> allBranches = new List<Branch>();
        Branch branch = new Branch();
        List<string> ubicaciones = new List<string>();
        
        for (int i = 0; i < data.Count; i++)
        {
            if (!data[i][0].Equals(""))
            {
                branch.nombre = data[i][0];
                branch.fechaInicioGerente = data[i][1];
                branch.fechaApertura = data[i][2];
                try
                {
                    branch.gerente = Convert.ToInt32(data[i][3]);

                }
                catch (Exception e)
                {
                    branch.gerente = 0;
                }
                ubicaciones.Add(data[i][4]);
                ubicaciones.Add(data[i][5]);
                ubicaciones.Add(data[i][6]);
                branch.ubicacion = ubicaciones;
                ubicaciones.Clear();
                allBranches.Add(branch);

            }
        }

        return allBranches;
    }
    
     public bool deleteBranch(string branchName)
    {
        if (!getBranch(branchName).nombre.Equals(""))
        {
            dataBaseManager.ExecuteQuery(String.Format("DELETE FROM Sucursal " +
                                                       "WHERE nombre ='{0}' ",
                                                       branchName));
                                                       
            return true;
        }

        return false;
    }

    public bool updateBranch(Branch updateBranch)
    {
        Branch branch = getBranch(updateBranch.nombre);
        if (branch.nombre.Equals(""))
        {
            return false;
        }

        if (!updateBranch.telefono.Equals(""))
        {
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Sucursal " +
                                                       "SET telefono = '{0}' " +
                                                       "WHERE nombre = '{1}';",
                updateBranch.telefono,updateBranch.nombre ));
        }

        if (!updateBranch.fechaApertura.Equals(""))
        {
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Sucursal " +
                                                       "SET  fechaApertura= convert(date,'{0}',103) " +
                                                       "WHERE nombre = '{1}';",
                updateBranch.fechaApertura, updateBranch.nombre));
            
        }

        if (!updateBranch.fechaInicioGerente.Equals(""))
        {
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Sucursal " +
                                                       "SET  fechaInicioGerente= convert(date,'{0}',103) " +
                                                       "WHERE nombre = '{1}';",
                updateBranch.fechaInicioGerente, updateBranch.nombre));
            
        }

        if (!updateBranch.gerente.Equals(0))
        {
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Sucursal " +
                                                       "SET  gerente= {0} " +
                                                       "WHERE nombre = '{1}';",
                updateBranch.gerente, updateBranch.nombre));
            
        }

        if (updateBranch.ubicacion.Count != 0)
        {
            if (!updateBranch.ubicacion[0].Equals(""))
            {
                dataBaseManager.ExecuteQuery(String.Format("UPDATE Sucursal " +
                                                           "SET  provincia= '{0}' " +
                                                           "WHERE nombre = '{1}';",
                    updateBranch.ubicacion[0], updateBranch.nombre));
            }
            
            if (!updateBranch.ubicacion[1].Equals(""))
            {
                dataBaseManager.ExecuteQuery(String.Format("UPDATE Sucursal " +
                                                           "SET  canton= '{0}' " +
                                                           "WHERE nombre = '{1}';",
                    updateBranch.ubicacion[1], updateBranch.nombre));
            }
            
            if (!updateBranch.ubicacion[2].Equals(""))
            {
                dataBaseManager.ExecuteQuery(String.Format("UPDATE Sucursal " +
                                                           "SET distrito= '{0}' " +
                                                           "WHERE nombre = '{1}';",
                    updateBranch.ubicacion[2], updateBranch.nombre));
            }
            
            
            
        }

        return true;
    }
    
}