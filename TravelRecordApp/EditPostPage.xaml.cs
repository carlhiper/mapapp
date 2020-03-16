using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{
    public partial class EditPostPage : ContentPage
    {
        Post selectedItem;
        public EditPostPage(Post selectedItem)
        {
            InitializeComponent();

            this.selectedItem = selectedItem;

            experienceEntry.Text = selectedItem.Experience;
        }

        void editButton_Clicked(System.Object sender, System.EventArgs e)
        {
            selectedItem.Experience = experienceEntry.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Update(selectedItem);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Post changed", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Post not changed", "Ok");
                }
            }
        }

        void deleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Delete(selectedItem);

                if (rows > 0)
                {
                    DisplayAlert("Success", "Post deleted", "Ok");
                }
                else
                {
                    DisplayAlert("Failure", "Post not deleted", "Ok");
                }
            }
        }
    }
}
