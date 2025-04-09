using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp
{
    public class Task
    {
        [Key]
        public int idTasks { get; set; }

        [StringLength(127)]
        public string titre { get; set; }

        public string description { get; set; }

        public DateTime dateCreation { get; set; } = DateTime.Now;

        public DateTime echeance { get; set; }

        [StringLength(10)]
        public string statut { get; set; } // Enum: 'a faire', 'en cours', 'terminee', 'annulee'

        [StringLength(10)]
        public string priorite { get; set; } // Enum: 'basse', 'moyenne', 'haute', 'critique'

        public int? auteur { get; set; }

        public int? realisateur { get; set; }

        [StringLength(255)]
        public string categorie { get; set; }

        [StringLength(255)]
        public string tags { get; set; }
    }
}