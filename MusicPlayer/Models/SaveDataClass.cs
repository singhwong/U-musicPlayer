using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Xaml.Shapes;

namespace MusicPlayer.Models
{
    public class SaveDataClass
    {

        public static void SaveMusicListData(List<SaveMusicList> list, string folder_path)
        {
            FileStream writer = new FileStream(folder_path, FileMode.Create);

            DataContractSerializer ser = new DataContractSerializer(typeof(List<SaveMusicList>));
            ser.WriteObject(writer, list);
            writer.Dispose();
        }

        public static List<SaveMusicList> ReadMusicListData(string folder_path)
        {
            List<SaveMusicList> objectMusic = new List<SaveMusicList>();
            FileStream fs = new FileStream(folder_path, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(List<SaveMusicList>));
            objectMusic = (List<SaveMusicList>)ser.ReadObject(reader, true);
            reader.Dispose();
            fs.Dispose();
            return objectMusic;
        }
    }
}
