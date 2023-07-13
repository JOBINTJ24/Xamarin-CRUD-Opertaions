using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using xapp.Models;

namespace xapp.Views
{
    public class DeleteCompanyPages : ContentPage
    {
        private ListView listView;
        private Button _ButtonEntry;

        Company company = new Company();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "myDB.db3");

        public DeleteCompanyPages()
        {

            this.Title = "Delete Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            listView = new ListView();
            listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            listView.ItemSelected += ListView_ItemSelected;
            stackLayout.Children.Add(listView);

            Content = stackLayout;


            _ButtonEntry = new Button();
            _ButtonEntry.Text = "Delete";
            _ButtonEntry.Clicked += _ButtonEntry_Clicked;
            stackLayout.Children.Add(_ButtonEntry);

        }
        private async void _ButtonEntry_Clicked(object sender, EventArgs e)
        {

            var db = new SQLiteConnection(_dbPath);
            db.Table<Company>().Delete(x => x.Id == company.Id);
            await Navigation.PopAsync();
            await DisplayAlert(null, company.Name + "Deleted", "Ok");
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            company = (Company)e.SelectedItem;
          
        }
    }
}