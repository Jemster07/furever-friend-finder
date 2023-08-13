using Microsoft.AspNetCore.SignalR;
using System.Web;

namespace Capstone.Models
{
    public class PetFinderApiAuth
    {
        public string client_id { get; set; }
        public string grant_type { get; set; }
        public string client_secret { get; set; }


        //public PetFinderApiAuth(string client_id, string grant_type, string client_secret)
        //{
        //    this.client_id = client_id;
        //    this.grant_type = grant_type;
        //    this.client_secret = client_secret;
        //
        //}
    }
}