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
        public JsonResult AlisFiyatlari(Stok stok)
        {
            string query = @"
                             Select TOP 100 PERCENT
                             [msg_S_0089] AS Tarih,
                             [msg_S_0200] AS CariKodu,
                             [msg_S_0201] AS CariAdi,
                             [msg_S_0165\T] AS Miktar,
                             [msg_S_0166] AS BirimAdi,
                             [msg_S_0180\O] AS BrutBirimFiyati,
                             [msg_S_0181\O] AS NetBirimFiyati,
                             [msg_S_0182] AS BrutTutar
                             FROM fn_StokFoy(@stokKodu,'20211231','20220101','20221231',0,N',1,')
                             WHERE [msg_S_0094] = 'Çıkış Faturası' AND [msg_S_0097] ='Normal' ORDER BY Tarih DESC
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
