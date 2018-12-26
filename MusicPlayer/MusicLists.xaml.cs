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
    public sealed partial class MusicLists : UserControl
    {
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);
        private SolidColorBrush white = new SolidColorBrush(Colors.White);
        private SolidColorBrush skyblue = new SolidColorBrush(Colors.SkyBlue);
        public MusicList this_musicList { get { return this.DataContext as MusicList; } }
        public MusicLists()
        {
            this.InitializeComponent();
            this.DataContextChanged += (s, e) => Bindings.Update();
            main_storyBoard.Begin();
        }

        private void main_storyBoard_Completed(object sender, object e)
        {
            try
            {
                switch (this_musicList.MusicListColor_str)
                {
                    case "black":musicList_textblock.Foreground = black;break;
                    case "white":musicList_textblock.Foreground = white;break;
                    case "skyblue":musicList_textblock.Foreground = skyblue;break;
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
