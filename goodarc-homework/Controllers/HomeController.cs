using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homework.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            //當網站不是放在根目錄時，重新導向有trailing slash的網址
            if (HttpContext.Request.PathBase.ToString() != "" && HttpContext.Request.Path == "") {
                var path = new StringBuilder()
                    .Append(HttpContext.Request.Scheme)
                    .Append("://")
                    .Append(HttpContext.Request.Host)
                    .Append(HttpContext.Request.PathBase)
                    .Append("/")
                    .ToString();
                return RedirectPermanent(path);
            }
            return View();
        }
    }
}
