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
    public class Addcompany : ContentPage
    {
        private Entry _nameEntry;
        private Entry _addressEntry;
        private Button _saveButton;

        string _dbPath = Path.Combine(System.Environment.GetFolderPath
            (System.Environment.SpecialFolder.Personal), "myDB.db3");
        public Addcompany()
        {
            this.Title = "Add ompany";
            StackLayout stackLayout = new StackLayout();

            _nameEntry = new Entry();
            _nameEntry.Keyboard = Keyboard.Text;
            _nameEntry.Placeholder = "Company name";
            stackLayout.Children.Add(_nameEntry);

            _addressEntry = new Entry();
            _addressEntry.Keyboard = Keyboard.Text;
            _addressEntry.Placeholder = "Company address";
            stackLayout.Children.Add(_addressEntry);


            _saveButton = new Button();
            _saveButton.Text = "add";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;

        }

        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(_dbPath);
            db.CreateTable<Company>();

            var maxPk = db.Table<Company>().OrderByDescending(c => c.Id).FirstOrDefault();

            Company company = new Company()
            {
                Id=(maxPk == null ? 1 : maxPk.Id +1),
                Name=_nameEntry.Text,
                Address=_addressEntry.Text

            };
            db.Insert(company);
            await DisplayAlert(null, company.Name + "saved", "Ok");
        }
    }
}