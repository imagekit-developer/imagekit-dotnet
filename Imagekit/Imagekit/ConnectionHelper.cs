using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagekit
{
    public static class ConnectionHelper
    {
        public static void Initialize(string APIPublic, string APIPrivate, string ImageKitID )
        {
            Secret.Address = "https://upload.imagekit.io/rest/api/image/v2/" + ImageKitID;
            Secret.ApiKey = APIPublic;
            Secret.ApiPrivate = APIPrivate;

        }
    }
}
