using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AMaRMS
{
    public class MaintenanceRecord
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public DateTime MaintenanceDate { get; set; }
        public string MaintenanceType { get; set; }
        public string Description { get; set; }
        public double DurationHours { get; set; }
        public double Cost { get; set; }
        public string PerformedBy { get; set; }
    }
}
