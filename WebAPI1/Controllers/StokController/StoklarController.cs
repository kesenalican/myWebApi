using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAPI1.Controllers.StokController
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
        public JsonResult GetWithCode(int offset)
        {
            string query = @"							SELECT  
							BARKOD_TANIMLARI.bar_kodu AS barkodu,
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
                            sto_model_kodu AS StokModel,
							CASE 
							WHEN sto_perakende_vergi = 2 Then dbo.fn_VergiIsim(2)
							WHEN sto_perakende_vergi = 3 Then dbo.fn_VergiIsim(3)
							WHEN sto_perakende_vergi = 4 Then  dbo.fn_VergiIsim(4)
							END AS PerakendeVergiIsim,
							CASE 
							WHEN sto_perakende_vergi = 2 Then dbo.fn_VergiYuzde(2)
							WHEN sto_perakende_vergi = 3 Then dbo.fn_VergiYuzde(3)
							WHEN sto_perakende_vergi = 4 Then dbo.fn_VergiYuzde(4)
							END AS PerakendeVergiYuzde,
							CASE 
							WHEN sto_toptan_vergi = 2 Then dbo.fn_VergiIsim(2)
							WHEN sto_toptan_vergi = 3 Then dbo.fn_VergiIsim(3)
							WHEN sto_toptan_vergi = 4 Then dbo.fn_VergiIsim(4)
							END AS ToptanVergiIsim,
							CASE 
							WHEN sto_toptan_vergi = 2 Then dbo.fn_VergiYuzde(2)
							WHEN sto_toptan_vergi = 3 Then dbo.fn_VergiYuzde(3)
							WHEN sto_toptan_vergi = 4 Then dbo.fn_VergiYuzde(4)
							END AS ToptanVergiYuzde
                            FROM STOKLAR WITH (NOLOCK)
							INNER JOIN BARKOD_TANIMLARI ON BARKOD_TANIMLARI.bar_stokkodu = STOKLAR.sto_kod
                            LEFT OUTER JOIN dbo.STOK_SATIS_FIYATLARI_F1_D0_VIEW on sfiyat_stokkod = sto_kod AND sfiyat_satirno = 1
                            LEFT OUTER JOIN MikroDB_V16.dbo.KUR_ISIMLERI on Kur_No =  ISNULL(sfiyat_doviz,0)
                            ORDER BY sto_kod
                            OFFSET @offset ROWS FETCH NEXT 20 ROWS ONLY
                             ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    //myCommand.Parameters.AddWithValue("@pageCount", page.Page);
                    myCommand.Parameters.AddWithValue("@offset", offset);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet("barcode")]
        public JsonResult GetWithBarcode(string barcode)
        {
            string query = @"							SELECT  
							BARKOD_TANIMLARI.bar_kodu AS barkodu,
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
                            sto_model_kodu AS StokModel,
							CASE 
							WHEN sto_perakende_vergi = 2 Then dbo.fn_VergiIsim(2)
							WHEN sto_perakende_vergi = 3 Then dbo.fn_VergiIsim(3)
							WHEN sto_perakende_vergi = 4 Then  dbo.fn_VergiIsim(4)
							END AS PerakendeVergiIsim,
							CASE 
							WHEN sto_perakende_vergi = 2 Then dbo.fn_VergiYuzde(2)
							WHEN sto_perakende_vergi = 3 Then dbo.fn_VergiYuzde(3)
							WHEN sto_perakende_vergi = 4 Then dbo.fn_VergiYuzde(4)
							END AS PerakendeVergiYuzde,
							CASE 
							WHEN sto_toptan_vergi = 2 Then dbo.fn_VergiIsim(2)
							WHEN sto_toptan_vergi = 3 Then dbo.fn_VergiIsim(3)
							WHEN sto_toptan_vergi = 4 Then dbo.fn_VergiIsim(4)
							END AS ToptanVergiIsim,
							CASE 
							WHEN sto_toptan_vergi = 2 Then dbo.fn_VergiYuzde(2)
							WHEN sto_toptan_vergi = 3 Then dbo.fn_VergiYuzde(3)
							WHEN sto_toptan_vergi = 4 Then dbo.fn_VergiYuzde(4)
							END AS ToptanVergiYuzde
                            FROM STOKLAR WITH (NOLOCK)
							INNER JOIN BARKOD_TANIMLARI ON BARKOD_TANIMLARI.bar_stokkodu = STOKLAR.sto_kod
                            LEFT OUTER JOIN dbo.STOK_SATIS_FIYATLARI_F1_D0_VIEW on sfiyat_stokkod = sto_kod AND sfiyat_satirno = 1
                            LEFT OUTER JOIN MikroDB_V16.dbo.KUR_ISIMLERI on Kur_No =  ISNULL(sfiyat_doviz,0)
                            WHERE BARKOD_TANIMLARI.bar_kodu=@barcode
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
                    myCommand.Parameters.AddWithValue("@barcode", barcode);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
        [HttpGet("search")]
        public JsonResult SearchStok()
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



    }
}
