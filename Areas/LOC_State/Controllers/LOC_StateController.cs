using metronic.Areas.LOC_Country.Models;
using metronic.Areas.LOC_State.Models;
using metronic.BAL;
using metronic.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace metronic.Areas.LOC_State.Controllers
{
    [CheckAccess]
    [Area("LOC_State")]
    [Route("LOC_State/[controller]/[action]")]
    public class Loc_StateController : Controller
    {
        private IConfiguration Configuration;

        public Loc_StateController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_LOC_State_SelectAll(connectionstr);

            //DataTable dt = new DataTable();
            //SqlConnection conn = new SqlConnection(connectionstr);
            //conn.Open();
            //SqlCommand objCmd = conn.CreateCommand();
            //objCmd.CommandType = CommandType.StoredProcedure;
            //objCmd.CommandText = "PR_LOC_State_SelectAll";

            //SqlDataReader objSDR = objCmd.ExecuteReader();
            //dt.Load(objSDR);
            return View("LOC_StateList", dt);
        }
        public IActionResult Filter(string? StateCode, string? StateName, string? CountryName)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByStateNameCode(connectionstr, CountryName, StateName, StateCode);
            return View("LOC_StateList", dt);
        }
        public IActionResult Delete(int StateID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_LOC_State_DeleteByPK(connectionstr, StateID);
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? StateID)
        {
            string connectionstr1 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt1 = dalLOC.dbo_PR_LOC_Country_SelectForDropDown(connectionstr1);
            List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();
            foreach (DataRow dr in dt1.Rows)
            {
                LOC_CountryDropDownModel vlst = new LOC_CountryDropDownModel();

                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = Convert.ToString(dr["CountryName"]);
                list.Add(vlst);
            }
            ViewBag.CountryList = list;
            if (StateID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");

                DataTable dt = dalLOC.dbo_PR_LOC_State_SelectByPK(connectionstr, StateID);

                LOC_StateModel modelLOC_State = new LOC_StateModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_State.StateName = Convert.ToString(dr["StateName"]);
                    modelLOC_State.StateCode = Convert.ToString(dr["StateCode"]);
                    modelLOC_State.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_State.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_StateAddEdit", modelLOC_State);

            }
            return View("LOC_StateAddEdit");
        }
        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {
            if (ModelState.IsValid)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                if (modelLOC_State.StateID == null)
                {
                    dalLOC.dbo_PR_LOC_State_Insert(connectionstr, modelLOC_State);
                }
                else
                {
                    dalLOC.dbo_PR_LOC_State_UpdateByPK(connectionstr, modelLOC_State);
                }

            }
            return RedirectToAction("Index");
        }
    }
}
