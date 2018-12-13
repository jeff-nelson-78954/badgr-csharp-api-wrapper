using System;
using System.IO;

namespace Badgr.Utilities
{
    public static class ImageUtilities
    {
        public static string GetBase64(string filePath)
        {
            byte[] imageArray = File.ReadAllBytes(filePath);
            return "data:image/png;base64," + Convert.ToBase64String(imageArray);
        }
    }
}
