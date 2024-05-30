namespace AMaRMS
{
    public partial class App : Application
    {
        private static DB database;
        public static DB Database
        {
            get
            {
                if (database == null)
                {
                    database = new DB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Maintenance.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }
    }
}
