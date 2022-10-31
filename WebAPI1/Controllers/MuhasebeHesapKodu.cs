using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuhasebeHesapKodu : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MuhasebeHesapKodu(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetMuhasebeHesapKodu()
        {
            string query = @"SELECT TOP 100 PERCENT
                            muh_hesap_kod   AS MuhHesapKodu /* HESAP KODU */ ,
                            muh_hesap_isim1 AS MuhHesapIsim /* HESAP İSMİ */
                            FROM dbo.MUHASEBE_HESAP_PLANI WITH (NOLOCK)
                            ORDER BY muh_hesap_kod";
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
