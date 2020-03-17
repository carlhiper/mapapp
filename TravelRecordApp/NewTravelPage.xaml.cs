﻿using System;
using System.Collections.Generic;
using Plugin.Geolocator;
using SQLite;
using TravelRecordApp.Logic;
using TravelRecordApp.Model;

using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class NewTravelPage : ContentPage
    {
        public NewTravelPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();
            var venues = VenueLogic.GetVenues(position.Latitude, position.Longitude);
        }

        void ToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
            Post post = new Post()
            {
                Experience = experienceEntry.Text
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);
             
                if (rows > 0)
                {
                    DisplayAlert("Success", "Experience successfullt inserted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Experience insert failed", "Ok");
                }
            }
        }
    }
}
