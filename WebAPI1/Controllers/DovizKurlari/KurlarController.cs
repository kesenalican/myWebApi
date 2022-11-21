using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.DovizKurlari
{
    [ApiController]
    [Route("/api/[controller]")]
    public class KurlarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public KurlarController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpGet]
        public JsonResult GetWithCode()
        {
            string query = @"SELECT TOP 100 PERCENT
                            Kur_No AS KUR_NUMARASI,
                            Kur_sembol COLLATE database_default AS KUR_SEMBOLU,
                            Kur_orjAdi COLLATE database_default AS KUR_ORJINAL_ISMI
                            FROM MikroDB_V16.dbo.KUR_ISIMLERI ORDER BY KUR_NUMARASI";
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
