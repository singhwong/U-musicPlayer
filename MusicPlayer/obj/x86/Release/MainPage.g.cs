﻿#pragma checksum "C:\Users\wang\source\repos\U-musicPlayer\MusicPlayer\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D379C6EF9149D23FF6C54642C58A4BE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicPlayer
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(global::Windows.UI.Xaml.Controls.ItemsControl obj, global::System.Object value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = (global::System.Object) global::Windows.UI.Xaml.Markup.XamlBindingHelper.ConvertValue(typeof(global::System.Object), targetNullValue);
                }
                obj.ItemsSource = value;
            }
            public static void Set_Windows_UI_Xaml_Controls_TextBlock_Text(global::Windows.UI.Xaml.Controls.TextBlock obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj22_Bindings :
            global::Windows.UI.Xaml.IDataTemplateExtension,
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::MusicPlayer.Models.MusicList dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);
            private bool removedDataContextHandler = false;

            // Fields for each control that has bindings.
            private global::System.WeakReference obj22;

            public MainPage_obj22_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 22: // MainPage.xaml line 376
                        this.obj22 = new global::System.WeakReference((global::Windows.UI.Xaml.Controls.TextBlock)target);
                        break;
                    default:
                        break;
                }
            }

            public void DataContextChangedHandler(global::Windows.UI.Xaml.FrameworkElement sender, global::Windows.UI.Xaml.DataContextChangedEventArgs args)
            {
                 if (this.SetDataRoot(args.NewValue))
                 {
                    this.Update();
                 }
            }

            // IDataTemplateExtension

            public bool ProcessBinding(uint phase)
            {
                throw new global::System.NotImplementedException();
            }

            public int ProcessBindings(global::Windows.UI.Xaml.Controls.ContainerContentChangingEventArgs args)
            {
                int nextPhase = -1;
                ProcessBindings(args.Item, args.ItemIndex, (int)args.Phase, out nextPhase);
                return nextPhase;
            }

            public void ResetTemplate()
            {
                Recycle();
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
                switch(phase)
                {
                    case 0:
                        nextPhase = -1;
                        this.SetDataRoot(item);
                        if (!removedDataContextHandler)
                        {
                            removedDataContextHandler = true;
                            (this.obj22.Target as global::Windows.UI.Xaml.Controls.TextBlock).DataContextChanged -= this.DataContextChangedHandler;
                        }
                        this.initialized = true;
                        break;
                }
                this.Update_((global::MusicPlayer.Models.MusicList) item, 1 << phase);
            }

            public void Recycle()
            {
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MusicPlayer.Models.MusicList)newDataRoot;
                    return true;
                }
                return false;
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MusicPlayer.Models.MusicList obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_MusicList_Name(obj.MusicList_Name, phase);
                    }
                }
            }
            private void Update_MusicList_Name(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 376
                    if ((this.obj22.Target as global::Windows.UI.Xaml.Controls.TextBlock) != null)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBlock_Text((this.obj22.Target as global::Windows.UI.Xaml.Controls.TextBlock), obj, null);
                    }
                }
            }
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class MainPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IMainPage_Bindings
        {
            private global::MusicPlayer.MainPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.ListView obj6;
            private global::Windows.UI.Xaml.Controls.ListView obj21;
            private global::Windows.UI.Xaml.Controls.ListView obj46;

            public MainPage_obj1_Bindings()
            {
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 6: // MainPage.xaml line 78
                        this.obj6 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 21: // MainPage.xaml line 369
                        this.obj21 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    case 46: // MainPage.xaml line 143
                        this.obj46 = (global::Windows.UI.Xaml.Controls.ListView)target;
                        break;
                    default:
                        break;
                }
            }

            // IMainPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MusicPlayer.MainPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MusicPlayer.MainPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | (1 << 0))) != 0)
                    {
                        this.Update_main_musicList(obj.main_musicList, phase);
                        this.Update_use_music(obj.use_music, phase);
                    }
                }
            }
            private void Update_main_musicList(global::System.Collections.ObjectModel.ObservableCollection<global::MusicPlayer.Models.MusicList> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 78
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj6, obj, null);
                    // MainPage.xaml line 369
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj21, obj, null);
                }
            }
            private void Update_use_music(global::System.Collections.ObjectModel.ObservableCollection<global::MusicPlayer.Models.Music> obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED )) != 0)
                {
                    // MainPage.xaml line 143
                    XamlBindingSetters.Set_Windows_UI_Xaml_Controls_ItemsControl_ItemsSource(this.obj46, obj, null);
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Loaded += this.Page_Loaded;
                    ((global::Windows.UI.Xaml.Controls.Page)element1).SizeChanged += this.Page_SizeChanged;
                }
                break;
            case 2: // MainPage.xaml line 25
                {
                    this.main_grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MainPage.xaml line 60
                {
                    this.MusicList_SplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 4: // MainPage.xaml line 65
                {
                    this.musicListShow_grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5: // MainPage.xaml line 70
                {
                    this.addMusicList_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.addMusicList_button).Click += this.AddMusicList_button_Click;
                }
                break;
            case 6: // MainPage.xaml line 78
                {
                    this.MusicList_ListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MusicList_ListView).ItemClick += this.MusicList_ListView_ItemClick;
                }
                break;
            case 7: // MainPage.xaml line 88
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element7 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element7).RightTapped += this.MusicList_stackPanel_RightTapped;
                }
                break;
            case 8: // MainPage.xaml line 93
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element8 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element8).Click += this.RemoveMusicList_item_Click;
                }
                break;
            case 9: // MainPage.xaml line 112
                {
                    this.the_colume = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 10: // MainPage.xaml line 114
                {
                    this.second_colume = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 11: // MainPage.xaml line 116
                {
                    this.third_colume = (global::Windows.UI.Xaml.Controls.ColumnDefinition)(target);
                }
                break;
            case 12: // MainPage.xaml line 119
                {
                    this.main_progressRing = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 13: // MainPage.xaml line 128
                {
                    this.title_stackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 14: // MainPage.xaml line 140
                {
                    this.listView_grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 15: // MainPage.xaml line 192
                {
                    this.MusicShow_Grid = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 16: // MainPage.xaml line 251
                {
                    this.main_scrollViewer = (global::Windows.UI.Xaml.Controls.ScrollViewer)(target);
                }
                break;
            case 17: // MainPage.xaml line 292
                {
                    this.slider_stackPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 18: // MainPage.xaml line 333
                {
                    this.main_mediaElement = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                    ((global::Windows.UI.Xaml.Controls.MediaElement)this.main_mediaElement).CurrentStateChanged += this.Main_mediaElement_CurrentStateChanged_1;
                }
                break;
            case 19: // MainPage.xaml line 340
                {
                    this.addList_ContentDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                }
                break;
            case 20: // MainPage.xaml line 364
                {
                    this.musicList_ContentDialog = (global::Windows.UI.Xaml.Controls.ContentDialog)(target);
                    ((global::Windows.UI.Xaml.Controls.ContentDialog)this.musicList_ContentDialog).Opened += this.MusicList_ContentDialog_Opened;
                }
                break;
            case 21: // MainPage.xaml line 369
                {
                    this.MusicList2_ListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MusicList2_ListView).ItemClick += this.MusicList2_ListView_ItemClick;
                }
                break;
            case 23: // MainPage.xaml line 349
                {
                    this.addListContentDialogTile_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 24: // MainPage.xaml line 354
                {
                    this.addList_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 25: // MainPage.xaml line 358
                {
                    this.list_textbox = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 26: // MainPage.xaml line 298
                {
                    this.main_slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.main_slider).ValueChanged += this.Main_slider_ValueChanged_1;
                }
                break;
            case 27: // MainPage.xaml line 313
                {
                    this.playTitle_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 28: // MainPage.xaml line 317
                {
                    this.line_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 29: // MainPage.xaml line 321
                {
                    this.playArtist_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 30: // MainPage.xaml line 325
                {
                    this.playTime_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 31: // MainPage.xaml line 259
                {
                    this.songDetails_grid = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 32: // MainPage.xaml line 261
                {
                    this.main_image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 33: // MainPage.xaml line 267
                {
                    this.songTile_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 34: // MainPage.xaml line 271
                {
                    this.artist_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 35: // MainPage.xaml line 275
                {
                    this.album_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 36: // MainPage.xaml line 279
                {
                    this.lyric_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.lyric_button).Click += this.Lyric_button_Click;
                }
                break;
            case 37: // MainPage.xaml line 285
                {
                    this.lyric_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 38: // MainPage.xaml line 200
                {
                    this.addMusic_button = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 39: // MainPage.xaml line 207
                {
                    this.musidlistTitle_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 40: // MainPage.xaml line 211
                {
                    this.back_Button = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.back_Button).Click += this.Back_Button_Click;
                }
                break;
            case 41: // MainPage.xaml line 218
                {
                    this.MusicShow_ListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.MusicShow_ListView).SelectionChanged += this.MusicShow_ListView_SelectionChanged;
                }
                break;
            case 42: // MainPage.xaml line 226
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element42 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element42).DoubleTapped += this.MusicListSongsShow_stackPanel_DoubleTapped;
                }
                break;
            case 43: // MainPage.xaml line 232
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element43 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element43).Click += this.ListPlay_item_Click;
                }
                break;
            case 44: // MainPage.xaml line 235
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element44 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element44).Click += this.ListPause_item_Click;
                }
                break;
            case 45: // MainPage.xaml line 239
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element45 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element45).Click += this.ListRemove_item_Click;
                }
                break;
            case 46: // MainPage.xaml line 143
                {
                    this.main_listview = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    ((global::Windows.UI.Xaml.Controls.ListView)this.main_listview).SelectionChanged += this.Main_listview_SelectionChanged;
                }
                break;
            case 47: // MainPage.xaml line 152
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element47 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element47).DoubleTapped += this.RightClick_stackPanel_DoubleTapped;
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element47).RightTapped += this.RightClick_stackPanel_RightTapped;
                }
                break;
            case 48: // MainPage.xaml line 159
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element48 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element48).Click += this.Play_menu_Click;
                }
                break;
            case 49: // MainPage.xaml line 162
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element49 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element49).Click += this.Stop_menu_Click;
                }
                break;
            case 50: // MainPage.xaml line 166
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element50 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element50).Click += this.AddToList_menu_Click;
                }
                break;
            case 51: // MainPage.xaml line 171
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element51 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element51).Click += this.RemoveFromList_menu_Click;
                }
                break;
            case 52: // MainPage.xaml line 176
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element52 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element52).Click += this.RecycleBin_menu_Click;
                }
                break;
            case 53: // MainPage.xaml line 179
                {
                    global::Windows.UI.Xaml.Controls.MenuFlyoutItem element53 = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)element53).Click += this.Direct_menu_Click;
                }
                break;
            case 54: // MainPage.xaml line 130
                {
                    this.songNumStr_textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 55: // MainPage.xaml line 135
                {
                    this.songNum_textBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 56: // MainPage.xaml line 386
                {
                    this.main_commandBar = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 57: // MainPage.xaml line 388
                {
                    this.listShow_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.listShow_button).Click += this.ListShow_button_Click;
                }
                break;
            case 58: // MainPage.xaml line 393
                {
                    this.musicList_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.musicList_button).Click += this.MusicList_button_Click;
                }
                break;
            case 59: // MainPage.xaml line 398
                {
                    this.back_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.back_button).Click += this.Back_button_Click_1;
                }
                break;
            case 60: // MainPage.xaml line 402
                {
                    this.play_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.play_button).Click += this.Play_button_Click;
                }
                break;
            case 61: // MainPage.xaml line 406
                {
                    this.forward_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.forward_button).Click += this.Forward_button_Click_1;
                }
                break;
            case 62: // MainPage.xaml line 410
                {
                    this.model_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 63: // MainPage.xaml line 430
                {
                    this.stop_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.stop_button).Click += this.Model_button_Click_1;
                }
                break;
            case 64: // MainPage.xaml line 436
                {
                    this.volume_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.volume_button).Click += this.Volume_button_Click;
                }
                break;
            case 65: // MainPage.xaml line 465
                {
                    this.fullScreen_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.fullScreen_button).Click += this.FullScreen_button_Click;
                }
                break;
            case 66: // MainPage.xaml line 470
                {
                    this.openFile_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.openFile_button).Click += this.OpenFile_button_Click;
                }
                break;
            case 67: // MainPage.xaml line 474
                {
                    this.musicFolder_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.musicFolder_button).Click += this.MusicFolder_button_Click;
                }
                break;
            case 68: // MainPage.xaml line 478
                {
                    this.addFolder_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.addFolder_button).Click += this.AddFolder_button_Click;
                }
                break;
            case 69: // MainPage.xaml line 482
                {
                    this.clear_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.clear_button).Click += this.Clear_button_Click;
                }
                break;
            case 70: // MainPage.xaml line 486
                {
                    this.backGround_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 71: // MainPage.xaml line 501
                {
                    this.help_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.help_button).Click += this.Help_button_Click;
                }
                break;
            case 72: // MainPage.xaml line 505
                {
                    this.mail_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.mail_button).Click += this.Mail_button_Click;
                }
                break;
            case 73: // MainPage.xaml line 509
                {
                    this.settings_button = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 74: // MainPage.xaml line 513
                {
                    this.menu_flyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 75: // MainPage.xaml line 514
                {
                    this.feedBack_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.feedBack_menu).Click += this.FeedBack_menu_Click_1;
                }
                break;
            case 76: // MainPage.xaml line 518
                {
                    this.theme_textblock = (global::Windows.UI.Xaml.Controls.MenuFlyoutSubItem)(target);
                }
                break;
            case 77: // MainPage.xaml line 520
                {
                    this.light_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.light_menu).Click += this.Light_menu_Click;
                }
                break;
            case 78: // MainPage.xaml line 523
                {
                    this.dark_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.dark_menu).Click += this.Dark_menu_Click;
                }
                break;
            case 79: // MainPage.xaml line 526
                {
                    this.defaultTheme_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.defaultTheme_menu).Click += this.DefaultTheme_menu_Click;
                }
                break;
            case 80: // MainPage.xaml line 491
                {
                    this.custom_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.custom_menu).Click += this.Custom_menu_Click;
                }
                break;
            case 81: // MainPage.xaml line 494
                {
                    this.default_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.default_menu).Click += this.Default_menu_Click;
                }
                break;
            case 82: // MainPage.xaml line 445
                {
                    this.volumeIcon_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.volumeIcon_textblock).Tapped += this.VolumeIcon_textblock_Tapped_1;
                }
                break;
            case 83: // MainPage.xaml line 452
                {
                    this.volume_slider = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.volume_slider).ValueChanged += this.Volume_slider_ValueChanged_1;
                }
                break;
            case 84: // MainPage.xaml line 457
                {
                    this.volume_textblock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 85: // MainPage.xaml line 414
                {
                    this.model_flyout = (global::Windows.UI.Xaml.Controls.MenuFlyout)(target);
                }
                break;
            case 86: // MainPage.xaml line 415
                {
                    this.single_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.single_menu).Click += this.Single_menu_Click;
                }
                break;
            case 87: // MainPage.xaml line 419
                {
                    this.order_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.order_menu).Click += this.Order_menu_Click;
                }
                break;
            case 88: // MainPage.xaml line 423
                {
                    this.random_menu = (global::Windows.UI.Xaml.Controls.MenuFlyoutItem)(target);
                    ((global::Windows.UI.Xaml.Controls.MenuFlyoutItem)this.random_menu).Click += this.Random_menu_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            switch(connectionId)
            {
            case 1: // MainPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    MainPage_obj1_Bindings bindings = new MainPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                }
                break;
            case 22: // MainPage.xaml line 376
                {                    
                    global::Windows.UI.Xaml.Controls.TextBlock element22 = (global::Windows.UI.Xaml.Controls.TextBlock)target;
                    MainPage_obj22_Bindings bindings = new MainPage_obj22_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(element22.DataContext);
                    element22.DataContextChanged += bindings.DataContextChangedHandler;
                    global::Windows.UI.Xaml.DataTemplate.SetExtensionInstance(element22, bindings);
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element22, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}

