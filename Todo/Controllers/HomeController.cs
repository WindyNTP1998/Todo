using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Models;
using Microsoft.Data.Sqlite;


namespace Todo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public RedirectResult Insert(TodoItem todo)
        {
            using (SqliteConnection conn = new SqliteConnection("Data Source=db.sqlite"))
            {
                using (var tableCmd = conn.CreateCommand())
                {
                    conn.Open();
                    var query = $"INSERT INTO todo (name) VALUES ('{todo.Name}')";
                    tableCmd.CommandText = query;
                    Console.WriteLine(query);
                    try
                    {
                        tableCmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            return Redirect("https://localhost:5001/");
        }

    }
}
