using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Text;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace proxy_cameras
{
    public class AuthenticatedRequest
    {
        private ICamerasConfiguration _camerasConfiguration;
        private CameraSetting _cameraSetting;

        public AuthenticatedRequest(ICamerasConfiguration camerasConfiguration)
        {
            this._camerasConfiguration = camerasConfiguration;
        }

        public string GetImage(CameraSetting cameraSetting)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(cameraSetting.Url);
            request.AllowWriteStreamBuffering = true;
            request.Credentials = new NetworkCredential(_camerasConfiguration.User, _camerasConfiguration.Password);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    var x = stream;
                }
            }

            return "x";
        }

    }
}
