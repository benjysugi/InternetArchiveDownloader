using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace XmlSchema {
    [XmlRoot(ElementName = "file")]
    public class File {
        [XmlElement(ElementName = "mtime")]
        public string Mtime { get; set; }
        [XmlElement(ElementName = "size")]
        public string Size { get; set; }
        [XmlElement(ElementName = "md5")]
        public string Md5 { get; set; }
        [XmlElement(ElementName = "crc32")]
        public string Crc32 { get; set; }
        [XmlElement(ElementName = "sha1")]
        public string Sha1 { get; set; }
        [XmlElement(ElementName = "format")]
        public string Format { get; set; }
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "source")]
        public string Source { get; set; }
        [XmlElement(ElementName = "rotation")]
        public string Rotation { get; set; }
        [XmlElement(ElementName = "length")]
        public string Length { get; set; }
        [XmlElement(ElementName = "height")]
        public string Height { get; set; }
        [XmlElement(ElementName = "width")]
        public string Width { get; set; }
        [XmlElement(ElementName = "btih")]
        public string Btih { get; set; }
        [XmlElement(ElementName = "summation")]
        public string Summation { get; set; }
    }

    [XmlRoot(ElementName = "files")]
    public class Files {
        [XmlElement(ElementName = "file")]
        public List<File> File { get; set; }
    }

}
