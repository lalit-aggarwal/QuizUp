using System.Collections.Generic;
using System.ComponentModel;

namespace QuizUp.Models
{
    /// <summary>
    /// Represents question in database
    /// </summary>
    public class Question: INotifyPropertyChanged
    {
        private string _selectedAnswer;

        public int ID { get; set; }

        public string Header { get; set; }

        public string SelectedAnswer
        {
            get
            {
                return _selectedAnswer;
            }
            set
            {
                _selectedAnswer = value;
                OnPropertyChanged("SelectedAnswer");
            }
        }

        public string Choice1 { get; set; }

        public string Choice2 { get; set; }

        public string Choice3 { get; set; }

        public string Choice4 { get; set; }

        public string Answer { get; set; }

        public List<string> Choices
        {
            get
            {
                return new List<string> { Choice1, Choice2, Choice3, Choice4 };
            }
        }

        #region INotifyPropertyChanged Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
