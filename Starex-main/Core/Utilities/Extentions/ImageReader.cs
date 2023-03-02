using Microsoft.AspNetCore.Http;
namespace Core.Utilities.Extentions
{
    public static class ImageReader
    {
        public static bool IsImage(this IFormFile formFile)
        {
            return formFile.ContentType.Contains("image/");
        }
        public static bool IsSizeOk(this IFormFile FormFile, int size)
        {
            return FormFile.Length / 1024 / 1024 <= size;
        }

        public static string SaveImage(this IFormFile FormFile, string root, string folder)
        {
            string RootPath = Path.Combine(root, folder);
            string FileName = Guid.NewGuid().ToString() + FormFile.FileName;
            string FullPath = Path.Combine(RootPath, FileName);
            using (FileStream fileStream = new FileStream(FullPath, FileMode.Create))
            {
                FormFile.CopyTo(fileStream);
            }
            return FileName;
        }

    }
}
