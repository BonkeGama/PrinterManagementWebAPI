using CompanyPrinterz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompanyPrinterz.Controllers
{

    [RoutePrefix("Api/Designations")]
    public class DesignationsController : ApiController
    {
        private CompanyPrintersEntities cprintersobj = new CompanyPrintersEntities();
        // GET api/<controller>/5
        [HttpGet]
        [Route("AllDepartments")]
        public IQueryable<Designation> Get()
        {
            try
            {
                return cprintersobj.Designations;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetDesignationsById/{DesignationID}")]
        public IHttpActionResult GetDesignationsById(string DesignationID)
        {
            Designation objDep = new Designation();
            int ID = Convert.ToInt32(DesignationID);
            try
            {
                objDep = cprintersobj.Designations.Find(ID);
                if (objDep == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok(objDep);
        }

        [HttpPost]
        [Route("InsertDes")]
        public IHttpActionResult Post(Designation data)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                cprintersobj.Designations.Add(data);
                cprintersobj.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateDepartments")]
        public IHttpActionResult PutDepartment(Designation designation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Designation objDep = new Designation();
               
                objDep = cprintersobj.Designations.Find(designation.DesignationID);
                if (objDep != null)
                {
                    objDep.DesignationName = designation.DesignationName;
                }
                int i = this.cprintersobj.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return Ok(designation);
        }

        [HttpDelete]
        [Route("DeleteDes")]
        public IHttpActionResult Delete(int id)
        {
            //int empId = Convert.ToInt32(id);  
            Designation designation = cprintersobj.Designations.Find(id);
            if (designation == null)
            {
                return NotFound();
            }

            cprintersobj.Designations.Remove(designation);
            cprintersobj.SaveChanges();

            return Ok(designation);
        }

    }
}