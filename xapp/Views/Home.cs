using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace xapp.Views
{
    public class Home : ContentPage
    {
        public Home()
        {
            this.Title = "Select Option";

            StackLayout stackLayout = new StackLayout();
            stackLayout.Margin = new Thickness(20); // Add some margin around the stack layout

            Button button = new Button();
            button.Text = "Add Company";
            button.Clicked += Button_Clicked;
            button.BackgroundColor = Color.Green;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "View";
            button.BackgroundColor = Color.Yellow;
            button.Clicked += Button_Get_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Edit";
            button.Clicked += Button_Edit_Clicked;
            stackLayout.Children.Add(button);

            button = new Button();
            button.Text = "Delete";
            button.BackgroundColor = Color.Red;
            button.Clicked += Button_Delete_Clicked;
            stackLayout.Children.Add(button);

            Content = new ScrollView // Add a ScrollView to enable scrolling if the content overflows
            {
                Content = stackLayout
            };

            BackgroundColor = Color.LightGray; // Set a background color for the page
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Addcompany());
        }

        private async void Button_Get_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllCompanyPages());
        }

        private async void Button_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditCompanyPages());
        }

        private async void Button_Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DeleteCompanyPages());
        }
    }
}
