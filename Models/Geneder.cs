namespace infolink.rect_asp_hr.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Gender")]
    public class Geneder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id {get; set;}

        [Column("type")]
        public string Type {get; set;}
    }

}