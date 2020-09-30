using System;
using System.IO;
using System.Text;

namespace ArrayChar
{
    public class FileArrayChar
    {
        public string Path { get; private set; }
        public int Length { get; private set; }

        public char this[int i]
        {
            get
            {
                char tmp;

                using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader sw = new StreamReader(fs, Encoding.GetEncoding("windows-1251"));
                    fs.Seek(i, SeekOrigin.Begin);
                    sw = new StreamReader(fs);

                    tmp = Convert.ToChar(sw.Read());
                    sw.Close();
                }

                return tmp;
            }
            set
            {
                using (FileStream fs = new FileStream(Path, FileMode.Open, FileAccess.Write))
                {
                    StreamWriter sw = new StreamWriter(fs, Encoding.GetEncoding("windows-1251"));
                    sw.Flush();
                    fs.Seek(i, SeekOrigin.Begin);
                    sw = new StreamWriter(fs);

                    sw.Write(value);
                    sw.Close();
                }
            }
        }
        public FileArrayChar(string path, int length)
        {
            Length = length;
            Path = path;    //TODO: Add checkings

            var arrayByte = new byte[length];
            for (int i = 0; i < arrayByte.Length; i++)
                arrayByte[i] = Convert.ToByte(' ');

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                fileStream.Write(arrayByte, 0, arrayByte.Length);
            }
        }
    }
}
