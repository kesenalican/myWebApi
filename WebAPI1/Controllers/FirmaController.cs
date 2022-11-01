using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public FirmaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult GetFirmalar()
        {
            string query = @"SELECT TOP 100 PERCENT
                            fir_sirano AS SiraNo /* FİRMA SIRA NO */ ,
                            fir_unvan  AS FirmaUnvan /* FİRMA UNVANI */ 
                            FROM dbo.FIRMALAR WITH (NOLOCK)
                            ORDER BY fir_sirano";
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
