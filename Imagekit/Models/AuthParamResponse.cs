namespace Imagekit.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class AuthParamResponse
    {
        public string token { get; set; }

        public string expire { get; set; }

        public string signature { get; set; }
    }
}
