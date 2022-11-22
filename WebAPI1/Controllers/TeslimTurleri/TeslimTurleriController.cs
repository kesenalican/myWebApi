using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.TeslimTurleri
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeslimTurleriController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TeslimTurleriController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult GetMerkez()
        {
            string query = @"select 
                            msg_S_1135 AS teslimTuruKodu,
                            msg_S_1136 AS teslimTuruAdi
                            from TESLIM_TURLERI_CHOOSE_2 ORDER BY  teslimTuruKodu ASC";
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
