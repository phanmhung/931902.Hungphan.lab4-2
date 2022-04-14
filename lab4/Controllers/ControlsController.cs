using Microsoft.AspNetCore.Mvc;
using System;


namespace lab4.Controllers
{
    public class ControlsController : Controller
    {

        public IActionResult Controls()
        {
            return View();
        }

        public IActionResult TextBox(string myTextbox)
        {
            if (Request.Method == "POST")
            {
                ViewBag.Type = "TextBox";
                ViewBag.Name = "Text";
                ViewBag.Result = myTextbox;
                return View("Result");
            }
            else return View();
        }

        public IActionResult TextArea(string myTextArea)
        {
            if (Request.Method == "POST")
            {
                ViewBag.Type = "TextArea";
                ViewBag.Name = "Text";
                ViewBag.Result = myTextArea;
                return View("Result");
            }
            else return View();
        }

        public IActionResult CheckBox(bool isSelected)
        {
            if (Request.Method == "POST")
            {
                ViewBag.Type = "CheckBox";
                ViewBag.Name = "isSelected";
                ViewBag.Result = Convert.ToString(isSelected);
                return View("Result");
            }
            else return View();
        }

        public IActionResult Radio(string myRadiobutton)
        {
            if (Request.Method == "POST")
            {
                ViewBag.Type = "Radio";
                ViewBag.Name = "Month";
                ViewBag.Result = myRadiobutton;
                return View("Result");
            }
            else return View();
        }

        public IActionResult DropDownList(string myList)
        {
            if (Request.Method == "POST")
            {

                ViewBag.Type = "DropDownList";
                ViewBag.Name = "Month";
                ViewBag.Result = myList;
                return View("Result");
            }
            else return View();
        }

        public IActionResult ListBox(string myList)
        {
            if (Request.Method == "POST")
            {
                ViewBag.Type = "ListBox";
                ViewBag.Name = "Months";
                ViewBag.Result = myList;
                return View("Result");

            }
            else return View();
        }

    }
}
