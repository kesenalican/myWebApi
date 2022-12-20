
namespace WebAPI1.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CariPersonelTanimlari
    {
        [JsonProperty("cari_per_DBCno")]
        public long CariPerDbCno { get; set; } = 0;

        [JsonProperty("cari_per_SpecRECno")]
        public long CariPerSpecReCno { get; set; } = 0;

        [JsonProperty("cari_per_iptal")]
        public bool CariPerIptal { get; set; } = false;

        [JsonProperty("cari_per_fileid")]
        public long CariPerFileid { get; set; } =104;

        [JsonProperty("cari_per_hidden")]
        public bool CariPerHidden { get; set; } = false;

        [JsonProperty("cari_per_kilitli")]
        public bool CariPerKilitli { get; set; } = false;

        [JsonProperty("cari_per_degisti")]
        public bool CariPerDegisti { get; set; } = false;

        [JsonProperty("cari_per_checksum")]
        public long CariPerChecksum { get; set; } = 0;

        [JsonProperty("cari_per_create_user")]
        public long CariPerCreateUser { get; set; } // USERI BASTIRACAĞIM.

        [JsonProperty("cari_per_create_date")]
        public DateTimeOffset CariPerCreateDate { get; set; } = DateTime.Now;

        [JsonProperty("cari_per_lastup_user")]
        public long CariPerLastupUser { get; set; } // USERI BASTIR

        [JsonProperty("cari_per_lastup_date")]
        public DateTimeOffset CariPerLastupDate { get; set; } = DateTime.Now;

        [JsonProperty("cari_per_special1")]
        public string CariPerSpecial1 { get; set; } = string.Empty;

        [JsonProperty("cari_per_special2")]
        public string CariPerSpecial2 { get; set; } = string.Empty;

        [JsonProperty("cari_per_special3")]
        public string CariPerSpecial3 { get; set; } = string.Empty;

        [JsonProperty("cari_per_kod")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string CariPerKod { get; set; } // SATICI KODU	

        [JsonProperty("cari_per_adi")]
        //JsonConverter(typeof(ParseStringConverter))]
        public string CariPerAdi { get; set; } = string.Empty;// PERSONEL ADI

        [JsonProperty("cari_per_soyadi")]
        public string CariPerSoyadi { get; set; } = string.Empty;

        [JsonProperty("cari_per_tip")]
        public long CariPerTip { get; set; } = 0;//	0:Satıcı Eleman 1:Satın Almacı 2:Diğer Eleman

        [JsonProperty("cari_per_doviz_cinsi")]
        public long CariPerDovizCinsi { get; set; } = 0;

        [JsonProperty("cari_per_muhkod0")]
        public string CariPerMuhkod0 { get; set; } = string.Empty;

        [JsonProperty("cari_per_muhkod1")]
        public string CariPerMuhkod1 { get; set; } = string.Empty;

        [JsonProperty("cari_per_muhkod2")]
        public string CariPerMuhkod2 { get; set; } = string.Empty;

        [JsonProperty("cari_per_muhkod3")]
        public string CariPerMuhkod3 { get; set; } = string.Empty;

        [JsonProperty("cari_per_muhkod4")]
        public string CariPerMuhkod4 { get; set; } = string.Empty;

        [JsonProperty("cari_per_banka_tcmb_kod")]
        public string CariPerBankaTcmbKod { get; set; } = string.Empty;

        [JsonProperty("cari_per_banka_tcmb_subekod")]
        public string CariPerBankaTcmbSubekod { get; set; } = string.Empty;

        [JsonProperty("cari_per_banka_tcmb_ilkod")]
        public string CariPerBankaTcmbIlkod { get; set; } = string.Empty;

        [JsonProperty("cari_per_banka_hesapno")]
        public string CariPerBankaHesapno { get; set; } = string.Empty;

        [JsonProperty("cari_per_banka_swiftkodu")]
        public string CariPerBankaSwiftkodu { get; set; } = string.Empty;

        [JsonProperty("cari_per_prim_adet")]
        public long CariPerPrimAdet { get; set; } = 0;

        [JsonProperty("cari_per_prim_yuzde")]
        public long CariPerPrimYuzde { get; set; } = 0;

        [JsonProperty("cari_per_prim_carpani")]
        public long CariPerPrimCarpani { get; set; } = 0;

        [JsonProperty("cari_per_basmprimcirotav1")]
        public long CariPerBasmprimcirotav1 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimyuz1")]
        public long CariPerBasmprimyuz1 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimcirotav2")]
        public long CariPerBasmprimcirotav2 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimyuz2")]
        public long CariPerBasmprimyuz2 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimcirotav3")]
        public long CariPerBasmprimcirotav3 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimyuz3")]
        public long CariPerBasmprimyuz3 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimcirotav4")]
        public long CariPerBasmprimcirotav4 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimyuz4")]
        public long CariPerBasmprimyuz4 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimcirotav5")]
        public long CariPerBasmprimcirotav5 { get; set; } = 0;

        [JsonProperty("cari_per_basmprimyuz5")]
        public long CariPerBasmprimyuz5 { get; set; } = 0;

        [JsonProperty("cari_per_kasiyerkodu")]
        //[JsonConverter(typeof(ParseStringConverter))]
        public string CariPerKasiyerkodu { get; set; } // SATICI KODUNU GÖNDER

        [JsonProperty("cari_per_kasiyersifresi")]
        public string CariPerKasiyersifresi { get; set; } = string.Empty;

        [JsonProperty("cari_per_kasiyerAmiri")]
        public string CariPerKasiyerAmiri { get; set; } = string.Empty;

        [JsonProperty("cari_per_userno")]
        public long CariPerUserno { get; set; } = 0;

        [JsonProperty("cari_per_depono")]
        public long CariPerDepono { get; set; } = 0; //MERKEZ Mİ GENEL Mİ DEPO SEÇTİR.

        [JsonProperty("cari_per_cepno")]
        public string CariPerCepno { get; set; } = string.Empty; // cep telefonu yazdırabilirsin.

        [JsonProperty("cari_per_mail")]
        public string CariPerMail { get; set; } = string.Empty; // mail girişi

        [JsonProperty("cari_takvim_kodu")]
        public string CariTakvimKodu { get; set; } = string.Empty;

        [JsonProperty("cari_per_kasiyerfirmaid")]
        public string CariPerKasiyerfirmaid { get; set; } = string.Empty;

        [JsonProperty("cari_per_KEP_adresi")]
        public string CariPerKepAdresi { get; set; } = string.Empty;

        [JsonProperty("cari_per_TcKimlikNo")]
        public string CariPerTcKimlikNo { get; set; } = string.Empty;
    }

    public partial class CariPersonelTanimlari
    {
        public static CariPersonelTanimlari FromJson(string json) => JsonConvert.DeserializeObject<CariPersonelTanimlari>(json, WebAPI1.Models.Converter.Settings);
    }
}
