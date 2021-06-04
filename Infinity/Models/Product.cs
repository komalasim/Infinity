using System.ComponentModel.DataAnnotations;

namespace Infinity.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Image { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Model { get; set; }
        public int Cost { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Brand { get; set; }
        public bool Desktop { get; set; }
        public bool TwoInOne { get; set; }
        public bool Touch { get; set; }
        public bool Laptop { get; set; }
        public bool Gaming { get; set; }
        public bool Workstation { get; set; }
        public int Core { get; set; }
        public int Generation { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Processor{ get; set; }
        public float Size { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Resolution { get; set; }
        public float Length { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public int RAM { get; set; }
        public bool DriveType { get; set; }
        public int DiskSpace { get; set; }
        public int USBA { get; set; }
        public int USBC { get; set; }
        public int Ethernet { get; set; }
        public int HDMI { get; set; }
        public int VGA { get; set; }
        public bool AudioJack { get; set; }
        public bool DVDPlayer { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Feature { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Software { get; set; }
    }
}