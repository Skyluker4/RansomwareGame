using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace RansomwareGame
{
    internal class FileTime
    {
        public int year;
        public int day;
        public int month;

        public FileTime(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        public FileTime(string isoTime)
        {
            var split = isoTime.Split('-');
            this.year = int.Parse(split[0]);
            this.month = int.Parse(split[1]);
            this.day = int.Parse(split[2].Substring(0,2));
        }
    }
}
