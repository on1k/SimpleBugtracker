using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.Data.Entities
{
    public class Ticket
    {
        public int TicketID { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Статус тикета")]
        public int StatusID { get; set; }
        public int PersonID { get; set; }
        public virtual Person Person { get; set; }
        public virtual Status Status { get; set; }
    }
}
