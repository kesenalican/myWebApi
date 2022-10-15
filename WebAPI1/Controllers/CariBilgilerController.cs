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
            string query = @"SELECT TOP 100 PERCENT

                cari_kod AS CariKodu /* CARI KODU */ ,
                cari_unvan1 AS CariUnvani1 ,
                cari_unvan2 AS CariUnvani2,
                cari_vdaire_adi AS CariVDaireAdi,
                cari_vdaire_no AS CariVDaireNo,
                cari_EMail AS CariEmail,
                cari_CepTel AS CariCepTel,

                CASE
                WHEN Cari_F10da_detay = 1 Then dbo.fn_CariHesapAnaDovizBakiye('',0,cari_kod,'','',NULL,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 2 Then dbo.fn_CariHesapAlternatifDovizBakiye('',0,cari_kod,'','',NULL,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 3 Then dbo.fn_CariHesapOrjinalDovizBakiye('',0,cari_kod,'','',0,NULL,NULL,0,MusteriTeminatMektubu_Bakiyeyi_Etkilemesin_fl,FirmaTeminatMektubu_Bakiyeyi_Etkilemesin_fl,DepozitoCeki_Bakiyeyi_Etkilemesin_fl,DepozitoSenedi_Bakiyeyi_Etkilemesin_fl)
                WHEN Cari_F10da_detay = 4 Then dbo.fn_CariHareketSayisi(0,cari_kod,'')
                END AS CariBakiye /* BAKİYE / HAREKET SAYISI */ 
                FROM dbo.CARI_HESAPLAR
                LEFT OUTER JOIN dbo.vw_Gendata ON 1=1
                ORDER BY cari_kod

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
