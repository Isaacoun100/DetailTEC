namespace API.RequestFromDatabase;

using API.DataBaseQueries;
using API.Models;

public class ManageEmployees {
    
    private DataBaseManager dataBaseManager= new DataBaseManager();
    
    public Employee getEmployee(string cedula) {
        
        List<List<String>> data =  dataBaseManager.ReadOrderData("SELECT * " +
                                            "FROM Trabajador " +
                                            "WHERE cedula="+cedula);

        Employee employee = new Employee();

        if (data.Count!=0) {
            if (data[0][0].Contains("")) {
                
                employee.cedula = Convert.ToInt32(data[0][0]);
                employee.nombre  = data[0][1];
                employee.apellidos  = data[0][2];
                employee.contrasena  = data[0][3];
                employee.edad = Convert.ToInt32(data[0][4]);
                employee.fechaNacimiento = DateTime.Parse(data[0][5]).ToShortDateString();
                employee.fechaIngreso = DateTime.Parse(data[0][6]).ToShortDateString();
                employee.tipoPago = data[0][7];
                employee.rol = data[0][8];

                if (data[0][9].Equals("true"))
                    employee.isGerente = true;
                else
                    employee.isGerente = false;

            }
        }

        return employee;

    }
    
    public List<Employee> GetAllEmployees() {
        
        List<List<String>> data =  dataBaseManager.ReadOrderData("SELECT * " +
                                                                 "FROM Trabajador;");

        List<Employee> employeeList = new List<Employee>();
        Employee employee = new Employee();

        for (int i = 0; i < data.Count; i++) {
            if (data[i][0].Contains("")) {
                
                employee.cedula = Convert.ToInt32(data[i][0]);
                employee.nombre  = data[i][1];
                employee.apellidos  = data[i][2];
                employee.contrasena  = data[i][3];
                employee.edad = Convert.ToInt32(data[i][4]);
                employee.fechaNacimiento = data[i][5];
                employee.fechaIngreso = data[i][6];
                employee.tipoPago = data[i][7];
                employee.rol = data[i][8];
                
                if (data[i][9].Equals("true"))
                    employee.isGerente = true;
                else
                    employee.isGerente = false;

            }

            employeeList.Add(employee);
            employee= new Employee();

        }

        return employeeList;

    }

    public bool addEmployee(Employee newEmployee) {

        if (!getEmployee(newEmployee.cedula.ToString()).cedula.Equals('0')) {

            string queryString = string.Format(
                "INSERT INTO Trabajador (cedula, nombre, apellidos, contrasena, edad, fechaNacimiento, fechaIngreso, tipoPago, rol, isGerente)" +
                " VALUES ({0} , '{1}' , '{2}' , '{3}' , '{4}' , convert(date,'{5}',103) , convert(date,'{6}',103) , '{7}','{8}','{9}')",
                newEmployee.cedula, newEmployee.nombre, newEmployee.apellidos, newEmployee.contrasena, newEmployee.edad,
                newEmployee.fechaNacimiento, newEmployee.fechaIngreso, newEmployee.tipoPago, newEmployee.rol, newEmployee.isGerente);

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
    
    public bool deleteEmployee(string cedula) {

        if (getEmployee(cedula).cedula!=0) {

            dataBaseManager.ExecuteQuery(String.Format( "DELETE FROM Trabajador" +
                                         " WHERE cedula = {0};",cedula));
            return true;
        }

        return false;

    }

    public bool updateEmployee(Employee newEmployee) {
        
        Employee updatedEmployee = getEmployee(newEmployee.cedula.ToString());

        if (updatedEmployee.cedula==0)
            return false;

        if (!newEmployee.nombre.Equals(""))
                dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                        "SET nombre = '{0}' " +
                                                        "WHERE cedula = {1};", 
                                                        newEmployee.nombre, newEmployee.cedula));
        if (!newEmployee.apellidos.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET apellidos = '{0}' " +
                                                       "WHERE cedula = {1};", 
                                                        newEmployee.apellidos, newEmployee.cedula));
        if (!newEmployee.contrasena.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET contrasena = '{0}' " +
                                                       "WHERE cedula = {1};", 
                                                         newEmployee.contrasena, newEmployee.cedula));
        if (newEmployee.edad!=0)
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET edad = {0} " +
                                                       "WHERE cedula = {1};", 
                                                        newEmployee.edad, newEmployee.cedula));
        if (!newEmployee.fechaNacimiento.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET fechaNacimiento = convert(date,'{0}',103) " +
                                                       "WHERE cedula = {1};", 
                                                        newEmployee.fechaNacimiento, newEmployee.cedula));
        if (!newEmployee.fechaIngreso.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET fechaIngreso = convert(date,'{0}',103) " +
                                                       "WHERE cedula = {1};", 
                                                        newEmployee.fechaIngreso, newEmployee.cedula));
        if (!newEmployee.tipoPago.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET tipoPago = '{0}' " +
                                                       "WHERE cedula = {1};", 
                                                       newEmployee.tipoPago, newEmployee.cedula));
        if (!newEmployee.rol.Equals(""))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET rol = '{0}' " +
                                                       "WHERE cedula = {1};", 
                                                        newEmployee.rol, newEmployee.cedula));
        if (!newEmployee.isGerente.Equals(null))
            dataBaseManager.ExecuteQuery(String.Format("UPDATE Trabajador " +
                                                       "SET isGerente = '{0}' " +
                                                       "WHERE cedula = {1};", 
                                                        newEmployee.isGerente, newEmployee.cedula));

        return true;

    }
    
    public Employee loginEmployee(string cedula, string contrasena) {

        List<List<String>> data = dataBaseManager.ReadOrderData(String.Format(
            "SELECT * FROM Trabajador " +
            "WHERE cedula={0} AND contrasena='{1}';", cedula, contrasena));

        Employee employee = new Employee();

        if (data.Count!=0) {
            if (data[0][0].Contains("")) {
                
                employee.cedula = Convert.ToInt32(data[0][0]);
                employee.nombre  = data[0][1];
                employee.apellidos  = data[0][2];
                employee.contrasena  = data[0][3];
                employee.edad = Convert.ToInt32(data[0][4]);
                employee.fechaNacimiento = DateTime.Parse(data[0][5]).ToShortDateString();
                employee.fechaIngreso = DateTime.Parse(data[0][6]).ToShortDateString();
                employee.tipoPago = data[0][7];
                employee.rol = data[0][8];

                if (data[0][9].Equals("true"))
                    employee.isGerente = true;
                else
                    employee.isGerente = false;

            }
        }

        return employee;
    }
    
}