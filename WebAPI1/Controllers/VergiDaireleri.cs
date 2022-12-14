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
        [HttpGet]
        public JsonResult GetVergiDaireleri()
        {
            string query = @"SELECT
                           [Vgd_orj_kod] AS VergiDaireKodu
                           ,[Vgd_adi] AS VergiDaireAdi
                           ,[Vgd_Il] AS VergiDaireIl
                           FROM [MikroDB_V16].[dbo].[VERGI_DAIRELERI] ORDER BY Vgd_adi
                           ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MikroUsers");
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
