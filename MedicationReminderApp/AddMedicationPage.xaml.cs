using MedicationReminderApp.Models;
using MedicationReminderApp.Services;

namespace MedicationReminderApp;

public partial class AddMedicationPage : ContentPage
{
    private DatabaseService _databaseService;

    public AddMedicationPage(DatabaseService databaseService)
    {
        InitializeComponent();
        _databaseService = databaseService;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        var medication = new Medication
        {
            Name = NameEntry.Text,
            Dosage = DosageEntry.Text,
            Time = TimePicker.Time
        };

        await _databaseService.SaveMedicationAsync(medication);
        await Navigation.PopAsync();
    }
}