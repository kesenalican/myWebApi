using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebAPI1.Models;

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
            string query = @"SELECT TOP 10  * FROM CARI_HESAPLAR";
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
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpPost]
        public JsonResult SaveCari(CariModel cari)
        {
            string query = @"INSERT INTO MikroDB_V16_2022.dbo.CARI_HESAPLAR
                               (cari_DBCno,cari_SpecRECno,cari_iptal,
                               cari_fileid,cari_hidden,cari_kilitli,cari_degisti
                               ,cari_checksum,cari_create_user,cari_create_date,
                               cari_lastup_user,cari_lastup_date,cari_special1,
                               cari_special2,cari_special3,cari_kod,cari_unvan1,
                               cari_unvan2,cari_hareket_tipi,cari_baglanti_tipi,cari_stok_alim_cinsi,
                               cari_stok_satim_cinsi,cari_muh_kod,cari_muh_kod1,cari_muh_kod2,cari_doviz_cinsi
                               ,cari_doviz_cinsi1,cari_doviz_cinsi2,cari_vade_fark_yuz,cari_vade_fark_yuz1
                               ,cari_vade_fark_yuz2,cari_KurHesapSekli,cari_vdaire_adi,cari_vdaire_no
                               ,cari_sicil_no,cari_VergiKimlikNo,cari_satis_fk,cari_odeme_cinsi,
                               cari_odeme_gunu,cari_odemeplan_no,cari_opsiyon_gun,
                               cari_cariodemetercihi,cari_fatura_adres_no,cari_sevk_adres_no,
                               cari_banka_tcmb_kod1,cari_banka_tcmb_subekod1,cari_banka_tcmb_ilkod1,
                               cari_banka_hesapno1,cari_banka_swiftkodu1,cari_banka_tcmb_kod2,cari_banka_tcmb_subekod2,
                               cari_banka_tcmb_ilkod2,cari_banka_hesapno2,cari_banka_swiftkodu2,cari_banka_tcmb_kod3,cari_banka_tcmb_subekod3
                               ,cari_banka_tcmb_ilkod3,cari_banka_hesapno3,cari_banka_swiftkodu3,cari_banka_tcmb_kod4,cari_banka_tcmb_subekod4,
                               cari_banka_tcmb_ilkod4,cari_banka_hesapno4,cari_banka_swiftkodu4,cari_banka_tcmb_kod5,cari_banka_tcmb_subekod5,
                               cari_banka_tcmb_ilkod5,cari_banka_hesapno5,cari_banka_swiftkodu5,cari_banka_tcmb_kod6,cari_banka_tcmb_subekod6,
                               cari_banka_tcmb_ilkod6,cari_banka_hesapno6,cari_banka_swiftkodu6,cari_banka_tcmb_kod7,cari_banka_tcmb_subekod7,
                               cari_banka_tcmb_ilkod7,cari_banka_hesapno7,cari_banka_swiftkodu7,cari_banka_tcmb_kod8,cari_banka_tcmb_subekod8,
                               cari_banka_tcmb_ilkod8,cari_banka_hesapno8,cari_banka_swiftkodu8,cari_banka_tcmb_kod9,cari_banka_tcmb_subekod9,
                               cari_banka_tcmb_ilkod9,cari_banka_hesapno9,cari_banka_swiftkodu9,cari_banka_tcmb_kod10,cari_banka_tcmb_subekod10,
                               cari_banka_tcmb_ilkod10,cari_banka_hesapno10,cari_banka_swiftkodu10,cari_EftHesapNum,cari_Ana_cari_kodu,cari_satis_isk_kod,
                               cari_sektor_kodu,cari_bolge_kodu,cari_grup_kodu,cari_temsilci_kodu,cari_muhartikeli,cari_firma_acik_kapal,cari_BUV_tabi_fl,
                               cari_cari_kilitli_flg,cari_etiket_bas_fl,cari_Detay_incele_flg,cari_efatura_fl,cari_POS_ongpesyuzde,cari_POS_ongtaksayi,
                               cari_POS_ongIskOran,cari_kaydagiristarihi,cari_KabEdFCekTutar,cari_hal_caritip,cari_HalKomYuzdesi,cari_TeslimSuresi,
                               cari_wwwadresi,cari_EMail,cari_CepTel,cari_VarsayilanGirisDepo,cari_VarsayilanCikisDepo,cari_Portal_Enabled,
                               cari_Portal_PW,cari_BagliOrtaklisa_Firma,cari_kampanyakodu,cari_b_bakiye_degerlendirilmesin_fl,cari_a_bakiye_degerlendirilmesin_fl,
                               cari_b_irsbakiye_degerlendirilmesin_fl,cari_a_irsbakiye_degerlendirilmesin_fl,cari_b_sipbakiye_degerlendirilmesin_fl,
                               cari_a_sipbakiye_degerlendirilmesin_fl,cari_KrediRiskTakibiVar_flg,cari_ufrs_fark_muh_kod,cari_ufrs_fark_muh_kod1,
                               cari_ufrs_fark_muh_kod2,cari_odeme_sekli,cari_TeminatMekAlacakMuhKodu,cari_TeminatMekAlacakMuhKodu1,cari_TeminatMekAlacakMuhKodu2
                               ,cari_TeminatMekBorcMuhKodu,cari_TeminatMekBorcMuhKodu1,cari_TeminatMekBorcMuhKodu2,cari_VerilenDepozitoTeminatMuhKodu,
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
                               VALUES(0,0,0,31,0,0,0,0,1,'20221028 14:09:42.402',1,
                               '20221028 14:09:42.402',N'',N'',N'',N'123456',N'kesen',N'alican',0,0,0,0,N'',N'',N'',
                               0,255,255,25.000000000000,0,0,1,N'ŞAHİNBEY VERGİ DAİRESİ',N'43906160942',N'',N'',1,0,
                               0,0,0,0,1,1,N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'',N'')



";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cariKodu", cari.CariKod);
                    myCommand.Parameters.AddWithValue("@cariUnvan1", cari.CariUnvan1);
                    myCommand.Parameters.AddWithValue("@cariUnvan2", cari.CariUnvan2);
                    myCommand.Parameters.AddWithValue("@vergiDairesi", cari.CariVdaireAdi);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }





    }
}
