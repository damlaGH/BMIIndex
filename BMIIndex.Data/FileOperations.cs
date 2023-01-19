using System.Reflection.Metadata.Ecma335;

namespace BMIIndex.Data
{
    public class FileOperations
    {
        private const string fileRoad = "data.txt";

        public static void Write(string data)
        {
            File.WriteAllText(fileRoad, data);    //if there is no file make a new file, else write to old file.
        }
        public static string Read()
        {
            if (File.Exists(fileRoad))
                return File.ReadAllText(fileRoad);    //if there is no file make a new file, else write to old file.
            return string.Empty;
        }
    }
}