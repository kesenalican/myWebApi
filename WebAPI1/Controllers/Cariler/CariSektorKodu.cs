using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAPI1.Models;

namespace WebAPI1.Controllers.Cariler
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariSektorKodu : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CariSektorKodu(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpPost]
        public JsonResult GetSektorKodu()
        {
            string query = @"  SELECT TOP 100 PERCENT
                            sktr_kod   AS SektorKodu /* SEKTÖR KODU */ ,
                            sktr_ismi  AS SektorIsmi /* SEKTÖR İSMİ */
                            FROM dbo.STOK_SEKTORLERI WITH (NOLOCK)
                            ORDER BY sktr_kod
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
