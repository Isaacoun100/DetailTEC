namespace API.DataBaseQueries;

using Microsoft.Data.SqlClient;

public class DataBaseManager {
    
    public SqlDataReader ReadOrderData(string queryString) {
        
        string connectionString = @"Server=DESKTOP-E6SO50B\SQL_DETAILTEC;
                                    Database=DetailTEC_DB;
                                    Integrated Security=True;
                                    TrustServerCertificate=True";
        SqlDataReader reader = null;
        
        using (SqlConnection connection = new SqlConnection(connectionString)) {
            SqlCommand command = new SqlCommand( queryString, connection);

            try { connection.Open(); }
            catch (Exception e) { Console.WriteLine("Could'nt connect to the Database with error" + "\n" + e); }

            try{reader = command.ExecuteReader();}
            catch(Exception e){ Console.WriteLine("Couldn't fulfill the request");}
            
            connection.Close();

            return reader;
        }
    }
}