using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AMaRMS
{
    public class MaintenanceSchedule
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string MaintenanceType { get; set; }
        public int IntervalDays { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime NextMaintenanceDate { get; set; }
        public bool IsDone { get; set; }
    }
}
