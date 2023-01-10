using System;

namespace _01_KT.Entity.Entity
{
    public class Ogrenci
    {
        public int Id { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public string Cinsiyet { get; set; }
        public DateTime DogumTarih { get; set; }
        public string Sinif { get; set; }
        public byte Puan { get; set; }

    }
}
