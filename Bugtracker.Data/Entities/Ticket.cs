using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.Data.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusID { get; set; }
        public virtual Person Person { get; set; }
        public virtual Status Status { get; set; }
    }
}
