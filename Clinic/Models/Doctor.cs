using System.ComponentModel.DataAnnotations;

public class Doctor {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
}
