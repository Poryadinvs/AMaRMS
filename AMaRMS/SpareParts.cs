using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace AMaRMS
{
    public class SpareParts
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
    }
}
