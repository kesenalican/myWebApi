

namespace WebAPI1.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using System.Net.Mail;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CariModel
    {
        static UserModel userModel;
       

    
        [JsonProperty("cari_SpecRECno")]
        public long CariSpecReCno { get; set; } = 0;

        [JsonProperty("cari_iptal")]
        public bool CariIptal { get; set; } = false;

        [JsonProperty("cari_fileid")]
        public long CariFileid { get; set; } = 31;

        [JsonProperty("cari_hidden")]
        public bool CariHidden { get; set; } = false;

        [JsonProperty("cari_kilitli")]
        public bool CariKilitli { get; set; } = false;

        [JsonProperty("cari_degisti")]
        public bool CariDegisti { get; set; }= false;

        [JsonProperty("cari_checksum")]
        public long CariChecksum { get; set; } = 0;

        [JsonProperty("cari_create_user")]
        public long CariCreateUser { get; set; } = 0;

        [JsonProperty("cari_create_date")]
        public DateTimeOffset CariCreateDate { get; set; } = DateTime.Now;

        [JsonProperty("cari_lastup_user")]
        public long CariLastupUser { get; set; } = 0;

        [JsonProperty("cari_lastup_date")]
        public DateTimeOffset CariLastupDate { get; set; } = DateTime.Now;

        [JsonProperty("cari_special1")]
        public string CariSpecial1 { get; set; } = string.Empty;

        [JsonProperty("cari_special2")]
        public string CariSpecial2 { get; set; } = string.Empty;

        [JsonProperty("cari_special3")]
        public string CariSpecial3 { get; set; } = string.Empty;

        [JsonProperty("cari_kod")]
        public string CariKod { get; set; } ="";

        [JsonProperty("cari_unvan1")]
        public string CariUnvan1 { get; set; } = string.Empty;

        [JsonProperty("cari_unvan2")]
        public string CariUnvan2 { get; set; } = string.Empty;

        [JsonProperty("cari_hareket_tipi")]
        public long CariHareketTipi { get; set; } = 0;

        [JsonProperty("cari_baglanti_tipi")]
        public long CariBaglantiTipi { get; set; } = 0;

        [JsonProperty("cari_stok_alim_cinsi")]
        public long CariStokAlimCinsi { get; set; } = 0;

        [JsonProperty("cari_stok_satim_cinsi")]
        public long CariStokSatimCinsi { get; set; } = 0;

        [JsonProperty("cari_muh_kod")]
        public string CariMuhKod { get; set; } = string.Empty;

        [JsonProperty("cari_muh_kod1")]
        public string CariMuhKod1 { get; set; } = string.Empty;

        [JsonProperty("cari_muh_kod2")]
        public string CariMuhKod2 { get; set; } = string.Empty;

        [JsonProperty("cari_doviz_cinsi")]
        public long CariDovizCinsi { get; set; } = 0;

        [JsonProperty("cari_doviz_cinsi1")]
        public long CariDovizCinsi1 { get; set; } = 255;

        [JsonProperty("cari_doviz_cinsi2")]
        public long CariDovizCinsi2 { get; set; } = 255;

        [JsonProperty("cari_vade_fark_yuz")]
        public long CariVadeFarkYuz { get; set; } = 0;

        [JsonProperty("cari_vade_fark_yuz1")]
        public long CariVadeFarkYuz1 { get; set; } = 0;

        [JsonProperty("cari_vade_fark_yuz2")]
        public long CariVadeFarkYuz2 { get; set; } = 0;

        [JsonProperty("cari_KurHesapSekli")]
        public long CariKurHesapSekli { get; set; } = 1;

        [JsonProperty("cari_vdaire_adi")]
        public string CariVdaireAdi { get; set; } = string.Empty;

        [JsonProperty("cari_vdaire_no")]
        public string CariVdaireNo { get; set; } = string.Empty;

        [JsonProperty("cari_sicil_no")]
        public string CariSicilNo { get; set; } = string.Empty;

        [JsonProperty("cari_VergiKimlikNo")]
        public string CariVergiKimlikNo { get; set; } = string.Empty;

        [JsonProperty("cari_satis_fk")]
        public long CariSatisFk { get; set; } = 0;

        [JsonProperty("cari_odeme_cinsi")]
        public long CariOdemeCinsi { get; set; } = 0;

        [JsonProperty("cari_odeme_gunu")]
        public long CariOdemeGunu { get; set; } = 0;

        [JsonProperty("cari_odemeplan_no")]
        public long CariOdemeplanNo { get; set; } = 0;

        [JsonProperty("cari_opsiyon_gun")]
        public long CariOpsiyonGun { get; set; } = 0;

        [JsonProperty("cari_cariodemetercihi")]
        public long CariCariodemetercihi { get; set; } = 0;

        [JsonProperty("cari_fatura_adres_no")]
        public long CariFaturaAdresNo { get; set; } = 0;

        [JsonProperty("cari_sevk_adres_no")]
        public long CariSevkAdresNo { get; set; } = 0;

        [JsonProperty("cari_banka_tcmb_kod1")]
        public string CariBankaTcmbKod1 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod1")]
        public string CariBankaTcmbSubekod1 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod1")]
        public string CariBankaTcmbIlkod1 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno1")]
        public string CariBankaHesapno1 { get; set; }= string.Empty;

        [JsonProperty("cari_banka_swiftkodu1")]
        public string CariBankaSwiftkodu1 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod2")]
        public string CariBankaTcmbKod2 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod2")]
        public string CariBankaTcmbSubekod2 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod2")]
        public string CariBankaTcmbIlkod2 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno2")]
        public string CariBankaHesapno2 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu2")]
        public string CariBankaSwiftkodu2 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod3")]
        public string CariBankaTcmbKod3 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod3")]
        public string CariBankaTcmbSubekod3 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod3")]
        public string CariBankaTcmbIlkod3 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno3")]
        public string CariBankaHesapno3 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu3")]
        public string CariBankaSwiftkodu3 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod4")]
        public string CariBankaTcmbKod4 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod4")]
        public string CariBankaTcmbSubekod4 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod4")]
        public string CariBankaTcmbIlkod4 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno4")]
        public string CariBankaHesapno4 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu4")]
        public string CariBankaSwiftkodu4 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod5")]
        public string CariBankaTcmbKod5 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod5")]
        public string CariBankaTcmbSubekod5 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod5")]
        public string CariBankaTcmbIlkod5 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno5")]
        public string CariBankaHesapno5 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu5")]
        public string CariBankaSwiftkodu5 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod6")]
        public string CariBankaTcmbKod6 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod6")]
        public string CariBankaTcmbSubekod6 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod6")]
        public string CariBankaTcmbIlkod6 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno6")]
        public string CariBankaHesapno6 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu6")]
        public string CariBankaSwiftkodu6 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod7")]
        public string CariBankaTcmbKod7 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod7")]
        public string CariBankaTcmbSubekod7 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod7")]
        public string CariBankaTcmbIlkod7 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno7")]
        public string CariBankaHesapno7 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu7")]
        public string CariBankaSwiftkodu7 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod8")]
        public string CariBankaTcmbKod8 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod8")]
        public string CariBankaTcmbSubekod8 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod8")]
        public string CariBankaTcmbIlkod8 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno8")]
        public string CariBankaHesapno8 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu8")]
        public string CariBankaSwiftkodu8 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod9")]
        public string CariBankaTcmbKod9 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod9")]
        public string CariBankaTcmbSubekod9 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod9")]
        public string CariBankaTcmbIlkod9 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno9")]
        public string CariBankaHesapno9 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu9")]
        public string CariBankaSwiftkodu9 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_kod10")]
        public string CariBankaTcmbKod10 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_subekod10")]
        public string CariBankaTcmbSubekod10 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_tcmb_ilkod10")]
        public string CariBankaTcmbIlkod10 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_hesapno10")]
        public string CariBankaHesapno10 { get; set; } = string.Empty;

        [JsonProperty("cari_banka_swiftkodu10")]
        public string CariBankaSwiftkodu10 { get; set; } = string.Empty;

        [JsonProperty("cari_EftHesapNum")]
        public long CariEftHesapNum { get; set; } = 1;

        [JsonProperty("cari_Ana_cari_kodu")]
        public string CariAnaCariKodu { get; set; } = string.Empty;

        [JsonProperty("cari_satis_isk_kod")]
        public string CariSatisIskKod { get; set; } = string.Empty;

        [JsonProperty("cari_sektor_kodu")]
        public string CariSektorKodu { get; set; } = string.Empty;

        [JsonProperty("cari_bolge_kodu")]
        public string CariBolgeKodu { get; set; } = string.Empty;

        [JsonProperty("cari_grup_kodu")]
        public string CariGrupKodu { get; set; } = string.Empty;

        [JsonProperty("cari_temsilci_kodu")]
        public string CariTemsilciKodu { get; set; } = string.Empty;

        [JsonProperty("cari_muhartikeli")]
        public string CariMuhartikeli { get; set; } = string.Empty;

        [JsonProperty("cari_firma_acik_kapal")]
        public bool CariFirmaAcikKapal { get; set; } = false;

        [JsonProperty("cari_BUV_tabi_fl")]
        public bool CariBuvTabiFl { get; set; }=false;

        [JsonProperty("cari_cari_kilitli_flg")]
        public bool CariCariKilitliFlg { get; set; } =  false;

        [JsonProperty("cari_etiket_bas_fl")]
        public bool CariEtiketBasFl { get; set; }=  false;

        [JsonProperty("cari_Detay_incele_flg")]
        public bool CariDetayInceleFlg { get; set; }=  false;

        [JsonProperty("cari_efatura_fl")]
        public bool CariEfaturaFl { get; set; } =false;

        [JsonProperty("cari_POS_ongpesyuzde")]
        public long CariPosOngpesyuzde { get; set; } = 0;

        [JsonProperty("cari_POS_ongtaksayi")]
        public long CariPosOngtaksayi { get; set; }=0;

        [JsonProperty("cari_POS_ongIskOran")]
        public long CariPosOngIskOran { get; set; } = 0;

        [JsonProperty("cari_kaydagiristarihi")]
        public DateTimeOffset CariKaydagiristarihi { get; set; } = DateTime.Now;

        [JsonProperty("cari_KabEdFCekTutar")]
        public long CariKabEdFCekTutar { get; set; } = 0;

        [JsonProperty("cari_hal_caritip")]
        public long CariHalCaritip { get; set; } = 0;

        [JsonProperty("cari_HalKomYuzdesi")]
        public long CariHalKomYuzdesi { get; set; } = 0;

        [JsonProperty("cari_TeslimSuresi")]
        public long CariTeslimSuresi { get; set; } = 0;

        [JsonProperty("cari_wwwadresi")]
        public string CariWwwadresi { get; set; } = string.Empty;

        [JsonProperty("cari_EMail")]
        public string CariEMail { get; set; } = string.Empty;

        [JsonProperty("cari_CepTel")]
        public string CariCepTel { get; set; } = string.Empty;

        [JsonProperty("cari_VarsayilanGirisDepo")]
        public long CariVarsayilanGirisDepo { get; set; } = 0;

        [JsonProperty("cari_VarsayilanCikisDepo")]
        public long CariVarsayilanCikisDepo { get; set; } = 0;

        [JsonProperty("cari_Portal_Enabled")]
        public bool CariPortalEnabled { get; set; } = false;

        [JsonProperty("cari_Portal_PW")]
        public string CariPortalPw { get; set; } = string.Empty;

        [JsonProperty("cari_BagliOrtaklisa_Firma")]
        public long CariBagliOrtaklisaFirma { get; set; } = 0;

        [JsonProperty("cari_kampanyakodu")]
        public string CariKampanyakodu { get; set; } = string.Empty;

        [JsonProperty("cari_b_bakiye_degerlendirilmesin_fl")]
        public bool CariBBakiyeDegerlendirilmesinFl { get; set; } = false;

        [JsonProperty("cari_a_bakiye_degerlendirilmesin_fl")]
        public bool CariABakiyeDegerlendirilmesinFl { get; set; } = false;

        [JsonProperty("cari_b_irsbakiye_degerlendirilmesin_fl")]
        public bool CariBIrsbakiyeDegerlendirilmesinFl { get; set; } = false;

        [JsonProperty("cari_a_irsbakiye_degerlendirilmesin_fl")]
        public bool CariAIrsbakiyeDegerlendirilmesinFl { get; set; } = false;

        [JsonProperty("cari_b_sipbakiye_degerlendirilmesin_fl")]
        public bool CariBSipbakiyeDegerlendirilmesinFl { get; set; } = false;

        [JsonProperty("cari_a_sipbakiye_degerlendirilmesin_fl")]
        public bool CariASipbakiyeDegerlendirilmesinFl { get; set; } = false;

        [JsonProperty("cari_KrediRiskTakibiVar_flg")]
        public bool CariKrediRiskTakibiVarFlg { get; set; } = true;

        [JsonProperty("cari_ufrs_fark_muh_kod")]
        public string CariUfrsFarkMuhKod { get; set; } = string.Empty;

        [JsonProperty("cari_ufrs_fark_muh_kod1")]
        public string CariUfrsFarkMuhKod1 { get; set; } = string.Empty;

        [JsonProperty("cari_ufrs_fark_muh_kod2")]
        public string CariUfrsFarkMuhKod2 { get; set; } = string.Empty;

        [JsonProperty("cari_odeme_sekli")]
        public long CariOdemeSekli { get; set; } = 0; // 0: Vadeye Göre 1: Satış Üzerinden

        [JsonProperty("cari_TeminatMekAlacakMuhKodu")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CariTeminatMekAlacakMuhKodu { get; set; } = 910; // 910 kodu public mi yoksa mutable mı öğren!

        [JsonProperty("cari_TeminatMekAlacakMuhKodu1")]
        public string CariTeminatMekAlacakMuhKodu1 { get; set; } = string.Empty;

        [JsonProperty("cari_TeminatMekAlacakMuhKodu2")]
        public string CariTeminatMekAlacakMuhKodu2 { get; set; } = string.Empty;

        [JsonProperty("cari_TeminatMekBorcMuhKodu")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CariTeminatMekBorcMuhKodu { get; set; } = 912;

        [JsonProperty("cari_TeminatMekBorcMuhKodu1")]
        public string CariTeminatMekBorcMuhKodu1 { get; set; } = string.Empty;

        [JsonProperty("cari_TeminatMekBorcMuhKodu2")]
        public string CariTeminatMekBorcMuhKodu2 { get; set; } = string.Empty;

        [JsonProperty("cari_VerilenDepozitoTeminatMuhKodu")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CariVerilenDepozitoTeminatMuhKodu { get; set; } = 226;

        [JsonProperty("cari_VerilenDepozitoTeminatMuhKodu1")]
        public string CariVerilenDepozitoTeminatMuhKodu1 { get; set; } = string.Empty;

        [JsonProperty("cari_VerilenDepozitoTeminatMuhKodu2")]
        public string CariVerilenDepozitoTeminatMuhKodu2 { get; set; } = string.Empty;

        [JsonProperty("cari_AlinanDepozitoTeminatMuhKodu")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CariAlinanDepozitoTeminatMuhKodu { get; set; } = 326;

        [JsonProperty("cari_AlinanDepozitoTeminatMuhKodu1")]
        public string CariAlinanDepozitoTeminatMuhKodu1 { get; set; } = string.Empty;

        [JsonProperty("cari_AlinanDepozitoTeminatMuhKodu2")]
        public string CariAlinanDepozitoTeminatMuhKodu2 { get; set; } = string.Empty;

        [JsonProperty("cari_def_efatura_cinsi")]
        public long CariDefEfaturaCinsi { get; set; } = 0; // 0: Temel Fatura 1: Ticari Fatura 2: Yolcu Beraberinde Fatura 3:İhracat

        [JsonProperty("cari_otv_tevkifatina_tabii_fl")]
        public bool CariOtvTevkifatinaTabiiFl { get; set; }=false;

        [JsonProperty("cari_KEP_adresi")]
        public string CariKepAdresi { get; set; } = string.Empty;

        [JsonProperty("cari_efatura_baslangic_tarihi")]
        public DateTimeOffset CariEfaturaBaslangicTarihi { get; set; } = DateTimeOffset.Now; // E-Fatura başlangıç tarihini öğrenmek lazım.

        [JsonProperty("cari_mutabakat_mail_adresi")]
        public string CariMutabakatMailAdresi { get; set; } = string.Empty;

        [JsonProperty("cari_mersis_no")]
        public string CariMersisNo { get; set; } = string.Empty;

        [JsonProperty("cari_istasyon_cari_kodu")]
        public string CariIstasyonCariKodu { get; set; } = string.Empty;

        [JsonProperty("cari_gonderionayi_sms")]
        public bool CariGonderionayiSms { get; set; } = false; // SMS GÖNDERİLSİN Mİ CHECKBOX 

        [JsonProperty("cari_gonderionayi_email")]
        public bool CariGonderionayiEmail { get; set; } = false; // SMS GÖNDERİLSİN Mİ CHECKBOX

        [JsonProperty("cari_eirsaliye_fl")]
        public bool CariEirsaliyeFl { get; set; } =false; // E-İrsaliyemi??

        [JsonProperty("cari_eirsaliye_baslangic_tarihi")]
        public DateTimeOffset CariEirsaliyeBaslangicTarihi { get; set; }=DateTime.Now; // E-irsaliye başlangıç tarihi

        [JsonProperty("cari_vergidairekodu")]
        public string CariVergidairekodu { get; set; }=string.Empty;

        [JsonProperty("cari_CRM_sistemine_aktar_fl")]
        public bool CariCrmSistemineAktarFl { get; set; } = false;

        [JsonProperty("cari_efatura_xslt_dosya")]
        public string CariEfaturaXsltDosya { get; set; } = string.Empty;

        [JsonProperty("cari_pasaport_no")]
        public string CariPasaportNo { get; set; } = string.Empty;

        [JsonProperty("cari_kisi_kimlik_bilgisi_aciklama_turu")]
        public long CariKisiKimlikBilgisiAciklamaTuru { get; set; } = 0;

        [JsonProperty("cari_kisi_kimlik_bilgisi_diger_aciklama")]
        public string CariKisiKimlikBilgisiDigerAciklama { get; set; } = string.Empty;

        [JsonProperty("cari_uts_kurum_no")]
        public string CariUtsKurumNo { get; set; } = string.Empty;

        [JsonProperty("cari_kamu_kurumu_fl")]
        public bool CariKamuKurumuFl { get; set; } = false;

        [JsonProperty("cari_earsiv_xslt_dosya")]
        public string CariEarsivXsltDosya { get; set; } = string.Empty;

        [JsonProperty("cari_Perakende_fl")]
        public bool CariPerakendeFl { get; set; } = false;

        [JsonProperty("cari_yeni_dogan_mi")]
        public bool CariYeniDoganMi { get; set; } = false;

        [JsonProperty("cari_eirsaliye_xslt_dosya")]
        public string CariEirsaliyeXsltDosya { get; set; } = string.Empty;

        [JsonProperty("cari_def_eirsaliye_cinsi")]
        public long CariDefEirsaliyeCinsi { get; set; } = 0;

        [JsonProperty("cari_ozel_butceli_kurum_carisi")]
        public string CariOzelButceliKurumCarisi { get; set; } = string.Empty;

        [JsonProperty("cari_nakakincelenmesi")]
        public bool CariNakakincelenmesi { get; set; } = false;

        [JsonProperty("cari_vergimukellefidegil_mi")]
        public bool CariVergimukellefidegilMi { get; set; } = false;

        [JsonProperty("cari_tasiyicifirma_cari_kodu")]
        public string CariTasiyicifirmaCariKodu { get; set; } = string.Empty;

        [JsonProperty("cari_nacekodu_1")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CariNacekodu1 { get; set; } = 0;

        [JsonProperty("cari_nacekodu_2")]
        public string CariNacekodu2 { get; set; } = string.Empty;

        [JsonProperty("cari_nacekodu_3")]
        public string CariNacekodu3 { get; set; } = string.Empty;

        [JsonProperty("cari_sirket_turu")]
        public long CariSirketTuru { get; set; } = 0; // CARİ ŞİRKET TÜRÜ 9'a kadar var..!!

        [JsonProperty("cari_baba_adi")]
        public string CariBabaAdi { get; set; } = string.Empty;

        [JsonProperty("cari_faal_terk")]
        public long CariFaalTerk { get; set; } = 0;
    }

    public partial class CariModel
    {
        public static CariModel FromJson(string json) => JsonConvert.DeserializeObject<CariModel>(json, WebAPI1.Models.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CariModel self) => JsonConvert.SerializeObject(self, WebAPI1.Models.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
