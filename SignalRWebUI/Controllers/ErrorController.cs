﻿using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page(int code)
        {
            return View();
        }
    }
}
