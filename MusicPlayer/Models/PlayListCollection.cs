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
    [DataContract]
    class PlayListCollection
    {
        [DataMember]
        public List<PlayListDataModel> Playlists { get; set; }
    }

    [DataContract]
    public class PlayListDataModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public AdvancedCollectionView MusicList_list = new AdvancedCollectionView(new ObservableCollection<Music>());
    }
}
