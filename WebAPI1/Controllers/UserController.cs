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
        [HttpPost]
        public JsonResult GetUsers()
        {
                                string query = @"SELECT TOP 100 PERCENT
                    User_Guid    AS [#msg_S_0088] /* KAYIT NO */ ,
                    User_name     AS [msg_S_0870] /* ADI */ ,
                    User_LongName AS [msg_S_1360] /* UZUN ADI */  ,
                    User_no       AS [msg_S_1107] /* NO */  ,
                    User_DBase    AS [msg_S_1361] /* VERİTABANI */
                    FROM dbo.KULLANICILAR
                     WHERE (User_pasif = 0) ORDER BY User_name
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
