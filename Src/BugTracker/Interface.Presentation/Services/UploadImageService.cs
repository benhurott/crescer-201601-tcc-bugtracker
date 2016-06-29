using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Services
{
    public static class UploadImageService
    {
        private static string serverPath = HttpContext.Current.Server.MapPath("~/");

        private static string userImagePath = serverPath + "/Content/Images/Application";
        private static string applicationImagePath = serverPath + ("/Content/Images/User");

        public static bool UploadUserImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(userImagePath, fileName);

                file.SaveAs(path);

                return true;
            }

            return false;
        }

        public static bool UploadApplicationImage(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(applicationImagePath, fileName);

                file.SaveAs(path);

                return true;
            }

            return false;
        }
    }
}