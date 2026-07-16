namespace OtoServisSatis.WebUI.Utils
{
    public class FileHelper
    {
        // dosya yükleme işlemi için bir yardımcı metot,
        //formFile parametresi ile yüklenen dosyayı alır ve belirtilen dosya yoluna kaydeder.
        public static async Task<string> FileLoaderAsync(IFormFile formFile, string filePath = "/Img/")
        {
            var fileName = "";
            if (formFile != null && formFile.Length > 0 )
            {
                fileName = formFile.FileName;
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/" + filePath + fileName;
                using var stream = new FileStream(directory, FileMode.Create);
                await formFile.CopyToAsync(stream);
            }
            return fileName; 
        }
    }
}
