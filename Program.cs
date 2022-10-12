using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace InternetArchiveDownloader {
    internal class Program {
        static string temp = Environment.GetEnvironmentVariable("TEMP");

        static void Main(string[] args) {
            Console.Write("Enter the ID (the bit after the /details/:> ");
            string id = Console.ReadLine();

            Console.Write("Enter the path you want to download to :> ");
            string dlFinal = Console.ReadLine();

            string downloadRoot = "https://archive.org/download";

            string xmlLocalPath = temp + "\\" + id + ".xml";

            try {
                string dlPath = $"{downloadRoot}/{id}/{id}_files.xml";

                using (var wc = new WebClient()) {
                    wc.DownloadFile(dlPath, xmlLocalPath);
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }

            if(File.Exists(xmlLocalPath)) {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlSchema.Files));

                XmlSchema.Files deserialized;

                using (Stream reader = new FileStream(xmlLocalPath, FileMode.Open)) {
                    deserialized = (XmlSchema.Files)serializer.Deserialize(reader);
                }

                File.Delete(xmlLocalPath);

                foreach (var file in deserialized.File) {
                    Console.WriteLine(file.Name);

                    string fileName = file.Name;
                    string fileNamePathFriendly = file.Name.Replace("/", "\\");

                    string dlPath = dlFinal + "\\" + fileNamePathFriendly;

                    string webFile = $"{downloadRoot}/{id}/{fileName}";

                    try {
                        Directory.CreateDirectory(Path.GetDirectoryName(dlPath));
                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }

                    try {
                        using(var wc = new WebClient()) {
                            wc.DownloadFile(webFile, dlPath);
                        }
                    }
                    catch(Exception ex) {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
