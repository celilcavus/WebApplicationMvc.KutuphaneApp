namespace _01_KT.Entity.Entity
{
    public class Kitap
    {
        public int Id { get; set; }
       
        public string KitapAdi { get; set; }
        public int YazaId { get; set; }
        public int TurId { get; set; }
        public float SayfaSayisi { get; set; }
        public byte Puan { get; set; }
    }
}
