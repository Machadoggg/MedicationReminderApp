namespace MedicationReminderApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //// Manejo de excepciones no controladas
            //AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            //{
            //    Exception ex = (Exception)args.ExceptionObject;
            //    Console.WriteLine($"Excepción no controlada: {ex}");
            //};

            MainPage = new AppShell();

            
        }
    }
}
