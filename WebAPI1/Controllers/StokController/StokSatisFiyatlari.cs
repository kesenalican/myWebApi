using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebAPI1.Models;

namespace WebAPI1.Controllers.StokController
{

    [Route("api/[controller]")]
    [ApiController]
    public class StokSatisFiyatlari : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StokSatisFiyatlari(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpPost]
        public JsonResult PostAlisFiyatlari(Stok stok)
        {
            string query = @"
                             Select * FROM fn_StokSatisFiyatlari(@stokKodu) ORDER BY Tarih DESC
                             ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@stokKodu", stok.StokKodu);
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
