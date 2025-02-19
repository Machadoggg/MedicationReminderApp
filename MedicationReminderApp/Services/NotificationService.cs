using MedicationReminderApp.Models;
using Plugin.LocalNotification;

namespace MedicationReminderApp.Services
{
    public class NotificationService
    {
        public void ScheduleNotification(Medication medication)
        {
            foreach (var day in medication.DaysOfWeek)
            {
                if (day)
                {
                    var notification = new NotificationRequest
                    {
                        NotificationId = medication.Id,
                        Title = "Recordatorio de Medicamento",
                        Description = $"Es hora de tomar {medication.Name} - {medication.Dosage}",
                        Schedule = new NotificationRequestSchedule
                        {
                            NotifyTime = DateTime.Today.Add(medication.Time).AddDays((int)(day ? 1 : 0)),
                            RepeatType = NotificationRepeat.Daily
                        }
                    };

                    LocalNotificationCenter.Current.Show(notification);
                }
            }
        }

        public void CancelNotification(int medicationId)
        {
            LocalNotificationCenter.Current.Cancel(medicationId);
        }
    }
}
