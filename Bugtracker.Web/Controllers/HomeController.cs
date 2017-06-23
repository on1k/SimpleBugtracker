using Bugtracker.Data;
using Bugtracker.Data.Entities;
using Bugtracker.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bugtracker.Web.Controllers
{
    public class HomeController : Controller
    {
        //Создаем подключения к таблицам
        BaseRepository<Person> personDb = new BaseRepository<Person>();
        BaseRepository<Ticket> ticketDb = new BaseRepository<Ticket>();
        BaseRepository<Position> positionDb = new BaseRepository<Position>();
        BaseRepository<Status> statusDb = new BaseRepository<Status>();

        //Создаем выпадающий список должностей
        private void CreatePositionsList()
        {
            var positionList = positionDb.GetAll().ToList();
            SelectList list = new SelectList(positionList, "PositionID", "Title");
            ViewBag.PositionList = list;
        }

        //Создаем выпадающий список статусов тикетов
        private void CreateStatusList()
        {
            var statusList = statusDb.GetAll().ToList();
            SelectList list = new SelectList(statusList, "StatusID", "Title");
            ViewBag.StatusList = list;
        }
        //Создаем выпадающий список сотрудников
        private void CreatePersonList()
        {
            var personList = personDb.GetAll().ToList();
            SelectList list = new SelectList(personList, "PersonID", "FullName");
            ViewBag.PersonList = list;
        }

        //Начальная загрузка всех данных в представление
        public ActionResult Index()
        {
            PersonTicketViewModel personTicketVM = new PersonTicketViewModel();
            personTicketVM.Persons = personDb.GetAll();
            personTicketVM.Tickets = ticketDb.GetAll().OrderBy(x => x.CreatedDate);
            return View(personTicketVM);
        }

        //Выводим сотрудника в представление редактирования
        [HttpGet]
        public ActionResult EditPerson(int? id)
        {
            CreatePositionsList();
            var result = personDb.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }
            return View(result);
        }
        
        //Сохраняем измененные данные в БД
        [HttpPost]
        public ActionResult EditPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                personDb.Edit(person);
                personDb.Save();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult DeletePerson(int? id)
        {
            var result = personDb.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("DeletePerson")]
        public ActionResult DeletePersonConfirm(int? id)
        {
            var result = personDb.GetOne(id);
            if (result == null)
            {
                return HttpNotFound();
            }
            personDb.Delete(result);
            personDb.Save();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreatePerson()
        {
            CreatePositionsList();
            return View();
        }

        [HttpPost]
        public ActionResult CreatePerson(Person person)
        {
            if (ModelState.IsValid)
            {
                personDb.Add(person);
                personDb.Save();
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public ActionResult EditTicket(int? id)
        {
            CreateStatusList();
            var result = ticketDb.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }
            return View(result);
        }

        [HttpPost]
        public ActionResult EditTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.CreatedDate = DateTime.Now;
                ticketDb.Edit(ticket);
                ticketDb.Save();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }
        
        [HttpGet]
        public ActionResult DeleteTicket(int? id)
        {
            var result = ticketDb.GetOne(id);
            if (result == null)
            {
                return View("Index");
            }
            return View(result);
        }

        [HttpPost, ActionName("DeleteTicket")]
        public ActionResult DeleteTicketConfirm(int? id)
        {
            try
            {
                var result = ticketDb.GetOne(id);
                if (result == null)
                {
                    return HttpNotFound();
                }
                ticketDb.Delete(result);
                ticketDb.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CreateTicket()
        {
            CreatePersonList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateTicket(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.StatusID = 2;
                ticket.CreatedDate = DateTime.Now;
                ticketDb.Add(ticket);
                ticketDb.Save();
                ticketDb.GetAll().OrderBy(x => x.CreatedDate);
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        public ActionResult Complete(int? id)
        {
            var result = ticketDb.GetOne(id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }
            result.StatusID = 1;
            ticketDb.Edit(result);
            ticketDb.Save();
            return RedirectToAction("Index");
        }

        public ActionResult Refresh()
        {
            return RedirectToAction("Index");
        }
    }
}