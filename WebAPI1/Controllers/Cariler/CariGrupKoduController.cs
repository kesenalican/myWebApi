using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.Cariler
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariGrupKoduController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CariGrupKoduController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult GetCariGrupKodlari()
        {
            string query = @"SELECT TOP 100 PERCENT
                                crg_kod   AS CariGrupKodu /* KODU */ ,
                                crg_isim  AS CariGrupIsmi /* İSMİ */
                                FROM dbo.CARI_HESAP_GRUPLARI WITH (NOLOCK)
                                ORDER BY crg_kod ";

            DataTable dataTable = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    dataTable.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(dataTable);
        }
        
    }
}
