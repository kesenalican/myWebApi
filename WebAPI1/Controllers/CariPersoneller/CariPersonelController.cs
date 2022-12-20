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
        public JsonResult GetMerkez(int tipi)
        {
            string query = @"SELECT TOP 100 PERCENT
                            cari_per_kod AS cari_personel_kodu /* CARİ PERSONEL KODU */ ,
                            cari_per_adi AS cari_personel_adi /* CARİ PERSONEL ADI */ ,
                            cari_per_soyadi AS cari_personel_soyadi /* CARİ PERSONEL SOYADI */,
                            cari_per_kasiyerkodu AS kasiyer /* KASİYER */,
                            cari_per_tip AS personelTipi /* Personel Tipi */
                            FROM dbo.CARI_PERSONEL_TANIMLARI WITH (NOLOCK)
                             WHERE (cari_per_tip=@tipi) ORDER BY cari_per_kod ";
            // cari_per_tip == 	0:Satıcı Eleman 1:Satın Almacı 2:Diğer Eleman
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@tipi", tipi);
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
