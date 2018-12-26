using Microsoft.Toolkit.Uwp.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class MusicList
    {
        public string MusicList_Name { get; set; }
        public ObservableCollection<SaveMusic> Musics = new ObservableCollection<SaveMusic>();
        public string MusicListColor_str { get; set; }
    }

    public class SaveMusicList//用于保存List数据
    {
        public string MusicList_Name { get; set; }
        public  List<SaveMusic> SaveMusics = new List<SaveMusic>();
        
    }
}
