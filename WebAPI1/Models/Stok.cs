namespace WebAPI1.Models
{
    public class Stok
    {
        public int Id { get; set; }
        public string? StokKodu { get; set; }
        public string? StokName { get; set; }
        public double? StokFiyat { get; set; }
        public string? StokKur { get; set; }
        public double? StokMiktar { get; set; }
        public string? StokAnaGrup { get; set; }
        public string? SektorKodu { get; set; }
        public string? StokBirim { get; set; }
        public string? StokBirim2 { get; set; }
        public string? StokBirim3 { get; set; }
        public double? stokBirim3KatSayi { get; set; }
        public string? StokReyon { get; set; }
        public string? StokMarka { get; set; }
        public string? StokModel { get; set; }
        public int? KacVeri { get; set; }

    }
}
