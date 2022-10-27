using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.Kasalar
{
    [Route("api/[controller]")]
    [ApiController]
    public class KasalarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public KasalarController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetKasalar()
        {
            string query = @"SELECT TOP 100 PERCENT
                            kas_kod AS kasaKodu /* KASALAR KODU */ ,
                            kas_isim AS kasaIsmi /* KASALAR İSMİ */ ,
                            kas_firma_no AS FirmaNo /* FİRMA NO */ ,
                            dbo.fn_KasaTipi(kas_tip) AS kasaTipi /* KASALAR TİPİ */ ,
                            CASE
                            WHEN Cari_F10da_detay = 1 Then dbo.fn_CariHesapAnaDovizBakiye(kas_firma_no,4,kas_kod,'','',0,NULL,NULL,0,0,0,0,0)
                            WHEN Cari_F10da_detay = 2 Then dbo.fn_CariHesapAlternatifDovizBakiye(kas_firma_no,4,kas_kod,'','',0,NULL,NULL,0,0,0,0,0)
                            WHEN Cari_F10da_detay = 3 Then dbo.fn_CariHesapOrjinalDovizBakiye(kas_firma_no,4,kas_kod,'','',0,NULL,NULL,0,0,0,0,0)
                            WHEN Cari_F10da_detay = 4 Then dbo.fn_CariHareketSayisi(4,kas_kod,'')
                            END AS bakiyeHareketSayisi /* BAKİYE / HAREKET SAYISI */
                            FROM dbo.KASALAR WITH (NOLOCK)
                            LEFT OUTER JOIN dbo.vw_Gendata ON 1=1
                            ORDER BY kas_kod
                             ";
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
