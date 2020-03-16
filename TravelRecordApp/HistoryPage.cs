using System;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

