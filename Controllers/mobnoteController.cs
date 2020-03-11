using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeowTeam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class mobnoteController : ControllerBase
    {
        [HttpGet("{fun}/{id}/{val}")]
        public mobnote onGet(string fun, string id, string val)
        {
            string ret;
            switch (fun)
            {
                case "get":
                    ret = stuff.readFromFile(id);
                    break;
                case "post":
                    stuff.writeToFile(val, id);ret = "Done post in "+id+".txt";
                    break;
                default:
                    ret = "?";
                    break;
            }
            return new mobnote() { val = ret };
        }
    }
}