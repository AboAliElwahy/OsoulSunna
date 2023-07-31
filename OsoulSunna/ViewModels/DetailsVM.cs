using OsoulSunna.Data;
using OsoulSunna.Models;
using System.Collections.ObjectModel;
using System.Reflection;

namespace OsoulSunna.ViewModels
{
    public class DetailsVM : BaseVM
    {
        List<LocalBook> AllLocalBooks;
        public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();
        public ObservableCollection<LocalBook> LocalBooks { get; set; } = new ObservableCollection<LocalBook>();

        public DetailsVM()
        {
            Get();
        }
        private async void Get()
        {
            AllLocalBooks = await App.Database.GetAllbooks();
            if (AllLocalBooks.Count > 0)
            {
                LocalBooks = new ObservableCollection<LocalBook>(AllLocalBooks);
                OnPropertyChanged(nameof(LocalBooks));
            }
            else
            {
                var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;

                using (Stream stream = assembly.GetManifestResourceStream("OsoulSunna.Data.Osoul.db"))
                {
                    using MemoryStream memoryStream = new();
                    stream.CopyTo(memoryStream);
                    File.WriteAllBytes(DataRepository.DbPath, memoryStream.ToArray());
                }
                DataRepository dataRepository = new();
                foreach (Book AllBooks in dataRepository.GetAllBooks())
                {
                    Books.Add(AllBooks);
                }
                foreach (var localBook in Books)
                {
                    await App.Database.AddNew(new LocalBook
                    {
                        BookTitle = localBook.BookTitle,
                        Content1 = localBook.Content1,
                        Content2 = localBook.Content2,
                        Content3 = localBook.Content3,
                        Content4 = localBook.Content4,
                        Content5 = localBook.Content5,
                        Head = localBook.Head,
                        PageNo = localBook.PageNo,
                        Source1 = localBook.Source1,
                        Source2 = localBook.Source2,
                        Source3 = localBook.Source3,
                        Source4 = localBook.Source4,
                        Source5 = localBook.Source5,
                    });
                }
                _ = Application.Current.MainPage.DisplayAlert("", "تم اضافة الكتب\n اغلق الصفخة وافتحها مرة اخرى", "OK");
            }
        }
    }
}