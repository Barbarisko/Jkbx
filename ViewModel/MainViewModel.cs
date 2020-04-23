using Business.Interfaces;
using Business.Models;
using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModel;

namespace ViewModel
{
    public class MainViewModel : ViewModelBasic
    {
        public IMachineService machineService { get; }

        MachineModel jukebox = new MachineModel() ;
        AlbumModel album;
        List<SongModel> sorted;
        
        private List<string> _albumsList;
        public List<string> AlbumsListVM
        {
            set
            {
                _albumsList = value;
                onPropertyChanged();
            }
            get { return _albumsList; }
        }

        private List<string> _authorsList;
        public List<string> AuthorsListVM
        {
            set
            {
                _authorsList = value;
                onPropertyChanged();
            }
            get { return _authorsList; }
        }

        private List<string> _genresList;
        public List<string> GenresListVM
        {
            set
            {
                _genresList = value;
                onPropertyChanged();
            }
            get { return _genresList; }
        }

        private List<string> _sortedList;
        public List<string> SortedListVM
        {
            set
            {
                _sortedList = value;
                onPropertyChanged();
            }
            get { return _sortedList; }
        }

        private string selectedItem1;
        public string SelectedItem1
        {
            get { return selectedItem1; }
            set { selectedItem1 = value;
                  onPropertyChanged();}
        }
        private string selectedItem2;
        public string SelectedItem2
        {
            get { return selectedItem2; }
            set
            {
                selectedItem2 = value;
                onPropertyChanged();
            }
        }
        private string selectedItem3;
        public string SelectedItem3
        {
            get { return selectedItem3; }
            set
            {
                selectedItem3 = value;
                onPropertyChanged();
            }
        }

        private int selectedIndx1;
        public int SelectedIndx1
        {
            get { return selectedIndx1; }
            set
            {
                selectedIndx1 = value;
                onPropertyChanged();
            }
        }
        private int selectedIndx2;
        public int SelectedIndx2
        {
            get { return selectedIndx2; }
            set
            {
                selectedIndx2 = value;
                onPropertyChanged();
            }
        }
        private int selectedIndx3;
        public int SelectedIndx3
        {
            get { return selectedIndx3; }
            set
            {
                selectedIndx3 = value;
                onPropertyChanged();
            }
        }
        private string _currentAmount;
        public string CurrentAmVM
        {
            set
            {
                _currentAmount = value;
                onPropertyChanged();
            }
            get { return _currentAmount; }
        }

        public MainViewModel(IMachineService ms)
        {
            machineService = ms;

            album = new AlbumModel();
            machineService.JukeboxFill(album, jukebox);

            FillListboxes();

            //ms.saveToFile(InfoInput.json);

        }

        public void FillListboxes()
        {
            AlbumsListVM = new List<string>();
            AuthorsListVM = new List<string>();
            GenresListVM = new List<string>();

            foreach (AlbumModel al in jukebox.albums)
            {
                AlbumsListVM.Add(al.Name);

                foreach (SongModel s in al.Songs)
                {
                    if (!AuthorsListVM.Contains(s.Singer))
                    {
                        AuthorsListVM.Add(s.Singer);

                    }
                    if (!GenresListVM.Contains(s.Genre))
                    {
                        GenresListVM.Add(s.Genre);
                    }
                }

            }
        }

        static bool IsNum(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsDigit(c)) return false;
            }
            return true;
        }

        public ICommand ShowSongsBy
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    SortedListVM = new List<string>();
                    if (IsNum(CurrentAmVM) == true)
                    {
                        if (Convert.ToInt32(CurrentAmVM) <= 0)
                        {
                            MessageBox.Show("input money");
                            return;
                        }
                        sorted = machineService.findSortedListOfSongs(jukebox, SelectedItem2, SelectedItem1,  selectedItem3, Convert.ToInt32(CurrentAmVM));
                        SortedListVM.Clear();

                        foreach (SongModel i in sorted)
                        {
                            SortedListVM.Add(i.Name);
                        }

                        SelectedIndx1 = -1;
                        SelectedIndx2 = -1;
                        SelectedIndx3 = -1;
                    }                                  
                });
            }
        }
    }
}
