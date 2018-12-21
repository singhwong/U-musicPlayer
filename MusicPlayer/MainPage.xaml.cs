using Microsoft.Toolkit.Uwp.UI;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Resources;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using static MusicPlayer.Models.LyricService;

using Windows.Media.Playlists;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;


// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace MusicPlayer
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private ObservableCollection<MusicList> main_musicList;
        private List<SaveMusicList> save_mainMusicList;
        private static StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        private string filePath = storageFolder.Path + @"\PlaylistCollection.xml";

        private ObservableCollection<Music> use_music;
        private ObservableCollection<StorageFile> allMusic;
        private Music main_music;
        private Music local_music;
        private bool RandomPlay_bool = false;
        private bool ListPlay_bool = true;
        private bool SingleCycle_bool = false;
        private bool IsBackButtonClick = false;
        private bool IsMusicPlaying = false;
        private bool IsVolumeOpen = true;
        private string source_path;
        private string image_source_path;
        private string backGround_path;
        private string theme_str;
        private string isCustom_str;
        private string mm_str;
        private string ss_str;
        private string allmm_str;
        private string allss_str;
        private string play_str;
        private string pause_str;
        private string single_str;
        private string order_str;
        private string random_str;

        private string _searchLyric_str;
        private string _clearLyric_str;
        private double volume_value;
        private double volume_num;
        private ImageBrush imageBrush = new ImageBrush();
        private ImageBrush imageBrush_ellipse = new ImageBrush();
        private BitmapImage Album_Cover = new BitmapImage();
        private int allsong_count;
        private int num = 0;
        private int allListSongsCount = 0;
        private ApplicationDataContainer local_volume = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_backGround = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_musicPath = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_allTime = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_theme = ApplicationData.Current.LocalSettings;
        private ApplicationDataContainer local_IsCustom = ApplicationData.Current.LocalSettings;
        #region 初始化并设置颜色
        private SolidColorBrush white = new SolidColorBrush(Colors.White);
        private SolidColorBrush transParent = new SolidColorBrush(Colors.Transparent);
        private SolidColorBrush red = new SolidColorBrush(Colors.Red);
        private SolidColorBrush lightPink = new SolidColorBrush(Colors.LightPink);
        private SolidColorBrush skyblue = new SolidColorBrush(Colors.SkyBlue);
        private SolidColorBrush black = new SolidColorBrush(Colors.Black);
        //private SolidColorBrush red = new SolidColorBrush(Colors.Red);
        #endregion
        private Color newWhite = Colors.White;
        private Color newBlack = Colors.Black;
        private AcrylicBrush myBrush = new AcrylicBrush();
        private string local_allTimeStr;
        private StorageFolder folder;
        private IRandomAccessStream main_stream;
        private SystemMediaTransportControls systemMedia_TransportControls = SystemMediaTransportControls.GetForCurrentView();
        public MainPage()
        {
            this.InitializeComponent();
            ExtendAcrylicIntoTitleBar();
            main_musicList = new ObservableCollection<MusicList>();
            save_mainMusicList = new List<SaveMusicList>();

            use_music = new ObservableCollection<Music>();
            allMusic = new ObservableCollection<StorageFile>();
        }

        private void SetAllTimeMethod()
        {
            #region 播放时间动态显示
            int allSeconds = (int)main_slider.Maximum;
            int currentSeconds = (int)main_slider.Value;
            int mm = currentSeconds / 60;
            int ss = currentSeconds % 60;
            int all_mm = allSeconds / 60;
            int all_ss = allSeconds % 60;
            if (mm > 9)
            {
                mm_str = mm.ToString();
            }
            else
            {
                mm_str = "0" + mm.ToString();
            }
            if (ss > 9)
            {
                ss_str = ss.ToString();
            }
            else
            {
                ss_str = "0" + ss.ToString();
            }
            if (all_mm > 9)
            {
                allmm_str = all_mm.ToString();
            }
            else
            {
                allmm_str = "0" + all_mm.ToString();
            }
            if (all_ss > 9)
            {
                allss_str = all_ss.ToString();
            }
            else
            {
                allss_str = "0" + all_ss.ToString();
            }
            playTime_textblock.Text = mm_str + ":" + ss_str + "/" + allmm_str + ":" + allss_str;
            local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
            #endregion
        }

        private void Random_Source()
        {
            #region 随机播放设置

            allsong_count = use_music.Count;
            Random rm = new Random();
            int index = rm.Next(0, allsong_count);
            main_music = use_music[index];
            source_path = main_music.Music_Path;
            _musicStream = main_music.Music_Stream;
            try
            {
                main_mediaElement.SetSource(main_music.Music_Stream, main_music.SongFile.ContentType);//对流的访问
            }
            catch
            {
                SetPlayErrorMethod();
            }

            Album_Cover = main_music.Cover;
            main_image.Source = Album_Cover;
            songTile_textblock.Text = main_music.Title;
            artist_textblock.Text = main_music.Artist;
            album_textblock.Text = "【" + main_music.album_title + "】";
            playTitle_textblock.Text = songTile_textblock.Text;
            playArtist_textblock.Text = main_music.Artist;
            line_textblock.Text = " - ";
            //GetLyrics(main_music.Artist,main_music.Title);
            main_music.Music_Color = skyblue;
            if (main_savemusic != null)
            {
                main_savemusic.SaveMusic_Color = transParent;
            }            
            lyric_textblock.Text = "";
            lyric_button.Content = resourceLoader.GetString("searchLyric_str");
            #endregion
        }

        private void SetMusicListRandomPlay()
        {
            //var random_music = SetMusic.GetMusicByStream(use_music,_musicStream);
            Random rd_2 = new Random();
            int random_index = rd_2.Next(0,value_List.Musics.Count);
            main_savemusic = value_List.Musics[random_index];//获取歌单列表歌曲
            string random_path = main_savemusic.Music_Path;
            main_music = SetMusic.GetMusicByPath(use_music,random_path);
            #region 重复代码，后续需要进行简化优化
            source_path = main_music.Music_Path;
            _musicStream = main_music.Music_Stream;
            try
            {
                main_mediaElement.SetSource(main_music.Music_Stream, main_music.SongFile.ContentType);//对流的访问
            }
            catch
            {
                SetPlayErrorMethod();
            }

            Album_Cover = main_music.Cover;
            main_image.Source = Album_Cover;
            songTile_textblock.Text = main_music.Title;
            artist_textblock.Text = main_music.Artist;
            album_textblock.Text = "【" + main_music.album_title + "】";
            playTitle_textblock.Text = songTile_textblock.Text;
            playArtist_textblock.Text = main_music.Artist;
            line_textblock.Text = " - ";
            //GetLyrics(main_music.Artist,main_music.Title);
            ClearUseMusicIconColor();//清除获取的总歌曲icon颜色并设置歌单歌曲列表icon颜色
            lyric_textblock.Text = "";
            lyric_button.Content = resourceLoader.GetString("searchLyric_str");
            #endregion

        }
        private IRandomAccessStream _musicStream;

        private int num_2 = 0;
        private void SetMusicListListPlay()
        {
            #region 歌单列表顺序播放
            int index_2 = 0;
            var list_music2 = SetMusic.GetMusicByStream(use_music,_musicStream);
            string path = list_music2.Music_Path;
            for (int i = 0; i < value_List.Musics.Count; i++)
            {
                if (value_List.Musics[i].Music_Path == path)
                {
                    index_2 = i;
                }
            }
            if (IsBackButtonClick)
            {
                num_2 = index_2 - 1;
                IsBackButtonClick = false;
            }
            else
            {
                num_2 = index_2 + 1;
            }
            if (num_2 == value_List.Musics.Count)
            {
                num_2 = 0;
            }
            else if (num_2 == -1)
            {
                num_2 = value_List.Musics.Count - 1;
            }
            main_savemusic = value_List.Musics[num_2];//获取歌单列表歌曲
            string value_path = main_savemusic.Music_Path;
            main_music = SetMusic.GetMusicByPath(use_music,value_path);
            #region 重复代码(List_Source())，需要优化
            source_path = main_music.Music_Path;
            _musicStream = main_music.Music_Stream;
            try//从本地删除歌曲后，列表未删除，引发播放异常
            {
                main_mediaElement.SetSource(main_music.Music_Stream, main_music.SongFile.ContentType);//对流的访问
            }
            catch
            {
                SetPlayErrorMethod();
            }

            Album_Cover = main_music.Cover;
            main_image.Source = Album_Cover;
            songTile_textblock.Text = main_music.Title;
            artist_textblock.Text = main_music.Artist;
            album_textblock.Text = "【" + main_music.album_title + "】";
            playTitle_textblock.Text = songTile_textblock.Text;
            playArtist_textblock.Text = main_music.Artist;
            line_textblock.Text = " - ";
            //GetLyrics(main_music.Artist,main_music.Title);
            ClearUseMusicIconColor();//清除获取的总歌曲icon颜色并设置歌单歌曲列表icon颜色
            lyric_textblock.Text = "";
            lyric_button.Content = resourceLoader.GetString("searchLyric_str");
            #endregion
            #endregion
        }
        private void List_Source()
        {
            #region 顺序播放设置
            int index = 0;
            var list_music = SetMusic.GetMusicByStream(use_music, _musicStream);
                for (int i = 0; i <= use_music.Count - 1; i++)
                {
                    if (use_music[i] == list_music)
                    {
                        index = i;
                    }
                }
                if (IsBackButtonClick)
                {
                    num = index - 1;
                    IsBackButtonClick = false;
                }
                else
                {
                    num = index + 1;
                }
                if (num == use_music.Count)
                {
                    num = 0;
                }
                else if (num == -1)
                {
                    num = use_music.Count - 1;
                }
                main_music = use_music[num];
            source_path = main_music.Music_Path;
            _musicStream = main_music.Music_Stream;
            try//从本地删除歌曲后，列表未删除，引发播放异常
            {
                main_mediaElement.SetSource(main_music.Music_Stream, main_music.SongFile.ContentType);//对流的访问
            }
            catch
            {
                SetPlayErrorMethod();
            }

            Album_Cover = main_music.Cover;
            main_image.Source = Album_Cover;
            songTile_textblock.Text = main_music.Title;
            artist_textblock.Text = main_music.Artist;
            album_textblock.Text = "【" + main_music.album_title + "】";
            playTitle_textblock.Text = songTile_textblock.Text;
            playArtist_textblock.Text = main_music.Artist;
            line_textblock.Text = " - ";
            //GetLyrics(main_music.Artist,main_music.Title);
            main_music.Music_Color = skyblue;
            if (main_savemusic != null)
            {
                main_savemusic.SaveMusic_Color = transParent;
            }           
            lyric_textblock.Text = "";
            lyric_button.Content = resourceLoader.GetString("searchLyric_str");
            #endregion
        }
        private ResourceLoader resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();
        private async void SetPlayErrorMethod()
        {
            string content_str = resourceLoader.GetString("content_str");
            ContentDialog content = new ContentDialog
            {
                Content = content_str,
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
                Background = skyblue,
                Foreground = white,
            };
            ContentDialogResult result = await content.ShowAsync();
        }
        private void Single_Cycle()
        {
            main_mediaElement.SetSource(main_music.Music_Stream, main_music.SongFile.ContentType);
        }

        //初始化Load
        public AdvancedCollectionView local_musics;
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ReadLocalMusicListData();//获取保存的历史歌单数据
            main_slider.Maximum = 0;//第二次启动，上次保存歌曲进度条，在播放前不可滑动，以优化时间显示
            #region 显示并启用后台运行控件按钮
            systemMedia_TransportControls.IsPlayEnabled = true;
            systemMedia_TransportControls.IsPauseEnabled = true;
            systemMedia_TransportControls.IsPreviousEnabled = true;
            systemMedia_TransportControls.IsNextEnabled = true;
            systemMedia_TransportControls.ButtonPressed += SystemControls_ButtonPressed;
            #endregion
            if (Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.IsSupported())
            {
                this.feedBack_menu.Visibility = Visibility.Visible;
            }//确定设备是否显示反馈按钮
            ListPlay_bool = true;
            GetLocalMusic();//获取本地音乐文件ListView

            playTime_textblock.Text = "00:00/00:00";

            HistoryThemeHelpMethod();//根据保存的主题,启动后运行该主题
            HistoryBackGroundHelpMethod();//若上次设置的是自定义图片,则自动将backGround设置为该图片
            HistoryVolumeHelpMethod();//设置保存的音量

            play_str = resourceLoader.GetString("play_str");
            pause_str = resourceLoader.GetString("pause_str");
            single_str = resourceLoader.GetString("single_str");
            order_str = resourceLoader.GetString("order_str");
            random_str = resourceLoader.GetString("random_str");
        }

        private void HistoryThemeHelpMethod()
        {
            #region 历史主题
            try
            {
                theme_str = local_theme.Values["theme"].ToString();
                switch (theme_str)
                {
                    case "light":
                        this.RequestedTheme = ElementTheme.Light;
                        main_commandBar.RequestedTheme = ElementTheme.Light;
                        SetAcrylic(newWhite);
                        main_grid.Background = myBrush;
                        musicListShow_grid.Background = myBrush; break;
                    case "dark":
                        this.RequestedTheme = ElementTheme.Dark;
                        main_commandBar.RequestedTheme = ElementTheme.Dark;
                        SetAcrylic(newBlack);
                        main_grid.Background = myBrush;
                        musicListShow_grid.Background = myBrush; break;
                    case "defalut":
                        this.RequestedTheme = ElementTheme.Default;
                        main_commandBar.RequestedTheme = ElementTheme.Default;
                        SetAcrylic(newWhite);
                        main_grid.Background = myBrush;
                        musicListShow_grid.Background = myBrush; break;
                    default:
                        break;
                }
            }
            catch
            {
                this.RequestedTheme = ElementTheme.Default;
                main_commandBar.RequestedTheme = ElementTheme.Default;
                SetAcrylic(newWhite);
                main_grid.Background = myBrush;
                musicListShow_grid.Background = myBrush;
            }
            #endregion
        }

        private void HistoryBackGroundHelpMethod()
        {
            #region 历史背景
            try
            {
                isCustom_str = local_IsCustom.Values["custom"].ToString();
                switch (isCustom_str)
                {
                    case "TRUE": IsCustom = true; break;
                    case "FALSE": IsCustom = false; break;
                    default:
                        break;
                }
            }
            catch
            {
            }
            if (IsCustom)
            {
                try
                {
                    backGround_path = local_backGround.Values["backGround_image"].ToString();
                    imageBrush.ImageSource = new BitmapImage(new Uri(backGround_path));
                    main_grid.Background = imageBrush;
                    main_grid.Background.Opacity = 0.7;
                }
                catch
                {
                    //main_grid.Background = myBrush;
                    //imageBrush.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/rain.jpg", UriKind.Absolute));
                }
            }
            #endregion
        }

        private void HistoryVolumeHelpMethod()
        {
            #region 历史音量
            try
            {
                volume_value = (double)local_volume.Values["Volume"];
                volume_slider.Value = volume_value;
                volume_textblock.Text = volume_value.ToString();
                main_mediaElement.Volume = volume_value / 100;
            }
            catch
            {
                volume_slider.Value = 30;
                volume_textblock.Text = "30";
                main_mediaElement.Volume = 0.3;
            }
            #endregion
        }
        private async void GetBackgroundImage()
        {
            #region 获取本地图片并将其设置为背景
            FileOpenPicker file = new FileOpenPicker();
            file.FileTypeFilter.Add(".jpg");
            file.FileTypeFilter.Add(".png");
            StorageFile image_file = await file.PickSingleFileAsync();
            if (image_file != null)
            {
                BitmapImage image = new BitmapImage();
                using (var iamge_stream = await image_file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    image.SetSource(iamge_stream);
                }//及时释放资源
            }
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile fileCopy = await image_file.CopyAsync(localFolder, image_file.Name, NameCollisionOption.ReplaceExisting);
                image_source_path = "ms-appdata:///local/" + image_file.Name;

                imageBrush.ImageSource = new BitmapImage(new Uri(image_source_path));
                main_grid.Background = imageBrush;
                local_backGround.Values["backGround_image"] = image_source_path;
                IsCustom = true;
                local_IsCustom.Values["custom"] = "TRUE";
            }
            catch
            {
            }
            #endregion
        }

        private void ExtendAcrylicIntoTitleBar()
        {
            #region 将亚克力扩展到标题栏
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            #endregion
        }


        private void SetAcrylic(Color color)
        {
            #region 设置亚克力背景
            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.Xaml.Media.XamlCompositionBrushBase"))
            {

                myBrush.BackgroundSource = AcrylicBackgroundSource.HostBackdrop;
                myBrush.TintColor = color;
                myBrush.FallbackColor = color;
                myBrush.TintOpacity = 0.3;
                main_grid.Background = myBrush;
            }
            else
            {
                SolidColorBrush myBrush = new SolidColorBrush(Color.FromArgb(100, 20, 24, 37));
                main_grid.Background = myBrush;
            }
            #endregion
        }

        private async Task GetAllSongs(ObservableCollection<StorageFile> list, StorageFolder folder)
        {
            foreach (var song in await folder.GetFilesAsync())
            {
                if (song.FileType == ".mp3" || song.FileType == ".wav")
                {
                    list.Add(song);
                }
            }
            foreach (var item in await folder.GetFoldersAsync())
            {
                await GetAllSongs(list, item);
            }
        }

        private async Task ListView_Songs(ObservableCollection<StorageFile> files)
        {
            #region 设置列表歌曲信息
            foreach (var song in files)
            {
                MusicProperties song_Properties = await song.Properties.GetMusicPropertiesAsync();
                StorageItemThumbnail current_Thumb = await song.GetThumbnailAsync(
                    ThumbnailMode.MusicView,
                    300,
                    ThumbnailOptions.UseCurrentScale);
                BitmapImage album_cover = new BitmapImage();
                album_cover.SetSource(current_Thumb);
                Music music = new Music();
                music.Title = song_Properties.Title;
                music.Artist = song_Properties.Artist;
                music.Cover = album_cover;
                main_stream = await song.OpenAsync(FileAccessMode.Read);
                SetListTimeMethod((int)song_Properties.Duration.TotalSeconds);
                music.MusicSeconds_Str = list_hh + ":" + list_mm + ":" + list_ss;
                music.Music_Stream = main_stream;
                music.Music_Path = song.Name;
                music.id = num;
                music.SongFile = song;
                music.Music_Color = transParent;
                music.album_title = song_Properties.Album;
                use_music.Add(music);
                num++;
            }
            #endregion
        }
        private string list_hh;
        private string list_mm;
        private string list_ss;
        private void SetListTimeMethod(int allTime)
        {

            int HH = allTime / 3600;
            int MM = (allTime - HH * 3600) / 60;
            int SS = allTime % 60;
            if (HH < 10)
            {
                list_hh = "0" + HH.ToString();
            }
            else
            {
                list_hh = HH.ToString();
            }
            if (MM < 10)
            {
                list_mm = "0" + MM.ToString();
            }
            else
            {
                list_mm = MM.ToString();
            }
            if (SS < 10)
            {
                list_ss = "0" + SS.ToString();
            }
            else
            {
                list_ss = SS.ToString();
            }
        }
        private async void GetLocalMusic()
        {
            main_progressRing.IsActive = true;
            main_progressRing.Visibility = Visibility.Visible;
            folder = KnownFolders.MusicLibrary;
            await GetAllSongs(allMusic, folder);
            await ListView_Songs(allMusic);
            if (use_music.Count > 0)
            {

                main_mediaElement.AutoPlay = false;
                GetHistoryMusic();
                play_button.IsEnabled = true;
                back_button.IsEnabled = true;
                forward_button.IsEnabled = true;
            }

            else//启动或刷新本地音乐时，若获取歌曲为空，则运行以下代码
            {
                play_button.IsEnabled = false;
                back_button.IsEnabled = false;
                forward_button.IsEnabled = false;
                main_image.Source = new BitmapImage(new Uri("ms-appx:///Assets/music_1.png"));
                songTile_textblock.Text = "";
                artist_textblock.Text = "";
                album_textblock.Text = "";
                playTitle_textblock.Text = "";
                playArtist_textblock.Text = "";
                line_textblock.Text = "";
                string noneMusic_str = resourceLoader.GetString("noneMusic_str");
                ContentDialog content = new ContentDialog
                {
                    Content = noneMusic_str,
                    IsPrimaryButtonEnabled = true,
                    PrimaryButtonText = "OK",
                    Background = skyblue,
                    Foreground = white,
                };
                ContentDialogResult result = await content.ShowAsync();
            }
            allListSongsCount = use_music.Count;
            songNum_textBlock.Text = allListSongsCount.ToString();
            main_progressRing.IsActive = false;
            main_progressRing.Visibility = Visibility.Collapsed;
        }
        private bool IsMusicListSongPlay_bool = false;
        private void SwitchMusic()
        {
            IsMusicPlaying = true;
            main_mediaElement.AutoPlay = true;
            GetSavedMusicForeGround();
            play_button.Icon = new SymbolIcon(Symbol.Pause);
            play_button.Label = pause_str;//显示 "暂停"
            if (IsMusicListSongPlay_bool)
            {
                if (ListPlay_bool)
                {
                    SetMusicListListPlay();
                }
                else if (RandomPlay_bool)
                {
                    SetMusicListRandomPlay();
                }
            }
            else
            {
                if (ListPlay_bool)
                {
                    List_Source();
                }
                else if (RandomPlay_bool)
                {
                    Random_Source();
                }
            }
            
            local_musicPath.Values["music_path"] = source_path;
            local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;

        }

        private async void SetAboutContent()
        {
            string help_str = resourceLoader.GetString("help_str");
            string about_str = resourceLoader.GetString("about_str");
            #region 帮助弹窗内容
            ContentDialog content = new ContentDialog
            {
                Title = about_str,
                Content = help_str,
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
                Background = skyblue,
                Foreground = white,
            };
            ContentDialogResult result = await content.ShowAsync();
            #endregion
        }

        private async void SystemControls_ButtonPressed(SystemMediaTransportControls sender,
    SystemMediaTransportControlsButtonPressedEventArgs args)
        {

            switch (args.Button)
            {
                case SystemMediaTransportControlsButton.Play:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        main_mediaElement.AutoPlay = true;
                        main_mediaElement.Play();
                        play_button.Icon = new SymbolIcon(Symbol.Pause);
                        play_button.Label = pause_str;//显示 "暂停"
                        IsMusicPlaying = true;
                    });
                    break;
                case SystemMediaTransportControlsButton.Pause:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        main_mediaElement.Pause();
                        play_button.Icon = new SymbolIcon(Symbol.Play);
                        play_button.Label = pause_str;//显示 "暂停"
                        IsMusicPlaying = false;
                    });
                    break;
                case SystemMediaTransportControlsButton.Previous:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        IsBackButtonClick = true;
                        SwitchMusic();
                    });
                    break;
                case SystemMediaTransportControlsButton.Next:
                    await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                    {
                        IsBackButtonClick = false;
                        SwitchMusic();
                    });
                    break;
                default:
                    break;
            }
        }

        #region 获取上次启动最后播放歌曲
        private void GetHistoryMusic()
        {
            try
            {
                source_path = local_musicPath.Values["music_path"].ToString();
                local_allTimeStr = local_allTime.Values["allTime"].ToString();
                local_music = SetMusic.GetMusicByPath(use_music, source_path);//对于历史歌曲，启用 GetMusicByPath 方法
                SameSongDetailsHelpMethod(local_music);//解决 第二次启动，有上一次歌曲path，而无重新获取该歌曲，引发的异常
            }
            catch
            {
                local_music = use_music[0];
                SameSongDetailsHelpMethod(local_music);//(如：播放添加文件夹中的歌曲，然后关闭应用重新打开，则会引发该异常)
            }

            playTime_textblock.Text = "00:00" + "/" + local_allTimeStr;
            local_music.Music_Color = skyblue;
            main_music = local_music;//删除正在播放歌曲后，随机切换下一首会用到该main_music
        }
        #endregion
        private async void SetContentDialog()
        {
            string await_Str = resourceLoader.GetString("await_str");
            ContentDialog content = new ContentDialog
            {
                Title = "",
                Content = await_Str,
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
                Background = skyblue,
                Foreground = white,
            };
            ContentDialogResult result = await content.ShowAsync();
        }


        private void Back_button_Click_1(object sender, RoutedEventArgs e)
        {
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                IsBackButtonClick = true;
                SwitchMusic();
            }
        }

        private void Forward_button_Click_1(object sender, RoutedEventArgs e)
        {
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                IsBackButtonClick = false;
                SwitchMusic();
            }
        }

        private void Model_button_Click_1(object sender, RoutedEventArgs e)
        {
            play_button.Icon = new SymbolIcon(Symbol.Play);
            play_button.Label = play_str;
            IsMusicPlaying = false;
            main_mediaElement.Stop();
        }

        private void Main_slider_ValueChanged_1(object sender, RangeBaseValueChangedEventArgs e)
        {
            SetAllTimeMethod();

            if (main_slider.Value == main_slider.Maximum)
            {
                if (SingleCycle_bool)
                {
                    Single_Cycle();
                }
                else if (ListPlay_bool)
                {
                    GetSavedMusicForeGround();
                    if (IsMusicListSongPlay_bool)
                    {
                        SetMusicListListPlay();//歌单歌曲列表，列表循环播放模式设置
                    }
                    else
                    {
                        List_Source();
                    }
                   
                }
                else if (RandomPlay_bool)
                {
                    GetSavedMusicForeGround();
                    if (IsMusicListSongPlay_bool)
                    {
                        SetMusicListRandomPlay();//歌单歌曲列表，随机循环播放模式设置
                    }
                    else
                    {
                        Random_Source();
                    }                    
                }
                else
                {
                    IsMusicPlaying = false;
                }
                local_musicPath.Values["music_path"] = source_path;
            }
        }

        private void Main_mediaElement_CurrentStateChanged_1(object sender, RoutedEventArgs e)
        {
            switch (main_mediaElement.CurrentState)
            {
                case MediaElementState.Playing:
                    systemMedia_TransportControls.PlaybackStatus = MediaPlaybackStatus.Playing;
                    main_slider.Maximum = main_mediaElement.NaturalDuration.TimeSpan.TotalSeconds;//有了此段代码，可以删除storyBoard控件了
                    break;
                case MediaElementState.Paused:
                    systemMedia_TransportControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                    break;
                case MediaElementState.Stopped:
                    systemMedia_TransportControls.PlaybackStatus = MediaPlaybackStatus.Paused;
                    break;
                default:
                    break;
            }
        }

        private bool IslistShowButtonClick = false;
        private void ListShow_button_Click(object sender, RoutedEventArgs e)
        {
            if (IslistShowButtonClick)
            {
                the_colume.Width = new GridLength(0);
                main_listview.Visibility = Visibility.Collapsed;
                title_stackPanel.Visibility = Visibility.Collapsed;
                IslistShowButtonClick = false;
            }
            else
            {
                the_colume.Width = third_colume.Width;
                main_listview.Visibility = Visibility.Visible;
                IslistShowButtonClick = true;
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            IslistShowButtonClick = false;
        }

        private void Volume_button_Click(object sender, RoutedEventArgs e)
        {
            volume_button.Flyout.Hide();
        }

        private void VolumeIcon_textblock_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            if (IsVolumeOpen)
            {
                volumeIcon_textblock.FontFamily = new FontFamily("Segoe MDL2 Assets");
                volumeIcon_textblock.Text = "\uE74F";
                main_mediaElement.Volume = 0;
                IsVolumeOpen = false;
            }
            else
            {
                volumeIcon_textblock.FontFamily = new FontFamily("Segoe MDL2 Assets");
                volumeIcon_textblock.Text = "\uE994";
                main_mediaElement.Volume = volume_num / 100;
                IsVolumeOpen = true;
            }
        }

        private void Volume_slider_ValueChanged_1(object sender, RangeBaseValueChangedEventArgs e)
        {
            volume_num = volume_slider.Value;
            volume_textblock.Text = volume_num.ToString();
            main_mediaElement.Volume = volume_num / 100;
            local_volume.Values["Volume"] = volume_num;
        }

        private bool IsCustom = false;
        private void Custom_menu_Click(object sender, RoutedEventArgs e)
        {

            GetBackgroundImage();

        }

        private void Default_menu_Click(object sender, RoutedEventArgs e)
        {

            SetAcrylic(newWhite);
            main_grid.Background = myBrush;
            musicListShow_grid.Background = myBrush;
            this.RequestedTheme = ElementTheme.Light;
            main_commandBar.RequestedTheme = ElementTheme.Light;
            local_backGround.Values.Remove("backGround_image");
            IsCustom = false;
            local_IsCustom.Values["custom"] = "FALSE";
        }

        private void Single_menu_Click(object sender, RoutedEventArgs e)
        {
            SingleCycle_bool = true;
            ListPlay_bool = false;
            RandomPlay_bool = false;
            model_button.Icon = new SymbolIcon(Symbol.RepeatOne);
            model_button.Label = single_str;//显示 "单曲循环"
            back_button.IsEnabled = false;
            forward_button.IsEnabled = false;
        }

        private void Order_menu_Click(object sender, RoutedEventArgs e)
        {
            ListPlay_bool = true;
            SingleCycle_bool = false;
            RandomPlay_bool = false;
            model_button.Icon = new SymbolIcon(Symbol.RepeatAll);
            model_button.Label = order_str;//显示 "列表循环"
            back_button.IsEnabled = true;
            forward_button.IsEnabled = true;
        }

        private void Random_menu_Click(object sender, RoutedEventArgs e)
        {
            RandomPlay_bool = true;
            SingleCycle_bool = false;
            ListPlay_bool = false;
            model_button.Icon = new SymbolIcon(Symbol.Shuffle);
            model_button.Label = random_str;//显示 "随机播放"
            back_button.IsEnabled = true;
            forward_button.IsEnabled = true;
        }

        private void FullScreen_button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationView view = ApplicationView.GetForCurrentView();
            bool isInFullScreenMode = view.IsFullScreenMode;
            if (isInFullScreenMode)
            {

                view.ExitFullScreenMode();
                fullScreen_button.Icon = new SymbolIcon(Symbol.FullScreen);
            }
            else
            {
                view.TryEnterFullScreenMode();
                fullScreen_button.Icon = new SymbolIcon(Symbol.BackToWindow);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;           
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
        }
        private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
        {//启用空格键(播放、暂停)和ESC键(退出全屏)
            if (args.VirtualKey == VirtualKey.Escape)
            {
                ApplicationView view = ApplicationView.GetForCurrentView();
                bool isInFullScreenMode = view.IsFullScreenMode;
                if (isInFullScreenMode)
                {
                    view.ExitFullScreenMode();
                    fullScreen_button.Icon = new SymbolIcon(Symbol.FullScreen);
                }
            }
            if (args.VirtualKey == VirtualKey.Space)
            {
                if (main_mediaElement.CurrentState == MediaElementState.Playing)
                {
                    main_mediaElement.Pause();
                    play_button.Icon = new SymbolIcon(Symbol.Play);
                    play_button.Label = play_str;//显示 "播放"
                }
                else if (main_mediaElement.CurrentState == MediaElementState.Paused)
                {
                    main_mediaElement.Play();
                    play_button.Icon = new SymbolIcon(Symbol.Pause);
                    play_button.Label = pause_str;//显示 "暂停"
                }
            }
        }

        private async void FeedBack_menu_Click_1(object sender, RoutedEventArgs e)
        {
            #region 启动反馈窗口
            var launcher = Microsoft.Services.Store.Engagement.StoreServicesFeedbackLauncher.GetDefault();
            await launcher.LaunchAsync();
            #endregion
        }

        private async Task ComposeEmail()
        {
            #region 启动邮件
            //Windows.ApplicationModel.Contacts.Contact recipient = new Windows.ApplicationModel.Contacts.Contact();
            var emailMessage = new Windows.ApplicationModel.Email.EmailMessage();



            //var email = recipient.Emails.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactEmail>();
            //if (email != null)
            //{
            //    email.Address = "singhwongwxg@hotmail.com";
            //    var emailRecipient = new Windows.ApplicationModel.Email.EmailRecipient(email.Address);
            //    emailMessage.To.Add(emailRecipient);
            //}
            await Windows.ApplicationModel.Email.EmailManager.ShowComposeNewEmailAsync(emailMessage);
            #endregion
        }

        private async void Mail_button_Click(object sender, RoutedEventArgs e)
        {
            await ComposeEmail();
        }
        private Music menu_music;
        #region 右键选项播放
        private void Play_menu_Click(object sender, RoutedEventArgs e)
        {
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                IsMusicListSongPlay_bool = false;
                main_mediaElement.AutoPlay = true;
                main_mediaElement.Play();
                GetSavedMusicForeGround();
                main_music = (Music)sender_value.DataContext;

                source_path = main_music.Music_Path;
                //_musicStream = main_music.Music_Stream;
                play_button.Icon = new SymbolIcon(Symbol.Pause);
                play_button.Label = pause_str;//显示 "暂停"
                IsMusicPlaying = true;
                try
                {
                    SameSongDetailsHelpMethod(main_music);
                    //GetLyrics(main_music.Artist,main_music.Title);
                }
                catch
                {
                    SetPlayErrorMethod();
                }
                local_musicPath.Values["music_path"] = source_path;
                local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
                main_music.Music_Color = skyblue;
                if (main_savemusic != null)//清除歌单歌曲列表icon颜色
                {
                    main_savemusic.SaveMusic_Color = transParent;
                }
                lyric_textblock.Text = "";
                lyric_button.Content = resourceLoader.GetString("searchLyric_str");
            }
        }
        #endregion
        private FrameworkElement sender_value;
        //string menuItem_url = "";
        //private FrameworkElement savesender_value;
        private void RightClick_stackPanel_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            sender_value = (FrameworkElement)sender;
            //savesender_value = (FrameworkElement)sender;
            //var song = (ListViewItem)sender;
            //song.IsSelected = true;
            main_listview.IsItemClickEnabled = true;
        }

        private void Stop_menu_Click(object sender, RoutedEventArgs e)
        {
            main_mediaElement.Pause();
            play_button.Icon = new SymbolIcon(Symbol.Play);
            play_button.Label = play_str;//显示 "播放"
            IsMusicPlaying = false;
        }
        //private string local_url;
        #region 双击歌曲
        private void RightClick_stackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            sender_value = (FrameworkElement)sender;
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                IsMusicListSongPlay_bool = false;
                main_mediaElement.AutoPlay = true;
                GetSavedMusicForeGround();
                main_music = (Music)sender_value.DataContext;
                source_path = main_music.Music_Path;
                //_musicStream = main_music.Music_Stream;
                try
                {
                    SameSongDetailsHelpMethod(main_music);
                    //GetLyrics(main_music.Artist,main_music.Title);
                }
                catch
                {
                    SetPlayErrorMethod();
                }

                IsMusicPlaying = true;
                play_button.Icon = new SymbolIcon(Symbol.Pause);
                play_button.Label = resourceLoader.GetString("pause_str");
                main_music.Music_Color = skyblue;
                if (main_savemusic != null)
                {
                    main_savemusic.SaveMusic_Color = transParent;
                }

                local_musicPath.Values["music_path"] = source_path;
                local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
                lyric_textblock.Text = "";
                lyric_button.Content = resourceLoader.GetString("searchLyric_str");

            }
        }
        #endregion
        private void SameSongDetailsHelpMethod(Music musicDetails_music)
        {
            main_mediaElement.SetSource(musicDetails_music.Music_Stream, musicDetails_music.SongFile.ContentType);
            Album_Cover = musicDetails_music.Cover;
            main_image.Source = Album_Cover;
            songTile_textblock.Text = musicDetails_music.Title;
            artist_textblock.Text = musicDetails_music.Artist;
            album_textblock.Text = "【" + musicDetails_music.album_title + "】";
            playTitle_textblock.Text = musicDetails_music.Title;
            playArtist_textblock.Text = musicDetails_music.Artist;
            line_textblock.Text = " - ";
            _musicStream = musicDetails_music.Music_Stream;
        }
        #region 上一首恢复颜色
        private void GetSavedMusicForeGround()
        {
            if (IsMusicListSongPlay_bool)
            {
                if (main_savemusic != null)
                {
                    main_savemusic.SaveMusic_Color = transParent;
                }
            }
            else
            {
                if (local_music != null)
                {
                    local_music.Music_Color = transParent;
                }
                //if (menu_music != null)
                //{
                //    menu_music.ForeColor = transParent;
                //}
                if (main_music != null)
                {
                    main_music.Music_Color = transParent;
                }
            }
           
        }
        #endregion
        private IRandomAccessStream stream;
        private async void OpenFile_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                stream.Dispose();
            }
            catch
            {
            }
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                main_mediaElement.AutoPlay = false;
                FileOpenPicker file = new FileOpenPicker();
                file.FileTypeFilter.Add(".mp3");
                file.FileTypeFilter.Add(".wav");
                StorageFile media_file = await file.PickSingleFileAsync();
                if (media_file != null)
                {


                    #region 获取音乐文件专辑封面
                    StorageItemThumbnail current_Thumb = await media_file.GetThumbnailAsync(
                    ThumbnailMode.MusicView,
                    300,
                    ThumbnailOptions.UseCurrentScale);
                    BitmapImage add_AlbumCover = new BitmapImage();//重新实例化，不然会出现专辑封面显示错乱bug
                    add_AlbumCover.SetSource(current_Thumb);
                    #endregion
                    main_image.Source = add_AlbumCover;

                    GetSavedMusicForeGround();
                    MusicProperties song_Properties = await media_file.Properties.GetMusicPropertiesAsync();
                    stream = await media_file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    main_mediaElement.SetSource(stream, media_file.ContentType);
                    songTile_textblock.Text = song_Properties.Title;
                    artist_textblock.Text = song_Properties.Artist;
                    album_textblock.Text = "【" + song_Properties.Album + "】";

                    playTitle_textblock.Text = song_Properties.Title;
                    playArtist_textblock.Text = song_Properties.Artist;
                    line_textblock.Text = " - ";
                    //GetLyrics(song_Properties.Artist,song_Properties.Title);

                    play_button.Icon = new SymbolIcon(Symbol.Play);
                    play_button.Label = play_str;//显示 "播放"
                    IsMusicPlaying = false;

                    play_button.IsEnabled = true;
                    back_button.IsEnabled = true;
                    forward_button.IsEnabled = true;

                    lyric_textblock.Text = "";
                    lyric_button.Content = resourceLoader.GetString("searchLyric_str");
                }
            }
        }

        private void RemoveFromList_menu_Click(object sender, RoutedEventArgs e)
        {
            menu_music = (Music)sender_value.DataContext;
            if (main_music == menu_music)
            {
                AfterRemoveSongMethod();//删除正在播放歌曲后，随机切换下一首
            }
            use_music.Remove(menu_music);
            allListSongsCount = use_music.Count;
            songNum_textBlock.Text = allListSongsCount.ToString();
        }

        private void AfterRemoveSongMethod()
        {
            #region 删除正在播放歌曲后，随机切换下一首(重复代码)
            IsMusicPlaying = false;
            main_mediaElement.AutoPlay = false;
            GetSavedMusicForeGround();
            play_button.Icon = new SymbolIcon(Symbol.Play);
            play_button.Label = play_str;//显示 "播放"

            Random_Source();

            local_musicPath.Values["music_path"] = source_path;
            local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
            #endregion
        }
        private async void RecycleBin_menu_Click(object sender, RoutedEventArgs e)
        {
            menu_music = (Music)sender_value.DataContext;
            if (main_music == menu_music)
            {
                AfterRemoveSongMethod();
            }
            use_music.Remove(menu_music);
            StorageFile file = menu_music.SongFile;
            await file.DeleteAsync(StorageDeleteOption.Default);
            allListSongsCount = use_music.Count;
            songNum_textBlock.Text = allListSongsCount.ToString();
        }

        private async void Direct_menu_Click(object sender, RoutedEventArgs e)
        {
            menu_music = (Music)sender_value.DataContext;
            if (main_music == menu_music)
            {
                AfterRemoveSongMethod();
            }
            use_music.Remove(menu_music);
            StorageFile file = menu_music.SongFile;
            await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
            allListSongsCount = use_music.Count;
            songNum_textBlock.Text = allListSongsCount.ToString();
        }

        private async void GetFolderMusic()
        {
            FolderPicker pick = new FolderPicker();
            pick.FileTypeFilter.Add(".mp3");
            pick.FileTypeFilter.Add(".wav");
            IAsyncOperation<StorageFolder> folderTask = pick.PickSingleFolderAsync();

            StorageFolder Folder = await folderTask;

            if (Folder != null)//判断是否为null，解决打开文件夹未选择文件异常

            {
                main_mediaElement.AutoPlay = false;
                main_progressRing.IsActive = true;
                main_progressRing.Visibility = Visibility.Visible;
                await GetAllSongs(allMusic, Folder);
                await ListView_Songs(allMusic);
                main_progressRing.IsActive = false;
                main_progressRing.Visibility = Visibility.Collapsed;
                allListSongsCount = use_music.Count;
                songNum_textBlock.Text = allListSongsCount.ToString();
            }
            if (use_music.Count > 0)
            {
                play_button.IsEnabled = true;
                back_button.IsEnabled = true;
                forward_button.IsEnabled = true;
                main_music = use_music[0];
                SameSongDetailsHelpMethod(main_music);
                main_music.Music_Color = skyblue;
            }
        }

        private void AddFolder_button_Click(object sender, RoutedEventArgs e)
        {//增加文件夹歌曲文件时，由于要保留列表中已有歌曲文件，故每次点击不可以进行释放流
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                listView_grid.Visibility = Visibility.Visible;
                IslistShowButtonClick = true;
                GetSavedMusicForeGround();
                allMusic.Clear();
                GetFolderMusic();
            }
        }

        private void Light_menu_Click(object sender, RoutedEventArgs e)
        {
            if (IsCustom == false)
            {
                SetAcrylic(newWhite);
                main_grid.Background = myBrush;
            }
            this.RequestedTheme = ElementTheme.Light;
            main_commandBar.RequestedTheme = ElementTheme.Light;
            local_theme.Values["theme"] = "light";
        }

        private void Dark_menu_Click(object sender, RoutedEventArgs e)
        {
            if (IsCustom == false)
            {
                SetAcrylic(newBlack);
                main_grid.Background = myBrush;
            }

            this.RequestedTheme = ElementTheme.Dark;
            main_commandBar.RequestedTheme = ElementTheme.Dark;
            local_theme.Values["theme"] = "dark";
        }

        private void DefaultTheme_menu_Click(object sender, RoutedEventArgs e)
        {
            if (IsCustom == false)
            {
                SetAcrylic(newWhite);
                main_grid.Background = myBrush;
            }
            this.RequestedTheme = ElementTheme.Default;
            main_commandBar.RequestedTheme = ElementTheme.Default;
            local_theme.Values["theme"] = "default";
        }

        private void Help_button_Click(object sender, RoutedEventArgs e)
        {
            SetAboutContent();
        }

        private void MusicFolder_button_Click(object sender, RoutedEventArgs e)
        {
            DisPoseStream();
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                allMusic.Clear();
                use_music.Clear();
                main_mediaElement.Stop();
                play_button.Icon = new SymbolIcon(Symbol.Play);
                play_button.Label = play_str;//显示 "播放"
                IsMusicPlaying = false;
                GetLocalMusic();
            }
        }
        private void Clear_button_Click(object sender, RoutedEventArgs e)
        {//清空所有列表歌曲,释放所有流
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                songNum_textBlock.Text = "0";
                DisPoseStream();
                use_music.Clear();
                allMusic.Clear();
                main_mediaElement.AutoPlay = false;
                main_mediaElement.Stop();
                IsMusicPlaying = false;
                play_button.Icon = new SymbolIcon(Symbol.Play);
                play_button.Label = play_str;//显示 "播放"
                play_button.IsEnabled = false;
                back_button.IsEnabled = false;
                forward_button.IsEnabled = false;

                main_image.Source = new BitmapImage(new Uri("ms-appx:///Assets/music_1.png"));
                songTile_textblock.Text = "";
                artist_textblock.Text = "";
                album_textblock.Text = "";
                playTitle_textblock.Text = "";
                playArtist_textblock.Text = "";
                line_textblock.Text = "";

                lyric_button.Content = resourceLoader.GetString("searchLyric_str");
                lyric_textblock.Text = "";
            }
        }
        private void DisPoseStream()
        {
            #region 刷新本地音乐列表前，释放流
            try
            {
                foreach (var item in use_music)
                {
                    item.Music_Stream.Dispose();
                }
            }
            catch
            {
            }
            #endregion
        }

        private void Main_listview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            #region 取消item选中backGround效果
            var selection_value = (ListView)sender;
            selection_value.SelectedItem = null;
            #endregion
        }

        private void Play_button_Click(object sender, RoutedEventArgs e)
        {
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                if (IsMusicPlaying == false)
                {
                    main_mediaElement.AutoPlay = true;
                    main_mediaElement.Play();
                    play_button.Icon = new SymbolIcon(Symbol.Pause);
                    play_button.Label = pause_str;//显示 "暂停"
                    IsMusicPlaying = true;
                }
                else
                {
                    main_mediaElement.Pause();
                    play_button.Icon = new SymbolIcon(Symbol.Play);
                    play_button.Label = play_str;//显示 "播放"
                    IsMusicPlaying = false;
                }
            }
        }
        private string _resultLyric_str;
        private void GetLyrics(string artist_str, string title_str)
        {
            _resultLyric_str = resourceLoader.GetString("resultLyric_str");
            LyricService ls = new LyricService();
            main_progressRing.Visibility = Visibility.Visible;
            LyricData result = ls.GetLyrics(artist_str, title_str);
            main_progressRing.Visibility = Visibility.Collapsed;
            if (result != null)
            {
                lyric_textblock.Text = result.Lyrics;
            }
            else
            {
                lyric_textblock.Text = _resultLyric_str;
            }
        }


        private void Lyric_button_Click(object sender, RoutedEventArgs e)
        {
            _searchLyric_str = resourceLoader.GetString("searchLyric_str");
            _clearLyric_str = resourceLoader.GetString("clearLyric_str");
            if (lyric_button.Content.ToString() == _searchLyric_str)
            {
                GetLyrics(artist_textblock.Text, songTile_textblock.Text);
                lyric_button.Content = _clearLyric_str;
            }
            else
            {
                lyric_textblock.Text = "";
                lyric_button.Content = _searchLyric_str;
            }
        }

        private void MusicList_button_Click(object sender, RoutedEventArgs e)
        {
            MusicList_SplitView.IsPaneOpen = !MusicList_SplitView.IsPaneOpen;
            MusicList_ListView.SelectedItem = null;
        }
        private void SetMusicListName(string name)
        {
            if (!String.IsNullOrEmpty(name.Trim()))
            {
                foreach (var item in main_musicList)
                {
                    if (item.MusicList_Name == name)
                    {
                        SetErrorMusicListNameContentDialog();
                        return;
                    }
                }
                MusicList music_list = new MusicList();
                music_list.MusicList_Name = name;
                main_musicList.Add(music_list);
                SaveMusicList value = new SaveMusicList();
                value.MusicList_Name = name;
                save_mainMusicList.Add(value);
            }
            else
            {
                SetErrorMusicListNameContentDialog();
            }
        }

        private async void SetErrorMusicListNameContentDialog()
        {
            ContentDialog content = new ContentDialog()
            {
                Title = "",
                Content = "歌单名不能为空或重复",
                IsPrimaryButtonEnabled = true,
                PrimaryButtonText = "OK",
                Background = skyblue,
                Foreground = white,
            };
            ContentDialogResult result = await content.ShowAsync();
        }

        private async void AddMusicList_button_Click(object sender, RoutedEventArgs e)
        {
            list_textbox.Text = "";
            ContentDialogResult result = await addList_ContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                SetMusicListName(list_textbox.Text);
                SaveDataClass.SaveMusicListData(save_mainMusicList, filePath);
            }
            else
            {
            }
        }
        private MusicList value_List;
        private void MusicList_ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            the_colume.Width = new GridLength(0);
            second_colume.Width = third_colume.Width;
            value_List = (MusicList)e.ClickedItem;
            MusicShow_ListView.ItemsSource = value_List.Musics;
            musidlistTitle_textblock.Text = value_List.MusicList_Name;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            the_colume.Width = third_colume.Width;
            main_listview.Visibility = Visibility.Visible;
            IslistShowButtonClick = true;
            second_colume.Width = new GridLength(0);
        }

        private async void AddToList_menu_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await musicList_ContentDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                int num = 0;
                Music using_music = (Music)sender_value.DataContext;
                SaveMusic list_mainmusic = new SaveMusic();
                list_mainmusic.Title = using_music.Title;
                list_mainmusic.Artist = using_music.Artist;
                list_mainmusic.Music_Path = using_music.Music_Path;
                list_mainmusic.MusicSeconds_Str = using_music.MusicSeconds_Str;
                value_MusicList.Musics.Add(list_mainmusic);
                for (int i = 0; i < main_musicList.Count; i++)
                {
                    if (main_musicList[i] == value_MusicList)
                    {
                        num = i;
                    }
                }
                for (int i = 0; i < save_mainMusicList.Count; i++)
                {
                    if (i == num)
                    {
                        save_mainMusicList[i].SaveMusics.Add(list_mainmusic);
                    }
                }
                SaveDataClass.SaveMusicListData(save_mainMusicList, filePath);
            }
        }
        private MusicList value_MusicList = new MusicList();

        private void MusicList2_ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            musicList_ContentDialog.IsPrimaryButtonEnabled = true;
            value_MusicList = (MusicList)e.ClickedItem;
        }

        private void MusicList2_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MusicList_ContentDialog_Closed(ContentDialog sender, ContentDialogClosedEventArgs args)
        {

        }

        private void MusicList_ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            musicList_ContentDialog.IsPrimaryButtonEnabled = false;
            #region 取消item选中backGround效果
            //var selection_value = (ListView)sender;
            MusicList2_ListView.SelectedItem = null;
            #endregion
        }

        private void MusicShow_ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selection_value = (ListView)sender;
            selection_value.SelectedItem = null;
        }

        private void ReadLocalMusicListData()
        {
            try
            {
                save_mainMusicList = SaveDataClass.ReadMusicListData(filePath);
                for (int i = 0; i < save_mainMusicList.Count; i++)
                {
                    MusicList value = new MusicList();
                    value.MusicList_Name = save_mainMusicList[i].MusicList_Name;
                    for (int j = 0; j < save_mainMusicList[i].SaveMusics.Count; j++)
                    {
                        value.Musics.Add(save_mainMusicList[i].SaveMusics[j]);
                    }
                    main_musicList.Add(value);
                }
            }
            catch
            {
            }
        }

        private void Remove_musicList_Click(object sender, RoutedEventArgs e)
        {
            MusicList remove_value = (MusicList)musicList_senderValue.DataContext;
            main_musicList.Remove(remove_value);
            for (int j = 0; j < save_mainMusicList.Count; j++)
            {
                if (save_mainMusicList[j].MusicList_Name == remove_value.MusicList_Name)
                {
                    save_mainMusicList.RemoveAt(j);
                }
            }
            SaveDataClass.SaveMusicListData(save_mainMusicList, filePath);
        }
        private FrameworkElement musicList_senderValue;
        private void MusicList_stackPanel_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            musicList_senderValue = (FrameworkElement)sender;
        }
        private FrameworkElement doubleTapped_senderValue;
        private SaveMusic main_savemusic;
        private void MusicListSongsShow_stackPanel_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (main_progressRing.IsActive)
            {
                SetContentDialog();
            }
            else
            {
                IsMusicListSongPlay_bool = true;//启用歌单歌曲列表播放模式设置
                main_mediaElement.AutoPlay = true;
                GetSavedMusicForeGround();

                #region 包含一些重复代码，后期需要进行优化
                doubleTapped_senderValue = (FrameworkElement)sender;
                main_savemusic = (SaveMusic)doubleTapped_senderValue.DataContext;//获取歌单列表歌曲
                string path = main_savemusic.Music_Path;
                main_music = SetMusic.GetMusicByPath(use_music, path);
                source_path = main_music.Music_Path;
                //_musicStream = main_music.Music_Stream;
                try
                {
                    SameSongDetailsHelpMethod(main_music);
                }
                catch
                {
                    SetPlayErrorMethod();
                }

                IsMusicPlaying = true;
                play_button.Icon = new SymbolIcon(Symbol.Pause);
                play_button.Label = resourceLoader.GetString("pause_str");
                ClearUseMusicIconColor();
                local_musicPath.Values["music_path"] = source_path;
                local_allTime.Values["allTime"] = allmm_str + ":" + allss_str;
                lyric_textblock.Text = "";
                lyric_button.Content = resourceLoader.GetString("searchLyric_str");
                #endregion
            }
        }
        private void ClearUseMusicIconColor()
        {
            #region 清除获取的总歌曲列表icon颜色并设置歌单歌曲列表icon颜色
            foreach (var item in use_music)//清除获取的总歌曲列表icon颜色
            {
                item.Music_Color = transParent;
            }
            main_savemusic.SaveMusic_Color = red;//设置歌单歌曲icon颜色变化
            #endregion
        }
    }
}

