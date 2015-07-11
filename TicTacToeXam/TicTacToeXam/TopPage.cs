using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace TicTacToeXam
{
    public class TopPage : ContentPage
    {
        // theGamePage;
        // transition to GameBoard Page
        async void OnPlayGameButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameBoard());
        }

        string theDescription = "TicTacXam from iOSDevcamp 2015, Chris Mason and Tanlin Dickey";

        void OnAboutGameButtonClicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new GameBoard());
            DisplayMessages("About TicTacXam", theDescription);
        }

        async void DisplayMessages(string title, string message)
        {
            await DisplayAlert(title, message, "OK", "Cancel");
        }

        WebView webView = new WebView
        {
            Source = new UrlWebViewSource
            {
                Url = "http://iosdevcamp.org",
            },
            VerticalOptions = LayoutOptions.FillAndExpand
        };

        public TopPage()
        {
            Label labeliOSDevCamp = new Label
            {
                Text = "Developed at iOSDevCamp 2015"
            };
                 Color backGroundColor = Device.OnPlatform<Color>(
                 Color.Green,
                 Color.Green,
                 Color.Green
            );

            Color textColor = Device.OnPlatform<Color>(
                   Color.Black,
                   Color.Black,
                   Color.Black
                );
            double buttonHeight = Device.OnPlatform<double>
              (
                50, // iOS
                50, // Android
                80  // Windows Phone

             );
            var buttonStyle = new Style(typeof(Button))
            {
                Setters = {
                  new Setter {Property = Button.BackgroundColorProperty, Value = backGroundColor},
                  new Setter {Property = Button.BorderRadiusProperty, Value = 0},
                  new Setter {Property = Button.HeightRequestProperty, Value = buttonHeight},
                  new Setter {Property = Button.TextColorProperty, Value = textColor }
                }
            };
            Label labelProgrammer = new Label
            {
                Text = "Programmers = Chris Mason, Tanlin Dickey"
            };
            Button playGameButton = new Button
            {
                Text = "Play Tic Tac Toe",
                Style = buttonStyle
            };
            Button aboutGameButton = new Button
            {
                Text = "About TicTacToeXam",
                Style = buttonStyle
            };

           

            // add the event handler to go to the other page
            playGameButton.Clicked += OnPlayGameButtonClicked;

            aboutGameButton.Clicked += OnAboutGameButtonClicked;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "TicTacToe using Xamarin.Forms!" },
                    labeliOSDevCamp,
                    labelProgrammer,
                    playGameButton,
                    aboutGameButton,
                    webView
                }
            };
        }
    }
}
