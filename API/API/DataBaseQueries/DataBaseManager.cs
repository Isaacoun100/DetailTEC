namespace API.DataBaseQueries;

using Microsoft.Data.SqlClient;

public class DataBaseManager {
    
    /**
     * Reads the data received from the query
     */
    public List<List<String>> ReadOrderData(string queryString) {
        
        string connectionString = @"Server=LAPTOP\SQL_DETAILTEC;
                                    Database=DetailTEC_DB;
                                    Integrated Security=True;
                                    TrustServerCertificate=True";
        SqlDataReader reader = null;
        
        using (SqlConnection connection = new SqlConnection(connectionString)) {
            SqlCommand command = new SqlCommand( queryString, connection);

            try { connection.Open(); }
            catch (Exception e) { Console.WriteLine("Couldn't connect to the Database with error" + "\n" + e); }

            try{reader = command.ExecuteReader();}
            catch(Exception e){ Console.WriteLine("Couldn't fulfill the request");}

            List<String> temp = new List<string>();
            List<List<String>> result = new List<List<string>>();

            for (int i = 0; reader.Read() ; i++) {

                for (int j = 0; j < reader.FieldCount; j++)
                    temp.Add(String.Format("{0}", reader[j]));

                result.Add(temp);
                temp=new List<string>();
            }

            return result;
        }
    }

    /**
     * Excecutes a query, no response
     */
    public bool ExecuteQuery(string queryString) {
        
        string connectionString = @"Server=DESKTOP-E6SO50B\SQL_DETAILTEC;
                                    Database=DetailTEC_DB;
                                    Integrated Security=True;
                                    TrustServerCertificate=True";

        try {
            using var sc = new SqlConnection(connectionString);
            using var cmd = sc.CreateCommand();
            sc.Open();
            cmd.CommandText = queryString;
            cmd.ExecuteNonQuery();
            return true;
        }
        catch (Exception e) {
            Console.WriteLine(e);
            return false;
        }
    }
}