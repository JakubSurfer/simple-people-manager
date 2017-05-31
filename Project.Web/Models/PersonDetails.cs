using System;
using System.ComponentModel.DataAnnotations;

namespace Project.Web.Models
{
    public enum Sex
    {
        M,
        W
    }

    public enum MartialStatus
    {
        Single,
        Married,
        Divorced
    }

    public class PersonDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Secondname { get; set; }
        public Sex Sex { get; set; }
        public MartialStatus MartialStatus { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
