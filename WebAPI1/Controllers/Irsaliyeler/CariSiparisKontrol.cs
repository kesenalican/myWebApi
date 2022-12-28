using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.Irsaliyeler
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariSiparisKontrol : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CariSiparisKontrol(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get(string cariKodu)
        {
            string query = @"SELECT TOP 100 PERCENT
                            sip_Guid AS [#msg_S_0966] /* İLK KAYIT NO */ ,
                            dbo.fn_Split(dbo.fn_GetResourceMax('A',3033, DEFAULT), sip_harekettipi+1, DEFAULT) AS [msg_S_0003] /* CİNSİ */ ,
                            sip_stok_kod AS [msg_S_0078] /* KODU */ ,
                            CASE
                            WHEN sip_harekettipi=0 THEN dbo.fn_StokIsmi(sip_stok_kod)
                            WHEN sip_harekettipi=1 THEN dbo.fn_CarininIsminiBul(3, sip_stok_kod)
                            WHEN sip_harekettipi=2 THEN dbo.fn_CarininIsminiBul(5, sip_stok_kod)
                            WHEN sip_harekettipi=3 THEN dbo.fn_CarininIsminiBul(8, sip_stok_kod)
                            END AS [msg_S_0070] /* İSMİ */ ,
                            dbo.fn_TalepTemin(sip_tip) AS [msg_S_0077] /* TİPİ */ ,
                            dbo.fn_SiparisCins(sip_cins) AS [msg_S_0242] /* SİPARİŞ CİNSİ */ ,
                            sip_evrakno_seri AS [msg_S_0423] /* EVRAK SERİ */ ,
                            sip_evrakno_sira AS [msg_S_0789] /* EVRAK SIRA */ ,
                            sip_tarih AS [msg_S_1097] /* ALINIŞ TARİHİ */ ,
                            dbo.fn_DateTimeKontrol(sip_teslim_tarih) AS [msg_S_0405] /* TES.TARİHİ */ ,
                            sip_miktar AS [msg_S_0165] /* MİKTAR */ ,
                            sip_tutar AS [msg_S_0293],
                            sip_teslim_miktar as [msg_S_1474],
                            dbo.fn_Evrak_Kalan_Miktar(sip_miktar,sip_teslim_miktar,sip_kapat_fl) AS [msg_S_0247] /* KALAN MİKTAR */ ,
                            sip_musteri_kod AS [msg_S_0200] /* CARİ KODU */ ,
                            dbo.fn_CarininIsminiBul(0, sip_musteri_kod) AS [msg_S_0201] /* CARİ İSMİ */ ,
                            sip_cari_sormerk AS [msg_S_1098] /* SRM. MRK KODU */ ,
                            dbo.fn_SorumlulukMerkeziIsmi(sip_cari_sormerk) AS [msg_S_1099] /* SRM. MRK İSMİ */ ,
                            CASE
                            WHEN sip_harekettipi=0 THEN dbo.fn_DepodakiMiktar(sip_stok_kod,sip_depono,'1900-1-1')
                            ELSE 0
                            END AS [msg_S_1100] /* DEPODAKİ MİKTAR */ ,
                            sip_aciklama AS [#msg_S_0085] /* AÇIKLAMA */ ,
                            sip_depono AS [msg_S_0873] /* DEPO NO */,
                            dbo.fn_DepoIsmi(sip_depono) AS [msg_S_0874] /* DEPO ADI */
                            FROM dbo.SIPARISLER WITH (NOLOCK)
                             WHERE (1=1)  AND ((sip_harekettipi in (1,2,3)) OR (sip_depono=1))  AND (sip_musteri_kod=N'@cariKodu')  AND (sip_tip=0)  AND (sip_kapat_fl = 0) AND (sip_cagrilabilir_fl = 1) 
                            AND ((sip_miktar - sip_teslim_miktar) > 0)  AND (sip_cins=0)  
                            AND (sip_harekettipi=0)  ORDER BY sip_teslim_tarih, sip_tarih, sip_evrakno_seri, sip_evrakno_sira, sip_cari_sormerk                             ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cariKodu", cariKodu);
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
