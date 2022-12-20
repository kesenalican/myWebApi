using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.StokController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokDepoFiyatlariController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StokDepoFiyatlariController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get(string stokKodu)
        {
            string query = @"SELECT TOP 100 PERCENT
                            sfiyat_Guid AS fiyat_guid,                    /* KAYIT NO */
                            sfiyat_stokkod AS stokKodu,                  /* STOK KODU */
                            sto_isim AS stok_ismi, /* STOK İSMİ */
                            sfiyat_listesirano AS fiyat_liste_no,              /* FİYAT LİSTE NO */
                            sfl_aciklama  AS fiyat_liste_aciklama,                   /* FİYAT LİSTE AÇIKLAMASI */
                            sfiyat_deposirano AS stok_depo,               /* DEPO */
                            dbo.fn_DepoIsmi(sfiyat_deposirano) AS stok_depo_ismi, /* DEPO İSMİ */
                            Case
                            WHEN sfiyat_birim_pntr=1 THEN sto_birim1_ad
                            WHEN sfiyat_birim_pntr=2 THEN sto_birim2_ad
                            WHEN sfiyat_birim_pntr=3 THEN sto_birim3_ad
                            WHEN sfiyat_birim_pntr=4 THEN sto_birim4_ad
                            END AS [msg_S_4612], /*FİYAT BİRİMİ*/
                            sfiyat_fiyati AS fiyati,                   /* FİYATI */
                            dbo.fn_DovizIsmi(sfiyat_doviz) AS doviz,  /* DÖVİZ */
                            sfiyat_iskontokod AS iskonto,               /* ISKONTO */
                            sfiyat_kampanyakod AS kampanya_kodu,               /* KAMPANYA KODU */
                            dbo.fn_EvetHayir(sfl_fiyatuygulama) AS formullu, /* FORMÜLLÜ */
                            sfl_fiyatformul AS formul,                 /* FORMÜL */
                            sfiyat_doviz AS doviz,                   /* DÖVİZ NO*/
                            sfl_fiyatuygulama AS fiyat_uygulama,              /* FİYAT UYGULAMA */
                            sfiyat_odemeplan AS odeme_plan,               /* ÖDEME PLANI NUMARASI */
                            sfiyat_birim_pntr AS [#msg_S_0010]  /* BİRİM */
                            FROM dbo.STOKLAR WITH(NOLOCK), dbo.STOK_SATIS_FIYAT_LISTELERI WITH (NOLOCK)
                            LEFT OUTER JOIN dbo.STOK_SATIS_FIYAT_LISTE_TANIMLARI ON (sfiyat_listesirano=sfl_sirano)
                            WHERE sfiyat_stokkod=@stokKodu
                            AND sfiyat_stokkod=sto_kod
                            ORDER BY sfiyat_stokkod, sfiyat_listesirano, sfiyat_deposirano";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource)) 
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@stokKodu", stokKodu);
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
