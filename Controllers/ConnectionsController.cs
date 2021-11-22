using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
namespace InvalidConnection.Controllers
{
    public class ConnectionsController : ApiController
    {
        [Route("Connections/goodConnection")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            string conn = "www.google.com";
            try
            {
                using (SqlConnection connection = new SqlConnection($"server = {conn}; database = foobar; user = sa; password = 123"))
                {
                    connection.Open();
                    Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                    Console.WriteLine("State: {0}", connection.State);
                }
            }
            catch (Exception)
            {

                return BadRequest($"Connection {conn} errored properly");
            }
            return Ok($"Good conneciton to {conn}");
        }
        [Route("Connections/badConnection")]
        [HttpGet]
        public IHttpActionResult Post()
        {
            string conn = "www.foo.bar.com";
            try
            {
                using (SqlConnection connection = new SqlConnection($"server = {conn}; database = foobar; user = sa; password = 123"))
                {
                    connection.Open();
                    Console.WriteLine("ServerVersion: {0}", connection.ServerVersion);
                    Console.WriteLine("State: {0}", connection.State);
                }
            }
            catch (Exception)
            {

                return BadRequest($"Connection {conn} errored properly");
            }
            return Ok($"Good conneciton to {conn}");
        }
    }
}
