using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Dmh

    {
        public double DiemA { get; set; }
        public double DiemB { get; set; }
        public double DiemC { get; set; }
        public double Dtb()
        {
        return (DiemA*0.6 + DiemB*0.3 + DiemC*0.1);
        }
    }