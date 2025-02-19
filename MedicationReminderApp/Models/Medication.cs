using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationReminderApp.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Dosage { get; set; } = default!;
        public TimeSpan Time { get; set; }
        public bool[] DaysOfWeek { get; set; } = new bool[7]; // Monday to Sunday
    }
}
