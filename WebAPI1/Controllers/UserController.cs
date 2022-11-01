using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetUsers()
        {
                                string query = @"SELECT TOP 100 PERCENT
                                User_no AS KULLANICI_NO,
                                User_name COLLATE database_default AS KULLANICI_KISA_ADI,
                                User_LongName COLLATE database_default AS KULLANICI_UZUN_ADI,
                                CASE WHEN LTRIM(RTRIM(User_LongName))<>'' THEN User_LongName ELSE User_name END AS KULLANICI_ADI
                                FROM MikroDB_V16.dbo.KULLANICILAR   ";
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
