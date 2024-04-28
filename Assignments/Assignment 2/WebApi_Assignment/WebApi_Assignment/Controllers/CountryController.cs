﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Assignment.Models;

namespace WebApi_Assignment.Controllers
{
    [RoutePrefix("api/countryList")]
    public class CountryController : ApiController
    {
        static List<Country> Countrylist = new List<Country>()
        {
            new Country{ID=1,CountryName="India",Capital="Delhi"},
            new Country{ID=2,CountryName="Sri Lanka",Capital="Jayawardenepura"},
            new Country{ID=3,CountryName="Germany",Capital="Berlin"},
            new Country{ID=4,CountryName="France",Capital="Paris"},
        };

        //Get-------------------
        [HttpGet]
        [Route("All")]
        public IEnumerable<Country> Get()
        {
            return Countrylist;
        }

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult PersonById(int pid)
        {
            var person = Countrylist.Find(p => p.ID == pid);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        //Post---------
        [HttpPost]
        [Route("AllPost")]
        public List<Country> PostAll([FromBody] Country person)
        {
            Countrylist.Add(person);
            return Countrylist;
        }

        [HttpPost]
        [Route("countryPost")]
        public void Personpost([FromUri] int Id, string name, string desig)
        {
            Country person = new Country();
            person.ID = Id;
            person.CountryName = name;
            person.Capital = desig;
            Countrylist.Add(person);
        }

        //Put--------------

        [HttpPut]
        [Route("updateCountry")]
        public void Put(int pid, [FromUri] Country p)
        {
            Countrylist[pid - 1] = p;
        }

        //Delete--------
        [HttpDelete]
        [Route("deleteCountry")]
        public void Delete(int pid)
        {
            Countrylist.RemoveAt(pid - 1);
        }
    }
}
