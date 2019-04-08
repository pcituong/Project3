using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Base.Models;

namespace Base.Controllers
{
    [Authorize]
    public class employeedetailsController : Controller
    {
        private employee_managementEntities db = new employee_managementEntities();

        // GET: employeedetails
        public ActionResult Index()
        {
            var employeeDetails = db.EmployeeDetails.Include(e => e.Department).Include(e => e.Education).Include(e => e.Position);
            return View(employeeDetails.ToList());
        }

        // GET: employeedetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // GET: employeedetails/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName");
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName");
            return View();
        }

        // POST: employeedetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,Name,Gender,Address,IdentityCard,Phone,Email,Nation,Birthday,Certificate,DepartmentID,EducationID,PositionID,Avatar,Status,StartWorkingTime")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeDetails.Add(employeeDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employeeDetail.DepartmentID);
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName", employeeDetail.EducationID);
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName", employeeDetail.PositionID);
            return View(employeeDetail);
        }

        // GET: employeedetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employeeDetail.DepartmentID);
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName", employeeDetail.EducationID);
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName", employeeDetail.PositionID);
            return View(employeeDetail);
        }

        // POST: employeedetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,Name,Gender,Address,IdentityCard,Phone,Email,Nation,Birthday,Certificate,DepartmentID,EducationID,PositionID,Avatar,Status,StartWorkingTime")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", employeeDetail.DepartmentID);
            ViewBag.EducationID = new SelectList(db.Educations, "EducationID", "EducationName", employeeDetail.EducationID);
            ViewBag.PositionID = new SelectList(db.Positions, "PositionID", "PositionName", employeeDetail.PositionID);
            return View(employeeDetail);
        }

        // GET: employeedetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: employeedetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(employeeDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
