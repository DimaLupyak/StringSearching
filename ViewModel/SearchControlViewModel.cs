using Logic;
using StringSearch;
using System;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class SearchControlViewModel : AViewModel
    {
        public event EventHandler<ResultItemEventArgs> ResultItemClicked;

         #region Constructor

        public SearchControlViewModel(SearchAlgorithmItem algorithm)
        {
            AlgorithmItem = algorithm;
            Results = new ObservableCollection<ResultItem>();
        }      

        #endregion

        #region Properties
        public SearchAlgorithmItem AlgorithmItem { get; set; }
        public ObservableCollection<ResultItem> Results { get; private set; }
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
                if (ResultItemClicked != null)
                    ResultItemClicked(this, new ResultItemEventArgs(lastClickedResultItem));
                OnPropertyChanged("LastClickedResultItem");
            }
        }
        #endregion

        public void UpdateResults(string text, string pattern)
        {
            Results.Clear();
            foreach (var item in AlgorithmItem.Algorithm.SearchAll(text, pattern))
            {
                Results.Add(item);
            }
        }
    }

    public class ResultItemEventArgs : EventArgs
    {
        public int Index { get; private set; }
        public string Value { get; private set; }
        public ResultItemEventArgs(ResultItem result)
        {
            Index = result.Index;
            Value = result.Value;
        }
    }
}
