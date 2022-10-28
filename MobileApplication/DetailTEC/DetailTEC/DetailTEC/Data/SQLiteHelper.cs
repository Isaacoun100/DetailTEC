using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using DetailTEC.SQLite_Models;
using System.Threading.Tasks;

namespace DetailTEC.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            //db.CreateTableAsync<Client>().Wait();
            db.CreateTableAsync<Appointment>().Wait();
        }
        public Task<int> SaveAppointmentAsync(Appointment appo)
        {
            return appo.cliente == null ? db.InsertAsync(appo) : null;
             
        }
        
        public Task<int> SaveClientAsync(Client cli)
        {
            if (cli.cedula == null)
            {
                return db.InsertAsync(cli);
            }
            else
            {
                return null;
            }
        }
        public Task<List<Appointment>> GetAppointmentsAsync()
        {
            return db.Table<Appointment>().ToListAsync();
        }

        public Task<Appointment> GetAppointmentByIdAsync(string idCliente)
        {
            return db.Table<Appointment>().Where(a => a.cliente == idCliente).FirstOrDefaultAsync();
        }
        
        public Task<List<Client>> GetClientsAsync()
        {
            return db.Table<Client>().ToListAsync();
        }

        public Task<Client> GetClientByIdAsync(string idCliente)
        {
            return db.Table<Client>().Where(a => a.cedula == idCliente).FirstOrDefaultAsync() ;
        }

    }
}
