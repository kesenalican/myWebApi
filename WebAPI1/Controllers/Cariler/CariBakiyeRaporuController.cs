using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebAPI1.Controllers.Cariler
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariBakiyeRaporuController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CariBakiyeRaporuController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetCariBakiye(string cariKodu)
        {
            string query = @"Select TOP 100 PERCENT
                        SUM([msg_S_0101\T] /* ANA DÖVİZ BORÇ */ ) AS anaDovizBorc,
                        SUM([msg_S_0102\T] /* ANA DÖVİZ ALACAK */ ) AS anaDovizAlacak,
                        SUM([msg_S_0105\T] /* ALT. DÖVİZ BORÇ */ ) AS altDovizBorc,
                        SUM([msg_S_0106\T] /* ALT. DÖVİZ ALACAK */ ) AS altDovizAlacak,
                        SUM([msg_S_0109\T] /* ORJ. DÖVİZ BORÇ */ ) AS orjDovizBorc,
                        SUM([msg_S_0110\T] /* ORJ. DÖVİZ ALACAK */ ) AS orjDovizAlacak
                        FROM dbo.fn_CariTutarlar('0',0, @cariKodu,0,NULL,NULL,N'','','')
                        WHERE (([msg_S_0118] /* SRM.MRK.KODU */ =0) OR
                        (([msg_S_0118] /* SRM.MRK.KODU */ =0) AND (''=dbo.fn_GetResource('M',430,DEFAULT))) OR
                        (0='') OR
                        (0='TOPLAM'))
                        AND
                        (([msg_S_0116] /* PROJE KODU */ =0) OR
                        (([msg_S_0116] /* PROJE KODU */ ='') AND (0=dbo.fn_GetResource('M',430,DEFAULT))) OR
                        (0='') OR
                        (0='TOPLAM'))";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cariKodu", cariKodu);
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
