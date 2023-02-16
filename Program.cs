using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace DeleteFileOnXDays
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string path = ConfigurationManager.AppSettings["FilePath"];
            int x = Convert.ToInt32(ConfigurationManager.AppSettings["Days"]);
            //Console.WriteLine(x);
            TimeSpan timeSpan = TimeSpan.FromDays(x);

            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                if (File.GetLastWriteTime(file) < DateTime.Now.Subtract(timeSpan))
                {
                    File.Delete(file);
                }
            }

        }
    }
}
