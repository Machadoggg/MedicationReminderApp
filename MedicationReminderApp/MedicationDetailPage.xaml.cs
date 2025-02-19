using MedicationReminderApp.Models;
using MedicationReminderApp.Services;

namespace MedicationReminderApp;

public partial class MedicationDetailPage : ContentPage
{
    private Medication _medication;
    private DatabaseService _databaseService;

    public MedicationDetailPage(Medication medication, DatabaseService databaseService)
    {
        //InitializeComponent();
        _medication = medication;
        _databaseService = databaseService;
        BindingContext = _medication;
    }

    //private void InitializeComponent()
    //{
    //    throw new NotImplementedException();
    //}

    private async void OnMarkAsTakenClicked(object sender, EventArgs e)
    {
        var history = new MedicationHistory
        {
            MedicationId = _medication.Id,
            TakenTime = DateTime.Now,
            Taken = true
        };

        await _databaseService.SaveMedicationHistoryAsync(history);
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        await _databaseService.DeleteMedicationAsync(_medication);
        await Navigation.PopAsync();
    }
}