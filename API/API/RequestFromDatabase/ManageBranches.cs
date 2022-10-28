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
                "VALUES ('{0}' , convert(date,'{1}',103), conver(date, '{2}',103) , {3} , '{4}' , '{5}', '{6}' , '{7}')",
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
        
    
}