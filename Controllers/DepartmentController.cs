using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Existek.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Existek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        //private readonly EmployeeDBContext _db;

        public DepartmentController(IConfiguration configuration, IWebHostEnvironment env/*, EmployeeDBContext db*/)
        {
            _configuration = configuration;
            _env = env;
            //_db = db;
        }

        [HttpGet]
        public JsonResult Get(/*int page, string depName = ""*/)
        {
            try
            {
                using (EmployeeDBContext db = new EmployeeDBContext())
                {
                    var deps = db.Department.ToList();
                    return Json(deps);
                }
            }
            catch (Exception)
            {
                return new JsonResult("failed");
            }
        }
        //    try
        //    {
        //        var deps = _db.Departments.Where(x => x.DepartmentName.ToLower().Contains(depName.ToLower())).Skip(page * 5).Take(5).ToList();
        //        return Json(deps);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new { error = "Failed!" });
        //    }
        //}


        [HttpPost]
        public JsonResult Post(Department dep)
        {
            try
            {
                using (EmployeeDBContext db = new EmployeeDBContext())
                {
                    Department dep1 = new Department();
                    if (dep.DepartmentName !="")
                    {
                        dep1.DepartmentName = dep.DepartmentName;
                    }
                    else
                    {
                        return new JsonResult("Enter name of the department!");
                    }
                    db.Department.Add(dep1);
                    db.SaveChanges();
                }
                return new JsonResult("Added Successfully!");
            }
            catch (Exception)
            {
                return new JsonResult("Failed to Add!");
            }
        }






        [HttpPut]
        public JsonResult Put(Department dep)
        {
            try
            {
                using (EmployeeDBContext db = new EmployeeDBContext())
                {
                    var id = dep.DepartmentId;
                    var dep1 = db.Department.Find(id);
                    dep1.DepartmentName = dep.DepartmentName;
                    db.SaveChanges();
                }
                return new JsonResult("Updated Successfully!");
            }
            catch (Exception)
            {
                return new JsonResult("Failed to Update!");
            }
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                using (EmployeeDBContext db = new EmployeeDBContext())
                {
                    var dep1 = db.Department.Find(id);
                    db.Department.Remove(dep1);
                    db.SaveChanges();
                }
                return new JsonResult("Deleted Successfully!");
            }
            catch (Exception)
            {
                return new JsonResult("Failed to Delete !");
            }
        }
    }
}
