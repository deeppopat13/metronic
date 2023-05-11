using metronic.Areas.LOC_Country.Models;
using metronic.BAL;
using metronic.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace metronic.Areas.LOC_Country.Controllers
{
    [CheckAccess]
    [Area("LOC_Country")]
    [Route("LOC_Country/[controller]/[action]")]
    public class LOC_CountryController : Controller
    {
        private IConfiguration Configuration;

        public LOC_CountryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectAll(connectionstr);
            return View("LOC_CountryList", dt);


        }
        public IActionResult Filter(int? CountryCode, string? CountryName)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByCountryNameCode(connectionstr, CountryCode, CountryName);
            return View("LOC_CountryList", dt);
        }
        public IActionResult Delete(int CountryID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_LOC_Country_DeleteByPK(connectionstr, CountryID);
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? CountryID)
        {
            if (CountryID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                DataTable dt = dalLOC.dbo_PR_LOC_Country_SelectByPK(connectionstr, CountryID);
                LOC_CountryModel modelLOC_Country = new LOC_CountryModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_Country.CountryName = Convert.ToString(dr["CountryName"]);
                    modelLOC_Country.CountryCode = Convert.ToInt32(dr["CountryCode"]);
                    modelLOC_Country.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_Country.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_CountryAddEdit", modelLOC_Country);

            }
            return View("LOC_CountryAddEdit");
        }
        [HttpPost]
        public IActionResult Save(LOC_CountryModel modelLOC_Country)
        {
            if (ModelState.IsValid)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();

                if (modelLOC_Country.CountryID == null)
                {
                    dalLOC.dbo_PR_LOC_Country_Insert(connectionstr, modelLOC_Country);
                }
                else
                {
                    dalLOC.dbo_PR_LOC_Country_UpdateByPK(connectionstr, modelLOC_Country);
                }
            }




            return RedirectToAction("Index");
        }
    }
}
