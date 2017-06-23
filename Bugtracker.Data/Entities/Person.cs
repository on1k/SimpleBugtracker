using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugtracker.Data.Entities
{
    public class Person
    {
        public int PersonID { get; set; }
        [Display(Name = "Должность")]
        public int PositionID { get; set; }
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string LastName { get; set; }
        public string FullName { get { return  FirstName + " " + Name + " " + LastName; } }
        public virtual Position Position { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
