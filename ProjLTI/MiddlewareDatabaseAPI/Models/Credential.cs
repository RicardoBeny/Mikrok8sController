using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiddlewareDatabaseAPI.Models
{
    public class Credential
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Porto_ssh { get; set; }
        public string Porto_api { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
    }
}