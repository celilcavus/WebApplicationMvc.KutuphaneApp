using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KT.Entity.View
{
    public class KitapView
    {
        public int Id { get; set; }

        public string KitapAdi { get; set; }
        public string YazarAd { get; set; }
        public string TurAdi { get; set; }
        public float SayfaSayisi { get; set; }
        public byte Puan { get; set; }
    }
}
