using System;
using System.IO;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {

        public static string selectedActive = "";
        public static int selectedItem = 1;
        public NoteEntryPage()
        {
            InitializeComponent();
            //pickerActive.SelectedItem = //"Capuchin Monkey";
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (User_Access)BindingContext;
            //note.Date = DateTime.UtcNow;
            note.Comments = selectedActive;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (User_Access)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }

        void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var oldText = e.OldTextValue;
            var newText = e.NewTextValue;
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                //selectedActive = (string)picker.ItemsSource[selectedIndex];
                //steveLable.Text = (string)picker.ItemsSource[selectedIndex];
            }
        }

    }
}