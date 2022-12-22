using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebAPI1.Models;
using System.Linq;

namespace WebAPI1.Controllers.Cariler
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariBilgilerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CariBilgilerController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get(int offset)
        {
            string query = @"SELECT
                cari_kod AS CariKodu /* CARI KODU */ ,
                cari_unvan1 AS CariUnvani1 ,
                cari_unvan2 AS CariUnvani2,
                cari_vdaire_adi AS CariVDaireAdi,
                cari_vdaire_no AS CariVDaireNo,
                cari_EMail AS CariEmail,
                cari_CepTel AS CariCepTel,
                cari_satis_fk AS cariBagliStok,
                CASE
                WHEN Cari_F10da_detay = 1 Then dbo.fn_CariHesapAnaDovizBakiye('',0,cari_kod,'','',NULL,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 2 Then dbo.fn_CariHesapAlternatifDovizBakiye('',0,cari_kod,'','',NULL,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 3 Then dbo.fn_CariHesapOrjinalDovizBakiye('',0,cari_kod,'','',0,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 4 Then dbo.fn_CariHareketSayisi(0,cari_kod,'')
                END AS CariBakiye /* BAKİYE / HAREKET SAYISI */ 
                FROM dbo.CARI_HESAPLAR
                LEFT OUTER JOIN dbo.vw_Gendata ON 1=1
                ORDER BY cari_kod
                OFFSET @offset ROWS FETCH NEXT 20 ROWS ONLY
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@offset", offset);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet("fullCari")]
        public JsonResult GetCari()
        {
            string query = @"SELECT cari_kod AS CariKodu, cari_unvan1 AS CariUnvani1 FROM CARI_HESAPLAR ORDER BY cari_kod ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    table.Select();
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpGet("search")]
        public JsonResult SearchCari(int offset,string? cariUnvani, string? cariKodu)
        {
            string query = @"SELECT
                cari_kod AS CariKodu /* CARI KODU */ ,
                cari_unvan1 AS CariUnvani1 ,
                cari_unvan2 AS CariUnvani2,
                cari_vdaire_adi AS CariVDaireAdi,
                cari_vdaire_no AS CariVDaireNo,
                cari_EMail AS CariEmail,
                cari_CepTel AS CariCepTel,
                cari_satis_fk AS cariBagliStok,
                CASE
                WHEN Cari_F10da_detay = 1 Then dbo.fn_CariHesapAnaDovizBakiye('',0,cari_kod,'','',NULL,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 2 Then dbo.fn_CariHesapAlternatifDovizBakiye('',0,cari_kod,'','',NULL,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 3 Then dbo.fn_CariHesapOrjinalDovizBakiye('',0,cari_kod,'','',0,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 4 Then dbo.fn_CariHareketSayisi(0,cari_kod,'')
                END AS CariBakiye /* BAKİYE / HAREKET SAYISI */ 
                FROM dbo.CARI_HESAPLAR 
                LEFT OUTER JOIN dbo.vw_Gendata ON 1=1
				WHERE cari_unvan1 like '%'+@CariUnvani1+'%' AND cari_kod like '%'+@CariKodu+'%'
                ORDER BY cari_kod
                OFFSET @offset ROWS FETCH NEXT 20 ROWS ONLY
                ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    if(cariUnvani ==null)
                    {
                        cariUnvani = "";
                    }
                    if(cariKodu == null)
                    {
                        cariKodu = "";
                    }
                    myCommand.Parameters.AddWithValue("@offset", offset);
                    myCommand.Parameters.AddWithValue("@CariKodu", cariKodu);
                    myCommand.Parameters.AddWithValue("@CariUnvani1", cariUnvani);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    table.Select();
                    
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult SaveCari([FromBody] CariModel cari)
        {
            string query = @"INSERT INTO MikroDB_V16_2022.dbo.CARI_HESAPLAR
                               (cari_SpecRECno,cari_iptal,
                               cari_fileid,cari_hidden,cari_kilitli,cari_degisti
                               ,cari_checksum,cari_create_user,
                               cari_lastup_user,cari_lastup_date,cari_special1,
                               cari_special2,cari_special3,cari_kod,cari_unvan1,
                               cari_unvan2,cari_hareket_tipi,cari_baglanti_tipi,cari_stok_alim_cinsi,
                               cari_stok_satim_cinsi,cari_muh_kod,cari_muh_kod1,cari_muh_kod2,cari_doviz_cinsi
                               ,cari_doviz_cinsi1,cari_doviz_cinsi2,cari_vade_fark_yuz,cari_vade_fark_yuz1
                               ,cari_vade_fark_yuz2,cari_KurHesapSekli,cari_vdaire_adi,cari_vdaire_no,
                               cari_sicil_no,cari_VergiKimlikNo,cari_satis_fk,cari_odeme_cinsi,
                               cari_odeme_gunu,cari_odemeplan_no,cari_opsiyon_gun,
                               cari_cariodemetercihi,cari_fatura_adres_no,cari_sevk_adres_no,
                               cari_banka_tcmb_kod1,cari_banka_tcmb_subekod1,cari_banka_tcmb_ilkod1,
                               cari_banka_hesapno1,cari_banka_swiftkodu1,cari_banka_tcmb_kod2,cari_banka_tcmb_subekod2,
                               cari_banka_tcmb_ilkod2,cari_banka_hesapno2,cari_banka_swiftkodu2,cari_banka_tcmb_kod3,cari_banka_tcmb_subekod3,
                               cari_banka_tcmb_ilkod3,cari_banka_hesapno3,cari_banka_swiftkodu3,cari_banka_tcmb_kod4,cari_banka_tcmb_subekod4,
                               cari_banka_tcmb_ilkod4,cari_banka_hesapno4,cari_banka_swiftkodu4,cari_banka_tcmb_kod5,cari_banka_tcmb_subekod5,
                               cari_banka_tcmb_ilkod5,cari_banka_hesapno5,cari_banka_swiftkodu5,cari_banka_tcmb_kod6,cari_banka_tcmb_subekod6,
                               cari_banka_tcmb_ilkod6,cari_banka_hesapno6,cari_banka_swiftkodu6,cari_banka_tcmb_kod7,cari_banka_tcmb_subekod7,
                               cari_banka_tcmb_ilkod7,cari_banka_hesapno7,cari_banka_swiftkodu7,cari_banka_tcmb_kod8,cari_banka_tcmb_subekod8,
                               cari_banka_tcmb_ilkod8,cari_banka_hesapno8,cari_banka_swiftkodu8,cari_banka_tcmb_kod9,cari_banka_tcmb_subekod9,
                               cari_banka_tcmb_ilkod9,cari_banka_hesapno9,cari_banka_swiftkodu9,cari_banka_tcmb_kod10,cari_banka_tcmb_subekod10,
                               cari_banka_tcmb_ilkod10,cari_banka_hesapno10,cari_banka_swiftkodu10,
                               cari_EftHesapNum,cari_Ana_cari_kodu,cari_satis_isk_kod,
                               cari_sektor_kodu,cari_bolge_kodu,cari_grup_kodu,cari_temsilci_kodu,cari_muhartikeli,cari_firma_acik_kapal,cari_BUV_tabi_fl,
                               cari_cari_kilitli_flg,cari_etiket_bas_fl,cari_Detay_incele_flg,cari_efatura_fl,cari_POS_ongpesyuzde,cari_POS_ongtaksayi,
                               cari_POS_ongIskOran,cari_kaydagiristarihi,cari_KabEdFCekTutar,cari_hal_caritip,cari_HalKomYuzdesi,cari_TeslimSuresi,
                               cari_wwwadresi,cari_EMail,cari_CepTel,cari_VarsayilanGirisDepo,cari_VarsayilanCikisDepo,cari_Portal_Enabled,
                               cari_Portal_PW,cari_BagliOrtaklisa_Firma,cari_kampanyakodu,cari_b_bakiye_degerlendirilmesin_fl,cari_a_bakiye_degerlendirilmesin_fl,
                               cari_b_irsbakiye_degerlendirilmesin_fl,cari_a_irsbakiye_degerlendirilmesin_fl,cari_b_sipbakiye_degerlendirilmesin_fl,
                               cari_a_sipbakiye_degerlendirilmesin_fl,cari_KrediRiskTakibiVar_flg,cari_ufrs_fark_muh_kod,cari_ufrs_fark_muh_kod1,
                               cari_ufrs_fark_muh_kod2,cari_odeme_sekli,cari_TeminatMekAlacakMuhKodu,cari_TeminatMekAlacakMuhKodu1,cari_TeminatMekAlacakMuhKodu2,
                               cari_TeminatMekBorcMuhKodu,cari_TeminatMekBorcMuhKodu1,cari_TeminatMekBorcMuhKodu2,cari_VerilenDepozitoTeminatMuhKodu,
                               cari_VerilenDepozitoTeminatMuhKodu1,cari_VerilenDepozitoTeminatMuhKodu2,cari_AlinanDepozitoTeminatMuhKodu,
                               cari_AlinanDepozitoTeminatMuhKodu1,cari_AlinanDepozitoTeminatMuhKodu2,cari_def_efatura_cinsi,
                               cari_otv_tevkifatina_tabii_fl,cari_KEP_adresi,cari_efatura_baslangic_tarihi,
                               cari_mutabakat_mail_adresi,cari_mersis_no,cari_istasyon_cari_kodu,cari_gonderionayi_sms,
                               cari_gonderionayi_email,cari_eirsaliye_fl,cari_eirsaliye_baslangic_tarihi,cari_vergidairekodu,
                               cari_CRM_sistemine_aktar_fl,cari_efatura_xslt_dosya,cari_pasaport_no,
                               cari_kisi_kimlik_bilgisi_aciklama_turu,cari_kisi_kimlik_bilgisi_diger_aciklama,
                               cari_uts_kurum_no,cari_kamu_kurumu_fl,cari_earsiv_xslt_dosya,cari_Perakende_fl,
                               cari_yeni_dogan_mi,cari_eirsaliye_xslt_dosya,cari_def_eirsaliye_cinsi,cari_ozel_butceli_kurum_carisi,
                               cari_nakakincelenmesi,cari_vergimukellefidegil_mi,cari_tasiyicifirma_cari_kodu,cari_nacekodu_1,
                               cari_nacekodu_2,cari_nacekodu_3,cari_sirket_turu,cari_baba_adi,cari_faal_terk)

                               VALUES(@cari_SpecRECno,
                                    @cari_iptal,@cari_fileid,@cari_hidden,@cari_kilitli,@cari_degisti
                               ,@cari_checksum,@cari_create_user,
                               @cari_lastup_user,@cari_lastup_date,@cari_special1,
                               @cari_special2,@cari_special3,@cari_kod,@cari_unvan1, @cari_unvan2,@cari_hareket_tipi,@cari_baglanti_tipi,@cari_stok_alim_cinsi,
                               @cari_stok_satim_cinsi,@cari_muh_kod,@cari_muh_kod1,@cari_muh_kod2,@cari_doviz_cinsi
                               ,@cari_doviz_cinsi1,@cari_doviz_cinsi2,@cari_vade_fark_yuz,@cari_vade_fark_yuz1
                               ,@cari_vade_fark_yuz2,@cari_KurHesapSekli,@cari_vdaire_adi,@cari_vdaire_no,
                               @cari_sicil_no,@cari_VergiKimlikNo,@cari_satis_fk,@cari_odeme_cinsi,
                               @cari_odeme_gunu,@cari_odemeplan_no,@cari_opsiyon_gun,
                               @cari_cariodemetercihi,@cari_fatura_adres_no,@cari_sevk_adres_no,
                               @cari_banka_tcmb_kod1,@cari_banka_tcmb_subekod1,@cari_banka_tcmb_ilkod1,
                               @cari_banka_hesapno1,@cari_banka_swiftkodu1,@cari_banka_tcmb_kod2,@cari_banka_tcmb_subekod2,
                               @cari_banka_tcmb_ilkod2,@cari_banka_hesapno2,@cari_banka_swiftkodu2,@cari_banka_tcmb_kod3,@cari_banka_tcmb_subekod3,
                               @cari_banka_tcmb_ilkod3,@cari_banka_hesapno3,@cari_banka_swiftkodu3,@cari_banka_tcmb_kod4,@cari_banka_tcmb_subekod4,
                               @cari_banka_tcmb_ilkod4,@cari_banka_hesapno4,@cari_banka_swiftkodu4,@cari_banka_tcmb_kod5,@cari_banka_tcmb_subekod5,
                               @cari_banka_tcmb_ilkod5,@cari_banka_hesapno5,@cari_banka_swiftkodu5,@cari_banka_tcmb_kod6,@cari_banka_tcmb_subekod6,
                               @cari_banka_tcmb_ilkod6,@cari_banka_hesapno6,@cari_banka_swiftkodu6,@cari_banka_tcmb_kod7,@cari_banka_tcmb_subekod7,
                               @cari_banka_tcmb_ilkod7,@cari_banka_hesapno7,@cari_banka_swiftkodu7,@cari_banka_tcmb_kod8,@cari_banka_tcmb_subekod8,
                               @cari_banka_tcmb_ilkod8,@cari_banka_hesapno8,@cari_banka_swiftkodu8,@cari_banka_tcmb_kod9,@cari_banka_tcmb_subekod9,
                               @cari_banka_tcmb_ilkod9,@cari_banka_hesapno9,@cari_banka_swiftkodu9,@cari_banka_tcmb_kod10,@cari_banka_tcmb_subekod10,
                               @cari_banka_tcmb_ilkod10,@cari_banka_hesapno10,@cari_banka_swiftkodu10,
                               @cari_EftHesapNum,@cari_Ana_cari_kodu,@cari_satis_isk_kod,
                               @cari_sektor_kodu,@cari_bolge_kodu,@cari_grup_kodu,@cari_temsilci_kodu,@cari_muhartikeli,@cari_firma_acik_kapal,@cari_BUV_tabi_fl,
                               @cari_cari_kilitli_flg,@cari_etiket_bas_fl,@cari_Detay_incele_flg,@cari_efatura_fl,@cari_POS_ongpesyuzde,@cari_POS_ongtaksayi,
                               @cari_POS_ongIskOran,@cari_kaydagiristarihi,@cari_KabEdFCekTutar,@cari_hal_caritip,@cari_HalKomYuzdesi,@cari_TeslimSuresi,
                               @cari_wwwadresi,@cari_EMail,@cari_CepTel,@cari_VarsayilanGirisDepo,@cari_VarsayilanCikisDepo,@cari_Portal_Enabled,
                               @cari_Portal_PW,@cari_BagliOrtaklisa_Firma,@cari_kampanyakodu,@cari_b_bakiye_degerlendirilmesin_fl,@cari_a_bakiye_degerlendirilmesin_fl,
                               @cari_b_irsbakiye_degerlendirilmesin_fl,@cari_a_irsbakiye_degerlendirilmesin_fl,@cari_b_sipbakiye_degerlendirilmesin_fl,
                               @cari_a_sipbakiye_degerlendirilmesin_fl,@cari_KrediRiskTakibiVar_flg,@cari_ufrs_fark_muh_kod,@cari_ufrs_fark_muh_kod1,
                               @cari_ufrs_fark_muh_kod2,@cari_odeme_sekli,@cari_TeminatMekAlacakMuhKodu,@cari_TeminatMekAlacakMuhKodu1,@cari_TeminatMekAlacakMuhKodu2,
                               @cari_TeminatMekBorcMuhKodu,@cari_TeminatMekBorcMuhKodu1,@cari_TeminatMekBorcMuhKodu2,@cari_VerilenDepozitoTeminatMuhKodu,
                               @cari_VerilenDepozitoTeminatMuhKodu1,@cari_VerilenDepozitoTeminatMuhKodu2,@cari_AlinanDepozitoTeminatMuhKodu,
                               @cari_AlinanDepozitoTeminatMuhKodu1,@cari_AlinanDepozitoTeminatMuhKodu2,@cari_def_efatura_cinsi,
                               @cari_otv_tevkifatina_tabii_fl,@cari_KEP_adresi,@cari_efatura_baslangic_tarihi,
                               @cari_mutabakat_mail_adresi,@cari_mersis_no,@cari_istasyon_cari_kodu,@cari_gonderionayi_sms,
                               @cari_gonderionayi_email,@cari_eirsaliye_fl,@cari_eirsaliye_baslangic_tarihi,@cari_vergidairekodu,
                               @cari_CRM_sistemine_aktar_fl,@cari_efatura_xslt_dosya,@cari_pasaport_no,
                               @cari_kisi_kimlik_bilgisi_aciklama_turu,@cari_kisi_kimlik_bilgisi_diger_aciklama,
                               @cari_uts_kurum_no,@cari_kamu_kurumu_fl,@cari_earsiv_xslt_dosya,@cari_Perakende_fl,
                               @cari_yeni_dogan_mi,@cari_eirsaliye_xslt_dosya,@cari_def_eirsaliye_cinsi,@cari_ozel_butceli_kurum_carisi,
                               @cari_nakakincelenmesi,@cari_vergimukellefidegil_mi,@cari_tasiyicifirma_cari_kodu,@cari_nacekodu_1,
                               @cari_nacekodu_2,@cari_nacekodu_3,@cari_sirket_turu,@cari_baba_adi,@cari_faal_terk
                                       )";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    try {
                        myCommand.Parameters.AddWithValue("@cari_SpecRECno", cari.CariSpecReCno);
                        myCommand.Parameters.AddWithValue("@cari_iptal", cari.CariIptal);
                        myCommand.Parameters.AddWithValue("@cari_fileid", cari.CariFileid);
                        myCommand.Parameters.AddWithValue("@cari_hidden", cari.CariHidden);
                        myCommand.Parameters.AddWithValue("@cari_kilitli", cari.CariKilitli);
                        myCommand.Parameters.AddWithValue("@cari_degisti", cari.CariDegisti);
                        myCommand.Parameters.AddWithValue("@cari_checksum", cari.CariChecksum);
                        myCommand.Parameters.AddWithValue("@cari_create_user", cari.CariCreateUser);
                        myCommand.Parameters.AddWithValue("@cari_lastup_user", cari.CariLastupUser);
                        myCommand.Parameters.AddWithValue("@cari_lastup_date", cari.CariLastupDate);
                        myCommand.Parameters.AddWithValue("@cari_special1", cari.CariSpecial1);
                        myCommand.Parameters.AddWithValue("@cari_special2", cari.CariSpecial2);
                        myCommand.Parameters.AddWithValue("@cari_special3", cari.CariSpecial3);
                        myCommand.Parameters.AddWithValue("@cari_kod", cari.CariKod);
                        myCommand.Parameters.AddWithValue("@cari_unvan1", cari.CariUnvan1);
                        myCommand.Parameters.AddWithValue("@cari_unvan2", cari.CariUnvan2);
                        myCommand.Parameters.AddWithValue("@cari_hareket_tipi", cari.CariHareketTipi);
                        myCommand.Parameters.AddWithValue("@cari_baglanti_tipi", cari.CariBaglantiTipi);
                        myCommand.Parameters.AddWithValue("@cari_stok_alim_cinsi", cari.CariStokAlimCinsi);
                        myCommand.Parameters.AddWithValue("@cari_stok_satim_cinsi", cari.CariStokSatimCinsi);
                        myCommand.Parameters.AddWithValue("@cari_muh_kod", cari.CariMuhKod);
                        myCommand.Parameters.AddWithValue("@cari_muh_kod1", cari.CariMuhKod1);
                        myCommand.Parameters.AddWithValue("@cari_muh_kod2", cari.CariMuhKod2);
                        myCommand.Parameters.AddWithValue("@cari_doviz_cinsi", cari.CariDovizCinsi);
                        myCommand.Parameters.AddWithValue("@cari_doviz_cinsi1", cari.CariDovizCinsi1);
                        myCommand.Parameters.AddWithValue("@cari_doviz_cinsi2", cari.CariDovizCinsi2);
                        myCommand.Parameters.AddWithValue("@cari_vade_fark_yuz", cari.CariVadeFarkYuz);
                        myCommand.Parameters.AddWithValue("@cari_vade_fark_yuz1", cari.CariVadeFarkYuz1);
                        myCommand.Parameters.AddWithValue("@cari_vade_fark_yuz2", cari.CariVadeFarkYuz2);
                        myCommand.Parameters.AddWithValue("@cari_KurHesapSekli", cari.CariKurHesapSekli);
                        myCommand.Parameters.AddWithValue("@cari_vdaire_adi", cari.CariVdaireAdi);
                        myCommand.Parameters.AddWithValue("@cari_vdaire_no", cari.CariVdaireNo);
                        myCommand.Parameters.AddWithValue("@cari_sicil_no", cari.CariSicilNo);
                        myCommand.Parameters.AddWithValue("@cari_VergiKimlikNo", cari.CariVergiKimlikNo);
                        myCommand.Parameters.AddWithValue("@cari_satis_fk", cari.CariSatisFk);
                        myCommand.Parameters.AddWithValue("@cari_odeme_cinsi", cari.CariOdemeCinsi);
                        myCommand.Parameters.AddWithValue("@cari_odeme_gunu", cari.CariOdemeGunu);
                        myCommand.Parameters.AddWithValue("@cari_odemeplan_no", cari.CariOdemeplanNo);
                        myCommand.Parameters.AddWithValue("@cari_opsiyon_gun", cari.CariOpsiyonGun);
                        myCommand.Parameters.AddWithValue("@cari_cariodemetercihi", cari.CariCariodemetercihi);
                        myCommand.Parameters.AddWithValue("@cari_fatura_adres_no", cari.CariFaturaAdresNo);
                        myCommand.Parameters.AddWithValue("@cari_sevk_adres_no", cari.CariSevkAdresNo);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod1", cari.CariBankaTcmbKod1);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod1", cari.CariBankaTcmbSubekod1);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod1", cari.CariBankaTcmbIlkod1);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno1", cari.CariBankaHesapno1);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu1", cari.CariBankaSwiftkodu1);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod2", cari.CariBankaTcmbKod2);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod2", cari.CariBankaTcmbSubekod2);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod2", cari.CariBankaTcmbIlkod2);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno2", cari.CariBankaHesapno2);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu2", cari.CariBankaSwiftkodu2);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod3", cari.CariBankaTcmbKod3);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod3", cari.CariBankaTcmbSubekod3);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod3", cari.CariBankaTcmbIlkod3);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno3", cari.CariBankaHesapno3);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu3", cari.CariBankaSwiftkodu3);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod4", cari.CariBankaTcmbKod4);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod4", cari.CariBankaTcmbSubekod4);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod4", cari.CariBankaTcmbIlkod4);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno4", cari.CariBankaHesapno4);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu4", cari.CariBankaSwiftkodu4);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod5", cari.CariBankaTcmbKod5);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod5", cari.CariBankaTcmbSubekod5);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod5", cari.CariBankaTcmbIlkod5);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno5", cari.CariBankaHesapno5);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu5", cari.CariBankaSwiftkodu5);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod6", cari.CariBankaTcmbKod6);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod6", cari.CariBankaTcmbSubekod6);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod6", cari.CariBankaTcmbIlkod6);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno6", cari.CariBankaHesapno6);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu6", cari.CariBankaSwiftkodu6);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod7", cari.CariBankaTcmbKod7);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod7", cari.CariBankaTcmbSubekod7);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod7", cari.CariBankaTcmbIlkod7);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno7", cari.CariBankaHesapno7);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu7", cari.CariBankaSwiftkodu7);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod8", cari.CariBankaTcmbKod8);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod8", cari.CariBankaTcmbSubekod8);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod8", cari.CariBankaTcmbIlkod8);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno8", cari.CariBankaHesapno8);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu8", cari.CariBankaSwiftkodu8);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod9", cari.CariBankaTcmbKod9);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod9", cari.CariBankaTcmbSubekod9);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod9", cari.CariBankaTcmbIlkod9);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno9", cari.CariBankaHesapno9);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu9", cari.CariBankaSwiftkodu9);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_kod10", cari.CariBankaTcmbKod10);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_subekod10", cari.CariBankaTcmbSubekod10);
                        myCommand.Parameters.AddWithValue("@cari_banka_tcmb_ilkod10", cari.CariBankaTcmbIlkod10);
                        myCommand.Parameters.AddWithValue("@cari_banka_hesapno10", cari.CariBankaHesapno10);
                        myCommand.Parameters.AddWithValue("@cari_banka_swiftkodu10", cari.CariBankaSwiftkodu10);
                        myCommand.Parameters.AddWithValue("@cari_EftHesapNum", cari.CariEftHesapNum);
                        myCommand.Parameters.AddWithValue("@cari_Ana_cari_kodu", cari.CariAnaCariKodu);
                        myCommand.Parameters.AddWithValue("@cari_satis_isk_kod", cari.CariSatisIskKod);
                        myCommand.Parameters.AddWithValue("@cari_sektor_kodu", cari.CariSektorKodu);
                        myCommand.Parameters.AddWithValue("@cari_bolge_kodu", cari.CariBolgeKodu);
                        myCommand.Parameters.AddWithValue("@cari_grup_kodu", cari.CariGrupKodu);
                        myCommand.Parameters.AddWithValue("@cari_temsilci_kodu", cari.CariTemsilciKodu);
                        myCommand.Parameters.AddWithValue("@cari_muhartikeli", cari.CariMuhartikeli);
                        myCommand.Parameters.AddWithValue("@cari_firma_acik_kapal", cari.CariFirmaAcikKapal);
                        myCommand.Parameters.AddWithValue("@cari_BUV_tabi_fl", cari.CariBuvTabiFl);
                        myCommand.Parameters.AddWithValue("@cari_cari_kilitli_flg", cari.CariCariKilitliFlg);
                        myCommand.Parameters.AddWithValue("@cari_etiket_bas_fl", cari.CariEtiketBasFl);
                        myCommand.Parameters.AddWithValue("@cari_Detay_incele_flg", cari.CariDetayInceleFlg);
                        myCommand.Parameters.AddWithValue("@cari_efatura_fl", cari.CariEfaturaFl);
                        myCommand.Parameters.AddWithValue("@cari_POS_ongpesyuzde", cari.CariPosOngpesyuzde);
                        myCommand.Parameters.AddWithValue("@cari_POS_ongtaksayi", cari.CariPosOngtaksayi);
                        myCommand.Parameters.AddWithValue("@cari_POS_ongIskOran", cari.CariPosOngIskOran);
                        myCommand.Parameters.AddWithValue("@cari_kaydagiristarihi", cari.CariKaydagiristarihi);
                        myCommand.Parameters.AddWithValue("@cari_KabEdFCekTutar", cari.CariKabEdFCekTutar);
                        myCommand.Parameters.AddWithValue("@cari_hal_caritip", cari.CariHalCaritip);
                        myCommand.Parameters.AddWithValue("@cari_HalKomYuzdesi", cari.CariHalKomYuzdesi);
                        myCommand.Parameters.AddWithValue("@cari_TeslimSuresi", cari.CariTeslimSuresi);
                        myCommand.Parameters.AddWithValue("@cari_wwwadresi", cari.CariWwwadresi);
                        myCommand.Parameters.AddWithValue("@cari_EMail", cari.CariEMail);
                        myCommand.Parameters.AddWithValue("@cari_CepTel", cari.CariCepTel);
                        myCommand.Parameters.AddWithValue("@cari_VarsayilanGirisDepo", cari.CariVarsayilanGirisDepo);
                        myCommand.Parameters.AddWithValue("@cari_VarsayilanCikisDepo", cari.CariVarsayilanCikisDepo);
                        myCommand.Parameters.AddWithValue("@cari_Portal_Enabled", cari.CariPortalEnabled);
                        myCommand.Parameters.AddWithValue("@cari_Portal_PW", cari.CariPortalPw);
                        myCommand.Parameters.AddWithValue("@cari_BagliOrtaklisa_Firma", cari.CariBagliOrtaklisaFirma);
                        myCommand.Parameters.AddWithValue("@cari_kampanyakodu", cari.CariKampanyakodu);
                        myCommand.Parameters.AddWithValue("@cari_b_bakiye_degerlendirilmesin_fl", cari.CariBBakiyeDegerlendirilmesinFl);
                        myCommand.Parameters.AddWithValue("@cari_a_bakiye_degerlendirilmesin_fl", cari.CariABakiyeDegerlendirilmesinFl);
                        myCommand.Parameters.AddWithValue("@cari_b_irsbakiye_degerlendirilmesin_fl", cari.CariBIrsbakiyeDegerlendirilmesinFl);
                        myCommand.Parameters.AddWithValue("@cari_a_irsbakiye_degerlendirilmesin_fl", cari.CariAIrsbakiyeDegerlendirilmesinFl);
                        myCommand.Parameters.AddWithValue("@cari_b_sipbakiye_degerlendirilmesin_fl", cari.CariBSipbakiyeDegerlendirilmesinFl);
                        myCommand.Parameters.AddWithValue("@cari_a_sipbakiye_degerlendirilmesin_fl", cari.CariASipbakiyeDegerlendirilmesinFl);
                        myCommand.Parameters.AddWithValue("@cari_KrediRiskTakibiVar_flg", cari.CariKrediRiskTakibiVarFlg);
                        myCommand.Parameters.AddWithValue("@cari_ufrs_fark_muh_kod", cari.CariUfrsFarkMuhKod);
                        myCommand.Parameters.AddWithValue("@cari_ufrs_fark_muh_kod1", cari.CariUfrsFarkMuhKod1);
                        myCommand.Parameters.AddWithValue("@cari_ufrs_fark_muh_kod2", cari.CariUfrsFarkMuhKod2);
                        myCommand.Parameters.AddWithValue("@cari_odeme_sekli", cari.CariOdemeSekli);
                        myCommand.Parameters.AddWithValue("@cari_TeminatMekAlacakMuhKodu", cari.CariTeminatMekAlacakMuhKodu);
                        myCommand.Parameters.AddWithValue("@cari_TeminatMekAlacakMuhKodu1", cari.CariTeminatMekAlacakMuhKodu1);
                        myCommand.Parameters.AddWithValue("@cari_TeminatMekAlacakMuhKodu2", cari.CariTeminatMekAlacakMuhKodu2);
                        myCommand.Parameters.AddWithValue("@cari_TeminatMekBorcMuhKodu", cari.CariTeminatMekBorcMuhKodu);
                        myCommand.Parameters.AddWithValue("@cari_TeminatMekBorcMuhKodu1", cari.CariTeminatMekBorcMuhKodu1);
                        myCommand.Parameters.AddWithValue("@cari_TeminatMekBorcMuhKodu2", cari.CariTeminatMekBorcMuhKodu2);
                        myCommand.Parameters.AddWithValue("@cari_VerilenDepozitoTeminatMuhKodu", cari.CariVerilenDepozitoTeminatMuhKodu);
                        myCommand.Parameters.AddWithValue("@cari_VerilenDepozitoTeminatMuhKodu1", cari.CariVerilenDepozitoTeminatMuhKodu1);
                        myCommand.Parameters.AddWithValue("@cari_VerilenDepozitoTeminatMuhKodu2", cari.CariVerilenDepozitoTeminatMuhKodu2);
                        myCommand.Parameters.AddWithValue("@cari_AlinanDepozitoTeminatMuhKodu", cari.CariAlinanDepozitoTeminatMuhKodu);
                        myCommand.Parameters.AddWithValue("@cari_AlinanDepozitoTeminatMuhKodu1", cari.CariAlinanDepozitoTeminatMuhKodu1);
                        myCommand.Parameters.AddWithValue("@cari_AlinanDepozitoTeminatMuhKodu2", cari.CariAlinanDepozitoTeminatMuhKodu2);
                        myCommand.Parameters.AddWithValue("@cari_def_efatura_cinsi", cari.CariDefEfaturaCinsi);
                        myCommand.Parameters.AddWithValue("@cari_otv_tevkifatina_tabii_fl", cari.CariOtvTevkifatinaTabiiFl);
                        myCommand.Parameters.AddWithValue("@cari_KEP_adresi", cari.CariKepAdresi);
                        myCommand.Parameters.AddWithValue("@cari_efatura_baslangic_tarihi", cari.CariEfaturaBaslangicTarihi);
                        myCommand.Parameters.AddWithValue("@cari_mutabakat_mail_adresi", cari.CariMutabakatMailAdresi);
                        myCommand.Parameters.AddWithValue("@cari_mersis_no", cari.CariMersisNo);
                        myCommand.Parameters.AddWithValue("@cari_istasyon_cari_kodu", cari.CariIstasyonCariKodu);
                        myCommand.Parameters.AddWithValue("@cari_gonderionayi_sms", cari.CariGonderionayiSms);
                        myCommand.Parameters.AddWithValue("@cari_gonderionayi_email", cari.CariGonderionayiEmail);
                        myCommand.Parameters.AddWithValue("@cari_eirsaliye_fl", cari.CariEirsaliyeFl);
                        myCommand.Parameters.AddWithValue("@cari_eirsaliye_baslangic_tarihi", cari.CariEirsaliyeBaslangicTarihi);
                        myCommand.Parameters.AddWithValue("@cari_vergidairekodu", cari.CariVergidairekodu);
                        myCommand.Parameters.AddWithValue("@cari_CRM_sistemine_aktar_fl", cari.CariCrmSistemineAktarFl);
                        myCommand.Parameters.AddWithValue("@cari_efatura_xslt_dosya", cari.CariEfaturaXsltDosya);
                        myCommand.Parameters.AddWithValue("@cari_pasaport_no", cari.CariPasaportNo);
                        myCommand.Parameters.AddWithValue("@cari_kisi_kimlik_bilgisi_aciklama_turu", cari.CariKisiKimlikBilgisiAciklamaTuru);
                        myCommand.Parameters.AddWithValue("@cari_kisi_kimlik_bilgisi_diger_aciklama", cari.CariKisiKimlikBilgisiDigerAciklama);
                        myCommand.Parameters.AddWithValue("@cari_uts_kurum_no", cari.CariUtsKurumNo);
                        myCommand.Parameters.AddWithValue("@cari_kamu_kurumu_fl", cari.CariKamuKurumuFl);
                        myCommand.Parameters.AddWithValue("@cari_earsiv_xslt_dosya", cari.CariEarsivXsltDosya);
                        myCommand.Parameters.AddWithValue("@cari_Perakende_fl", cari.CariPerakendeFl);
                        myCommand.Parameters.AddWithValue("@cari_yeni_dogan_mi", cari.CariYeniDoganMi);
                        myCommand.Parameters.AddWithValue("@cari_eirsaliye_xslt_dosya", cari.CariEirsaliyeXsltDosya);
                        myCommand.Parameters.AddWithValue("@cari_def_eirsaliye_cinsi", cari.CariDefEirsaliyeCinsi);
                        myCommand.Parameters.AddWithValue("@cari_ozel_butceli_kurum_carisi", cari.CariOzelButceliKurumCarisi);
                        myCommand.Parameters.AddWithValue("@cari_nakakincelenmesi", cari.CariNakakincelenmesi);
                        myCommand.Parameters.AddWithValue("@cari_vergimukellefidegil_mi", cari.CariVergimukellefidegilMi);
                        myCommand.Parameters.AddWithValue("@cari_tasiyicifirma_cari_kodu", cari.CariTasiyicifirmaCariKodu);
                        myCommand.Parameters.AddWithValue("@cari_nacekodu_1", cari.CariNacekodu1);
                        myCommand.Parameters.AddWithValue("@cari_nacekodu_2", cari.CariNacekodu2);
                        myCommand.Parameters.AddWithValue("@cari_nacekodu_3", cari.CariNacekodu3);
                        myCommand.Parameters.AddWithValue("@cari_sirket_turu", cari.CariSirketTuru);
                        myCommand.Parameters.AddWithValue("@cari_baba_adi", cari.CariBabaAdi);
                        myCommand.Parameters.AddWithValue("@cari_faal_terk", cari.CariFaalTerk);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                    catch(Exception ex)
                    {

                        return new JsonResult(BadRequest(StatusCodes.Status500InternalServerError), ex);
                    }
                   
                }
            }
            return new JsonResult(table);
        }
    }
}
