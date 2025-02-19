using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicationReminderApp.Models
{
    public class MedicationHistory
    {
        public int Id { get; set; }
        public int MedicationId { get; set; }
        public DateTime TakenTime { get; set; }
        public bool Taken { get; set; }
    }
}
