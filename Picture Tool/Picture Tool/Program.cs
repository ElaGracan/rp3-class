using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Pictute_Tool
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

        public static string Serialize(PictureBox objectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PictureBox));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, objectToSerialize);
            return textWriter.ToString();
        }


        public static PictureBox Deserialize(string stringToDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PictureBox));
            StringReader textReader = new StringReader(stringToDeserialize);
            return (PictureBox)xmlSerializer.Deserialize(textReader);
        }
    }
}
