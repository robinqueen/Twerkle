using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Twerkle.AppLogic;
using Twerkle.ViewModel;
using Xamarin.Forms;

namespace Twerkle
{
    public partial class MainPage : ContentPage
    {
        
        public AttemptsViewModel attemptsViewModel = new AttemptsViewModel();

        

        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = attemptsViewModel;

            AppLogicHandler.InitializeGame();

            SetGuessContext();


        }



        public void SetGuessContext()
        {
            if (AttemptsViewModel.CurrentAttempt == 1)
            {
                PlayerGridG1.IsEnabled = true;
                Letter1.Focus();
                PlayerGridG2.IsEnabled = false;
                PlayerGridG3.IsEnabled = false;
                PlayerGridG4.IsEnabled = false;
            }

            if (AttemptsViewModel.CurrentAttempt == 2)
            {
                PlayerGridG1.IsEnabled = false;
                PlayerGridG2.IsEnabled = true;
                G2Letter1.Focus();
                PlayerGridG3.IsEnabled = false;
                PlayerGridG4.IsEnabled = false;
            }

            if (AttemptsViewModel.CurrentAttempt == 3)
            {
                PlayerGridG1.IsEnabled = false;
                PlayerGridG2.IsEnabled = false;
                PlayerGridG3.IsEnabled = true;
                G3Letter1.Focus();
                PlayerGridG4.IsEnabled = false;
            }

            if (AttemptsViewModel.CurrentAttempt == 4)
            {
                PlayerGridG1.IsEnabled = false;
                PlayerGridG2.IsEnabled = false;
                PlayerGridG3.IsEnabled = false;
                PlayerGridG4.IsEnabled = true;
                G4Letter1.Focus();
            }
        }

        private string attempt = "";

        private void Entry_Completed(object sender, EventArgs e)
        {
            if (!ValidateAttempt()) return;

            attempt = attempt.ToUpper();

            AppLogicHandler.CheckAttempt(attempt);

            if (AppLogicHandler.winCondition)
            {
                App.Current.MainPage.DisplayAlert("Congrats!", "You Guessed the Correct Twerker!", "TWERK!");
                return;
            }

            //need to update the wordentires via bindings to disable/show proper color attributes?
            //being able to do it this way would have been nice... if this wasn't such a black box but oh well... brute force it we go...
            

            switch (AttemptsViewModel.CurrentAttempt)
            {
                case 1:
                    DoPlayerGuess1Stuff();
                    break;
                case 2:
                    DoPlayerGuess2Stuff();
                    break;
                case 3:
                    DoPlayerGuess3Stuff();
                    break;
                case 4:
                    DoPlayerGuess4Stuff();
                    if (AppLogicHandler.winCondition)
                    {
                        App.Current.MainPage.DisplayAlert("Congrats!", "You Guessed the Correct Twerker!", "TWERK!");
                        return;
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Whoops!", "You ran out of guesses!", "Ok");
                    }
                    break;
            }

            
            


            AttemptsViewModel.CurrentAttempt++;
            SetGuessContext();
        }

        #region PlayerGuessLogic


        private void DoPlayerGuess1Stuff()
        {
            if (AppLogicHandler.correctLetterAndPosition.Count > 0)
            {
                var letter = "";
                AppLogicHandler.correctLetterAndPosition.TryGetValue(0, out letter);
                if (Letter1.Text.ToUpper() == letter)
                {
                    Letter1.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(1, out letter);
                if (Letter2.Text.ToUpper() == letter)
                {
                    Letter2.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(2, out letter);
                if (Letter3.Text.ToUpper() == letter)
                {
                    Letter3.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(3, out letter);
                if (Letter4.Text.ToUpper() == letter)
                {
                    Letter4.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(4, out letter);
                if (Letter5.Text.ToUpper() == letter)
                {
                    Letter5.BackgroundColor = Color.LightGreen;
                }
            }

            foreach (var i in AppLogicHandler.correctLetterNotPosition)
            {
                switch (i.Key)
                {
                    case 0:
                        Letter1.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 1:
                        Letter2.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 2:
                        Letter3.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 3:
                        Letter4.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 4:
                        Letter5.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                }
            }
        }
        private void DoPlayerGuess2Stuff()
        {
            if (AppLogicHandler.correctLetterAndPosition.Count > 0)
            {
                var letter = "";
                AppLogicHandler.correctLetterAndPosition.TryGetValue(0, out letter);
                if (G2Letter1.Text.ToUpper() == letter)
                {
                    G2Letter1.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(1, out letter);
                if (G2Letter2.Text.ToUpper() == letter)
                {
                    G2Letter2.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(2, out letter);
                if (G2Letter3.Text.ToUpper() == letter)
                {
                    G2Letter3.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(3, out letter);
                if (G2Letter4.Text.ToUpper() == letter)
                {
                    G2Letter4.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(4, out letter);
                if (G2Letter5.Text.ToUpper() == letter)
                {
                    G2Letter5.BackgroundColor = Color.LightGreen;
                }
            }

            foreach (var i in AppLogicHandler.correctLetterNotPosition)
            {
                switch (i.Key)
                {
                    case 0:
                        G2Letter1.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 1:
                        G2Letter2.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 2:
                        G2Letter3.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 3:
                        G2Letter4.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 4:
                        G2Letter5.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                }
            }
        }
        private void DoPlayerGuess3Stuff()
        {
            if (AppLogicHandler.correctLetterAndPosition.Count > 0)
            {
                var letter = "";
                AppLogicHandler.correctLetterAndPosition.TryGetValue(0, out letter);
                if (G3Letter1.Text.ToUpper() == letter)
                {
                    G3Letter1.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(1, out letter);
                if (G3Letter2.Text.ToUpper() == letter)
                {
                    G3Letter2.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(2, out letter);
                if (G3Letter3.Text.ToUpper() == letter)
                {
                    G3Letter3.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(3, out letter);
                if (G3Letter4.Text.ToUpper() == letter)
                {
                    G3Letter4.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(4, out letter);
                if (G3Letter5.Text.ToUpper() == letter)
                {
                    G3Letter5.BackgroundColor = Color.LightGreen;
                }
            }

            foreach (var i in AppLogicHandler.correctLetterNotPosition)
            {
                switch (i.Key)
                {
                    case 0:
                        G3Letter1.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 1:
                        G3Letter2.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 2:
                        G3Letter3.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 3:
                        G3Letter4.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 4:
                        G3Letter5.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                }
            }
        }
        private void DoPlayerGuess4Stuff()
        {
            if (AppLogicHandler.correctLetterAndPosition.Count > 0)
            {
                var letter = "";
                AppLogicHandler.correctLetterAndPosition.TryGetValue(0, out letter);
                if (G4Letter1.Text.ToUpper() == letter)
                {
                    G4Letter1.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(1, out letter);
                if (G4Letter2.Text.ToUpper() == letter)
                {
                    G4Letter2.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(2, out letter);
                if (G4Letter3.Text.ToUpper() == letter)
                {
                    G4Letter3.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(3, out letter);
                if (G4Letter4.Text.ToUpper() == letter)
                {
                    G4Letter4.BackgroundColor = Color.LightGreen;
                }

                AppLogicHandler.correctLetterAndPosition.TryGetValue(4, out letter);
                if (G4Letter5.Text.ToUpper() == letter)
                {
                    G4Letter5.BackgroundColor = Color.LightGreen;
                }
            }

            foreach (var i in AppLogicHandler.correctLetterNotPosition)
            {
                switch (i.Key)
                {
                    case 0:
                        G4Letter1.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 1:
                        G4Letter2.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 2:
                        G4Letter3.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 3:
                        G4Letter4.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                    case 4:
                        G4Letter5.BackgroundColor = Color.LightGoldenrodYellow;
                        break;
                }
            }
        }


        #endregion

        private bool ValidateAttempt()
        {
            switch (AttemptsViewModel.CurrentAttempt)
            {
                case 1:
                    return ValidateGuess1();
                case 2:
                    return ValidateGuess2();
                case 3:
                    return ValidateGuess3();
                case 4:
                    return ValidateGuess4();
                default: return false;
            }
            
        }

        #region GuessValidation


        private bool ValidateGuess1()
        {
            if (Letter1.Text is null || Letter2.Text is null || Letter3.Text is null || Letter4.Text is null || Letter5.Text is null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }
            attempt = Letter1.Text.Trim() + Letter2.Text.Trim() + Letter3.Text.Trim() + Letter4.Text.Trim() + Letter5.Text.Trim();

            if (attempt.Length != 5)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }

            return true;
        }

        private bool ValidateGuess2()
        {
            if (G2Letter1.Text is null || G2Letter2.Text is null || G2Letter3.Text is null || G2Letter4.Text is null || G2Letter5.Text is null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }
            attempt = G2Letter1.Text.Trim() + G2Letter2.Text.Trim() + G2Letter3.Text.Trim() + G2Letter4.Text.Trim() + G2Letter5.Text.Trim();

            if (attempt.Length != 5)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }

            return true;
        }

        private bool ValidateGuess3()
        {
            if (G3Letter1.Text is null || G3Letter2.Text is null || G3Letter3.Text is null || G3Letter4.Text is null || G3Letter5.Text is null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }
            attempt = G3Letter1.Text.Trim() + G3Letter2.Text.Trim() + G3Letter3.Text.Trim() + G3Letter4.Text.Trim() + G3Letter5.Text.Trim();

            if (attempt.Length != 5)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }

            return true;
        }

        private bool ValidateGuess4()
        {
            if (G4Letter1.Text is null || G4Letter2.Text is null || G4Letter3.Text is null || G4Letter4.Text is null || G4Letter5.Text is null)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }
            attempt = G4Letter1.Text.Trim() + G4Letter2.Text.Trim() + G4Letter3.Text.Trim() + G4Letter4.Text.Trim() + G4Letter5.Text.Trim();

            if (attempt.Length != 5)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Error Submitting Twerkle!", "Please submit a 5 letter Name.", "OK");
                });
                return false;
            }

            return true;
        }


        #endregion

        #region TextChanged


        private void Letter1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Letter1.Text))
            {
                Letter2.Focus();
            }
        }

        private void Letter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Letter2.Text))
            {
                Letter3.Focus();
            }
        }

        private void Letter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Letter3.Text))
            {
                Letter4.Focus();
            }
        }

        private void Letter4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Letter4.Text))
            {
                Letter5.Focus();
            }
        }

        private void G2Letter1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G2Letter1.Text))
            {
                G2Letter2.Focus();
            }
        }

        private void G2Letter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G2Letter2.Text))
            {
                G2Letter3.Focus();
            }
        }

        private void G2Letter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G2Letter3.Text))
            {
                G2Letter4.Focus();
            }
        }

        private void G2Letter4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G2Letter4.Text))
            {
                G2Letter5.Focus();
            }
        }

        private void G3Letter1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G3Letter1.Text))
            {
                G3Letter2.Focus();
            }
        }

        private void G3Letter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G3Letter2.Text))
            {
                G3Letter3.Focus();
            }
        }

        private void G3Letter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G3Letter3.Text))
            {
                G3Letter4.Focus();
            }
        }

        private void G3Letter4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G3Letter4.Text))
            {
                G3Letter5.Focus();
            }
        }

        private void G4Letter1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G4Letter1.Text))
            {
                G4Letter2.Focus();
            }
        }

        private void G4Letter2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G4Letter2.Text))
            {
                G4Letter3.Focus();
            }
        }

        private void G4Letter3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G4Letter3.Text))
            {
                G4Letter4.Focus();
            }
        }

        private void G4Letter4_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(G4Letter4.Text))
            {
                G4Letter5.Focus();
            }
        }

        #endregion

    }
}
