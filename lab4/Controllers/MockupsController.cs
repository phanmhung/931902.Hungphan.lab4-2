using Microsoft.AspNetCore.Mvc;
using lab4.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace lab4.Controllers
{
    public class MockupsController : Controller
    {
        Random rand = new Random();

        public IActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckEmail(string email)
        {
            if (AccountsBase.Get().ContainsKey(email))
                return Json(false);
            return Json(true);
        }

        [HttpGet]
        public IActionResult SignUp1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp1(AuthModel a)
        {
            if (ModelState["FirstName"].ValidationState == ModelValidationState.Valid &
                ModelState["LastName"].ValidationState == ModelValidationState.Valid &
                ModelState["Gender"].ValidationState == ModelValidationState.Valid)
                return RedirectToAction("SignUp2", a);
            return View();
        }

        [HttpGet]
        public IActionResult SignUp2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp2(AuthModel a)
        {

            if (ModelState["Email"].ValidationState == ModelValidationState.Valid &
                ModelState["Password"].ValidationState == ModelValidationState.Valid &
                ModelState["ConfirmPassword"].ValidationState == ModelValidationState.Valid)
            {
                if (AccountsBase.Get().ContainsKey(a.Email)) return View(a);
                AccountsBase.Get().Add(a.Email, a);
                return View("Result", a);
            }
            return View();
        }

        [HttpGet]
        public IActionResult ResetStageOne()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetStageOne(string Email, string action)
        {
            AuthModel a;
            if (Email == null)
            {
                ViewBag.Code = "Email not specified";
                return View();
            }
            if (AccountsBase.Get().TryGetValue(Email, out a))
            {
                if (action == "Send me a code")
                {
                    string b = Convert.ToString(rand.Next(0, 10)) + Convert.ToString(rand.Next(0, 10)) + Convert.ToString(rand.Next(0, 10)) + Convert.ToString(rand.Next(0, 10));
                    ViewBag.Code = b;
                    AccountsBase.Get()[Email].Code = b;
                    return View();
                }
                else return RedirectToAction("ResetStageTwo", a);
            }
            ViewBag.Code = "You are not registred";
            return View();
        }

        [HttpGet]
        public IActionResult ResetStageTwo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ResetStageTwo(AuthModel a, string myTextbox)
        {

            if (a.Code == myTextbox)
            {
                return RedirectToAction("PasswordChange", a);
            }
            ViewBag.Check = "Wrong code";
            return View(a);
        }
        [HttpGet]
        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PasswordChange(AuthModel a)
        {

            if (ModelState["Password"].ValidationState == ModelValidationState.Valid &
                ModelState["ConfirmPassword"].ValidationState == ModelValidationState.Valid)
                return View("ResetResult");
            else View(a);

            return View();
        }
        
    }
}
