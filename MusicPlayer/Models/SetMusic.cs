using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace MusicPlayer.Models
{
    public class SetMusic
    {
        public static Music GetMusicByStream(ObservableCollection<Music> music,IRandomAccessStream stream)
        {
            Music music_value = new Music();
            foreach (var item in music)
            {
                if (item.Music_Stream==stream)
                {
                    music_value = item;
                }
            }
            return music_value;
        }

        public static Music GetMusicByPath(ObservableCollection<Music> music, string path)
        {
            Music music_value = new Music();
            foreach (var item in music)
            {
                if (item.Music_Path == path)
                {
                    music_value = item;
                }
            }
            return music_value;
        }
    }
}
