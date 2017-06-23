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

        //Начальная загрузка всех данных в представление
        public ActionResult Index()
        {
            PersonTicketViewModel personTicketVM = new PersonTicketViewModel();
            personTicketVM.Persons = personDb.GetAll();
            personTicketVM.Tickets = ticketDb.GetAll();
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
                personDb.Add(person);
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

        [HttpPost]
        public ActionResult DeletePerson(Person person)
        {
            try
            {
                personDb.Delete(person);
                personDb.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
                ticketDb.Edit(ticket);
                ticketDb.Save();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }
        
    }
}