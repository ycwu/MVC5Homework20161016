using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Homework20161016.Models;
using System.Data.Entity.Validation;

namespace MVC5Homework20161016.Controllers
{
    public class ContactController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: Contact
        public ActionResult Index(string search, string titles, string sortOrder)
        {
            var data = db.客戶聯絡人.Include(客 => 客.客戶資料).OrderBy(c => c.職稱).Where(c => c.是否已刪除 == false);
            if (!string.IsNullOrEmpty(search))
                data = data.Where(c => c.姓名.Contains(search));
            if (!string.IsNullOrEmpty(titles))
                data = data.Where(c => c.職稱.Contains(titles));

            ViewBag.sort職稱 = String.IsNullOrEmpty(sortOrder) ? "職稱_DESC" : "";
            ViewBag.sort姓名 = sortOrder == "姓名" ? "姓名_DESC" : "姓名";
            ViewBag.sortEmail = sortOrder == "Email" ? "Email_DESC" : "Email";
            ViewBag.sort手機 = sortOrder == "手機" ? "手機_DESC" : "手機";
            ViewBag.sort電話 = sortOrder == "電話" ? "電話_DESC" : "電話";
            ViewBag.sort客戶名稱 = sortOrder == "客戶名稱" ? "客戶名稱_DESC" : "客戶名稱";
            switch (sortOrder)
            {
                case "職稱_DESC":
                    data = data.OrderByDescending(c => c.職稱);
                    break;
                case "姓名":
                    data = data.OrderBy(c => c.姓名);
                    break;
                case "姓名_DESC":
                    data = data.OrderByDescending(c => c.姓名);
                    break;
                case "Email":
                    data = data.OrderBy(c => c.Email);
                    break;
                case "Email_DESC":
                    data = data.OrderByDescending(c => c.Email);
                    break;
                case "手機":
                    data = data.OrderBy(c => c.手機);
                    break;
                case "手機_DESC":
                    data = data.OrderByDescending(c => c.手機);
                    break;
                case "電話":
                    data = data.OrderBy(c => c.電話);
                    break;
                case "電話_DESC":
                    data = data.OrderByDescending(c => c.電話);
                    break;
                case "客戶名稱":
                    data = data.OrderBy(c => c.客戶資料.客戶名稱);
                    break;
                case "客戶名稱_DESC":
                    data = data.OrderByDescending(c => c.客戶資料.客戶名稱);
                    break;
            }
            return View(data.ToList());
        }

        // GET: Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱");
            return View();
        }

        // POST: Contact/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                //var check = db.客戶聯絡人.Where(c => c.Email == 客戶聯絡人.Email);
                //if (check.Count() == 0)
                //{
                客戶聯絡人.是否已刪除 = false;
                    db.客戶聯絡人.Add(客戶聯絡人);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                //}
               // else
                //{
                    //ModelState.AddModelError("Email", "輸入Email位置重覆");
                //}
                
            }

            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // POST: Contact/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶Id,職稱,姓名,Email,手機,電話")] 客戶聯絡人 客戶聯絡人)
        {
            if (ModelState.IsValid)
            {
                db.Entry(客戶聯絡人).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(db.客戶資料, "Id", "客戶名稱", 客戶聯絡人.客戶Id);
            return View(客戶聯絡人);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            if (客戶聯絡人 == null)
            {
                return HttpNotFound();
            }
            return View(客戶聯絡人);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶聯絡人 客戶聯絡人 = db.客戶聯絡人.Find(id);
            //db.客戶聯絡人.Remove(客戶聯絡人);
            客戶聯絡人.是否已刪除 = true;
            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eError in ex.EntityValidationErrors)
                {
                    foreach (var sError in eError.ValidationErrors)
                    {
                        throw new DbEntityValidationException(sError.ErrorMessage + "," + sError.PropertyName);
                    }
                }
            }
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
