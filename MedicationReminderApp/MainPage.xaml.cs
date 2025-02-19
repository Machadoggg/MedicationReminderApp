using MedicationReminderApp.Models;
using MedicationReminderApp.Services;

namespace MedicationReminderApp
{
    public partial class MainPage : ContentPage
    {
        private DatabaseService _databaseService;
        //int count = 0;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "medications.db3"));
            LoadMedications();
        }

        private async void LoadMedications()
        {
            MedicationList.ItemsSource = await _databaseService.GetMedicationsAsync();
        }

        private async void OnAddMedicationClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMedicationPage(_databaseService));
        }

        private async void OnMedicationSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Medication medication)
            {
                await Navigation.PushAsync(new MedicationDetailPage(medication, _databaseService));
            }
        }

        //private void OnCounterClicked(object sender, EventArgs e)
        //{
        //    count++;

        //    if (count == 1)
        //        CounterBtn.Text = $"Clicked {count} time";
        //    else
        //        CounterBtn.Text = $"Clicked {count} times";

        //    SemanticScreenReader.Announce(CounterBtn.Text);
        //}
    }

}
