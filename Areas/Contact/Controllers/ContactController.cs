using metronic.Areas.Contact.Models;
using metronic.Areas.LOC_City.Models;
using metronic.Areas.LOC_ContactCategory.Models;
using metronic.Areas.LOC_Country.Models;
using metronic.Areas.LOC_State.Models;
using metronic.BAL;
using metronic.DAL;
using metronic.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace metronic.Areas.Contact.Controllers
{
    [CheckAccess]
    [Area("Contact")]
    [Route("Contact/[controller]/[action]")]
    public class ContactController : Controller
    {
        private IConfiguration Configuration;
        public ContactController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            CON_DAL dalCON = new CON_DAL();
            DataTable dt = dalCON.dbo_PR_Contact_SelectAll(connectionstr);
            return View("ContactList", dt);
        }
        public IActionResult Filter(string? ContactMobile, string? ContactName, string? CountryName, string? StateName, string? CityName, string? Category)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            CON_DAL dalCON = new CON_DAL();
            DataTable dt = dalCON.dbo_PR_Contact_SelectByContactNameMobile(connectionstr, CountryName, StateName, CityName, Category, ContactName, ContactMobile);
            return View("ContactList", dt);
        }

        public IActionResult Delete(int ContactID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            CON_DAL dalCON = new CON_DAL();
            dalCON.dbo_PR_Contact_DeleteByPK(connectionstr, ContactID);
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? ContactID)
        {
            string connectionstr2 = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn2 = new SqlConnection(connectionstr2);
            conn2.Open();
            SqlCommand objCmd2 = conn2.CreateCommand();
            objCmd2.CommandType = CommandType.StoredProcedure;
            objCmd2.CommandText = "PR_LOC_Country_SelectForDropDown";
            DataTable dt2 = new DataTable();
            SqlDataReader objSDR2 = objCmd2.ExecuteReader();
            dt2.Load(objSDR2);

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

            List<LOC_CityDropDownModel> list2 = new List<LOC_CityDropDownModel>();

            ViewBag.CityList = list2;

            string connectionstr4 = Configuration.GetConnectionString("myConnectionString");
            SqlConnection conn4 = new SqlConnection(connectionstr4);
            conn4.Open();
            SqlCommand objCmd4 = conn4.CreateCommand();
            objCmd4.CommandType = CommandType.StoredProcedure;
            objCmd4.CommandText = "PR_LOC_ContactCategory_SelectForDropDown";
            DataTable dt4 = new DataTable();
            SqlDataReader objSDR4 = objCmd4.ExecuteReader();
            dt4.Load(objSDR4);

            List<LOC_ContactCategoryDropDownModel> list3 = new List<LOC_ContactCategoryDropDownModel>();
            foreach (DataRow dr in dt4.Rows)
            {
                LOC_ContactCategoryDropDownModel vlst3 = new LOC_ContactCategoryDropDownModel();

                vlst3.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                vlst3.Category = Convert.ToString(dr["Category"]);
                list3.Add(vlst3);
            }
            ViewBag.ContactCategoryList = list3;


            if (ContactID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                CON_DAL dalCON = new CON_DAL();
                DataTable dt = dalCON.dbo_PR_Contact_SelectByPK(connectionstr, ContactID);
                ContactModel modelContact = new ContactModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelContact.ContactID = Convert.ToInt32(dr["ContactID"]);
                    modelContact.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    modelContact.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelContact.CityID = Convert.ToInt32(dr["CityID"]);
                    modelContact.StateID = Convert.ToInt32(dr["StateID"]);
                    modelContact.ContactName = Convert.ToString(dr["ContactName"]);
                    modelContact.ContactMobile = Convert.ToString(dr["ContactMobile"]);
                    modelContact.ContactAddress = Convert.ToString(dr["ContactAddress"]);
                    modelContact.ContactPincode = Convert.ToInt32(dr["ContactPincode"]);
                    modelContact.ContactEmail = Convert.ToString(dr["ContactEmail"]);
                    modelContact.PhotoPath = Convert.ToString(dr["PhotoPath"]);
                    modelContact.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                    TempData["PhotoPath"] = dr["PhotoPath"].ToString();
                }
                string connectionstr7 = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                DataTable dt7 = dalLOC.dbo_PR_LOC_State_SelectDropDownByCountryID(connectionstr7, modelContact.CountryID);
                List<LOC_StateDropDownModel> lista = new List<LOC_StateDropDownModel>();
                foreach (DataRow dr in dt7.Rows)
                {
                    LOC_StateDropDownModel vlst = new LOC_StateDropDownModel();

                    vlst.StateID = Convert.ToInt32(dr["StateID"]);
                    vlst.StateName = Convert.ToString(dr["StateName"]);
                    lista.Add(vlst);
                }
                ViewBag.StateList = lista;
                string connectionstr3 = Configuration.GetConnectionString("myConnectionString");

                DataTable dt3 = dalLOC.dbo_PR_LOC_City_SelectDropDownByStateID(connectionstr3, modelContact.StateID);
                List<LOC_CityDropDownModel> listc = new List<LOC_CityDropDownModel>();
                foreach (DataRow dr in dt3.Rows)
                {
                    LOC_CityDropDownModel vlst2 = new LOC_CityDropDownModel();

                    vlst2.CityID = Convert.ToInt32(dr["CityID"]);
                    vlst2.CityName = Convert.ToString(dr["CityName"]);
                    listc.Add(vlst2);
                }
                ViewBag.CityList = listc;
                return View("ContactAddEdit", modelContact);
            }
            return View("ContactAddEdit");
        }
        [HttpPost]
        public IActionResult Save(ContactModel modelContact)
        {
            if (modelContact.File != null)
            {
                string FilePath = "wwwroot\\Upload";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);


                string fileNameWithPath = Path.Combine(path, modelContact.File.FileName);
                modelContact.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelContact.File.FileName;
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelContact.File.CopyTo(stream);
                }
            }
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            CON_DAL dalCON = new CON_DAL();
            if (modelContact.ContactID == null)
            {
                dalCON.dbo_PR_Contact_Insert(connectionstr, modelContact);
            }
            else
            {
                dalCON.dbo_PR_Contact_UpdateByPK(connectionstr, modelContact);
            }


            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DropDownByCountry(int? CountryID)
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
        public IActionResult DropDownByState(int StateID)
        {
            string connectionstr3 = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt3 = dalLOC.dbo_PR_LOC_City_SelectDropDownByStateID(connectionstr3, StateID);
            List<LOC_CityDropDownModel> list2 = new List<LOC_CityDropDownModel>();
            foreach (DataRow dr in dt3.Rows)
            {
                LOC_CityDropDownModel vlst2 = new LOC_CityDropDownModel();

                vlst2.CityID = Convert.ToInt32(dr["CityID"]);
                vlst2.CityName = Convert.ToString(dr["CityName"]);
                list2.Add(vlst2);
            }
            var vModel = list2;
            return Json(vModel);
        }
    }
}
