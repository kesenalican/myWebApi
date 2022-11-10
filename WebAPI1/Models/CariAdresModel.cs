namespace WebAPI1.Models
    {
        using System;
        using System.Collections.Generic;

        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;

        public partial class CariAdresModel
        {
            [JsonProperty("adr_DBCno")]
            public long AdrDbCno { get; set; } = 0;

            [JsonProperty("adr_SpecRECno")]
            public long AdrSpecReCno { get; set; } = 0;

            [JsonProperty("adr_iptal")]
            public bool AdrIptal { get; set; } = false;

            [JsonProperty("adr_fileid")]
            public long AdrFileid { get; set; } = 32;

            [JsonProperty("adr_hidden")]
            public bool AdrHidden { get; set; } = false;

            [JsonProperty("adr_kilitli")]
            public bool AdrKilitli { get; set; } = false;

            [JsonProperty("adr_degisti")]
            public bool AdrDegisti { get; set; } = false;

            [JsonProperty("adr_checksum")]
            public long AdrChecksum { get; set; } = 0;

            [JsonProperty("adr_create_user")]
            public long AdrCreateUser { get; set; } = 0;

            [JsonProperty("adr_create_date")]
            public DateTimeOffset AdrCreateDate { get; set; } = DateTime.Now;

            [JsonProperty("adr_lastup_user")]
            public long AdrLastupUser { get; set; } = 0;

            [JsonProperty("adr_lastup_date")]
            public DateTimeOffset AdrLastupDate { get; set; } = DateTime.Now;

            [JsonProperty("adr_special1")]
            public string AdrSpecial1 { get; set; } = string.Empty;

            [JsonProperty("adr_special2")]
            public string AdrSpecial2 { get; set; } = string.Empty;

            [JsonProperty("adr_special3")]
            public string AdrSpecial3 { get; set; } = string.Empty;

            [JsonProperty("adr_cari_kod")]
            public string AdrCariKod { get; set; } = string.Empty;

            [JsonProperty("adr_adres_no")]
            public long AdrAdresNo { get; set; } = 0;

            [JsonProperty("adr_aprint_fl")]
            public bool AdrAprintFl { get; set; } = false;

            [JsonProperty("adr_cadde")]
            public string AdrCadde { get; set; } = string.Empty;

            [JsonProperty("adr_mahalle")]
            public string AdrMahalle { get; set; } = string.Empty;

            [JsonProperty("adr_sokak")]
            public string AdrSokak { get; set; } = string.Empty;

            [JsonProperty("adr_Semt")]
            public string AdrSemt { get; set; } = string.Empty;

            [JsonProperty("adr_Apt_No")]
            public string AdrAptNo { get; set; } = string.Empty;

            [JsonProperty("adr_Daire_No")]
            public string AdrDaireNo { get; set; } = string.Empty;

            [JsonProperty("adr_posta_kodu")]
            public string AdrPostaKodu { get; set; } = string.Empty;

            [JsonProperty("adr_ilce")]
            public string AdrIlce { get; set; } = string.Empty;

            [JsonProperty("adr_il")]
            public string AdrIl { get; set; } = string.Empty;

            [JsonProperty("adr_ulke")]
            public string AdrUlke { get; set; } = string.Empty;

            [JsonProperty("adr_Adres_kodu")]
            public string AdrAdresKodu { get; set; } = string.Empty;

            [JsonProperty("adr_tel_ulke_kodu")]
            public long AdrTelUlkeKodu { get; set; } = 90;

            [JsonProperty("adr_tel_bolge_kodu")]
            public string AdrTelBolgeKodu { get; set; } = string.Empty;

            [JsonProperty("adr_tel_no1")]
            public string AdrTelNo1 { get; set; } = string.Empty;

            [JsonProperty("adr_tel_no2")]
            public string AdrTelNo2 { get; set; } = string.Empty;

            [JsonProperty("adr_tel_faxno")]
            public string AdrTelFaxno { get; set; } = string.Empty;

            [JsonProperty("adr_tel_modem")]
            public string AdrTelModem { get; set; } = string.Empty;

            [JsonProperty("adr_yon_kodu")]
            public string AdrYonKodu { get; set; } = string.Empty;

            [JsonProperty("adr_uzaklik_kodu")]
            public long AdrUzaklikKodu { get; set; } = 0;

            [JsonProperty("adr_temsilci_kodu")]
            public string AdrTemsilciKodu { get; set; } = string.Empty;

            [JsonProperty("adr_ozel_not")]
            public string AdrOzelNot { get; set; } = string.Empty;

            [JsonProperty("adr_ziyaretperyodu")]
            public long AdrZiyaretperyodu { get; set; } = 0;

            [JsonProperty("adr_ziyaretgunu")]
            public long AdrZiyaretgunu { get; set; } = 0;

            [JsonProperty("adr_gps_enlem")]
            public long AdrGpsEnlem { get; set; } = 0;

            [JsonProperty("adr_gps_boylam")]
            public long AdrGpsBoylam { get; set; } = 0;

            [JsonProperty("adr_ziyarethaftasi")]
            public long AdrZiyarethaftasi { get; set; } = 0;

            [JsonProperty("adr_ziygunu2_1")]
            public bool AdrZiygunu21 { get; set; } = false;

            [JsonProperty("adr_ziygunu2_2")]
            public bool AdrZiygunu22 { get; set; } = false;

            [JsonProperty("adr_ziygunu2_3")]
            public bool AdrZiygunu23 { get; set; } = false;

            [JsonProperty("adr_ziygunu2_4")]
            public bool AdrZiygunu24 { get; set; } = false;

            [JsonProperty("adr_ziygunu2_5")]
            public bool AdrZiygunu25 { get; set; } = false;

            [JsonProperty("adr_ziygunu2_6")]
            public bool AdrZiygunu26 { get; set; } = false;

            [JsonProperty("adr_ziygunu2_7")]
            public bool AdrZiygunu27 { get; set; } = false;

            [JsonProperty("adr_efatura_alias")]
            public string AdrEfaturaAlias { get; set; }= string.Empty;

            [JsonProperty("adr_eirsaliye_alias")]
            public string AdrEirsaliyeAlias { get; set; } = string.Empty;
        }

        public partial class CariAdresModel
        {
            public static CariAdresModel FromJson(string json) => JsonConvert.DeserializeObject<CariAdresModel>(json, WebAPI1.Models.Converter.Settings);
        }
    }


