using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DrawingTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static T Deserialize<T>(string stringToDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringReader textReader = new StringReader(stringToDeserialize);
            return (T)xmlSerializer.Deserialize(textReader);
        }

        public static string Serialize<T>(T objectToSerialize)
        {

            XmlSerializer xml_serializer =
            new XmlSerializer(objectToSerialize.GetType());
            using (StringWriter stream_writer =
                new StringWriter())
            {
                xml_serializer.Serialize(stream_writer, objectToSerialize);
                return stream_writer.ToString(); 
            }
            
        }

    }
}
