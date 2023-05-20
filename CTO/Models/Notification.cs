using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTO.Models
{
    public class Notification
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mileage { get; set; } //пробег
        public string Icon { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
