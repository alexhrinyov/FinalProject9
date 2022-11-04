using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Task1
{
    internal class Program
    {
        static Exception[] exceptions;
        static void Main(string[] args)
        {
            Exception1 Exception1 = new Exception1();
            ArgumentException Exception2 = new ArgumentException();
            ArgumentOutOfRangeException Exception3 = new ArgumentOutOfRangeException();
            ArgumentNullException Exception4 = new ArgumentNullException();
            DirectoryNotFoundException Exception5 = new DirectoryNotFoundException();
            exceptions = new Exception[5] {Exception1, Exception2, Exception3, Exception4, Exception5 };

            foreach (var item in exceptions)
            {        
                try
                {
                    throw item;
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }       
        }

    }
    class Exception1 : Exception
    {
        static string message = "Новое исключение";
        public Exception1() : base(message)
        {

        }
    }
    
}
