using Microsoft.Toolkit.Uwp.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class MusicList
    {
        public string MusicList_Name { get; set; }
        public AdvancedCollectionView Musics = new AdvancedCollectionView(new ObservableCollection<Music>());
    }

    public class SaveMusicList
    {
        public string MusicList_Name { get; set; }
        public AdvancedCollectionView SaveMusics = new AdvancedCollectionView(new ObservableCollection<SaveMusic>());
    }
}
