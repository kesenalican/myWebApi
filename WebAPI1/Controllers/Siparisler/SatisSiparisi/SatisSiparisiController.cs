using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebAPI1.Models;

namespace WebAPI1.Controllers.Siparisler.SatisSiparisi
{
    [Route("api/[controller]")]
    [ApiController]
    public class SatisSiparisiController : Controller
    {
        private readonly IConfiguration _configuration;
        public SatisSiparisiController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        [HttpGet]
        public JsonResult GetWithCode()
        {
            string query = @"SELECT * FROM SIPARISLER";
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

        [HttpPost]
        public JsonResult SetSatisSiparisi(Siparis siparisler)
        {
            string query = @"INSERT INTO MikroDB_V16_2022.dbo.SIPARISLER 
                            (sip_DBCno,sip_SpecRECno,sip_iptal,sip_fileid,sip_hidden,sip_kilitli,sip_degisti,sip_checksum,sip_create_user,
                            sip_create_date,sip_lastup_user,sip_lastup_date,sip_special1,sip_special2,sip_special3,
                            sip_firmano,sip_subeno,sip_tarih,sip_teslim_tarih,sip_tip,sip_cins,
                            sip_evrakno_seri,sip_evrakno_sira,sip_satirno,sip_belgeno,
                            sip_belge_tarih,sip_satici_kod,sip_musteri_kod,sip_stok_kod,sip_b_fiyat,sip_miktar,sip_birim_pntr,
                            sip_teslim_miktar,sip_tutar,sip_iskonto_1,sip_iskonto_2,sip_iskonto_3,sip_iskonto_4,sip_iskonto_5,
                            sip_iskonto_6,sip_masraf_1,sip_masraf_2,sip_masraf_3,sip_masraf_4,sip_vergi_pntr,sip_vergi,
                            sip_masvergi_pntr,sip_masvergi,sip_opno,sip_aciklama,sip_aciklama2,sip_depono,sip_OnaylayanKulNo,
                            sip_vergisiz_fl,sip_kapat_fl,sip_promosyon_fl,sip_cari_sormerk,sip_stok_sormerk,sip_cari_grupno,
                            sip_doviz_cinsi,sip_doviz_kuru,sip_alt_doviz_kuru,sip_adresno,sip_teslimturu,sip_cagrilabilir_fl
                            ,sip_iskonto1,sip_iskonto2,sip_iskonto3,sip_iskonto4,sip_iskonto5,sip_iskonto6,
                            sip_masraf1,sip_masraf2,sip_masraf3,sip_masraf4,sip_isk1,sip_isk2,sip_isk3,sip_isk4,sip_isk5,
                            sip_isk6,sip_mas1,sip_mas2,sip_mas3,sip_mas4,sip_Exp_Imp_Kodu,sip_kar_orani,sip_durumu,
                            sip_planlananmiktar,sip_parti_kodu,sip_lot_no,sip_projekodu,sip_fiyat_liste_no,
                            sip_Otv_Pntr,sip_Otv_Vergi,sip_otvtutari,sip_OtvVergisiz_Fl,sip_paket_kod,sip_harekettipi,
                            sip_kapatmanedenkod,sip_gecerlilik_tarihi,sip_onodeme_evrak_tip,sip_onodeme_evrak_seri,
                            sip_onodeme_evrak_sira,sip_rezervasyon_miktari,sip_rezerveden_teslim_edilen,sip_HareketGrupKodu1,
                            sip_HareketGrupKodu2,sip_HareketGrupKodu3,sip_Olcu1,sip_Olcu2,sip_Olcu3,sip_Olcu4,sip_Olcu5,sip_FormulMiktarNo,
                            sip_FormulMiktar,sip_satis_fiyat_doviz_cinsi,sip_satis_fiyat_doviz_kuru,sip_eticaret_kanal_kodu) 
                            VALUES(
                            @sip_DBCno,@sip_SpecRECno,@sip_iptal,@sip_fileid,@sip_hidden,@sip_kilitli,@sip_degisti,@sip_checksum,@sip_create_user,
                            @sip_create_date,@sip_lastup_user,@sip_lastup_date,@sip_special1,@sip_special2,@sip_special3,
                            @sip_firmano,@sip_subeno,@sip_tarih,@sip_teslim_tarih,@sip_tip,@sip_cins,
                            @sip_evrakno_seri,@sip_evrakno_sira,@sip_satirno,@sip_belgeno,
                            @sip_belge_tarih,@sip_satici_kod,@sip_musteri_kod,@sip_stok_kod,@sip_b_fiyat,@sip_miktar,@sip_birim_pntr,
                            @sip_teslim_miktar,@sip_tutar,@sip_iskonto_1,@sip_iskonto_2,@sip_iskonto_3,@sip_iskonto_4,@sip_iskonto_5,
                            @sip_iskonto_6,@sip_masraf_1,@sip_masraf_2,@sip_masraf_3,@sip_masraf_4,@sip_vergi_pntr,@sip_vergi,
                            @sip_masvergi_pntr,@sip_masvergi,@sip_opno,@sip_aciklama,@sip_aciklama2,@sip_depono,@sip_OnaylayanKulNo,
                            @sip_vergisiz_fl,@sip_kapat_fl,@sip_promosyon_fl,@sip_cari_sormerk,@sip_stok_sormerk,@sip_cari_grupno,
                            @sip_doviz_cinsi,@sip_doviz_kuru,@sip_alt_doviz_kuru,@sip_adresno,@sip_teslimturu,@sip_cagrilabilir_fl
                            @,sip_iskonto1,@sip_iskonto2,@sip_iskonto3,@sip_iskonto4,@sip_iskonto5,@sip_iskonto6,
                            @sip_masraf1,@sip_masraf2,@sip_masraf3,@sip_masraf4,@sip_isk1,@sip_isk2,@sip_isk3,@sip_isk4,@sip_isk5,
                            @sip_isk6,@sip_mas1,@sip_mas2,@sip_mas3,@sip_mas4,@sip_Exp_Imp_Kodu,@sip_kar_orani,@sip_durumu,
                            @sip_planlananmiktar,@sip_parti_kodu,@sip_lot_no,@sip_projekodu,@sip_fiyat_liste_no,
                            @sip_Otv_Pntr,@sip_Otv_Vergi,@sip_otvtutari,@sip_OtvVergisiz_Fl,@sip_paket_kod,@sip_harekettipi,
                            @sip_kapatmanedenkod,@sip_gecerlilik_tarihi,@sip_onodeme_evrak_tip,@sip_onodeme_evrak_seri,
                            @sip_onodeme_evrak_sira,@sip_rezervasyon_miktari,@sip_rezerveden_teslim_edilen,@sip_HareketGrupKodu1,
                            @sip_HareketGrupKodu2,@sip_HareketGrupKodu3,@sip_Olcu1,@sip_Olcu2,@sip_Olcu3,@sip_Olcu4,@sip_Olcu5,@sip_FormulMiktarNo,
                            @sip_FormulMiktar,@sip_satis_fiyat_doviz_cinsi,@sip_satis_fiyat_doviz_kuru,@sip_eticaret_kanal_kodu)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@sip_DBCno", siparisler.SipDbCno); 
                    myCommand.Parameters.AddWithValue("@sip_SpecRECno", siparisler.SipSpecReCno); 
                    myCommand.Parameters.AddWithValue("@sip_iptal", siparisler.SipIptal); 
                    myCommand.Parameters.AddWithValue("@sip_fileid", siparisler.SipFileid); 
                    myCommand.Parameters.AddWithValue("@sip_hidden", siparisler.SipHidden); 
                    myCommand.Parameters.AddWithValue("@sip_kilitli", siparisler.SipKilitli); 
                    myCommand.Parameters.AddWithValue("@sip_degisti", siparisler.SipDegisti); 
                    myCommand.Parameters.AddWithValue("@sip_checksum", siparisler.SipChecksum); 
                    myCommand.Parameters.AddWithValue("@sip_create_user", siparisler.SipCreateUser);
                    myCommand.Parameters.AddWithValue("@sip_create_date", siparisler.SipCreateDate); 
                    myCommand.Parameters.AddWithValue("@sip_lastup_user", siparisler.SipLastupUser); 
                    myCommand.Parameters.AddWithValue("@sip_lastup_date", siparisler.SipLastupDate); 
                    myCommand.Parameters.AddWithValue("@sip_special1", siparisler.SipSpecial1); 
                    myCommand.Parameters.AddWithValue("@sip_special2", siparisler.SipSpecial2); 
                    myCommand.Parameters.AddWithValue("@sip_special3", siparisler.SipSpecial3); 
                    myCommand.Parameters.AddWithValue("@sip_firmano", siparisler.SipFirmano); 
                    myCommand.Parameters.AddWithValue("@sip_subeno", siparisler.SipSubeno); 
                    myCommand.Parameters.AddWithValue("@sip_tarih", siparisler.SipTarih); 
                    myCommand.Parameters.AddWithValue("@sip_teslim_tarih", siparisler.SipTeslimTarih); 
                    myCommand.Parameters.AddWithValue("@sip_tip", siparisler.SipTip); 
                    myCommand.Parameters.AddWithValue("@sip_cins", siparisler.SipCins); 
                    myCommand.Parameters.AddWithValue("@sip_evrakno_seri", siparisler.SipEvraknoSeri); 
                    myCommand.Parameters.AddWithValue("@sip_evrakno_sira", siparisler.SipEvraknoSira); 
                    myCommand.Parameters.AddWithValue("@sip_satirno", siparisler.SipSatirno); 
                    myCommand.Parameters.AddWithValue("@sip_belgeno", siparisler.SipBelgeno); 
                    myCommand.Parameters.AddWithValue("@sip_belge_tarih", siparisler.SipBelgeTarih); 
                    myCommand.Parameters.AddWithValue("@sip_satici_kod", siparisler.SipSaticiKod); 
                    myCommand.Parameters.AddWithValue("@sip_musteri_kod", siparisler.SipMusteriKod); 
                    myCommand.Parameters.AddWithValue("@sip_stok_kod", siparisler.SipStokKod); 
                    myCommand.Parameters.AddWithValue("@sip_b_fiyat", siparisler.SipBFiyat); 
                    myCommand.Parameters.AddWithValue("@sip_miktar", siparisler.SipMiktar); 
                    myCommand.Parameters.AddWithValue("@sip_birim_pntr", siparisler.SipBirimPntr); 
                    myCommand.Parameters.AddWithValue("@sip_teslim_miktar", siparisler.SipTeslimMiktar); 
                    myCommand.Parameters.AddWithValue("@sip_tutar", siparisler.SipTutar); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto_1", siparisler.SiparislerSipIskonto1); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto_2", siparisler.SiparislerSipIskonto2); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto_3", siparisler.SiparislerSipIskonto3); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto_4", siparisler.SiparislerSipIskonto4); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto_5", siparisler.SiparislerSipIskonto5); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto_6", siparisler.SiparislerSipIskonto6); 
                    myCommand.Parameters.AddWithValue("@sip_masraf_1", siparisler.SiparislerSipMasraf1); 
                    myCommand.Parameters.AddWithValue("@sip_masraf_2", siparisler.SiparislerSipMasraf2); 
                    myCommand.Parameters.AddWithValue("@sip_masraf_3", siparisler.SiparislerSipMasraf3); 
                    myCommand.Parameters.AddWithValue("@sip_masraf_4", siparisler.SiparislerSipMasraf4); 
                    myCommand.Parameters.AddWithValue("@sip_vergi_pntr", siparisler.SipVergiPntr); 
                    myCommand.Parameters.AddWithValue("@sip_vergi", siparisler.SipVergi); 
                    myCommand.Parameters.AddWithValue("@sip_masvergi_pntr", siparisler.SipMasvergiPntr); 
                    myCommand.Parameters.AddWithValue("@sip_masvergi", siparisler.SipMasvergi); 
                    myCommand.Parameters.AddWithValue("@sip_opno", siparisler.SipOpno); 
                    myCommand.Parameters.AddWithValue("@sip_aciklama", siparisler.SipAciklama); 
                    myCommand.Parameters.AddWithValue("@sip_aciklama2", siparisler.SipAciklama2); 
                    myCommand.Parameters.AddWithValue("@sip_depono", siparisler.SipDepono); 
                    myCommand.Parameters.AddWithValue("@sip_OnaylayanKulNo", siparisler.SipOnaylayanKulNo); 
                    myCommand.Parameters.AddWithValue("@sip_vergisiz_fl", siparisler.SipVergisizFl); 
                    myCommand.Parameters.AddWithValue("@sip_kapat_fl", siparisler.SipKapatFl); 
                    myCommand.Parameters.AddWithValue("@sip_promosyon_fl", siparisler.SipPromosyonFl); 
                    myCommand.Parameters.AddWithValue("@sip_cari_sormerk", siparisler.SipCariSormerk); 
                    myCommand.Parameters.AddWithValue("@sip_stok_sormerk", siparisler.SipStokSormerk); 
                    myCommand.Parameters.AddWithValue("@sip_cari_grupno", siparisler.SipCariGrupno); 
                    myCommand.Parameters.AddWithValue("@sip_doviz_cinsi", siparisler.SipDovizCinsi); 
                    myCommand.Parameters.AddWithValue("@sip_doviz_kuru", siparisler.SipDovizKuru); 
                    myCommand.Parameters.AddWithValue("@sip_alt_doviz_kuru", siparisler.SipAltDovizKuru); 
                    myCommand.Parameters.AddWithValue("@sip_adresno", siparisler.SipAdresno); 
                    myCommand.Parameters.AddWithValue("@sip_teslimturu", siparisler.SipTeslimturu); 
                    myCommand.Parameters.AddWithValue("@sip_cagrilabilir_fl", siparisler.SipCagrilabilirFl);
                    myCommand.Parameters.AddWithValue("@sip_iskonto1", siparisler.SipIskonto1); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto2", siparisler.SipIskonto2); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto3", siparisler.SipIskonto3); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto4", siparisler.SipIskonto4); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto5", siparisler.SipIskonto5); 
                    myCommand.Parameters.AddWithValue("@sip_iskonto6", siparisler.SipIskonto6); 
                    myCommand.Parameters.AddWithValue("@sip_masraf1", siparisler.SipMasraf1); 
                    myCommand.Parameters.AddWithValue("@sip_masraf2", siparisler.SipMasraf2); 
                    myCommand.Parameters.AddWithValue("@sip_masraf3", siparisler.SipMasraf3); 
                    myCommand.Parameters.AddWithValue("@sip_masraf4", siparisler.SipMasraf4); 
                    myCommand.Parameters.AddWithValue("@sip_isk1", siparisler.SipIsk1); 
                    myCommand.Parameters.AddWithValue("@sip_isk2", siparisler.SipIsk2); 
                    myCommand.Parameters.AddWithValue("@sip_isk3", siparisler.SipIsk3); 
                    myCommand.Parameters.AddWithValue("@sip_isk4", siparisler.SipIsk4); 
                    myCommand.Parameters.AddWithValue("@sip_isk5", siparisler.SipIsk5); 
                    myCommand.Parameters.AddWithValue("@sip_isk6", siparisler.SipIsk6); 
                    myCommand.Parameters.AddWithValue("@sip_mas1", siparisler.SipMas1); 
                    myCommand.Parameters.AddWithValue("@sip_mas2", siparisler.SipMas2); 
                    myCommand.Parameters.AddWithValue("@sip_mas3", siparisler.SipMas3); 
                    myCommand.Parameters.AddWithValue("@sip_mas4", siparisler.SipMas4); 
                    myCommand.Parameters.AddWithValue("@sip_Exp_Imp_Kodu", siparisler.SipExpImpKodu); 
                    myCommand.Parameters.AddWithValue("@sip_kar_orani", siparisler.SipKarOrani); 
                    myCommand.Parameters.AddWithValue("@sip_durumu", siparisler.SipDurumu); 
                    myCommand.Parameters.AddWithValue("@sip_planlananmiktar", siparisler.SipPlanlananmiktar); 
                    myCommand.Parameters.AddWithValue("@sip_parti_kodu", siparisler.SipPartiKodu); 
                    myCommand.Parameters.AddWithValue("@sip_lot_no", siparisler.SipLotNo); 
                    myCommand.Parameters.AddWithValue("@sip_projekodu", siparisler.SipProjekodu); 
                    myCommand.Parameters.AddWithValue("@sip_fiyat_liste_no", siparisler.SipFiyatListeNo); 
                    myCommand.Parameters.AddWithValue("@sip_Otv_Pntr", siparisler.SipOtvPntr); 
                    myCommand.Parameters.AddWithValue("@sip_Otv_Vergi", siparisler.SipOtvVergi); 
                    myCommand.Parameters.AddWithValue("@sip_otvtutari", siparisler.SipOtvtutari); 
                    myCommand.Parameters.AddWithValue("@sip_OtvVergisiz_Fl", siparisler.SipOtvVergisizFl); 
                    myCommand.Parameters.AddWithValue("@sip_paket_kod", siparisler.SipPaketKod); 
                    myCommand.Parameters.AddWithValue("@sip_harekettipi", siparisler.SipHarekettipi); 
                    myCommand.Parameters.AddWithValue("@sip_kapatmanedenkod", siparisler.SipKapatmanedenkod); 
                    myCommand.Parameters.AddWithValue("@sip_gecerlilik_tarihi", siparisler.SipGecerlilikTarihi); 
                    myCommand.Parameters.AddWithValue("@sip_onodeme_evrak_tip", siparisler.SipOnodemeEvrakTip); 
                    myCommand.Parameters.AddWithValue("@sip_onodeme_evrak_seri", siparisler.SipOnodemeEvrakSeri); 
                    myCommand.Parameters.AddWithValue("@sip_onodeme_evrak_sira", siparisler.SipOnodemeEvrakSira); 
                    myCommand.Parameters.AddWithValue("@sip_rezervasyon_miktari", siparisler.SipRezervasyonMiktari); 
                    myCommand.Parameters.AddWithValue("@sip_rezerveden_teslim_edilen", siparisler.SipRezervedenTeslimEdilen); 
                    myCommand.Parameters.AddWithValue("@sip_HareketGrupKodu1", siparisler.SipHareketGrupKodu1); 
                    myCommand.Parameters.AddWithValue("@sip_HareketGrupKodu2", siparisler.SipHareketGrupKodu2); 
                    myCommand.Parameters.AddWithValue("@sip_HareketGrupKodu3", siparisler.SipHareketGrupKodu3); 
                    myCommand.Parameters.AddWithValue("@sip_Olcu1", siparisler.SipOlcu1); 
                    myCommand.Parameters.AddWithValue("@sip_Olcu2", siparisler.SipOlcu2); 
                    myCommand.Parameters.AddWithValue("@sip_Olcu3", siparisler.SipOlcu3); 
                    myCommand.Parameters.AddWithValue("@sip_Olcu4", siparisler.SipOlcu4); 
                    myCommand.Parameters.AddWithValue("@sip_Olcu5", siparisler.SipOlcu5); 
                    myCommand.Parameters.AddWithValue("@sip_FormulMiktarNo", siparisler.SipFormulMiktarNo); 
                    myCommand.Parameters.AddWithValue("@sip_FormulMiktar", siparisler.SipFormulMiktar); 
                    myCommand.Parameters.AddWithValue("@sip_satis_fiyat_doviz_cinsi", siparisler.SipSatisFiyatDovizCinsi); 
                    myCommand.Parameters.AddWithValue("@sip_satis_fiyat_doviz_kuru", siparisler.SipSatisFiyatDovizKuru); 
                    myCommand.Parameters.AddWithValue("@sip_eticaret_kanal_kodu", siparisler.SipEticaretKanalKodu); 

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
