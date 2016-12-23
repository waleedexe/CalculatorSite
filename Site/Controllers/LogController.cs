using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Site.Controllers
{
    public class LogController : ApiController
    {
        private readonly ILogReader _logReader;

        public LogController(ILogReader logReader)
        {
            _logReader = logReader;
        }

        [HttpGet]
        public IHttpActionResult GetLogs()
        {
            var logs = _logReader.GetLogs();
            return Ok(logs.ToList());
        }
    }
}
