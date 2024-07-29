using SanPhamClassLiBrary.Controller;
using SanPhamClassLiBrary.Model;
using System;
using System.Web.Mvc;

namespace SanPhamWebMVC.Controllers
{
    public class AccessController : Controller
    {
        private UserController userController = new UserController();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username, string password)
        {
            try
            {
                if (userController.IsValidUser(username, password))
                {
                    return Json(new { success = true, message = "Đăng nhập thành công" });
                }
                else
                {
                    return Json(new { success = false, message = "Sai username hoặc password" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(string username, string password, string fullname, string address)
        {
            try
            {
                if (userController.IsUsernameExists(username))
                {
                    return Json(new { success = false, message = "Username already exists" });
                }

                User newUser = new User
                {
                    Username = username,
                    Password = password,
                    Fullname = fullname,
                    IsAdmin = false,
                    Address = address,
                    CreatedUser = username
                };

                if (userController.RegisterUser(newUser))
                {
                    return Json(new { success = true, message = "Registration successful" });
                }
                else
                {
                    return Json(new { success = false, message = "Registration failed" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred: " + ex.Message });
            }
        }
    }
}
