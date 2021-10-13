using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int AddMember(string UserName, string Email, string Phone, string Address)
        {
            DemoWCFEntities _dbEntity = new DemoWCFEntities();
            Member newMember = new Member();
            newMember.UserName = UserName;
            newMember.Email = Email;
            newMember.Phone = Phone;
            newMember.Address = Address;
            _dbEntity.Members.Add(newMember);
            int Retval = _dbEntity.SaveChanges();
            return Retval;
        }

        public int DeleteMemberById(int Id)
        {
            DemoWCFEntities _dbEntity = new DemoWCFEntities();
            var member = _dbEntity.Members.FirstOrDefault(p => p.Id == Id);
            _dbEntity.Entry(member).State = EntityState.Deleted;

            int Retval = _dbEntity.SaveChanges();
            return Retval;
        }

        public List<Member> GetAllUser()
        {
            DemoWCFEntities _dbEntity = new DemoWCFEntities();
            var lstMember = _dbEntity.Members.ToList();

            return lstMember;
        }

        public Member GetMemberById(int Id)
        {
            DemoWCFEntities _dbEntity = new DemoWCFEntities();
            var member = _dbEntity.Members.FirstOrDefault(p => p.Id == Id);

            return member;
        }

        public int UpdateMember(int Id, string UserName, string Email, string Phone, string Address)
        {
            DemoWCFEntities _dbEntity = new DemoWCFEntities();
            var member = _dbEntity.Members.FirstOrDefault(p => p.Id == Id);
            member.UserName = UserName;
            member.Email = Email;
            member.Phone = Phone;
            member.Address = Address;
            _dbEntity.Entry(member).State = EntityState.Modified;

            int Retval = _dbEntity.SaveChanges();
            return Retval;
        }
    }
}
