using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DepartmentController: ControllerBase
	{
		private readonly IConfiguration _configuration;
		public DepartmentController(IConfiguration configuration)
		{
			_configuration = configuration;
			
		}
		[HttpGet]
		public JsonResult Get()
		{
			string query = @"select ban_kod, ban_ismi from dbo.BANKALAR";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using(SqlCommand myCommand = new SqlCommand(query, myCon))
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
		public JsonResult Post(Bank bank)
		{
			string query = @"insert into dbo.BANKALAR 
							values(@bankName)
";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myCommand.Parameters.AddWithValue("@bankName", bank.BankName);
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);
					myReader.Close();
					myCon.Close();
				}
			}

			return new JsonResult("Added successfully");
		}


		[HttpPut]
		public JsonResult Put(Department dep)
		{
			string query = @"update dbo.Department 
							set departmentName = @departmentName
							where departmentId = @departmentId
";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myCommand.Parameters.AddWithValue("@departmentId", dep.DepartmentId);
					myCommand.Parameters.AddWithValue("@departmentName", dep.DepartmentName);
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);
					myReader.Close();
					myCon.Close();
				}
			}

			return new JsonResult("Updated successfully");
		}


		[HttpDelete]
		public JsonResult Delete(int id)
		{
			string query = @"delete from dbo.Department 
							where departmentId = @departmentId
";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("DinamikMikroMobilConn");
			SqlDataReader myReader;
			using (SqlConnection myCon = new SqlConnection(sqlDataSource))
			{
				myCon.Open();
				using (SqlCommand myCommand = new SqlCommand(query, myCon))
				{
					myCommand.Parameters.AddWithValue("@departmentId",id);
					myReader = myCommand.ExecuteReader();
					table.Load(myReader);
					myReader.Close();
					myCon.Close();
				}
			}

			return new JsonResult("deleted successfully");
		}

	}
}