using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp
{
    public class SousTache
    {
        [Key]
        public int idSubTask { get; set; }

        public int idTask { get; set; }

        [StringLength(127)]
        public string titre { get; set; }

        [StringLength(10)]
        public string status { get; set; } // Enum: 'a faire', 'en cours', 'terminee', 'annulee'

        public DateTime? echeance { get; set; }
    }
}