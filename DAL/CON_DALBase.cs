using metronic.Areas.Contact.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;
namespace metronic.DAL
{
    public class CON_DALBase
    {
        #region dbo.PR_Contact_SelectAll
        public DataTable dbo_PR_Contact_SelectAll(string conn)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Contact_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Contact_SelectByPK
        public DataTable dbo_PR_Contact_SelectByPK(string conn, int? ContactID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Contact_SelectByPK");
                sqlDb.AddInParameter(dbCmd, "ContactID", SqlDbType.Int, ContactID);

                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDb.ExecuteReader(dbCmd))
                {
                    dt.Load(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
        #region dbo.PR_Contact_Insert
        public void dbo_PR_Contact_Insert(string conn, ContactModel modelContact)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_CON_Contact_Insert");
                sqlDb.AddInParameter(dbCmd, "CategoryID", SqlDbType.Int, modelContact.CategoryID);
                sqlDb.AddInParameter(dbCmd, "CityID", SqlDbType.Int, modelContact.CityID);
                sqlDb.AddInParameter(dbCmd, "StateID", SqlDbType.Int, modelContact.StateID);
                sqlDb.AddInParameter(dbCmd, "CountryID", SqlDbType.Int, modelContact.CountryID);
                sqlDb.AddInParameter(dbCmd, "ContactName", SqlDbType.NVarChar, modelContact.ContactName);
                sqlDb.AddInParameter(dbCmd, "PhotoPath", SqlDbType.NVarChar, modelContact.PhotoPath);
                sqlDb.AddInParameter(dbCmd, "ContactMobile", SqlDbType.NVarChar, modelContact.ContactMobile);
                sqlDb.AddInParameter(dbCmd, "ContactAddress", SqlDbType.NVarChar, modelContact.ContactAddress);
                sqlDb.AddInParameter(dbCmd, "ContactPincode", SqlDbType.Int, modelContact.ContactPincode);
                sqlDb.AddInParameter(dbCmd, "ContactEmail", SqlDbType.NVarChar, modelContact.ContactEmail);
                sqlDb.AddInParameter(dbCmd, "CreationDate", SqlDbType.Date, DBNull.Value);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Contact_UpdateByPK
        public void dbo_PR_Contact_UpdateByPK(string conn, ContactModel modelContact)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_CON_Contact_UpdateByPK");
                sqlDb.AddInParameter(dbCmd, "ContactID", SqlDbType.Int, modelContact.ContactID);
                sqlDb.AddInParameter(dbCmd, "CategoryID", SqlDbType.Int, modelContact.CategoryID);
                sqlDb.AddInParameter(dbCmd, "CityID", SqlDbType.Int, modelContact.CityID);
                sqlDb.AddInParameter(dbCmd, "StateID", SqlDbType.Int, modelContact.StateID);
                sqlDb.AddInParameter(dbCmd, "CountryID", SqlDbType.Int, modelContact.CountryID);
                sqlDb.AddInParameter(dbCmd, "ContactName", SqlDbType.NVarChar, modelContact.ContactName);
                sqlDb.AddInParameter(dbCmd, "PhotoPath", SqlDbType.NVarChar, modelContact.PhotoPath);
                sqlDb.AddInParameter(dbCmd, "ContactMobile", SqlDbType.NVarChar, modelContact.ContactMobile);
                sqlDb.AddInParameter(dbCmd, "ContactAddress", SqlDbType.NVarChar, modelContact.ContactAddress);
                sqlDb.AddInParameter(dbCmd, "ContactPincode", SqlDbType.Int, modelContact.ContactPincode);
                sqlDb.AddInParameter(dbCmd, "ContactEmail", SqlDbType.NVarChar, modelContact.ContactEmail);
                sqlDb.AddInParameter(dbCmd, "ModificationDate", SqlDbType.Date, DBNull.Value);

                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion
        #region dbo.PR_Contact_DeleteByPK
        public void dbo_PR_Contact_DeleteByPK(string conn, int ContactID)
        {
            try
            {
                SqlDatabase sqlDb = new SqlDatabase(conn);
                DbCommand dbCmd = sqlDb.GetStoredProcCommand("dbo.PR_Contact_DeleteByPK");
                sqlDb.AddInParameter(dbCmd, "ContactID", SqlDbType.Int, ContactID);
                sqlDb.ExecuteNonQuery(dbCmd);
            }
            catch (Exception ex) { }
        }
        #endregion


    }
}
