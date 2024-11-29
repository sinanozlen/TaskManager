using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    //Property'ler bunlar database elemanlaridir
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Prsname { get; set; }

        public string Task { get; set; }

        // Yeni eklenen alanlar
        public string? Description { get; set; }

        public DateTime? Date { get; set; }
    }
}