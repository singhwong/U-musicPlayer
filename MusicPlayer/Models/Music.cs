using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace MusicPlayer.Models
{
    public class Music
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Music_Path { get; set; }
        public BitmapImage Cover { get; set; }
        public StorageFile SongFile { get; set; }
        public int Id { get; set; }
        public SolidColorBrush Music_Color { get; set; }
        public string Album_title { get; set; }
        public IRandomAccessStream Music_Stream { get; set; }
        public string MusicSeconds_Str { get; set; }
    }

    public class SaveMusic//用于保存为XML文件
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Music_Path { get; set; }
        public int Id { get; set; }
        public string Album_title { get; set; }
        public string MusicSeconds_Str { get; set; }
        //public SolidColorBrush SaveMusic_Color { get; set; }
        public string SaveMusicColor_str { get; set; }
    }
}
