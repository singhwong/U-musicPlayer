using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.Models
{
    public class AutoRemoveMusicFromList
    {
        public static void RemoveMusicFromList(ObservableCollection<Music> mainMusics,ObservableCollection<MusicList> mainMusicLists,
            List<SaveMusicList> saveMusicLists)
        {
            var path_list = new List<String>();
            foreach (var music in mainMusics)
            {
                path_list.Add(music.Music_Path);
            }
            for (int i = 0; i < mainMusicLists.Count; i++)
            {
                for (int j = 0; j < mainMusicLists[i].Musics.Count; j++)
                {
                    if (!path_list.Contains(mainMusicLists[i].Musics[j].Music_Path))
                    {
                        mainMusicLists[i].Musics.Remove(mainMusicLists[i].Musics[j]);
                    }
                }
            }
            for (int i = 0; i < saveMusicLists.Count; i++)
            {
                for (int j = 0; j < saveMusicLists[i].SaveMusics.Count; j++)
                {
                    if (!path_list.Contains(saveMusicLists[i].SaveMusics[j].Music_Path))
                    {
                        saveMusicLists[i].SaveMusics.Remove(saveMusicLists[i].SaveMusics[j]);
                    }
                }
            }
            path_list.Clear();
        }
    }
}
