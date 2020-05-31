using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class Error404Controller : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Cart() => View();
        public IActionResult Checout() => View();
        public IActionResult Login() => View();
        public IActionResult ProductDetails() => View();
    
    }
}
