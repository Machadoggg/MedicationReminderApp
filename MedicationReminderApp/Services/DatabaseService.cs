using MedicationReminderApp.Models;
using SQLite;

namespace MedicationReminderApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Medication>().Wait();
            _database.CreateTableAsync<MedicationHistory>().Wait();
        }

        public Task<List<Medication>> GetMedicationsAsync()
        {
            return _database.Table<Medication>().ToListAsync();
        }

        public Task<int> SaveMedicationAsync(Medication medication)
        {
            return medication.Id == 0 ? _database.InsertAsync(medication) : _database.UpdateAsync(medication);
        }

        public Task<int> DeleteMedicationAsync(Medication medication)
        {
            return _database.DeleteAsync(medication);
        }

        public Task<List<MedicationHistory>> GetMedicationHistoryAsync(int medicationId)
        {
            return _database.Table<MedicationHistory>().Where(h => h.MedicationId == medicationId).ToListAsync();
        }

        public Task<int> SaveMedicationHistoryAsync(MedicationHistory history)
        {
            return history.Id == 0 ? _database.InsertAsync(history) : _database.UpdateAsync(history);
        }
    }
}
