using System.Linq;
using System.Web.Mvc;
using ASPNETWebAppMVCStudentApp; // Thay bằng Namespace của bạn

namespace ASPNETWebAppMVCStudentApp.Controllers
{
    public class LoginController : Controller
    {
        private SchoolDBEntities db = new SchoolDBEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login/Autherize
        [HttpPost]
        public ActionResult Autherize(tblUser userModel)
        {
            var userDetails = db.tblUsers.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
            if (userDetails == null)
            {
                ViewBag.LoginErrorMessage = "Sai tên đăng nhập hoặc mật khẩu.";
                return View("Index", userModel);
            }
            else
            {
                Session["userID"] = userDetails.UserID;
                Session["userName"] = userDetails.Username;
                return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang chủ sau khi đăng nhập
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}