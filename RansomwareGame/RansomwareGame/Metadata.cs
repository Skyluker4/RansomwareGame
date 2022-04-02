using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RansomwareGame
{
    internal class Metadata
    {
        public string path;
        public int size;
        public FileTime modified;
        public FileTime created;
        public FileTime accessed;
        public bool isFile;
        public bool isDirectory;
        public bool isLink;
        public bool isMount;

        public static Metadata[] files;

        private static Metadata readLine(string line)
        {
            // Separate commas
            string[] parts = line.Split(',');

            string path = parts[0];
            int size = int.Parse(parts[1]);
            FileTime modified = new FileTime(parts[2]);
            FileTime created = new FileTime(parts[3]);
            FileTime accessed = new FileTime(parts[4]);
            bool isFile = bool.Parse(parts[5]);
            bool isDirectory = bool.Parse(parts[6]);
            bool isLink = bool.Parse(parts[7]);
            bool isMount = bool.Parse(parts[8]);

            return new Metadata()
            {
                path = path,
                size = size,
                modified = modified,
                created = created,
                accessed = accessed,
                isFile = isFile,
                isDirectory = isDirectory,
                isLink = isLink,
                isMount = isMount
            };
        }

        public static void readCSV(string path)
        {
            // Open the file to read from.
            System.IO.StreamReader file =
                new System.IO.StreamReader(path);

            // Read all lines of text
            string line = file.ReadLine();
            while (line != null)
            {
                //Console.WriteLine(line);
                line = file.ReadLine();
                files.Append(readLine(line));
            }
        }
    }
}
