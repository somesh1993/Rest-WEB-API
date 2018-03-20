using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCWebAPI.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVCWebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0GSPEDO\\SQLEXPRESS;Initial Catalog=Storage;Integrated Security=True");
        // GET api/values/GetAllEmployees
        public IEnumerable<Employee> GetAllEmployees()
        {
            con.Open();
            List<Employee> emplylist = new List<Employee>();
            SqlCommand cmd = new SqlCommand("select * from Datastorage", con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Employee emp = new Employee();
                emp.Name = dr["Name"].ToString();
                emp.Mobile = Convert.ToInt32(dr["Mobile"]);
                emp.Email = dr["Email"].ToString();
                emp.Id = Convert.ToInt32(dr["Id"]);
                emplylist.Add(emp);
            }
            con.Close();
            return emplylist;
        }
        // GET api/values/GetSelectedEmployees
        public Employee GetSelectedEmployees(string id)
        {
            con.Open();
            //List<Employee> emplylist = new List<Employee>();
            Employee emply = new Employee();
            string selectString = "select * from Datastorage where Name=" + "'" + id + "'";
            SqlCommand cmd = new SqlCommand(selectString, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                emply.Name = (string)rdr["Name"];
                emply.Mobile = Convert.ToInt32(rdr["Mobile"]);
                emply.Email = (string)rdr["Email"];
                emply.Id = Convert.ToInt32(rdr["Id"]);
            }
            //emplylist.Add(emply);
            con.Close();
            return emply;
        }

        // GET api/values/Get/5
        public Employee Get(int id)
        {
            con.Open();
            string selectString = "select * from Datastorage where Id=" + id;
            Employee emp = new Employee();
            SqlCommand cmd = new SqlCommand(selectString, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                emp.Name = (string)rdr["Name"];
                emp.Mobile = Convert.ToInt32(rdr["Mobile"]);
                emp.Email = (string)rdr["Email"];
                emp.Id = Convert.ToInt32(rdr["Id"]);
            }
            con.Close();
            return emp;
        }

        // POST api/values/Post
        public IHttpActionResult Post([FromBody]Employee emp)
        {
            con.Open();
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            string stmt = "INSERT INTO Datastorage(Name,Mobile,Email) VALUES(@Name,@Mob,@Eml)";
            //string insertString = "insert into Datastorage values(" + emp.Name+"," + (emp.Mobile).ToString()+ "," + emp.Email+")";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar,10);
            cmd.Parameters.Add("@Mob", SqlDbType.Int);
            cmd.Parameters.Add("@Eml", SqlDbType.VarChar, 10);
            cmd.Parameters["@Name"].Value = emp.Name.ToString();
            cmd.Parameters["@Mob"].Value = Convert.ToInt32(emp.Mobile);
            cmd.Parameters["@Eml"].Value = emp.Email.ToString();
            cmd.ExecuteNonQuery();
            return Ok();
        }

        // PUT api/values/EditDetail/5
        public IHttpActionResult EditDetail(int id,[FromBody]Employee employee)
        {
            con.Open();
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            string stmt = "update Datastorage set Name = @Name,Mobile= @Mob, Email = @Eml where Id = @Id";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@Mob", SqlDbType.Int);
            cmd.Parameters.Add("@Eml", SqlDbType.VarChar, 10);
            cmd.Parameters.Add("@Id", SqlDbType.Int);
            cmd.Parameters["@Name"].Value = employee.Name.ToString();
            cmd.Parameters["@Mob"].Value = Convert.ToInt32(employee.Mobile);
            cmd.Parameters["@Eml"].Value = employee.Email.ToString();
            cmd.Parameters["@Id"].Value = Convert.ToInt32(id);
            cmd.ExecuteNonQuery();
            return Ok();
        }

        // DELETE api/values/delete/5
        public IHttpActionResult Delete(int id)
        {
            con.Open();
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            string stmt = "delete from Datastorage where Id = @Id";
            SqlCommand cmd = new SqlCommand(stmt, con);
            cmd.Parameters.Add("@Id", SqlDbType.Int);
            cmd.Parameters["@Id"].Value = Convert.ToInt32(id);
            cmd.ExecuteNonQuery();
            return Ok();
        }
    }
}
