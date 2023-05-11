using metronic.Areas.LOC_ContactCategory.Models;
using metronic.BAL;
using metronic.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace metronic.Areas.LOC_ContactCategory.Controllers
{
    [CheckAccess]
    [Area("LOC_ContactCategory")]
    [Route("LOC_ContactCategory/[controller]/[action]")]
    public class LOC_ContactCategoryController : Controller
    {
        private IConfiguration Configuration;

        public LOC_ContactCategoryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            DataTable dt = dalLOC.dbo_PR_LOC_ContactCategory_SelectAll(connectionstr);
            return View("LOC_ContactCategoryList", dt);


        }
        public IActionResult Delete(int CategoryID)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionString");
            LOC_DAL dalLOC = new LOC_DAL();
            dalLOC.dbo_PR_LOC_ContactCategory_DeleteByPK(connectionstr, CategoryID);
            return RedirectToAction("Index");
        }
        public IActionResult Add(int? CategoryID)
        {
            if (CategoryID != null)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                DataTable dt = dalLOC.dbo_PR_LOC_ContactCategory_SelectByPK(connectionstr, CategoryID);
                LOC_ContactCategoryModel modelLOC_ContactCategory = new LOC_ContactCategoryModel();
                foreach (DataRow dr in dt.Rows)
                {

                    modelLOC_ContactCategory.CategoryID = Convert.ToInt32(dr["CategoryID"]);
                    modelLOC_ContactCategory.Category = Convert.ToString(dr["Category"]);
                    modelLOC_ContactCategory.CreationDate = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_ContactCategory.ModificationDate = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_ContactCategoryAddEdit", modelLOC_ContactCategory);
            }
            return View("LOC_ContactCategoryAddEdit");
        }
        [HttpPost]
        public IActionResult Save(LOC_ContactCategoryModel modelLOC_ContactCategory)
        {
            if (ModelState.IsValid)
            {
                string connectionstr = Configuration.GetConnectionString("myConnectionString");
                LOC_DAL dalLOC = new LOC_DAL();
                if (modelLOC_ContactCategory.CategoryID == null)
                {
                    dalLOC.dbo_PR_LOC_ContactCategory_Insert(connectionstr, modelLOC_ContactCategory);
                }
                else
                {
                    dalLOC.dbo_PR_LOC_ContactCategory_UpdateByPK(connectionstr, modelLOC_ContactCategory);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
