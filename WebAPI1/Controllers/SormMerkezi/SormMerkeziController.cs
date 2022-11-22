using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.SormMerkezi
{
    [ApiController]
    [Route("api/[controller]")]
    public class SormMerkeziController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SormMerkeziController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetMerkez()
        {
            string query = @"select 
                            msg_S_0078 AS MerkezKodu,
                            msg_S_0870 AS MerkezAdi
                            from SORUMLULUK_MERKEZLERI_CHOOSE_2 ORDER BY  MerkezKodu ASC";
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
