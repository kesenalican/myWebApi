using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.Projeler
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjelerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProjelerController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetProjects()
        {
            string query = @"select msg_S_0078 AS projeKodu, 
                             msg_S_0870 AS projeAdi
                             from PROJELER_CHOOSE_2 ORDER BY  projeKodu ASC";
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
