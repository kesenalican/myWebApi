using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepoController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT
                            dep_no,
                            dep_adi
                            FROM dbo.DEPOLAR WITH (NOLOCK)
                            WHERE dep_no > 0
                            UNION ALL
                            SELECT
                            CAST(0 AS integer),
                            CAST(dbo.fn_GetResource('M',588, DEFAULT) AS nvarchar(50))
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
