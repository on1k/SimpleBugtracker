using Bugtracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("name=MyConnection")
        {
            Database.SetInitializer<MyDbContext>(new MainInitalizer());
        }

        public IDbSet<Person> Persons { get; set; }
        public IDbSet<Position> Positions { get; set; }
        public IDbSet<Status> Statuses { get; set; }
        public IDbSet<Ticket> Tickets { get; set; }
        
    }
}
