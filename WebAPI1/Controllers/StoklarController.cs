﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoklarController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StoklarController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetWithCode()
        {
            string query = @"SELECT TOP 100 PERCENT 
                            sto_kod AS StokKodu /* KODU */,
                            sto_isim AS StokIsim /* ADI */,
                            ISNULL(sfiyat_fiyati,0) AS StokFiyat /* FİYAT */,
                            Kur_adi AS StokKur /* DVZ */,
                            sto_anagrup_kod AS StokAnaGrup,
                            sto_sektor_kodu AS StokSektor,
                            sto_birim1_ad AS StokBirim1, 
                            sto_birim3_ad AS StokBirim3,
                            sto_birim3_katsayi AS StokBirim3_katsayi,
                            sto_reyon_kodu AS StokReyon,
                            sto_marka_kodu AS StokMarka,
                            sto_model_kodu AS StokModel,
                            dbo.fn_DepodakiMiktar(sto_kod,1,0) AS [MERKEZ], 
                            dbo.fn_EldekiMiktar(sto_kod) AS StokMiktar /* MİKTAR */ 
                            FROM dbo.STOKLAR 
                            LEFT OUTER JOIN dbo.STOK_SATIS_FIYATLARI_F1_D0_VIEW on sfiyat_stokkod = sto_kod AND sfiyat_satirno = 1 
                            LEFT OUTER JOIN MikroDB_V16.dbo.KUR_ISIMLERI on Kur_No =  ISNULL(sfiyat_doviz,0)
                            ORDER BY sto_kod 
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
        [HttpGet("orderbyName")]
        public JsonResult GetWithName()
        {
            string query = @"SELECT TOP 100 PERCENT 
                            sto_kod AS StokKodu /* KODU */,
                            sto_isim AS StokIsim /* ADI */,
                            ISNULL(sfiyat_fiyati,0) AS StokFiyat /* FİYAT */,
                            Kur_adi AS StokKur /* DVZ */,
                            dbo.fn_EldekiMiktar(sto_kod) AS StokMiktar /* MİKTAR */,
                            sto_anagrup_kod AS StokAnaGrup,
                            sto_sektor_kodu AS StokSektor,
                            sto_birim1_ad AS StokBirim1,
                            sto_birim3_ad AS StokBirim3,
                            sto_birim3_katsayi AS StokBirim3_katsayi,
                            sto_reyon_kodu AS StokReyon,
                            sto_marka_kodu AS StokMarka,
                            sto_model_kodu AS StokModel
                            FROM STOKLAR WITH (NOLOCK)
                            LEFT OUTER JOIN dbo.STOK_SATIS_FIYATLARI_F1_D0_VIEW on sfiyat_stokkod = sto_kod AND sfiyat_satirno = 1
                            LEFT OUTER JOIN MikroDB_V16.dbo.KUR_ISIMLERI on Kur_No =  ISNULL(sfiyat_doviz,0)
                            ORDER BY sto_isim
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
