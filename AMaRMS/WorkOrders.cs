using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AMaRMS
{
    public class WorkOrders
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public DateTime WorkOrderDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string AssignedTo { get; set; }
    }
}
