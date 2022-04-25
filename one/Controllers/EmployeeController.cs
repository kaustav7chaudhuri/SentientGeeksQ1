using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using one.Models;

namespace one.Controllers
{
    public class EmployeeController : Controller
    {
        CodeFirstApproachEntities db = new CodeFirstApproachEntities();

        

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (db)
            {
                List<Employee> emplist = db.Employees.ToList<Employee>();
                return Json(new { data = emplist }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AddorEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new Employee());
            }
            else
            {
                using (db)
                {
                    return View(db.Employees.Where(x => x.ID == id).FirstOrDefault());
                }
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Employee emp)
        {
            using (db)
            {
                if (emp.ID == 0)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Data Saved Sucessfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Data Updated Sucessfully" }, JsonRequestBehavior.AllowGet);
                }
            }

        }

        [HttpPost]
        public ActionResult Delete( int id)
        {
            using (db)
            {
                Employee emp = db.Employees.Where(x => x.ID == id).FirstOrDefault();
                db.Employees.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Employee Data Deleted Succesfully" }, JsonRequestBehavior.AllowGet);
            }
        }
       
    }
}