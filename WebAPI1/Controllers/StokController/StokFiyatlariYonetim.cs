using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.StokController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokFiyatlariYonetim : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StokFiyatlariYonetim(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetWithCode(int depoNo, string cariKod)
        {
            string query = @" SELECT TOP 100 PERCENT
                               sfiyat_Guid AS kayit_no /* KAYIT NO */ ,
                               Case
                               WHEN sfiyat_birim_pntr=1 THEN sto_birim1_ad
                               WHEN sfiyat_birim_pntr=2 THEN sto_birim2_ad
                               WHEN sfiyat_birim_pntr=3 THEN sto_birim3_ad
                               WHEN sfiyat_birim_pntr=4 THEN sto_birim4_ad
                               END AS [msg_S_4612], /*FİYAT BİRİMİ*/
                               dbo.fn_OpVadeGun(sfiyat_odemeplan,dbo.fn_DatePart(GETDATE())) AS vade_gun, /* VADE GÜN */
                               dbo.fn_OpVadeTarih(sfiyat_odemeplan,dbo.fn_DatePart(GETDATE())) AS vade_tarih, /* VADE TARİH */
                               sfiyat_fiyati AS fiyati /* FİYATI */ ,
                               sfiyat_doviz AS doviz /* DÖVİZ */ ,
                               sfiyat_iskontokod AS iskonto /* ISKONTO */,
                               sfiyat_kampanyakod AS kampanya_kodu /* KAMPANYA KODU */,
                               sfiyat_primyuzdesi AS prim_yuzdesi /* PRİM YÜZDESİ */
                               FROM dbo.STOKLAR WITH (NOLOCK), dbo.STOK_SATIS_FIYAT_LISTELERI SFL WITH (NOLOCK)
                               LEFT OUTER JOIN dbo.STOKDETAYKODLAR_gizli SD ON (SFL.sfiyat_stokkod=SD.[msg_S_0001] /* STOKLAR KODU */ )
                               WHERE (sfiyat_listesirano=1) AND
                               (sfiyat_deposirano=@depoNo) AND
                               (SD.msg_S_0001 = '@cariKod') AND
                               (sfiyat_stokkod=sto_kod) AND
                               (
                               (0=0)OR                                       /* tümü */
                               (0=1  AND SD.[msg_S_0001]  LIKE 0)OR   /* kod */
                               (0=2  AND SD.[#msg_S_0013] LIKE 0)OR   /* ana grup */
                               (0=3  AND SD.[#msg_S_0015] LIKE 0)OR   /* alt grup */
                               (0=4  AND SD.[#msg_S_0016] LIKE 0)OR   /* sorumlu */
                               (0=5  AND SD.[#msg_S_0018] LIKE 0)OR   /* üretici */
                               (0=6  AND SD.[#msg_S_0020] LIKE 0)OR   /* reyon */
                               (0=7  AND SD.[#msg_S_0022] LIKE 0)OR   /* sektör */
                               (0=8  AND SD.[#msg_S_0024] LIKE 0)OR   /* marka */
                               (0=9  AND SD.[#msg_S_0026] LIKE 0)OR   /* muhgrup */
                               (0=10 AND SD.[#msg_S_0028] LIKE 0)OR   /* ambalaj */
                               (0=11 AND SD.[#msg_S_0030] LIKE 0)OR   /* kal kon */
                               (0=12 AND SD.[#msg_S_0032] LIKE 0)OR   /* sağlayıcı */
                               (0=13 AND SD.[#msg_S_0036] LIKE 0)OR   /* renk */
                               (0=14 AND SD.[#msg_S_0038] LIKE 0)OR   /* model */
                               (0=15 AND SD.[#msg_S_0040] LIKE 0)OR   /* sezon */
                               (0=16 AND SD.[#msg_S_0042] LIKE 0)OR   /* hammadde */
                               (0=17 AND SD.[#msg_S_0034] LIKE 0)OR   /* beden */
                               (0=18 AND SD.[#msg_S_0011] LIKE 0)OR   /* kategori */
                               (0=19 AND SD.[#msg_S_1122] LIKE 0)     /* prim */
                               )
                               ORDER BY sfiyat_stokkod, sfiyat_listesirano, sfiyat_deposirano, dbo.fn_OpVadeGun(sfiyat_odemeplan,dbo.fn_DatePart(GETDATE()))";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@depoNo", depoNo);
                    myCommand.Parameters.AddWithValue("@cariKod", cariKod);
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
