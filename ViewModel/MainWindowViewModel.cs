using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Logic;

namespace ViewModel
{
    public class MainWindowViewModel : AViewModel
    {
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
        #endregion
        #region Constructor
        public MainWindowViewModel()
        {
            SearchControlViewModels = new ObservableCollection<SearchControlViewModel>();
            foreach (var item in SearchAlgorithmsManager.Instance.GetAll())
            {
                SearchControlViewModels.Add(new SearchControlViewModel(item));
            }
        }
        #endregion

        public void UpdateResults()
        {
            foreach (var item in SearchControlViewModels)
            {
                item.UpdateResults(text, pattern);
            }
        }
    }
}
