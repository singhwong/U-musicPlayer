using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace MusicPlayer
{

    public sealed partial class MusicListSongsShow : UserControl
    {
        private SolidColorBrush transParent = new SolidColorBrush(Colors.Transparent);
        private SolidColorBrush red = new SolidColorBrush(Colors.Red);
        public SaveMusic this_music { get { return this.DataContext as SaveMusic; } }
        public MusicListSongsShow()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
            main_storyBoard.Begin();
        }

        private void main_storyBoard_Completed(object sender, object e)
        {
            try
            {
                switch (this_music.SaveMusicColor_str)
                {
                    case "transparent": icon_textblock.Foreground = transParent; break;
                    case "red": icon_textblock.Foreground = red; break;
                    default:
                        break;
                }
            }
            catch
            {
            }
            main_storyBoard.Begin();
        }
    }
}
