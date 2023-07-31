using OsoulSunna.Data;

namespace OsoulSunna
{
    public partial class App : Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                database ??= new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalOsoul.db3"));
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}