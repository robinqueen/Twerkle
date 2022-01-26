using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Twerkle.ViewModel
{
    public class AttemptsViewModel : INotifyPropertyChanged
    {
        public MainPage mp { get; set; }
        public AttemptsViewModel()
        {
            //_navigation = naviation;
            SaveCommand = new Command(SaveCommandHandler);

            CancelCommand = new Command(CancelCommandHandler);

        }

        private bool isAttemptEnabled;
        public bool IsAttemptEnabled
        {
            get
            {
                return this.isAttemptEnabled;
            }

            set
            {
                if (value != this.isAttemptEnabled)
                {
                    this.isAttemptEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        private static int _currentAttempt = 1;
        public static int CurrentAttempt
        {
            get { return _currentAttempt; }
            set
            {
                _currentAttempt = value;
            }
        }

        public static List<GuessedWordViewModel> GuessedWordsViewModel = new List<GuessedWordViewModel>();




       























        public Command SaveCommand { get; set; }

        public Command CancelCommand { get; set; }

        public void SaveCommandHandler()
        {    
            //_navigation.PopAsync();
        }

        public void CancelCommandHandler()
        {
            //_navigation.PopAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
