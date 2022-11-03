using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Aranda.Services
{
    public static class UploadFile
    {
        public static string Upload(IFormFile img)
        {
            var myAccount = new Account { ApiKey = "822319639789959", ApiSecret = "5VL6niAd7lMolt9cRcG4eHwcv1k", Cloud = "dr5e9fzqn" };

            Cloudinary _cloudinary = new Cloudinary(myAccount);

            if (img != null)
            {
                byte[] destinationData;

                using (var ms = new MemoryStream())
                {
                    img.CopyToAsync(ms);
                    destinationData = ms.ToArray();
                }

                UploadResult uploadResult = null;

                using (var ms = new MemoryStream(destinationData))
                {
                    ImageUploadParams uploadParams = new ImageUploadParams
                    {
                        Folder = "Aranda",
                        File = new FileDescription("Profile", ms),

                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }

                return uploadResult.SecureUri.AbsoluteUri;
            }
            else
            {
                return "Not img";
            }


        }
    }
}
