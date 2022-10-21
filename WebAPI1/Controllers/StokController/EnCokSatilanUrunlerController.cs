using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using WebAPI1.Models;

namespace WebAPI1.Controllers.StokController
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnCokSatilanUrunlerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EnCokSatilanUrunlerController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpPost]
        public JsonResult GetTopProduct(Tarih baslangic)
        {
            //EN ÇOK SATILAN 10 ÜRÜN (DEĞER BAZLI)
            string query = @"SELECT TOP 20
                            sth_stok_kod  as STOKKODU,
                            SUM ( Case         
                            When (sth_cins in (9,15)) THEN 0         
                            Else          CASE           
                            WHEN sth_normal_iade=0 THEN sth_miktar            
                            ELSE (-1) * sth_miktar          END        END) as MIKTAR,
                            sum(case when sth_normal_iade=0 then 
                            dbo.fn_StokHareketNetDeger ( sth_tutar,sth_iskonto1,sth_iskonto2,sth_iskonto3
                            ,sth_iskonto4,sth_iskonto5,sth_iskonto6, sth_masraf1,sth_masraf2,sth_masraf3
                            ,sth_masraf4,sth_otvtutari,sth_oivtutari,sth_tip,0,sth_har_doviz_kuru,
                            sth_alt_doviz_kuru,sth_stok_doviz_kuru) else dbo.fn_StokHareketNetDeger 
                            ( sth_tutar,sth_iskonto1,sth_iskonto2,sth_iskonto3,sth_iskonto4,sth_iskonto5,sth_iskonto6,
                            sth_masraf1,sth_masraf2,sth_masraf3,sth_masraf4,sth_otvtutari,sth_oivtutari,sth_tip,0,sth_har_doviz_kuru,
                            sth_alt_doviz_kuru,sth_stok_doviz_kuru)*(-1) end ) as DEGER from 
                            STOK_HAREKETLERI 
                            left outer join STOKLAR on  (sto_kod=sth_stok_kod) where (sth_tarih>=@baslangic) AND 
                            (sth_tarih<=GETDATE()) AND ( ( (sth_tip=1) AND (sth_normal_iade=0)) OR ( (sth_tip=0) AND (sth_normal_iade=1)) )
                            AND ((1=0) OR (sth_evraktip=13) OR (sth_evraktip=1) OR (sth_evraktip=3) OR (sth_evraktip=4)) group by sth_stok_kod order by DEGER DESC
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@baslangic",baslangic.BaslangicTarihi);
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
