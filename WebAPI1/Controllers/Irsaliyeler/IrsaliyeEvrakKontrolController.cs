using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.Irsaliyeler
{
    [Route("api/[controller]")]
    [ApiController]
    public class IrsaliyeEvrakKontrolController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public IrsaliyeEvrakKontrolController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetEvrakBilgileri()
        {
            string query = @"SELECT TOP 100 PERCENT
                        MIN(sth_Guid) AS ilkKayitNo /* KAYIT NO */ ,
                        sth_evrakno_seri AS seri /* SERİ */ ,
                        sth_evrakno_sira AS siraNo /* SIRA NO */ ,
                        MIN(sth_tarih) AS irsaliyeTarihi /* TARİH */ ,
                        MIN(CCinsIsim) AS cariCinsi /* CARİ CİNSİ */ ,
                        sth_cari_kodu AS cariKodu /* CARİ KODU */ ,
                        dbo.fn_CarininIsminiBul(sth_cari_cinsi,sth_cari_kodu) AS cariIsmi /* CARİ İSMİ */ ,
                        SUM(sth_tutar) AS tutar,
                        dbo.fn_StokHarDepoIsmi(MIN(sth_giris_depo_no),MIN(sth_cikis_depo_no),sth_tip) AS depo /* DEPO */ ,
                        MIN(SHEvrIsim) AS evrakAdı /* EVRAK ADI */ ,
                        MIN(SHCinsIsim) AS cinsi /* CİNSİ */ ,
                        MIN(SHTipIsim) AS tipi /* TİPİ */ ,
                        MIN(NIIsim) AS [msg_S_0097] /* N/İ */ ,
                        COUNT(sth_satirno) AS satirSayisi /* SATIR SAYISI */
                        FROM dbo.STOK_HAREKETLERI  WITH (NOLOCK)
                        LEFT OUTER JOIN dbo.vw_Stok_Hareket_Evrak_Isimleri ON SHEvrNo=sth_evraktip
                        LEFT OUTER JOIN dbo.vw_Stok_Hareket_Cins_Isimleri  ON SHCinsNo=sth_cins
                        LEFT OUTER JOIN dbo.vw_Stok_Hareket_Tip_Isimleri   ON SHTipNo=sth_tip
                        LEFT OUTER JOIN dbo.vw_Normal_Iade_Isimleri        ON NINo=sth_normal_iade
                        LEFT OUTER JOIN dbo.vw_Cari_Cins_Isimleri          ON CCinsNo=sth_cari_cinsi
                         WHERE (sth_tip=1) AND (sth_evraktip=1) AND (sth_evrakno_seri LIKE N'%') AND (sth_cins=0) AND (sth_normal_iade=0) and (sth_cari_cinsi=0) GROUP BY sth_tip, sth_evraktip, 
                        sth_evrakno_seri, sth_evrakno_sira, sth_cins,sth_normal_iade , sth_cari_cinsi , sth_cari_kodu
                        ORDER BY sth_tip, sth_evraktip, sth_evrakno_seri, sth_evrakno_sira, sth_cins,sth_normal_iade , sth_cari_cinsi , sth_cari_kodu";
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
