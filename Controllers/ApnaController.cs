using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.DB_Connection;

namespace Web_API.Controllersnf9
{
    public class ApnaController : ApiController
    {
        //[Route("Get/Data")]
        //public List<String> GetData()
        //{
        //    List<String> listobj = new List<string>() 
        //    {
        //        "Alok",
        //        "Abhishek",
        //        "Neha"
        //    };
        //    return listobj;
        //}
        [HttpGet]
        [Route("Get/Read")]
        public List<Client> Read()
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            var TblData = dbobj.Clients.ToList();

            return TblData;
        }

        [HttpPost]
        [Route("Post/Create")]//Create with Update
        public HttpResponseMessage Create(Client tblobj)
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            if(tblobj.ID == 0)
            {
                dbobj.Clients.Add(tblobj);
                dbobj.SaveChanges();
            }
            else
            {
                dbobj.Entry(tblobj).State = System.Data.Entity.EntityState.Modified;
                dbobj.SaveChanges();
            }

            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);

            return hrm;
        }

        [HttpGet]
        [Route("Get/Update")]
        public Client Update(int ID)
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            var UpdataData = dbobj.Clients.Where(m => m.ID == ID).First();

            return UpdataData;

        }

        [HttpGet]
        [Route("Get/Delete")]
        public HttpResponseMessage Delete(int ID)
        {
            Alok_KushwahaEntities dbobj = new Alok_KushwahaEntities();

            var DeleteData = dbobj.Clients.Where(m => m.ID == ID).First();

            dbobj.Clients.Remove(DeleteData);

            dbobj.SaveChanges();

            HttpResponseMessage hrm = new HttpResponseMessage(HttpStatusCode.OK);

            return hrm;
        }
    }
}
