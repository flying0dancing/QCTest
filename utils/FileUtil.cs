using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QCTest
{
    class FileUtil
    {
        private FileUtil() { }
        public static void createFolder(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (UnauthorizedAccessException)
            {

                Console.WriteLine("UnauthorizedAccessException");
            }
            catch (IOException)
            {
                Console.WriteLine("IOException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void createFile(string path, string filename)
        {
            try
            {
                string fullname = Path.Combine(path, filename);
                if (File.Exists(fullname))
                {
                    File.Delete(fullname);
                    Console.WriteLine("Delete file:" + fullname);
                }
                using (File.Create(fullname)) {
                    Console.WriteLine("Create new file:" + fullname);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public static string readFileContentToString(String path)
        {
            
            string content;
            using (StreamReader sr = new StreamReader(path))
            {
                content = sr.ReadToEnd();
            }
            return content;
        }

        public static bool isNotEmptyStr(string str) {
            bool flag = false;
            if (str!=null && str.Trim()!="")
            {
                flag = true;
            }
            return flag;
        }
    }
}
