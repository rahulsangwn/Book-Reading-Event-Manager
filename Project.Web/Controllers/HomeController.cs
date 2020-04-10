using Project.BLL.Processor;
using Project.BLL.UserModel;
using System.Collections;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class HomeController : Controller
    {
        readonly EventProcessor _eprocessor;
        readonly CommentProcessor _cprocessor;
        readonly InviteProcessor _iprocessor;

        public HomeController()
        {
            _eprocessor = new EventProcessor();
            _cprocessor = new CommentProcessor();
            _iprocessor = new InviteProcessor();
        }

        public ActionResult Index()
        {
            return View(_eprocessor.GetPublicAll());
        }

        public ActionResult Details(int Id) 
        {
            var comments = _cprocessor.GetAllComment(Id);
            var model = _eprocessor.GetEvent(Id);
            bool isNotUserPrivateEvent = model.Type == "Private" && User.Identity.Name != model.Email;
            bool isUserInvitedInPrivateEvent = _iprocessor.IsInvitedUser(User.Identity.Name, Id);
            if (isNotUserPrivateEvent && !isUserInvitedInPrivateEvent)
            {
                var errMsg = "You can not Access this Record";
                return View("Error", model:errMsg);
            }
            model.NoOfInvitedUsers = _iprocessor.InvitedUsersCount(Id);
            model.Comments = comments;
            return View(model);
        }
        
        public ActionResult Error(string error)
        {
            return View("Error", error);
        }

        public ActionResult Helpdesk()
        {
            return Redirect("https://helpdesk.nagarro.com/");
        }
    }
}