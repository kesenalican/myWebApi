using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VergiDaireleri : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public VergiDaireleri(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpPost]
        public JsonResult GetVergiDaireleri()
        {
            string query = @"SELECT 
                            [msg_S_1364] AS VergDaireKodu,
                            [msg_S_0870] AS VergiDaireAdi,
                            [msg_S_1366] AS VergiDaireIl
                            FROM [MikroDB_V16].[dbo].[VERGI_DAIRELERI_CHOOSE_2] ORDER BY VergiDaireAdi ASC
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
