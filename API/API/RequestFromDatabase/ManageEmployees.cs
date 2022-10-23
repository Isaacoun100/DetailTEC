namespace API.RequestFromDatabase;

using Microsoft.Data.SqlClient;
using API.DataBaseQueries;
using API.Models;

public class ManageEmployees {
    
    private DataBaseManager dataBaseManager = new DataBaseManager();
    
    public Employee getEmployee(string cedula) {

        SqlDataReader data = null;
        data = dataBaseManager.ReadOrderData("SELECT * " +
                                             "FROM Trabajador " +
                                             "WHERE cedula=" + cedula);

        Employee employee = new Employee();

        if (data[0] != null)
            employee.cedula = Convert.ToInt32(data[0]);
        else
            return new Employee();
            
        employee.nombre = data[1].ToString();
        employee.apellidos = data[2].ToString();
        employee.contrasena = data[3].ToString();
        employee.edad = Convert.ToInt32(data[4]);
        employee.fechaNacimiento = data[5].ToString();
        employee.fechaIngreso = data[6].ToString();
        employee.tipoPago = data[7].ToString();
        employee.rol = data[8].ToString();

        //if (data[9].ToString().Contains("1")) 
        //    employee.isGerente = true;
        //else
        //    employee.isGerente = false;

        return employee;

    }
}