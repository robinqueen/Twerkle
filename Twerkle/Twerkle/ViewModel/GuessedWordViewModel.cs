using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Twerkle.ViewModel
{
    public class GuessedWordViewModel : INotifyPropertyChanged
    {

        public GuessedWordViewModel()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private string _guessWordLetter1;
        public string guessWordLetter1
        {
            get { return _guessWordLetter1; }
            set
            {
                _guessWordLetter1 = value;
                OnPropertyChanged();
            }
        }

        private string _guessWordLetter1Green;
        public string guessWordLetter1Green
        {
            get { return _guessWordLetter1; }
            set
            {
                _guessWordLetter1 = value;
                OnPropertyChanged();
            }
        }

        private string _guessWordLetter2;
        public string guessWordLetter2
        {
            get { return _guessWordLetter2; }
            set
            {
                _guessWordLetter2 = value;
                OnPropertyChanged();
            }
        }

        private string _guessWordLetter3;
        public string guessWordLetter3
        {
            get { return _guessWordLetter3; }
            set
            {
                _guessWordLetter3 = value;
                OnPropertyChanged();
            }
        }

        private string _guessWordLetter4;
        public string guessWordLetter4
        {
            get { return _guessWordLetter4; }
            set
            {
                _guessWordLetter4 = value;
                OnPropertyChanged();
            }
        }

        private string _guessWordLetter5;

        public string guessWordLetter5
        {
            get { return _guessWordLetter5; }
            set
            {
                _guessWordLetter5 = value;
                OnPropertyChanged();
            }
        }

       
    }
}
