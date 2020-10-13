using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboration1.Models
{
    public class Workoutplanner
    {
        [Required(ErrorMessage = "Name must be specified")]
        public string Name { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Distance in kilometer must be specified")]
        [Display (Name = "Distance in kilometer")]
        public int Distance { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Pace in minutes per kilometer must be specified")]
        [Display (Name = "Pace (min/km) ")]
        public int Tempo { get; set; }

        [Display (Name = "Minutes of warmup")]
        public double Warmup { get; set; }
        [Display (Name = "Minutes of stretching")]

        public double Stretching { get; set; }

        public string Rating { get; set; }

        [Display (Name = "Total workout time in minutes")]
        public double TotalTime { get; set; }

        public Workoutplanner()
        {
            Warmup = 1;
            Stretching = 1;
            Name = "";
        }

        public void Calculate()
        {
            Warmup = Warmup * (Distance * 0.1) * Tempo + 5;
            Stretching = Stretching * (Distance * 0.05) * Tempo + 3;
            TotalTime = Distance * Tempo + Warmup + Stretching;
        }   
    }
}
