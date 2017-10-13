using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MySql.Data.MySqlClient;

using ASP.NET_VUEJS.Models;
using System.Web.Configuration;
using System.Data;

namespace ASP.NET_VUEJS.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        public ActionResult Index()
        {
            return Redirect("/index.html");
        }
        
        //获取MySql的连接数据库对象。MySqlConnection
        public MySqlConnection OpenConnection()
        {
            string mysqlconnectionString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            MySqlConnection connection = new MySqlConnection(mysqlconnectionString);
            connection.Open();
            return connection;
        }
        
        public JsonResult QueryContact()
        {
            using (IDbConnection conn = OpenConnection())
            {
                const string query = "select * from contacts order by id desc";
                var contactList = conn.Query<Contact>(query, null);
                return Json(contactList, JsonRequestBehavior.AllowGet);
            }
        }
        
        [HttpGet]
        public JsonResult RemoveContact(int id)
        {
          using (IDbConnection conn = OpenConnection())
          {
              string query = $"delete from contacts where id = {id}";
              var affected = conn.Execute(query, null);
              var data = new {msg="success",error_num="0"};
              
              if(affected == 1)
              {
                  return Json(data, JsonRequestBehavior.AllowGet);
              }
              else
              {
                  data = new { msg = "fail", error_num = "1" };
                  return Json(data, JsonRequestBehavior.AllowGet);
              }
          }
        }
        
        [HttpGet]
        public JsonResult QuerySingleContact(int id)
        {
            using (IDbConnection conn = OpenConnection())
            {
                string query = $"select * from contacts where id = {id}";
                var contactList = conn.Query<Contact>(query, null);
                return Json(contactList, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult ReviceContact(Contact contact)
        {
          using (IDbConnection conn = OpenConnection())
          {
              string query = $"update contacts set name='{contact.name}',phonenum1='{contact.phonenum1}',phonenum2='{contact.phonenum2}',address='{contact.address}' where id={contact.id}";
              var affected = conn.Execute(query, null);
              var data = new {msg="success",error_num="0"};
              if(affected == 1)
              {
                  return Json(data, JsonRequestBehavior.AllowGet);
              }
              else
              {
                  data = new { msg = "fail", error_num = "1" };
                  return Json(data, JsonRequestBehavior.AllowGet);
              }
          }
        }
        
        [HttpPost]
        public JsonResult AddContact(Contact contact)
        {
          using (IDbConnection conn = OpenConnection())
          {
              string query = $"INSERT INTO contacts (name,avatar,phonenum1,phonenum2,address) VALUES('{contact.name}','{contact.avatar}','{contact.phonenum1}','{contact.phonenum2}','{contact.address}')";
              var affected = conn.Execute(query, null);
              var data = new {msg="success",error_num="0"};
              if(affected == 1)
              {
                  return Json(data, JsonRequestBehavior.AllowGet);
              }
              else
              {
                  data = new { msg = "fail", error_num = "1" };
                  return Json(data, JsonRequestBehavior.AllowGet);
              }
          }
        }

  
    }
    
}
