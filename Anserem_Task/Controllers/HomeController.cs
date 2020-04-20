using Anserem_Task.Models;
using Anserem_Task.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Anserem_Task.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISellingRepository sellingRepository;
        public HomeController(ISellingRepository sellingRepository)
        {
            this.sellingRepository = sellingRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult List()
        {
            return Json(sellingRepository.GetSellings(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(SellingViewModel selling)
        {
            sellingRepository.CreateSelling(selling);
            sellingRepository.Save();
            return Json(-1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByID(int ID)
        {
            return Json(sellingRepository.GetSellingByID(ID), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(SellingViewModel selling)
        {
            sellingRepository.UpdateSelling(selling);
            sellingRepository.Save();
            return Json(-1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)            
        {
            sellingRepository.DeleteSelling(ID);
            sellingRepository.Save();
            return Json(-1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Copy(int ID)
        {
            sellingRepository.CopySelling(ID);
            sellingRepository.Save();
            return Json(-1, JsonRequestBehavior.AllowGet);
        }
    }
}