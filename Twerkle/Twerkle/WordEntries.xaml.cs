using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twerkle.AppLogic;
using Twerkle.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Twerkle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WordEntries : ContentView
    {

        private string attempt = "";
        public WordEntries()
        {
            InitializeComponent();

            Letter1Color = Color.White;
        }

        private string _displayMessage;
        public string DisplayMessage
        {
            get { return _displayMessage; }
            set
            {
                _displayMessage = value;
                OnPropertyChanged();
            }
        }

        private Color letter1Color;
        public Color Letter1Color
        {
            get
            {
                return this.letter1Color;
            }

            set
            {
                if (value != this.letter1Color)
                {
                    this.letter1Color = value;
                    OnPropertyChanged();
                }
            }
        }

       


        
    }
}