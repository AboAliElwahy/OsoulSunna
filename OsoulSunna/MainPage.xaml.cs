using OsoulSunna.Data;
using OsoulSunna.Models;
using OsoulSunna.Views;
using System.Collections.ObjectModel;
using System.Reflection;

namespace OsoulSunna
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<LocalBook> LocalBooks { get; set; } = new ObservableCollection<LocalBook>();
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnCounterClicked(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new DetailsPage());
        }

    }
}