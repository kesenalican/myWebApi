using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAPI1.Models;

namespace WebAPI1.Controllers.Cariler
{
    [ApiController]
    [Route("api/[controller]")]
    public class CariAdresController : ControllerBase
    {
      private readonly IConfiguration _configuration;
        
      public CariAdresController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult GetAdres(string cariKod)
        {
            string query = @"SELECT TOP 100 PERCENT *  FROM CARI_HESAP_ADRESLERI WHERE adr_cari_kod =@cariKod";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@cariKod", cariKod);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult SaveAdres([FromBody] CariAdresModel cariAdres)
        {
            string query = @"INSERT INTO MikroDB_V16_2022.dbo.CARI_HESAP_ADRESLERI (adr_DBCno,adr_SpecRECno,adr_iptal,adr_fileid,adr_hidden,adr_kilitli,adr_degisti,adr_checksum,
            adr_create_user,adr_create_date,adr_lastup_user,adr_lastup_date,adr_special1,adr_special2,adr_special3,adr_cari_kod,adr_adres_no,adr_aprint_fl,
            adr_cadde,adr_mahalle,adr_sokak,adr_Semt,adr_Apt_No,adr_Daire_No,adr_posta_kodu,adr_ilce,adr_il,adr_ulke,adr_Adres_kodu,adr_tel_ulke_kodu,adr_tel_bolge_kodu,
            adr_tel_no1,adr_tel_no2,adr_tel_faxno,adr_tel_modem,adr_yon_kodu,adr_uzaklik_kodu,adr_temsilci_kodu,adr_ozel_not,adr_ziyaretperyodu,adr_ziyaretgunu,

            adr_gps_enlem,adr_gps_boylam,adr_ziyarethaftasi,adr_ziygunu2_1,adr_ziygunu2_2,adr_ziygunu2_3,adr_ziygunu2_4,adr_ziygunu2_5,adr_ziygunu2_6,adr_ziygunu2_7,
            adr_efatura_alias,adr_eirsaliye_alias)
            VALUES(
            @adr_DBCno,@adr_SpecRECno,@adr_iptal,@adr_fileid,@adr_hidden,@adr_kilitli,@adr_degisti,@adr_checksum,
            @adr_create_user,@adr_create_date,@adr_lastup_user,@adr_lastup_date,@adr_special1,@adr_special2,@adr_special3,@adr_cari_kod,@adr_adres_no,@adr_aprint_fl,
            @adr_cadde,@adr_mahalle,@adr_sokak,@adr_Semt,@adr_Apt_No,@adr_Daire_No,@adr_posta_kodu,@adr_ilce,@adr_il,@adr_ulke,@adr_Adres_kodu,@adr_tel_ulke_kodu,@adr_tel_bolge_kodu,
            @adr_tel_no1,@adr_tel_no2,@adr_tel_faxno,@adr_tel_modem,@adr_yon_kodu,@adr_uzaklik_kodu,@adr_temsilci_kodu,@adr_ozel_not,@adr_ziyaretperyodu,@adr_ziyaretgunu,
            @adr_gps_enlem,@adr_gps_boylam,@adr_ziyarethaftasi,@adr_ziygunu2_1,@adr_ziygunu2_2,@adr_ziygunu2_3,@adr_ziygunu2_4,@adr_ziygunu2_5,@adr_ziygunu2_6,@adr_ziygunu2_7,
            @adr_efatura_alias,@adr_eirsaliye_alias
            )";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@adr_DBCno",cariAdres.AdrDbCno);
                    myCommand.Parameters.AddWithValue("@adr_SpecRECno", cariAdres.AdrSpecReCno);
                    myCommand.Parameters.AddWithValue("@adr_iptal", cariAdres.AdrIptal);
                    myCommand.Parameters.AddWithValue("@adr_fileid", cariAdres.AdrFileid);
                    myCommand.Parameters.AddWithValue("@adr_hidden", cariAdres.AdrHidden);
                    myCommand.Parameters.AddWithValue("@adr_kilitli", cariAdres.AdrKilitli);
                    myCommand.Parameters.AddWithValue("@adr_degisti", cariAdres.AdrDegisti);
                    myCommand.Parameters.AddWithValue("@adr_checksum", cariAdres.AdrChecksum);
                    myCommand.Parameters.AddWithValue("@adr_create_user", cariAdres.AdrCreateUser);
                    myCommand.Parameters.AddWithValue("@adr_create_date", cariAdres.AdrCreateDate);
                    myCommand.Parameters.AddWithValue("@adr_lastup_user", cariAdres.AdrLastupUser);
                    myCommand.Parameters.AddWithValue("@adr_lastup_date", cariAdres.AdrLastupDate);
                    myCommand.Parameters.AddWithValue("@adr_special1", cariAdres.AdrSpecial1);
                    myCommand.Parameters.AddWithValue("@adr_special2", cariAdres.AdrSpecial2);
                    myCommand.Parameters.AddWithValue("@adr_special3", cariAdres.AdrSpecial3);
                    myCommand.Parameters.AddWithValue("@adr_cari_kod", cariAdres.AdrCariKod);
                    myCommand.Parameters.AddWithValue("@adr_adres_no", cariAdres.AdrAdresNo);
                    myCommand.Parameters.AddWithValue("@adr_aprint_fl", cariAdres.AdrAprintFl);
                    myCommand.Parameters.AddWithValue("@adr_cadde", cariAdres.AdrCadde);
                    myCommand.Parameters.AddWithValue("@adr_mahalle", cariAdres.AdrMahalle);
                    myCommand.Parameters.AddWithValue("@adr_sokak", cariAdres.AdrSokak);
                    myCommand.Parameters.AddWithValue("@adr_Semt", cariAdres.AdrSemt);
                    myCommand.Parameters.AddWithValue("@adr_Apt_No", cariAdres.AdrAptNo);
                    myCommand.Parameters.AddWithValue("@adr_Daire_No", cariAdres.AdrDaireNo);
                    myCommand.Parameters.AddWithValue("@adr_posta_kodu", cariAdres.AdrPostaKodu);
                    myCommand.Parameters.AddWithValue("@adr_ilce", cariAdres.AdrIlce);
                    myCommand.Parameters.AddWithValue("@adr_il", cariAdres.AdrIl);
                    myCommand.Parameters.AddWithValue("@adr_ulke", cariAdres.AdrUlke);
                    myCommand.Parameters.AddWithValue("@adr_Adres_kodu", cariAdres.AdrAdresKodu);
                    myCommand.Parameters.AddWithValue("@adr_tel_ulke_kodu", cariAdres.AdrTelUlkeKodu);
                    myCommand.Parameters.AddWithValue("@adr_tel_bolge_kodu", cariAdres.AdrTelBolgeKodu);
                    myCommand.Parameters.AddWithValue("@adr_tel_no1", cariAdres.AdrTelNo1);
                    myCommand.Parameters.AddWithValue("@adr_tel_no2", cariAdres.AdrTelNo2);
                    myCommand.Parameters.AddWithValue("@adr_tel_faxno", cariAdres.AdrTelFaxno);
                    myCommand.Parameters.AddWithValue("@adr_tel_modem", cariAdres.AdrTelModem);
                    myCommand.Parameters.AddWithValue("@adr_yon_kodu", cariAdres.AdrYonKodu);
                    myCommand.Parameters.AddWithValue("@adr_uzaklik_kodu", cariAdres.AdrUzaklikKodu);
                    myCommand.Parameters.AddWithValue("@adr_temsilci_kodu", cariAdres.AdrTemsilciKodu);
                    myCommand.Parameters.AddWithValue("@adr_ozel_not", cariAdres.AdrOzelNot);
                    myCommand.Parameters.AddWithValue("@adr_ziyaretperyodu", cariAdres.AdrZiyaretperyodu);
                    myCommand.Parameters.AddWithValue("@adr_ziyaretgunu", cariAdres.AdrZiyaretgunu);
                    myCommand.Parameters.AddWithValue("@adr_gps_enlem", cariAdres.AdrGpsEnlem);
                    myCommand.Parameters.AddWithValue("@adr_gps_boylam", cariAdres.AdrGpsBoylam);
                    myCommand.Parameters.AddWithValue("@adr_ziyarethaftasi", cariAdres.AdrZiyarethaftasi);
                    myCommand.Parameters.AddWithValue("@adr_ziygunu2_1", cariAdres.AdrZiygunu21);
                    myCommand.Parameters.AddWithValue("@adr_ziygunu2_2", cariAdres.AdrZiygunu22);
                    myCommand.Parameters.AddWithValue("@adr_ziygunu2_3", cariAdres.AdrZiygunu23);
                    myCommand.Parameters.AddWithValue("@adr_ziygunu2_4", cariAdres.AdrZiygunu24);
                    myCommand.Parameters.AddWithValue("@adr_ziygunu2_5", cariAdres.AdrZiygunu25);
                    myCommand.Parameters.AddWithValue("@adr_ziygunu2_6", cariAdres.AdrZiygunu26);
                    myCommand.Parameters.AddWithValue("@adr_ziygunu2_7", cariAdres.AdrZiygunu27);
                    myCommand.Parameters.AddWithValue("@adr_efatura_alias", cariAdres.AdrEfaturaAlias);
                    myCommand.Parameters.AddWithValue("@adr_eirsaliye_alias", cariAdres.AdrEirsaliyeAlias);
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
