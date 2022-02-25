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



// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MusicLibraryApplication
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<SongItem> Musics; // List that has all music files loaded 

        private ObservableCollection<SongItem> SelectedMusic; // to the selected music of user collection 

        // Yassmin: the right menu that has the music category list displayed , when the user chooses a category all the songs under this list will be loaded 

        private List<MenuItem> MenuItems;
        public MainPage()
        {

            this.InitializeComponent();
            //Metadata tag = new Metadata();
            //tag.ReadFileMetaData();

            //Yassmin : Read all the music files into observable collection 

            Musics = new ObservableCollection<SongItem>();
            MusicManager.GetAllMusic(Musics);

            //Yassmin: Load all the music category list to the right menu 
            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Image/MusicLibrary/Classical/Classic.png",// Yassmin : the name of the icon needs to be changed based on the final icons we use and their names 
                MenuSelection = MusicGenre.Classical // Yassmin : I had to convert it toString untill Michelle changes the menuItem from string to MusicGenre
            });

            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Image/MusicLibrary/Country/Country_2.jpg",// Yassmin : the name of the icon needs to be changed based on the final icons we use and their names 
                MenuSelection = MusicGenre.Country// Yassmin : I had to convert it toString untill Michelle changes the menuItem from string to MusicGenre

            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Image/MusicLibrary/Electronic/Electronic.png",// Yassmin : the name of the icon needs to be changed based on the final icons we use and their names 
                MenuSelection = MusicGenre.Electronic// Yassmin : I had to convert it toString untill Michelle changes the menuItem from string to MusicGenre

            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Image/MusicLibrary/Pop/pop_1.png",// Yassmin : the name of the icon needs to be changed based on the final icons we use and their names 
                MenuSelection = MusicGenre.Pop// Yassmin : I had to convert it toString untill Michelle changes the menuItem from string to MusicGenre

            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Image/MusicLibrary/Rap/Rap.png",// Yassmin : the name of the icon needs to be changed based on the final icons we use and their names 
                MenuSelection = MusicGenre.Rap// Yassmin : I had to convert it toString untill Michelle changes the menuItem from string to MusicGenre

            });
            MenuItems.Add(new MenuItem
            {
                Icon = $"Assets/Image/MusicLibrary/Rock/images.png",// Yassmin : the name of the icon needs to be changed based on the final icons we use and their names 
                MenuSelection = MusicGenre.Rock// Yassmin : I had to convert it toString untill Michelle changes the menuItem from string to MusicGenre

            });
            /*    MenuItem.Add(new MenuItem    // Yassmin : for tge JAZZ if it is added 
                {
                    Icon = $"Assets/Image/MusicLibrary/Rap/Rap.png",
                    MenuSelection = MusicGenre.Rap
                });
            */



        }

        private void ListOfMusic_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            //Yassmin : expected that the texbock of the musics page changed to be the Genre 

            MusicManager.GetMusicByCategory(Musics, menuItem.MenuSelection);



        }

        // Yassmin :  when the check box is checked , the selected songs are put in a collection
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            // when the check box is checked , the item selected is added to the observable collection of selected item 

            string selectedSong = e.ToString();
            SelectedMusic = new ObservableCollection<SongItem>();
            MusicManager.GetMusicByTitle(SelectedMusic, selectedSong);

        }



        /// Yassmin :  when the check box is unchceked , remove it from the collection of added songs 

        private void CheckBox_Click_unchecked(object sender, RoutedEventArgs e)
        {
            string selectedSong = e.ToString();
            SelectedMusic.Remove(SelectedMusic.Where(i => i.SongTitle == selectedSong).Single());
        }


        private void CategoryList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            //Yassmin : expected that the texbock of the musics page changed to be the Genre 
            MusicManager.GetMusicByCategory(Musics, menuItem.MenuSelection);

        }

        private void MyCollection_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            //Yassmin : expected that the texbock of the musics page changed to be the Genre 
            MusicManager.GetMusicByCategory(Musics, menuItem.MenuSelection);

        }

        private void MyCollectio_Click(object sender, RoutedEventArgs e)
        {
            // I need to store all checked items in a list or collection 
            // I have created SelectedMusic collection , but loaed it with the data when the checkbox is checked 
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // I need to store all checked items in a list or collection 
            MusicManager.GetAllMusic(Musics);
            CategoryList.SelectedItem = null;
            // 
            BackButton.Visibility = Visibility.Collapsed;
        }

    }

}

