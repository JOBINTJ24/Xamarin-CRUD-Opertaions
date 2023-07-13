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
    public class EditCompanyPages : ContentPage
    {
        private ListView listView;
        private Entry _idEntry;
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Button _ButtonEntry;

        Company company = new Company();

        string _dbPath = Path.Combine(System.Environment.GetFolderPath
           (System.Environment.SpecialFolder.Personal), "myDB.db3");
        public EditCompanyPages()
        {
            this.Title = "Edit Company";
            var db = new SQLiteConnection(_dbPath);
            StackLayout stackLayout = new StackLayout();
            listView = new ListView();
            listView.ItemsSource = db.Table<Company>().OrderBy(x => x.Name).ToList();
            listView.ItemSelected += ListView_ItemSelected;
            stackLayout.Children.Add(listView);

            _idEntry = new Entry();
            _idEntry.Placeholder = "ID";
            _idEntry.IsVisible = false;
            stackLayout.Children.Add(_idEntry);

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Name";
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Address";
            stackLayout.Children.Add(_addressEntry);

            _ButtonEntry = new Button();
            _ButtonEntry.Text = "Update";
            _ButtonEntry.Clicked += _ButtonEntry_Clicked;
            stackLayout.Children.Add(_ButtonEntry);

            Content = stackLayout;
        }

        private async void _ButtonEntry_Clicked(object sender, EventArgs e)
        {

            var db = new SQLiteConnection(_dbPath);
            Company company = new Company()
            {
                Id=Convert.ToInt32(_idEntry.Text),
                Name=_nameEntry.Text,
                Address=_addressEntry.Text
            };
            db.Update(company);
            await Navigation.PopAsync();
            await DisplayAlert(null, company.Name + "Updated", "Ok");
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            company = (Company)e.SelectedItem;
            _idEntry.Text = company.Id.ToString();
            _nameEntry.Text = company.Name;
            _addressEntry.Text = company.Address;
        }
    }
}