using Project.BLL.Processor;
using Project.BLL.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    /// <summary>
    /// For handling all authorized event actions
    /// </summary>
    [Authorize]
    public class EventController : Controller
    {
        readonly EventProcessor _eprocessor;
        readonly InviteProcessor _iprocessor;
        readonly CommentProcessor _cprocessor;

        public EventController()
        {
            _eprocessor = new EventProcessor();
            _iprocessor = new InviteProcessor();
            _cprocessor = new CommentProcessor();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EventEntity evnt)
        {
            evnt.Email = User.Identity.Name;
            TimeSpan time = new TimeSpan(evnt.Hours, evnt.Mins, 0);
            evnt.StartTime = evnt.Date + time;
            int eventId = _eprocessor.CreateEvent(evnt);
            TempData["created"] = "true";

            if (!String.IsNullOrEmpty(evnt.InviteList))
            {
                if (_iprocessor.CreateInvitation(evnt.InviteList, eventId))
                {
                    TempData["invited"] = "true";
                }
                else
                {
                    TempData["invited"] = "false";
                }
            }

            return RedirectToAction("Create");
        }

        public ActionResult MyEvents()
        {
            var evnts = _eprocessor.GetAll(User.Identity.Name, User.IsInRole("Admin")).OrderBy(e => e.StartTime).ToList();
            return View(evnts);
        }

        [HttpPost]
        public ActionResult Invite(string email, int eventId)
        {
            if (_iprocessor.CreateInvitation(email, eventId))
            {
                return RedirectToAction("MyEvents");
            }
            string errmsg = "Enter valid users";
            return RedirectToAction("Error", "Home", (object)errmsg);
        }

        [HttpPost]
        public ActionResult Comment(string body, int eventId)
        {
            CommentEntity comment = new CommentEntity()
            {
                Email = User.Identity.Name,
                Body = body,
                EventId = eventId,
                CommentDate = System.DateTime.Now
            };
            _cprocessor.CreateComment(comment);

            return RedirectToAction("Details", "Home", new { Id = eventId });
        }

        public ActionResult ViewInvited()
        {
            return View(_iprocessor.GetAllInvitedUsers(User.Identity.Name));
        }

        public ActionResult Edit(int Id)
        {
            return View(_eprocessor.GetEvent(Id));
        }

        [HttpPost]
        public ActionResult Edit(EventEntity evnt)
        {
            var checker = _eprocessor.GetEvent(evnt.EventId);
            if (checker.Type == "Private" && User.Identity.Name != checker.Email)
            {
                var errMsg = "You can not Edit this Record";
                return RedirectToAction("Error", "Home", (object)errMsg);
            }
            _eprocessor.UpdateEvent(evnt);
            TempData["edited"] = "true";
            return View(evnt);
        }
    }
}