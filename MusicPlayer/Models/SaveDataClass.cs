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
        
        public static void SaveMusicListData(List<MusicList> list, string folder_path)
        {
            //var serializer = new XmlSerializer(typeof(List<MusicList>));
            //StorageFolder folder = ApplicationData.Current.LocalCacheFolder;
            //StorageFile file = await folder.CreateFileAsync(folder_path, CreationCollisionOption.ReplaceExisting);
            //Stream stream = await file.OpenStreamForWriteAsync();
            //using (stream)
            //{
            //    serializer.Serialize(stream, List);
            //}

            //if (System.IO.File.Exists(folder_path))
            //{
            //    System.IO.FileAttributes attr = File.GetAttributes(folder_path);
            //    if (attr == System.IO.FileAttributes.Directory)
            //    {
            //        Directory.Delete(folder_path, true);
            //    }
            //    else
            //    {
            //        //File.Delete(folder_path);
            //    }
            //}
            FileStream writer = new FileStream(folder_path, FileMode.Create);
            
                DataContractSerializer ser = new DataContractSerializer(typeof(List<MusicList>));
                ser.WriteObject(writer, list);
                writer.Dispose();

            
            

        }

        public static List<MusicList> ReadMusicListData(string folder_path)
        {
            List<MusicList> objectMusic = new List<MusicList>();
            //var serializer = new XmlSerializer(typeof(List<MusicList>));
            //StorageFolder folder = ApplicationData.Current.LocalFolder;
            //StorageFile file = await folder.GetFileAsync(folder_path);
            //Stream stream = await file.OpenStreamForReadAsync();
            //objectMusic = (List<MusicList>)serializer.Deserialize(stream);
            //stream.Dispose();
            //return objectMusic;

            FileStream fs = new FileStream(folder_path, FileMode.Open);
            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(List<MusicList>));
            objectMusic = (List<MusicList>)ser.ReadObject(reader, true);
            //reader.Dispose();
            fs.Dispose();
            return objectMusic;
        }
    }
}
