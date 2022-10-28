using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DetailTEC.SQLite_Models
{
    public class Appointment
    {
        [PrimaryKey]
        [MaxLength(100)]
        public string cliente { get; set; }
        [MaxLength(100)]
        public string placaVehiculo { get; set; }
        [MaxLength(100)]
        public string sucursal { get; set; }
        [MaxLength(100)]
        public string tipoLavado { get; set; }
        [MaxLength(100)]
        public string responsable { get; set; }
        [MaxLength(100)]
        public string factura { get; set; }
        [MaxLength(100)]
        public string numeroCita { get; set; }
    }
}
