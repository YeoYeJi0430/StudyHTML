
using EddyNewHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EddyNewHome.Controllers
{
    public class BoardController : Controller
    {
        EddyNewHomeEntities db = new EddyNewHomeEntities();
        // GET: Board
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            BoardArticles articles = new BoardArticles();
            return View(articles);
        }
        [HttpPost]
        public ActionResult Create(BoardArticles article)
        {
            article.Email = "test@test.com";
            article.BoardIDX = 2000;
            //article.RegistMemberID = "System";
            article.UserName = "임시 사용자";
            article.IPAddress = Commons.GetIPAdress();
            article.ViewCnt = 0;
            article.RegistDate = DateTime.Now;
            article.RegistUserName = "SYSTEM";

            try
            {
                db.BoardArticles.Add(article);
                db.SaveChanges();

                ViewBag.Result = "OK";
            }
            catch (Exception)
            {
                ViewBag.Result = "FAIL";
            }
            return View(article);
        }
        [HttpGet]
        public ActionResult List()
        {
            IEnumerable<BoardArticles> list = db.BoardArticles.ToList();
            return View(list);
        }
    }
}