using com.sun.org.apache.regexp.@internal;

namespace MyDrive_API.Classes
{
    public static class Utiles
    {
        public static async Task<byte[]> ConvertIformFileToByteArray(IFormFile file)
        {
            byte[]? data = null;

            if( file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    data = memoryStream.ToArray();
                }
            }

            return data;
        }

        public static string CreateFileId()
        {
            string id = string.Empty;

            /*DateTime dateTime = DateTime.UtcNow;
            string year = dateTime.Year.ToString().Substring(2, 2);
            string month = dateTime.Month.ToString().Substring(0, 2);
            string hour = dateTime.Hour.ToString().Substring(0, 2);
            string minute = dateTime.Minute.ToString().Substring(0, 2);
            string second = dateTime.Second.ToString().Substring(0, 2);
            string miliSecond = dateTime.Millisecond.ToString().Substring(0, 2);*/

            Random random = new Random();
            string rm = random.Next(0,99).ToString();

            // id = year + month + hour + minute + second + miliSecond + rm;
            id = rm;

            return id;
        }
    }
}
