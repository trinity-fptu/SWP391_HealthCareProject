namespace SWP391_HealthCareProject.DataAccess
{
    public static class UploadedFileProcessor
    {
        public static string SaveUploadedFile(this IFormFile uploadedFile, string path, string savedName)
        {
            string fileExtension = uploadedFile.FileName.Substring(uploadedFile.FileName.IndexOf('.') + 1);
            string fileName = $"{savedName}.{fileExtension}";
            fileName = Path.GetFileName(fileName);
            string uploadFilepath = Path.Combine(path, fileName);
            try
            {
                using (var stream = new FileStream(uploadFilepath, FileMode.Create))
                {
                    uploadedFile.CopyTo(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return uploadFilepath;
        }
    }
}