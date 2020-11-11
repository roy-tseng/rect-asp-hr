namespace infolink.rect_asp_hr.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.EntityFrameworkCore.Design;

    [Table("Employee")]
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id {get; set;}

        [Column("working_number")]
        public string workingNumber {get; set;}

        [Column("name")]
        public string name {get; set;}

        [Column("national_id")]
        public string nationalId {get; set;}

        [Column("gender")]
        public bool gender {get; set;}

        [Column("on_board_date")]
        public Nullable<DateTime> dateOnBoard {get; set;}

        [Column("on_board_birth")]
        public Nullable<DateTime> dateBirth {get; set;}       

        [Column("contact_address")]
        public string contactAddress {get; set;}

        [Column("mobile_phone")]
        public string mobilePhone {get; set;}
        
        [Column("home_phone")]
        public string homePhone {get; set;}

        [Column("avatar")]
        public string avatar { get; set; }
    }
}