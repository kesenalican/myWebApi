

namespace WebAPI1.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Siparis
    {
      

        [JsonProperty("sip_DBCno")]
        public long SipDbCno { get; set; } = 0;

        [JsonProperty("sip_SpecRECno")]
        public long SipSpecReCno { get; set; } = 0;

        [JsonProperty("sip_iptal")]
        public bool SipIptal { get; set; } = false;

        [JsonProperty("sip_fileid")]
        public long SipFileid { get; set; } = 21;

        [JsonProperty("sip_hidden")]
        public bool SipHidden { get; set; } = false;

        [JsonProperty("sip_kilitli")]
        public bool SipKilitli { get; set; } = false;

        [JsonProperty("sip_degisti")]
        public bool SipDegisti { get; set; } = false;

        [JsonProperty("sip_checksum")]
        public long SipChecksum { get; set; } = 0;

        [JsonProperty("sip_create_user")]
        public long SipCreateUser { get; set; } = 0;

        [JsonProperty("sip_create_date")]
        public DateTime SipCreateDate { get; set; } = DateTime.Now;

        [JsonProperty("sip_lastup_user")]
        public long SipLastupUser { get; set; } = 0;

        [JsonProperty("sip_lastup_date")] 
        public DateTime SipLastupDate { get; set; } = DateTime.Now;

        [JsonProperty("sip_special1")]
        public string SipSpecial1 { get; set; } = string.Empty;

        [JsonProperty("sip_special2")]
        public string SipSpecial2 { get; set; } = string.Empty;

        [JsonProperty("sip_special3")]
        public string SipSpecial3 { get; set; } = string.Empty;

        [JsonProperty("sip_firmano")]
        public long SipFirmano { get; set; } = 0;

        [JsonProperty("sip_subeno")]
        public long SipSubeno { get; set; } = 0;

        [JsonProperty("sip_tarih")]
        public DateTime SipTarih { get; set; } = DateTime.Now;

        [JsonProperty("sip_teslim_tarih")]
        public DateTime SipTeslimTarih { get; set; } = DateTime.Now;

        [JsonProperty("sip_tip")]
        public long SipTip { get; set; } = 0; // 0 : Talep 1: Temin

        [JsonProperty("sip_cins")]
        public long SipCins { get; set; } = 0; //0:Normal Sipariş 1:Konsinye Sipariş 2:Proforma Sipariş 3:Dış Ticaret Siparişi 4:Fason Siparişi 5:Dahili Sarf Siparişi 6:Depolar Arası Sipariş 7:Satın Alma Talebi 8:Üretim Talebi 9:İş Emirleri

        [JsonProperty("sip_evrakno_seri")]
        public string SipEvraknoSeri { get; set; } = string.Empty;

        [JsonProperty("sip_evrakno_sira")]
        public long SipEvraknoSira { get; set; } = 0; // NE OLDUĞUNU ÖĞREN

        [JsonProperty("sip_satirno")]
        public long SipSatirno { get; set; } = 0; // NE OLDUĞUNU ÖĞREN

        [JsonProperty("sip_belgeno")]
        public string SipBelgeno { get; set; } = string.Empty;

        [JsonProperty("sip_belge_tarih")]
        public DateTime SipBelgeTarih { get; set; } = DateTime.Now;

        [JsonProperty("sip_satici_kod")]
        public string SipSaticiKod { get; set; } = string.Empty;

        [JsonProperty("sip_musteri_kod")]
        public string SipMusteriKod { get; set; }= string.Empty; //CARİ KODU

        [JsonProperty("sip_stok_kod")]
        public string SipStokKod { get; set; }=string.Empty; // STOK KODU

        [JsonProperty("sip_b_fiyat")]
        public double SipBFiyat { get; set; } = 0; // STOK FİYATI

        [JsonProperty("sip_miktar")]
        public long SipMiktar { get; set; } = 0; // STOK MİKTARI

        [JsonProperty("sip_birim_pntr")]
        public long SipBirimPntr { get; set; } = 1;

        [JsonProperty("sip_teslim_miktar")]
        public long SipTeslimMiktar { get; set; } = 0; //STOK MİKTARI

        [JsonProperty("sip_tutar")]
        public double SipTutar { get; set; } = 0; // SİPARİŞ TUTARI = STOK MİKTARI * STOK FİYATI

        [JsonProperty("sip_iskonto_1")]
        public long SiparislerSipIskonto1 { get; set; } = 0; // İSKONTO 1

        [JsonProperty("sip_iskonto_2")]
        public long SiparislerSipIskonto2 { get; set; } = 0; // İSKONTO 2

        [JsonProperty("sip_iskonto_3")]
        public long SiparislerSipIskonto3 { get; set; } = 0; // İSKONTO 3

        [JsonProperty("sip_iskonto_4")]
        public long SiparislerSipIskonto4 { get; set; } = 0; // İSKONTO 4

        [JsonProperty("sip_iskonto_5")]
        public long SiparislerSipIskonto5 { get; set; } = 0; // İSKONTO 5

        [JsonProperty("sip_iskonto_6")]
        public long SiparislerSipIskonto6 { get; set; } = 0; // İSKONTO 6

        [JsonProperty("sip_masraf_1")]
        public long SiparislerSipMasraf1 { get; set; } = 0; // MASRAF ???

        [JsonProperty("sip_masraf_2")]
        public long SiparislerSipMasraf2 { get; set; } = 0; // MASRAF ???

        [JsonProperty("sip_masraf_3")]
        public long SiparislerSipMasraf3 { get; set; } = 0; // MASRAF ???

        [JsonProperty("sip_masraf_4")]
        public long SiparislerSipMasraf4 { get; set; } = 0; // MASRAF ???

        [JsonProperty("sip_vergi_pntr")]
        public long SipVergiPntr { get; set; } = 0; // VERGİ BAĞLANTISI 1,2,3,4 ???? 

        [JsonProperty("sip_vergi")]
        public double SipVergi { get; set; } = 0; // SİPARİŞ VERGİ YANİ KDV %18 YADA %8

        [JsonProperty("sip_masvergi_pntr")]
        public long SipMasvergiPntr { get; set; } = 0;

        [JsonProperty("sip_masvergi")]
        public long SipMasvergi { get; set; } = 0;

        [JsonProperty("sip_opno")]
        public long SipOpno { get; set; } = 0;

        [JsonProperty("sip_aciklama")]
        public string SipAciklama { get; set; } = string.Empty;

        [JsonProperty("sip_aciklama2")]
        public string SipAciklama2 { get; set; } = string.Empty;

        [JsonProperty("sip_depono")]
        public long SipDepono { get; set; } = 0; // HANGİ DEPODAN ÇIKACAK YA DA GİRECEK -- DEPOLARDAN ÇEK

        [JsonProperty("sip_OnaylayanKulNo")]
        public long SipOnaylayanKulNo { get; set; } = 0; // ONAY GEREKİRSE

        [JsonProperty("sip_vergisiz_fl")]
        public bool SipVergisizFl { get; set; } = false;

        [JsonProperty("sip_kapat_fl")]
        public bool SipKapatFl { get; set; } = false;

        [JsonProperty("sip_promosyon_fl")]
        public bool SipPromosyonFl { get; set; } = false;

        [JsonProperty("sip_cari_sormerk")]
        public string SipCariSormerk { get; set; } = string.Empty;

        [JsonProperty("sip_stok_sormerk")]
        public string SipStokSormerk { get; set; } = string.Empty;

        [JsonProperty("sip_cari_grupno")]
        public long SipCariGrupno { get; set; } = 0; // Cari grubu varsa

        [JsonProperty("sip_doviz_cinsi")]
        public long SipDovizCinsi { get; set; } = 0; // TL 

        [JsonProperty("sip_doviz_kuru")]
        public long SipDovizKuru { get; set; }=1;

        [JsonProperty("sip_alt_doviz_kuru")]
        public double SipAltDovizKuru { get; set; } = 6.0827;

        [JsonProperty("sip_adresno")]
        public long SipAdresno { get; set; } = 1;

        [JsonProperty("sip_teslimturu")]
        public string SipTeslimturu { get; set; } = string.Empty;

        [JsonProperty("sip_cagrilabilir_fl")]
        public bool SipCagrilabilirFl { get; set; } = true;

        [JsonProperty("sip_prosip_uid")]
        public Guid SipProsipUid { get; set; } = Guid.NewGuid(); //00000000 - 0000 - 0000 - 0000 - 000000000000

        [JsonProperty("sip_iskonto1")]
        public long SipIskonto1 { get; set; } = 0;

        [JsonProperty("sip_iskonto2")]
        public long SipIskonto2 { get; set; } = 1;

        [JsonProperty("sip_iskonto3")]
        public long SipIskonto3 { get; set; } = 1;

        [JsonProperty("sip_iskonto4")]
        public long SipIskonto4 { get; set; } = 1;

        [JsonProperty("sip_iskonto5")]
        public long SipIskonto5 { get; set; } = 1;

        [JsonProperty("sip_iskonto6")]
        public long SipIskonto6 { get; set; } = 1;

        [JsonProperty("sip_masraf1")]
        public long SipMasraf1 { get; set; } = 1;

        [JsonProperty("sip_masraf2")]
        public long SipMasraf2 { get; set; } = 1;

        [JsonProperty("sip_masraf3")]
        public long SipMasraf3 { get; set; } = 1;

        [JsonProperty("sip_masraf4")]
        public long SipMasraf4 { get; set; } = 1;

        [JsonProperty("sip_isk1")]
        public bool SipIsk1 { get; set; } = false;

        [JsonProperty("sip_isk2")]
        public bool SipIsk2 { get; set; } = false;

        [JsonProperty("sip_isk3")]
        public bool SipIsk3 { get; set; } = false;

        [JsonProperty("sip_isk4")]
        public bool SipIsk4 { get; set; } = false;

        [JsonProperty("sip_isk5")]
        public bool SipIsk5 { get; set; } = false;

        [JsonProperty("sip_isk6")]
        public bool SipIsk6 { get; set; } = false;

        [JsonProperty("sip_mas1")]
        public bool SipMas1 { get; set; } = false;

        [JsonProperty("sip_mas2")]
        public bool SipMas2 { get; set; } = false;

        [JsonProperty("sip_mas3")]
        public bool SipMas3 { get; set; } = false;

        [JsonProperty("sip_mas4")]
        public bool SipMas4 { get; set; } = false;

        [JsonProperty("sip_Exp_Imp_Kodu")]
        public string SipExpImpKodu { get; set; } = string.Empty;

        [JsonProperty("sip_kar_orani")]
        public long SipKarOrani { get; set; } = 0;

        [JsonProperty("sip_durumu")]
        public long SipDurumu { get; set; } = 0;//0:Stoktan sevk edilecek 1:Üretilecek 2:Satın alınacak 3:Stoktan sevk edilecek

        [JsonProperty("sip_stal_uid")]
        public Guid SipStalUid { get; set; } = Guid.NewGuid();

        [JsonProperty("sip_planlananmiktar")]
        public long SipPlanlananmiktar { get; set; } = 0;

        [JsonProperty("sip_teklif_uid")]
        public Guid SipTeklifUid { get; set; } = Guid.NewGuid(); // FARKLI OLMASI LAZIM

        [JsonProperty("sip_parti_kodu")]
        public string SipPartiKodu { get; set; } = string.Empty;

        [JsonProperty("sip_lot_no")]
        public long SipLotNo { get; set; } = 0;

        [JsonProperty("sip_projekodu")]
        public string SipProjekodu { get; set; } = string.Empty;

        [JsonProperty("sip_fiyat_liste_no")]
        public long SipFiyatListeNo { get; set; } = 1;

        [JsonProperty("sip_Otv_Pntr")]
        public long SipOtvPntr { get; set; } = 0;

        [JsonProperty("sip_Otv_Vergi")]
        public long SipOtvVergi { get; set; } = 0;

        [JsonProperty("sip_otvtutari")]
        public long SipOtvtutari { get; set; } = 0;

        [JsonProperty("sip_OtvVergisiz_Fl")]
        public long SipOtvVergisizFl { get; set; } = 0;

        [JsonProperty("sip_paket_kod")]
        public string SipPaketKod { get; set; } = string.Empty;

        [JsonProperty("sip_Rez_uid")]
        public Guid SipRezUid { get; set; } = Guid.NewGuid();

        [JsonProperty("sip_harekettipi")]
        public long SipHarekettipi { get; set; } = 0;

        [JsonProperty("sip_yetkili_uid")]
        public Guid SipYetkiliUid { get; set; } = Guid.NewGuid();

        [JsonProperty("sip_kapatmanedenkod")]
        public string SipKapatmanedenkod { get; set; } = string.Empty;

        [JsonProperty("sip_gecerlilik_tarihi")]
        public DateTime SipGecerlilikTarihi { get; set; } = DateTime.Now;

        [JsonProperty("sip_onodeme_evrak_tip")]
        public long SipOnodemeEvrakTip { get; set; } = 0;

        [JsonProperty("sip_onodeme_evrak_seri")]
        public string SipOnodemeEvrakSeri { get; set; } = string.Empty;

        [JsonProperty("sip_onodeme_evrak_sira")]
        public long SipOnodemeEvrakSira { get; set; } = 0;

        [JsonProperty("sip_rezervasyon_miktari")]
        public long SipRezervasyonMiktari { get; set; } = 0;

        [JsonProperty("sip_rezerveden_teslim_edilen")]
        public long SipRezervedenTeslimEdilen { get; set; } = 0;

        [JsonProperty("sip_HareketGrupKodu1")]
        public string SipHareketGrupKodu1 { get; set; } = string.Empty;

        [JsonProperty("sip_HareketGrupKodu2")]
        public string SipHareketGrupKodu2 { get; set; } = string.Empty;

        [JsonProperty("sip_HareketGrupKodu3")]
        public string SipHareketGrupKodu3 { get; set; } = string.Empty;

        [JsonProperty("sip_Olcu1")]
        public long SipOlcu1 { get; set; } = 0;

        [JsonProperty("sip_Olcu2")]
        public long SipOlcu2 { get; set; } = 0;

        [JsonProperty("sip_Olcu3")]
        public long SipOlcu3 { get; set; } = 0;

        [JsonProperty("sip_Olcu4")]
        public long SipOlcu4 { get; set; } = 0;

        [JsonProperty("sip_Olcu5")]
        public long SipOlcu5 { get; set; } = 0;

        [JsonProperty("sip_FormulMiktarNo")]
        public long SipFormulMiktarNo { get; set; } = 0;

        [JsonProperty("sip_FormulMiktar")]
        public long SipFormulMiktar { get; set; } = 0;

        [JsonProperty("sip_satis_fiyat_doviz_cinsi")]
        public long SipSatisFiyatDovizCinsi { get; set; } = 0;

        [JsonProperty("sip_satis_fiyat_doviz_kuru")]
        public long SipSatisFiyatDovizKuru { get; set; } = 0;

        [JsonProperty("sip_eticaret_kanal_kodu")]
        public string SipEticaretKanalKodu { get; set; } = string.Empty;
    }

    public partial class Siparisler
    {
        public static Siparisler FromJson(string json) => JsonConvert.DeserializeObject<Siparisler>(json, WebAPI1.Models.Converter.Settings);
    }
}
