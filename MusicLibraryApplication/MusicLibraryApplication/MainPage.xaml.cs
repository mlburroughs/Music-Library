﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections;
using System.Collections.ObjectModel;
using MusicLibraryApplication.Model;



namespace MusicLibraryApplication
{

    public sealed partial class MainPage : Page
    {
        private ObservableCollection<SongItem> Musics; // List that has all music files loaded
        private ObservableCollection<SongItem> SelectedMusic; // to the selected music of user collection 

        // Menus
        private List<MenuItem> MenuItems;
        private List<ArtistMenuItem> ArtistMenuItems;
        private List<DecadeMenuItem> DecadeMenuItems;

        private SongItem currentSongSelected;

        public MainPage()
        {

            this.InitializeComponent();
            BackButton.Visibility = Visibility.Collapsed;

            //Read all the music files into observable collection
            Musics = new ObservableCollection<SongItem>();
            SelectedMusic = new ObservableCollection<SongItem>();

            MusicManager.GetAllMusic(Musics);

            // Genre Menu Items
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Images/Genres/Classical.png",
                MenuSelection = MusicGenre.Classical
            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Images/Genres/Country.png",
                MenuSelection = MusicGenre.Country
            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Images/Genres/Electronic.png",
                MenuSelection = MusicGenre.Electronic

            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Images/Genres/Jazz.png",
                MenuSelection = MusicGenre.Jazz
            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Images/Genres/Pop.png",
                MenuSelection = MusicGenre.Pop
            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Images/Genres/Rap.png",
                MenuSelection = MusicGenre.Rap
            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Images/Genres/Rock.png",
                MenuSelection = MusicGenre.Rock
            });

            // Artist Menu Items
            ArtistMenuItems = new List<ArtistMenuItem>();
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Akon"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Beyonce"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Michael Buble"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "One Less Reason"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Christina Perri"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Josh Rouse"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Frank Sinatra"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Train"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Neil Young"
            });
            ArtistMenuItems.Add(new ArtistMenuItem
            {
                Icon = $"Assets/Images/Artists/Artist.png",
                ArtistName = "Hans Zimmer"
            });

            // Decade Music Items
            DecadeMenuItems = new List<DecadeMenuItem>();
            DecadeMenuItems.Add(new DecadeMenuItem
            {
                Icon = $"Assets/Images/Decades/Sixties.png",
                Decade = Decades.Sixties
            });
            DecadeMenuItems.Add(new DecadeMenuItem
            {
                Icon = $"Assets/Images/Decades/Seventies.png",
                Decade = Decades.Seventies
            });
            DecadeMenuItems.Add(new DecadeMenuItem
            {
                Icon = $"Assets/Images/Decades/Eighties.png",
                Decade = Decades.Eighties
            });
            DecadeMenuItems.Add(new DecadeMenuItem
            {
                Icon = $"Assets/Images/Decades/Ninties.png",
                Decade = Decades.Ninties
            });
            DecadeMenuItems.Add(new DecadeMenuItem
            {
                Icon = $"Assets/Images/Decades/Aughts.png",
                Decade = Decades.Aughts
            });
            DecadeMenuItems.Add(new DecadeMenuItem
            {
                Icon = $"Assets/Images/Decades/Teens.png",
                Decade = Decades.Teens
            });
            DecadeMenuItems.Add(new DecadeMenuItem
            {
                Icon = $"Assets/Images/Decades/Twenties.png",
                Decade = Decades.Twenties
            });

          
        }

        
        // Header Event Handlers
        private void ByGenre_Click(object sender, RoutedEventArgs e)
        {
            ListCategory.Visibility = Visibility.Visible;
            ArtistCategory.Visibility = Visibility.Collapsed;
            DecadeCategory.Visibility = Visibility.Collapsed;

            BackButton.Visibility = Visibility.Visible;
        }

        private void ByArtist_Click(object sender, RoutedEventArgs e)
        {
            ArtistCategory.Visibility = Visibility.Visible;
            ListCategory.Visibility = Visibility.Collapsed;
            DecadeCategory.Visibility = Visibility.Collapsed;

            BackButton.Visibility = Visibility.Visible;
        }

        private void ByDecade_Click(object sender, RoutedEventArgs e)
        {
            DecadeCategory.Visibility = Visibility.Visible;
            ListCategory.Visibility = Visibility.Collapsed;
            ArtistCategory.Visibility = Visibility.Collapsed;

            BackButton.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            MusicManager.GetAllMusic(Musics);
            CategoryList.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;

        }
        private void HamButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListCategory.Visibility == Visibility.Visible)
            {
                ListCategory.Visibility = Visibility.Collapsed;
                BackButton.Visibility = Visibility.Collapsed;
            }
            else if (ArtistCategory.Visibility == Visibility.Visible)
            {
                ArtistCategory.Visibility = Visibility.Collapsed;
                BackButton.Visibility = Visibility.Collapsed;
            }
            else if (DecadeCategory.Visibility == Visibility.Visible)
            {
                DecadeCategory.Visibility = Visibility.Collapsed;
                BackButton.Visibility = Visibility.Collapsed;
            }
        }

        // Menu Item Click Events
        private void CategoryList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            MusicManager.GetMusicByCategory(Musics, menuItem.MenuSelection);
            BackButton.Visibility = Visibility.Visible;
        }

        private void ArtistList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (ArtistMenuItem)e.ClickedItem;
            MusicManager.GetMusicByArtist(Musics, menuItem.ArtistName);
            BackButton.Visibility = Visibility.Visible;
        }
        private void DecadeList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (DecadeMenuItem)e.ClickedItem;
            MusicManager.GetMusicByDecade(Musics, menuItem.Decade);
            BackButton.Visibility = Visibility.Visible;
        }


        private void ListOfMusic_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mySelectedSong = (SongItem)e.ClickedItem;
            MusicManager.GetSelectedMusicByTitle(SelectedMusic, mySelectedSong.SongTitle);

        }

        private void MyMusicCollection_ItemClick(object sender, ItemClickEventArgs e)
        {
            currentSongSelected = (SongItem) e.ClickedItem;
            PlaySong(currentSongSelected);
        }

        private void PlaySong(SongItem songItem) {
            MusicMedia.Source = new Uri(BaseUri, currentSongSelected.AudioFile);
            MusicMedia.Play();
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            MusicMedia.Play();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            int currentSelectedSongIndex = SelectedMusic.IndexOf(currentSongSelected);
            if (currentSelectedSongIndex !=  0)
            {
                currentSongSelected = SelectedMusic.ElementAt(currentSelectedSongIndex - 1);
            }
            else
            {
                currentSongSelected = SelectedMusic.ElementAt(SelectedMusic.Count);
            }
            PlaySong(currentSongSelected);
        }
           

        
        private void ButtonStop_Click(object sender, RoutedEventArgs e)
        {
            MusicMedia.Stop();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            int currentSelectedSongIndex = SelectedMusic.IndexOf(currentSongSelected);
            if (SelectedMusic.Count != currentSelectedSongIndex + 1)
            {
                currentSongSelected = SelectedMusic.ElementAt(currentSelectedSongIndex + 1);
            }
            else {
               currentSongSelected = SelectedMusic.ElementAt(0);
            }
            PlaySong(currentSongSelected);
        }

        


    }

}

