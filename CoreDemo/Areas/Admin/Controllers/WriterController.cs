﻿using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult WriterList()
        {
            var JsonWriters = JsonConvert.SerializeObject(writers);

            return Json(JsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Ayşe"
            },
            new WriterClass
            {
                Id=2,
                Name="Ahmet"
            },
            new WriterClass
            {
                Id=3,
                Name="Buse"
            }

        };







    }
}
