using System;

namespace _01_KT.Entity.Entity
{
    public class Islem
    {
        public int Id { get; set; }
        public string OgrenciId { get; set; }
        public string kitapId { get; set; }
        public DateTime ATarih { get; set; } // Alış Tarihi
        public DateTime VTarih { get; set; } // Veriliş/Teslim Tarih
    }
}
