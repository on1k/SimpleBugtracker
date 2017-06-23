using Bugtracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bugtracker.Web.Models
{
    public class PersonTicketViewModel
    {
        public IQueryable<Person> Persons { get; set; }
        public IQueryable<Ticket> Tickets { get; set; }
    }
}