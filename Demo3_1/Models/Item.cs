using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo3_1.Models
{
    public class Item
    {
        [Required]
        [Display(Name ="Löpnummer")]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Namn")]
        public string Name { get; set; }

        public Item()
        {
            Id = 1;
            Name = "Test Testsson";
        }

    }
}
