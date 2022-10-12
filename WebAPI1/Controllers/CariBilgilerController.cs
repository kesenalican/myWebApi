using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariBilgilerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CariBilgilerController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"SELECT cari_kod AS CariKodu, cari_unvan1 AS CariUnvani1, cari_unvan2 AS
            CariUnvani2, cari_vdaire_adi AS CariVDaireAdi, cari_vdaire_no AS CariVDaireNo,
            cari_EMail AS CariEmail, cari_CepTel AS CariCepTel FROM CARI_HESAPLAR";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
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
