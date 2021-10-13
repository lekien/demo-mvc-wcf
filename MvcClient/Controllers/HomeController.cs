using MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcClient.Controllers
{
    public class HomeController : Controller
    {
        ServiceReference1.Service1Client ur = new ServiceReference1.Service1Client();
        public ActionResult Index()
        {
            List<MemberDetail> memberDetails = new List<MemberDetail>();
            var lst = ur.GetAllUser();
            foreach (var item in lst)
            {
                MemberDetail itemMember = new MemberDetail();
                itemMember.Id = item.Id;
                itemMember.UserName = item.UserName;
                itemMember.Email = item.Email;
                itemMember.Phone = item.Phone;
                item.Address = item.Address;
                memberDetails.Add(itemMember);
            }
            return View(memberDetails);
        }

        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(MemberDetail member)
        {
            ur.AddMember(member.UserName, member.Email, member.Phone, member.Address);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var memberExist = ur.GetMemberById(id);
            MemberDetail memberItem = new MemberDetail();
            if (memberExist != null)
            {
                memberItem.Id = memberExist.Id;
                memberItem.UserName = memberExist.UserName;
                memberItem.Email = memberExist.Email;
                memberItem.Phone = memberExist.Phone;
                memberItem.Address = memberExist.Address;
            }
            return View("Add", memberItem);
        }
        [HttpPost]
        public ActionResult Edit(MemberDetail member)
        {
            int Retval = ur.UpdateMember(member.Id, member.UserName, member.Email, member.Phone, member.Address);
            if (Retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            int retval = ur.DeleteMemberById(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}