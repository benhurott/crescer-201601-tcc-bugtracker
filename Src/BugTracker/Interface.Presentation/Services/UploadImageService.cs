using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Interface.Presentation.Services
{
    public static class UploadImageService
    {
        private static string userImagePath = PathService.userImagePath;
        private static string applicationImagePath = PathService.applicationImagePath;

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