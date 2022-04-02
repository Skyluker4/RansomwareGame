using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RansomwareGame
{
    internal class Metadata
    {
        public string path;
        public string fileName;
        public int size;
        public FileTime modified;
        public FileTime created;
        public FileTime accessed;
        public bool isFile;
        public bool isDirectory;
        public bool isLink;
        public bool isMount;

        public static List<Metadata> files = new List<Metadata>();

        private static Metadata readLine(string line)
        {
            // Separate commas
            string[] parts = line.Split(',');

            string path = parts[0];
            int size = int.Parse(parts[1]);
            FileTime modified = new FileTime(parts[2]);
            FileTime created = new FileTime(parts[3]);
            FileTime accessed = new FileTime(parts[4]);
            bool isFile = int.Parse(parts[5]) > 0;
            bool isDirectory = int.Parse(parts[6]) > 0;
            bool isLink = int.Parse(parts[7]) > 0;
            bool isMount = int.Parse(parts[8]) > 0;

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

        private void setFilename() {
            fileName = path.Split('\\').Last();
        }

        public static void readCSV(string path)
        {
            // Open the file to read from.
            var file =
                new System.IO.StreamReader(path);

            // Read all lines of text
            string line = file.ReadLine();
            while (line != null)
            {
                //Console.WriteLine(line);
                line = file.ReadLine();
                if (line == "" || line == null)
                {
                    line = file.ReadLine();
                    continue;
                }
                var metadata = readLine(line);
                if (metadata.isFile && metadata.size > 0)
                {
                    metadata.setFilename();
                    files.Add(metadata);
                }
            }

            file.Close();
        }
    }
}
