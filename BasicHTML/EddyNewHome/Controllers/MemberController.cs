using EddyNewHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EddyNewHome.Controllers
{
    public class MemberController : Controller
    {
        EddyNewHomeEntities db = new EddyNewHomeEntities();

        // GET: Member
        public ActionResult Entry()
        {
            Members member = new Members();
            return View(member);
        }

        [HttpPost]
        //action에서 받은일을 여기서 처리
        public ActionResult Entry(Members member)
        {
            member.EntryDate = DateTime.Now;

            try
            {
                db.Members.Add(member); // insert쿼리
                db.SaveChanges();//트랜잭션 커밋(값이 제대로 들어가면 들어감)
                ViewBag.Result = "OK";
            }
            catch (Exception ex)
            {
                ViewBag.Result = "FAIL";
                //ViewBag.Result = $"{ex.Message}";
            }

            return View(member);
        }

        public ActionResult List()
        {
            IEnumerable<Members> list = db.Members.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Edit(string memberid)
        {
            Members member = db.Members.Where(m => m.MemberID == memberid).FirstOrDefault();
            return View(member);
        }

        [HttpPost]
        public ActionResult Edit(Members member)
        {
            //Members dbmember = db.Members.Where(m => m.MemberID == member.MemberID).FirstOrDefault(); //람다
            Members origin = db.Members.Find(member.MemberID); //find메서드
            try
            {
                origin.MemberName = member.MemberName;
                origin.MemberPWD = member.MemberPWD;
                origin.Email = member.Email;
                origin.Telephone = member.Telephone;

                db.Entry(origin).State = System.Data.Entity.EntityState.Modified; //업뎃
                db.SaveChanges();//바꾸기
                ViewBag.Result = "OK";
            }
            catch (Exception)
            {
                ViewBag.Result = "FAIL";
            }

            return View(origin);

        }

        [HttpGet]
        public ActionResult Delete(string memberid)
        {
            Members member = db.Members.Find(memberid);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("List");//edit화면에서 삭제 완료 후 리스트 화면 띄우기 경로 : /Member/List
        }



        //Ajax 중복체크 메서드
        [HttpGet]
        public JsonResult IDCheck(string memberid)
        {
            string result = string.Empty;
            Members member = db.Members.Find(memberid);
            if (member == null)
            {
                result = "OK";
            }
            else
            {
                result = "FAIL";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}