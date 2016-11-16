using System.Collections.ObjectModel;
using Logic;
using Microsoft.Win32;
using System.Windows.Input;
using System.Threading;
using System;
using System.Windows.Threading;
using System.Windows;
using StringSearch;

namespace ViewModel
{
    public class MainWindowViewModel : AViewModel
    {
        public event EventHandler<ResultItemEventArgs> ResultItemUpated;

        #region Proerties
        public ObservableCollection<SearchControlViewModel> SearchControlViewModels { get; private set; }
        public string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;

                UpdateResults();
                OnPropertyChanged("Text");
            }
        }
        public string pattern;
        public string Pattern
        {
            get
            {
                return pattern;
            }
            set
            {
                pattern = value;                
                UpdateResults();
                OnPropertyChanged("Pattern");
            }
        }

        public ResultItem lastClickedResultItem;
        public ResultItem LastClickedResultItem
        {
            get
            {
                return lastClickedResultItem;
            }
            set
            {
                lastClickedResultItem = value;
                if (ResultItemUpated != null)
                    ResultItemUpated(this, new ResultItemEventArgs(lastClickedResultItem));
                OnPropertyChanged("LastClickedResultItem");
            }
        }

        #endregion
        #region Constructor
        public MainWindowViewModel()
        {
            LoadTextFromFileCommand = new Command(a => new Thread(LoadTextFromFile).Start());
            CloseWindowCommand = new Command(a => Environment.Exit(0));
            SearchControlViewModels = new ObservableCollection<SearchControlViewModel>();
            foreach (var item in SearchAlgorithmsManager.Instance.GetAll())
            {
                var searchControl = new SearchControlViewModel(item);
                searchControl.ResultItemClicked += (o, e) => LastClickedResultItem = new ResultItem(e.Index, e.Value);
                SearchControlViewModels.Add(searchControl);
            }

        }
        #endregion
        #region Methods
        public void UpdateResults()
        {
            if (text != null && pattern != null && pattern.Trim()!="")
                foreach (var item in SearchControlViewModels)
                {
                    try
                    {
                        item.UpdateResults(text, pattern); 
                    }
                    catch(Exception){}       
                }
        }

        public void LoadTextFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Text = DataProvider.GetStringFromFile(openFileDialog.FileName);
            }
        }
        #endregion
        #region Commands

        public ICommand LoadTextFromFileCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        #endregion
    }
}
