using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo3_1.Models
{
    public class Middag
    {
        [Required]
        public string Namn { get; set; }
        [Required]
        public int AntalPotioner { get; set; }

        public string Betyg { get; set; }

        [Display (Name = "Vetemjöl (dl)")]
        public int Vetemjol { get; set; }

        [Display(Name = "Antal ägg")]
        public int Agg { get; set; }

        [Display(Name = "Salt (kryddmått, krm)")]
        public int Salt { get; set; }

        [Display(Name = "Mjölk (dl)")]
        public int Mjolk { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        public Middag()
        {
            Vetemjol = 1;
            Agg = 1;
            Mjolk = 2;
            Salt = 1;
            Namn = "";
        }

        public void Berakna()
        {
            Vetemjol = Vetemjol * AntalPotioner;
            Agg = Agg * AntalPotioner;
            Mjolk = Mjolk * AntalPotioner;
            Salt = Salt * AntalPotioner;
        }
    }
}
