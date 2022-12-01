using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.Siparisler.SatisSiparisi
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvrakBilgileriController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EvrakBilgileriController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetEvrakBilgileri()
        {
            string query = @"SELECT TOP 100 PERCENT
                            MIN(sip_Guid) AS ilkKayitNo /* İLK KAYIT NO */ ,
                            sip_evrakno_seri AS seri /* SERİ */ ,
                            sip_evrakno_sira AS siraNo /* SIRA NO */ ,
                            sip_tarih AS sipTarihi /* SİPARİŞ TARİHİ */ ,
                            MIN(sip_teslim_tarih) AS teslimTarihi /* TESLİM TARİHİ */ ,
                            dbo.fn_TalepTemin(sip_tip) AS tipi /* TİPİ */ ,
                            dbo.fn_SiparisCins(sip_cins) AS siparisCinsi /* SİPARİŞ CİNSİ */ ,
                            sip_musteri_kod AS cariKodu /* CARİ KODU */ ,
                            dbo.fn_CarininIsminiBul(0,sip_musteri_kod) AS cariIsmi /* CARİ İSMİ */ ,
                            SUM(sip_miktar) AS miktar /* MİKTAR */,
                            SUM( dbo.fn_SiparisNetTutar ( sip_tutar, sip_iskonto_1, sip_iskonto_2, sip_iskonto_3, sip_iskonto_4, sip_iskonto_5, sip_iskonto_6,
                            sip_masraf_1, sip_masraf_2, sip_masraf_3, sip_masraf_4, sip_vergi, sip_masvergi, sip_Otv_Vergi, sip_otvtutari, sip_vergisiz_fl,
                            2,sip_doviz_kuru,sip_alt_doviz_kuru)
                            ) AS sipNetTutar,
                            SUM(dbo.fn_Evrak_Kalan_Miktar(sip_miktar,sip_teslim_miktar,sip_kapat_fl)) AS kalanMiktar  /* KALAN MİKTAR */,
                            COUNT(sip_satirno) AS satirSayisi /* SATIR SAYISI */
                            FROM dbo.SIPARISLER WITH (NOLOCK)
                             WHERE (sip_tip=0) AND (sip_cins=0) AND (sip_evrakno_seri LIKE N'%') GROUP BY sip_tip, sip_cins, sip_evrakno_seri, sip_evrakno_sira, sip_tarih, sip_musteri_kod
                            ORDER BY sip_tip, sip_cins, sip_evrakno_seri, sip_evrakno_sira, sip_tarih, sip_musteri_kod";
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
    }
}
