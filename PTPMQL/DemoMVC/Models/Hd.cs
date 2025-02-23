using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models;

public class HoaDon

    {
        public double SoLuong { get; set; }
        public double DonGia { get; set; }

        public double ThanhTien()
        {
            return (SoLuong * DonGia);
        }
    }