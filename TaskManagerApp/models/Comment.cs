using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp
{
    public class Comment
    {
        [Key]
        public int idComments { get; set; }

        public int idTask { get; set; }

        public int? idAuteur { get; set; }

        public DateTime date { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string contenu { get; set; }
    }
}