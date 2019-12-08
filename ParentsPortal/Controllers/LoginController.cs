using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using ParentsPortal.Models;

namespace ParentsPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly ParentsDbContext _context;

        public LoginController(ParentsDbContext context)
        {
            _context = context;
        }

        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Login login)
        {
            con.ConnectionString = "Server=DESKTOP-AK9TQR4\\BAPPYSQL;Database=ParentsPortal;Integrated Security=True";
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM StudentInfo WHERE Email='" + login.Email + "' AND Password='" + login.Password + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                int ID = Int32.Parse((dr["StdId"]).ToString());
                con.Close();
                var User = await _context.StudentInfo.FirstOrDefaultAsync(m => m.StdId == ID);
                return View("Profile", User);
            }
            else
            {
                con.Close();
                ModelState.AddModelError("", "Email or Password did not match");
                return View(login);
            }

        }

    }
}