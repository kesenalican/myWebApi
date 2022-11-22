using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.CariPersoneller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariPersonelController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CariPersonelController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetMerkez()
        {
            string query = @"SELECT TOP 100 PERCENT
                            cari_per_kod AS cariPersonelKodu /* CARİ PERSONEL KODU */ ,
                            cari_per_adi AS cariPersonelAdi /* CARİ PERSONEL ADI */ ,
                            cari_per_soyadi AS cariPersonelSoyadi /* CARİ PERSONEL SOYADI */,
                            cari_per_kasiyerkodu AS kasiyer /* KASİYER */
                            FROM dbo.CARI_PERSONEL_TANIMLARI WITH (NOLOCK)
                             WHERE (cari_per_tip=0) ORDER BY cari_per_kod";
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
