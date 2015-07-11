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
        public TopPage()
        {
            Button playGameButton = new Button
            {
                Text = "Play Tic Tac Toe",
            };

            // add the event handler to go to the other page
            playGameButton.Clicked += OnPlayGameButtonClicked;

            

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to TicTacToe" },
                    playGameButton
                }
            };
        }
    }
}
