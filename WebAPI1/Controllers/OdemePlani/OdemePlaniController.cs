using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.OdemePlani
{
    [ApiController]
    [Route("api/[controller]")]
    public class OdemePlaniController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public OdemePlaniController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult GetMerkez()
        {
            string query = @"select msg_S_1421 AS OdemePlanNo,
                           msg_S_1041 AS OdemePlanKod,
                           msg_S_1042 AS OdemePlanAdi 
                           from ODEME_PLANLARI_CHOOSE_2 ORDER BY  OdemePlanNo ASC";
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
