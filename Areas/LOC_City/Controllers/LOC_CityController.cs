using metronic.Areas.LOC_City.Models;
using metronic.Areas.LOC_Country.Models;
using metronic.Areas.LOC_State.Models;
using metronic.BAL;
using metronic.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace metronic.Areas.LOC_City.Controllers
{
    [CheckAccess]
    [Area("LOC_City")]
    [Route("LOC_City/[controller]/[action]")]
    public class LOC_CityController : Controller
    {
        private IConfiguration Configuration;
        public LOC_CityController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {

            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_LOC_City_SelectAll(connectionstr);
            return View("LOC_CityList", dt);
        }
        public IActionResult Filter(int? CityCode, string? CityName, string? CountryName, string? StateName)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_LOC_City_SelectByCityNameCode(connectionstr, CountryName, StateName, CityName, CityCode);
            return View("LOC_CityList", dt);
        }

        public IActionResult Delete(int CityID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_LOC_City_DeleteByPK(connectionstr, CityID);
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? CityID)
        {
            string connectionstr2 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt2 = dalLOC.dbo_PR_LOC_Country_SelectForDropDown(connectionstr2);
            List<LOC_CountryDropDownModel> list1 = new List<LOC_CountryDropDownModel>();
            foreach (DataRow dr in dt2.Rows)
            {
                LOC_CountryDropDownModel vlst1 = new LOC_CountryDropDownModel();

                vlst1.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst1.CountryName = Convert.ToString(dr["CountryName"]);
                list1.Add(vlst1);
            }
            ViewBag.CountryList = list1;



            List<LOC_StateDropDownModel> list = new List<LOC_StateDropDownModel>();

            ViewBag.StateList = list;



            if (CityID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");

                DataTable dt = dalLOC.dbo_PR_LOC_City_SelectByPK(connectionstr, CityID);
                LOC_CityModel modelLOC_City = new LOC_CityModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_City.CityID = Convert.ToInt32(dr["CityID"]);
                    modelLOC_City.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_City.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_City.CityName = Convert.ToString(dr["CityName"]);
                    modelLOC_City.CityCode = Convert.ToInt32(dr["CityCode"]);
                    modelLOC_City.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_City.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_CityAddEdit", modelLOC_City);
            }
            return View("LOC_CityAddEdit");
        }
        [HttpPost]
        public IActionResult Save(LOC_CityModel modelLOC_City)
        {
            if (ModelState.IsValid)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                if (modelLOC_City.CityID == null)
                {
                    dalLOC.dbo_PR_LOC_City_Insert(connectionstr, modelLOC_City);
                }
                else
                {
                    dalLOC.dbo_PR_LOC_City_UpdateByPK(connectionstr, modelLOC_City);
                }

            }
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult DropDownByCountry(int CountryID)
        {
            string connectionstr7 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt7 = dalLOC.dbo_PR_LOC_State_SelectDropDownByCountryID(connectionstr7, CountryID);
            List<LOC_StateDropDownModel> list = new List<LOC_StateDropDownModel>();
            foreach (DataRow dr in dt7.Rows)
            {
                LOC_StateDropDownModel vlst = new LOC_StateDropDownModel();

                vlst.StateID = Convert.ToInt32(dr["StateID"]);
                vlst.StateName = Convert.ToString(dr["StateName"]);
                list.Add(vlst);
            }
            var vModel = list;
            return Json(vModel);
        }
    }
}
