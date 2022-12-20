using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAPI1.Models;

namespace WebAPI1.Controllers.CariPersonelTanimlariController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CariPersonelTanimlariController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CariPersonelTanimlariController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetPersonel(int tipi)
        {
            string query = @"SELECT TOP 100 PERCENT
                            cari_per_kod AS cari_personel_kodu /* CARİ PERSONEL KODU */ ,
                            cari_per_adi AS cari_personel_adi /* CARİ PERSONEL ADI */ ,
                            cari_per_soyadi AS cari_personel_soyadi /* CARİ PERSONEL SOYADI */,
                            cari_per_kasiyerkodu AS kasiyer /* KASİYER */,
                            cari_per_tip AS personelTipi /* Personel Tipi */
                            FROM dbo.CARI_PERSONEL_TANIMLARI WITH (NOLOCK)
                             WHERE (cari_per_tip=@tipi) ORDER BY cari_per_kod";
            // cari_per_tip == 	0:Satıcı Eleman 1:Satın Almacı 2:Diğer Eleman
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@tipi", tipi);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }


        //   [HttpPost]
        //   public JsonResult SaveCariPersonel([FromBody] CariPersonelTanimlari personel)
        //   {
        //       string query = @"
        //       USE [MikroDB_V16_2022]
        //       GO
        //       INSERT INTO [dbo].[CARI_PERSONEL_TANIMLARI]
        //      (
        //      [cari_per_DBCno]
        //      ,[cari_per_SpecRECno]
        //      ,[cari_per_iptal]
        //      ,[cari_per_fileid]
        //      ,[cari_per_hidden]
        //      ,[cari_per_kilitli]
        //      ,[cari_per_degisti]
        //      ,[cari_per_checksum]
        //      ,[cari_per_create_user]
        //      ,[cari_per_create_date]
        //      ,[cari_per_lastup_user]
        //      ,[cari_per_lastup_date]
        //      ,[cari_per_special1]
        //      ,[cari_per_special2]
        //      ,[cari_per_special3]
        //      ,[cari_per_kod]
        //      ,[cari_per_adi]
        //      ,[cari_per_soyadi]
        //      ,[cari_per_tip]
        //      ,[cari_per_doviz_cinsi]
        //      ,[cari_per_muhkod0]
        //      ,[cari_per_muhkod1]
        //      ,[cari_per_muhkod2]
        //      ,[cari_per_muhkod3]
        //      ,[cari_per_muhkod4]
        //      ,[cari_per_banka_tcmb_kod]
        //      ,[cari_per_banka_tcmb_subekod]
        //      ,[cari_per_banka_tcmb_ilkod]
        //      ,[cari_per_banka_hesapno]
        //      ,[cari_per_banka_swiftkodu]
        //      ,[cari_per_prim_adet]
        //      ,[cari_per_prim_yuzde]
        //      ,[cari_per_prim_carpani]
        //      ,[cari_per_basmprimcirotav1]
        //      ,[cari_per_basmprimyuz1]
        //      ,[cari_per_basmprimcirotav2]
        //      ,[cari_per_basmprimyuz2]
        //      ,[cari_per_basmprimcirotav3]
        //      ,[cari_per_basmprimyuz3]
        //      ,[cari_per_basmprimcirotav4]
        //      ,[cari_per_basmprimyuz4]
        //      ,[cari_per_basmprimcirotav5]
        //      ,[cari_per_basmprimyuz5]
        //      ,[cari_per_kasiyerkodu]
        //      ,[cari_per_kasiyersifresi]
        //      ,[cari_per_kasiyerAmiri]
        //      ,[cari_per_userno]
        //      ,[cari_per_depono]
        //      ,[cari_per_cepno]
        //      ,[cari_per_mail]
        //      ,[cari_takvim_kodu]
        //      ,[cari_per_kasiyerfirmaid]
        //      ,[cari_per_KEP_adresi]
        //      ,[cari_per_TcKimlikNo])
        //VALUES
        //      (
        //      @cari_per_DBCno,
        //      @cari_per_SpecRECno, 
        //      @cari_per_iptal,
        //      @cari_per_fileid, 
        //      @cari_per_hidden,
        //      @cari_per_kilitli, 
        //      @cari_per_degisti, 
        //      @cari_per_checksum, 
        //      @cari_per_create_user,
        //      @cari_per_create_date,
        //      @cari_per_lastup_user,
        //      @cari_per_lastup_date,
        //      @cari_per_special1,
        //      @cari_per_special2,
        //      @cari_per_special3,
        //      @cari_per_kod,
        //      @cari_per_adi,
        //      @cari_per_soyadi, 
        //      @cari_per_tip,
        //      @cari_per_doviz_cinsi,
        //      @cari_per_muhkod0,
        //      @cari_per_muhkod1,
        //      @cari_per_muhkod2,
        //      @cari_per_muhkod3,
        //      @cari_per_muhkod4,
        //      @cari_per_banka_tcmb_kod, 
        //      @cari_per_banka_tcmb_subekod,
        //      @cari_per_banka_tcmb_ilkod,
        //      @cari_per_banka_hesapno, 
        //      @cari_per_banka_swiftkodu,
        //      @cari_per_prim_adet, 
        //      @cari_per_prim_yuzde,
        //      @cari_per_prim_carpani,
        //      @cari_per_basmprimcirotav1,
        //      @cari_per_basmprimyuz1,
        //      @cari_per_basmprimcirotav2,
        //      @cari_per_basmprimyuz2,
        //      @cari_per_basmprimcirotav3,
        //      @cari_per_basmprimyuz3,
        //      @cari_per_basmprimcirotav4,
        //      @cari_per_basmprimyuz4,
        //      @cari_per_basmprimcirotav5,
        //      @cari_per_basmprimyuz5,
        //      @cari_per_kasiyerkodu,
        //      @cari_per_kasiyersifresi,
        //      @cari_per_kasiyerAmiri,
        //      @cari_per_userno,
        //      @cari_per_depono,
        //      @cari_per_cepno,
        //      @cari_per_mail,
        //      @cari_takvim_kodu,
        //      @cari_per_kasiyerfirmaid,
        //      @cari_per_KEP_adresi,
        //      @cari_per_TcKimlikNo)";
        //       DataTable table = new DataTable();
        //       string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
        //       SqlDataReader myReader;
        //       using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        //       {
        //           myCon.Open();
        //           using (SqlCommand myCommand = new SqlCommand(query, myCon))
        //           {
        //               try
        //               {
        //                   myCommand.Parameters.AddWithValue("@cari_per_DBCno", personel.CariPerDbCno);
        //                   myCommand.Parameters.AddWithValue("@cari_per_SpecRECno", personel.CariPerSpecReCno);
        //                   myCommand.Parameters.AddWithValue("@cari_per_iptal", personel.CariPerIptal);
        //                   myCommand.Parameters.AddWithValue("@cari_per_fileid", personel.CariPerFileid);
        //                   myCommand.Parameters.AddWithValue("@cari_per_hidden", personel.CariPerHidden);
        //                   myCommand.Parameters.AddWithValue("@cari_per_kilitli", personel.CariPerKilitli);
        //                   myCommand.Parameters.AddWithValue("@cari_per_degisti", personel.CariPerDegisti);
        //                   myCommand.Parameters.AddWithValue("@cari_per_checksum", personel.CariPerChecksum);
        //                   myCommand.Parameters.AddWithValue("@cari_per_create_user", personel.CariPerCreateUser);
        //                   myCommand.Parameters.AddWithValue("@cari_per_create_date", personel.CariPerCreateDate);
        //                   myCommand.Parameters.AddWithValue("@cari_per_lastup_user", personel.CariPerLastupUser);
        //                   myCommand.Parameters.AddWithValue("@cari_per_lastup_date", personel.CariPerLastupDate);
        //                   myCommand.Parameters.AddWithValue("@cari_per_special1", personel.CariPerSpecial1);
        //                   myCommand.Parameters.AddWithValue("@cari_per_special2", personel.CariPerSpecial2);
        //                   myCommand.Parameters.AddWithValue("@cari_per_special3", personel.CariPerSpecial3);
        //                   myCommand.Parameters.AddWithValue("@cari_per_kod", personel.CariPerKod);
        //                   myCommand.Parameters.AddWithValue("@cari_per_adi", personel.CariPerAdi);
        //                   myCommand.Parameters.AddWithValue("@cari_per_soyadi", personel.CariPerSoyadi);
        //                   myCommand.Parameters.AddWithValue("@cari_per_tip", personel.CariPerTip);
        //                   myCommand.Parameters.AddWithValue("@cari_per_doviz_cinsi", personel.CariPerDovizCinsi);
        //                   myCommand.Parameters.AddWithValue("@cari_per_muhkod0", personel.CariPerMuhkod0);
        //                   myCommand.Parameters.AddWithValue("@cari_per_muhkod1", personel.CariPerMuhkod1);
        //                   myCommand.Parameters.AddWithValue("@cari_per_muhkod2", personel.CariPerMuhkod2);
        //                   myCommand.Parameters.AddWithValue("@cari_per_muhkod3", personel.CariPerMuhkod3);
        //                   myCommand.Parameters.AddWithValue("@cari_per_muhkod4", personel.CariPerMuhkod4);
        //                   myCommand.Parameters.AddWithValue("@cari_per_banka_tcmb_kod", personel.CariPerBankaTcmbKod);
        //                   myCommand.Parameters.AddWithValue("@cari_per_banka_tcmb_subekod", personel.CariPerBankaTcmbSubekod);
        //                   myCommand.Parameters.AddWithValue("@cari_per_banka_tcmb_ilkod", personel.CariPerBankaTcmbIlkod);
        //                   myCommand.Parameters.AddWithValue("@cari_per_banka_hesapno", personel.CariPerBankaHesapno);
        //                   myCommand.Parameters.AddWithValue("@cari_per_banka_swiftkodu", personel.CariPerBankaSwiftkodu);
        //                   myCommand.Parameters.AddWithValue("@cari_per_prim_adet", personel.CariPerPrimAdet);
        //                   myCommand.Parameters.AddWithValue("@cari_per_prim_yuzde", personel.CariPerPrimYuzde);
        //                   myCommand.Parameters.AddWithValue("@cari_per_prim_carpani", personel.CariPerPrimCarpani);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimcirotav1", personel.CariPerBasmprimcirotav1);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimyuz1", personel.CariPerBasmprimyuz1);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimcirotav2", personel.CariPerBasmprimcirotav2);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimyuz2", personel.CariPerBasmprimyuz2);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimcirotav3", personel.CariPerBasmprimcirotav3);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimyuz3", personel.CariPerBasmprimyuz3);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimcirotav4", personel.CariPerBasmprimcirotav4);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimyuz4", personel.CariPerBasmprimyuz4);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimcirotav5", personel.CariPerBasmprimcirotav5);
        //                   myCommand.Parameters.AddWithValue("@cari_per_basmprimyuz5", personel.CariPerBasmprimyuz5);
        //                   myCommand.Parameters.AddWithValue("@cari_per_kasiyerkodu", personel.CariPerKasiyerkodu);
        //                   myCommand.Parameters.AddWithValue("@cari_per_kasiyersifresi", personel.CariPerKasiyersifresi);
        //                   myCommand.Parameters.AddWithValue("@cari_per_kasiyerAmiri", personel.CariPerKasiyerAmiri);
        //                   myCommand.Parameters.AddWithValue("@cari_per_userno", personel.CariPerUserno);
        //                   myCommand.Parameters.AddWithValue("@cari_per_depono", personel.CariPerDepono);
        //                   myCommand.Parameters.AddWithValue("@cari_per_cepno", personel.CariPerCepno);
        //                   myCommand.Parameters.AddWithValue("@cari_per_mail", personel.CariPerMail);
        //                   myCommand.Parameters.AddWithValue("@cari_takvim_kodu", personel.CariTakvimKodu);
        //                   myCommand.Parameters.AddWithValue("@cari_per_kasiyerfirmaid", personel.CariPerKasiyerfirmaid);
        //                   myCommand.Parameters.AddWithValue("@cari_per_KEP_adresi", personel.CariPerKepAdresi);
        //                   myCommand.Parameters.AddWithValue("@cari_per_TcKimlikNo", personel.CariPerTcKimlikNo);
        //                   myReader = myCommand.ExecuteReader();
        //                   table.Load(myReader);
        //                   myReader.Close();
        //                   myCon.Close();
        //               }
        //               catch (Exception ex)
        //               {
        //                   return new JsonResult(BadRequest(StatusCodes.Status500InternalServerError), ex);
        //               }

        //           }
        //       }
        //       return new JsonResult(table);
        //   }



    }
}
