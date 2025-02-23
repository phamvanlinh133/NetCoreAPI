using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class BMI

    {
        public double Weight { get; set; }
        public double Height { get; set; }

        public double CalculateBMI()
        {
            if (Height > 0)
                return Weight / (Height * Height);
            return 0;
        }

        public string GetBMICategory()
        {
            double bmi = CalculateBMI();
            if (bmi < 18.5) return "Gầy";
            else if (bmi < 24.9) return "Bình thường";
            else if (bmi < 29.9) return "Thừa cân";
            else return "Béo phì";
        }
    }