using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DetailTEC.SQLite_Models
{
    public class Client
    {
        [PrimaryKey]
        [MaxLength(100)]
        public string cedula { get; set; }
        [MaxLength(50)]
        public string nombreCompleto { get; set; }
        [MaxLength(100)]
        public string correo { get; set; }
        [MaxLength(100)]
        public string direccion { get; set; }
        [MaxLength(100)]
        public string usuario { get; set; }
        [MaxLength(100)]
        public string password { get; set; }
        [MaxLength(100)]
        public int puntos { get; set; }
        [MaxLength(100)]
        public string telefonos { get; set; }
        
    }
}
