using Logic;
using StringSearch;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class SearchControlViewModel : AViewModel
    {
         #region Constructor

        public SearchControlViewModel(SearchAlgorithmItem algorithm)
        {
            AlgorithmItem = algorithm;
            Results = new ObservableCollection<ResultItem>();
            IsActive = true;
        }      

        #endregion

        #region Properties
        public SearchAlgorithmItem AlgorithmItem { get; set; }
        public ObservableCollection<ResultItem> Results { get; private set; }
        public bool isActive;
        public bool IsActive 
        {
            get
            {
            return isActive;
            }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
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
}
