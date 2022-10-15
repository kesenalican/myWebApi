using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoklarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StoklarController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT sto_kod AS StokKodu , sto_isim AS StokIsim, sfiyat_fiyati AS StokFiyat , sto_anagrup_kod AS StokAnaGrup, sto_sektor_kodu AS StokSektor,
	sto_birim1_ad AS StokBirim1, sto_birim3_ad AS StokBirim3
,sto_birim3_katsayi AS StokBirim3_katsayi, sto_reyon_kodu AS StokReyon, sto_marka_kodu AS StokMarka, sto_model_kodu AS StokModel
FROM  STOKLAR 
INNER JOIN STOK_SATIS_FIYAT_LISTELERI 
ON STOKLAR.sto_kod = STOK_SATIS_FIYAT_LISTELERI.sfiyat_stokkod
 
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
