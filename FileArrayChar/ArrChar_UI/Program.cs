using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArrayChar;

namespace ArrChar_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FileArrayChar fileArrayChar = new FileArrayChar("1.txt", 7);
            fileArrayChar[2] = 'A';
            fileArrayChar[4] = 'N';
            fileArrayChar[6] = 'C';

            for (int i = 0; i < fileArrayChar.Length; i++)
                Console.WriteLine($"{i}: {fileArrayChar[i]}");

            Console.ReadLine();
        }
    }
}
