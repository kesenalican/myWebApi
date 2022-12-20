using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.StokController
{
    [Route("api/[controller]")]
    [ApiController]
    public class StokSatisFiyatListeleriController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StokSatisFiyatListeleriController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetWithCode()
        {
            string query = @" SELECT TOP 100 PERCENT
                            sfl_sirano AS sira_no,
                            sfl_aciklama AS aciklama
                            FROM STOK_SATIS_FIYAT_LISTE_TANIMLARI
                            ORDER BY sfl_sirano";
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
