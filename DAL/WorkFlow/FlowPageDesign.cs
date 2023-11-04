using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Anchor.FA.Utility;
using System.Data.SqlClient;

namespace Anchor.FA.DAL.WorkFlow
{
    public class FlowPageDesign
    {
        public static DataSet DesignTableList(int flowId, string tableType)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@tabletype", SqlDbType.NVarChar);
            parameters[1].Value = tableType;

            return SQLHelper.ExecuteDataSet(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_TableDesignList", parameters);
        }

        public static DataSet FieldDesignList(int flowId, string tableName)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@tablename", SqlDbType.NVarChar);
            parameters[1].Value = tableName;

            return SQLHelper.ExecuteDataSet(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_FieldDesignList", parameters);
        }

        public static void InitPage(int flowId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;

            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_Init", parameters);
        }

        public static DataSet FieldDesignBeenLayout(int flowId, string fieldId)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@fieldId", SqlDbType.NVarChar);
            parameters[1].Value = fieldId;

            return SQLHelper.ExecuteDataSet(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_GetFieldPorperty", parameters);
        }

        public static bool FieldDesignBeenRef(int flowId, string fieldId)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@field_id", SqlDbType.NVarChar);
            parameters[1].Value = fieldId;
            parameters[2] = new SqlParameter("@result", SqlDbType.Int);
            parameters[2].Direction = ParameterDirection.Output;

            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_DeignFieldBeenRef", parameters);

            int result = int.Parse(parameters[2].Value.ToString());

            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void FieldDesignDelete(int flowId, string fieldId)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.NVarChar);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@fieldid", SqlDbType.NVarChar);
            parameters[1].Value = fieldId;

            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_FieldDesignDelete", parameters);
        }

        public static DataSet GetFieldDesignLayout(int flowId, string formPage)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@formpage", SqlDbType.NVarChar);
            parameters[1].Value = formPage;

            return SQLHelper.ExecuteDataSet(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_GetLayout", parameters);

        }

        public static DataSet FieldDesignGetFieldActiveList(int flowId, string formPage, int activityId)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@formPage", SqlDbType.NVarChar);
            parameters[1].Value = formPage;
            parameters[2] = new SqlParameter("@activityId", SqlDbType.Int);
            parameters[2].Value = activityId;
            DataSet dataSet = SQLHelper.ExecuteDataSet(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_GetFieldActiveList", parameters);
            return dataSet;
        }

        public static void FlowPageCopy(int flowId, string pageTo, string pageFrom)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@pageto", SqlDbType.NVarChar);
            parameters[1].Value = pageTo;
            parameters[2] = new SqlParameter("@pagefrom", SqlDbType.NVarChar);
            parameters[2].Value = pageFrom;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_FormPageCopy", parameters);
        }

        public static void FieldDesignUpdateFieldProperty(int flowId, string formPage, string empId, int fieldId, string flag)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@formPage", SqlDbType.NVarChar);
            parameters[1].Value = formPage;
            parameters[2] = new SqlParameter("@empId", SqlDbType.NVarChar);
            parameters[2].Value = empId;
            parameters[3] = new SqlParameter("@fieldId", SqlDbType.Int);
            parameters[3].Value = fieldId;
            parameters[4] = new SqlParameter("@flag", SqlDbType.NVarChar);
            parameters[4].Value = flag;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_UpdateFieldProperty", parameters);
        }

        public static void FieldDesignUpdateFieldSerial(int flowId, string formPage, string empId, string fieldName, int serial)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@formPage", SqlDbType.NVarChar);
            parameters[1].Value = formPage;
            parameters[2] = new SqlParameter("@empId", SqlDbType.NVarChar);
            parameters[2].Value = empId;
            parameters[3] = new SqlParameter("@fieldName", SqlDbType.NVarChar);
            parameters[3].Value = fieldName;
            parameters[4] = new SqlParameter("@serial", SqlDbType.Int);
            parameters[4].Value = serial;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure,"usp_FormDesign_UpdateFieldSerial", parameters);
        }

        public static void FieldDesignSaveLayout(int flowId, string formPage, string formLayoutOrigin, string formLayout, string createBy, string changedBy)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@formPage", SqlDbType.NVarChar);
            parameters[1].Value = formPage;
            parameters[2] = new SqlParameter("@formLayoutOrigin", SqlDbType.NVarChar);
            parameters[2].Value = formLayoutOrigin;
            parameters[3] = new SqlParameter("@formLayout", SqlDbType.NVarChar);
            parameters[3].Value = formLayout;
            parameters[4] = new SqlParameter("@createBy", SqlDbType.NVarChar);
            parameters[4].Value = createBy;
            parameters[5] = new SqlParameter("@changedBy", SqlDbType.NVarChar);
            parameters[5].Value = changedBy;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_SaveLayout", parameters);
        }

        public static void DesignTableSave(int flowId, int tableSerial, string tableName, string tableType, string tableLabel, string tableLabelLangId
        , bool editableA, bool editableV, bool editableP)
        {
            SqlParameter[] parameters = new SqlParameter[9];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@tableserial", SqlDbType.Decimal);
            parameters[1].Value = tableSerial;
            parameters[2] = new SqlParameter("@tablename", SqlDbType.NVarChar);
            parameters[2].Value = tableName;
            parameters[3] = new SqlParameter("@tabletype", SqlDbType.NVarChar);
            parameters[3].Value = tableType;
            parameters[4] = new SqlParameter("@tablelabel", SqlDbType.NVarChar);
            parameters[4].Value = tableLabel;
            int i = 4;
            i++;
            parameters[i] = new SqlParameter("@tablelabellangid", SqlDbType.NVarChar);
            parameters[i].Value = tableLabelLangId;
            i++;
            parameters[i] = new SqlParameter("@editablea", SqlDbType.Decimal);
            parameters[i].Value = editableA ? 1 : 0;
            i++;
            parameters[i] = new SqlParameter("@editablev", SqlDbType.Decimal);
            parameters[i].Value = editableV ? 1 : 0;
            i++;
            parameters[i] = new SqlParameter("@editablep", SqlDbType.Decimal);
            parameters[i].Value = editableP ? 1 : 0;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_TableDesignSave", parameters);
        }

        public static void DesignTableMove(string tableName, int intSerail)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@tablename", SqlDbType.NVarChar);
            parameters[0].Value = tableName;
            parameters[1] = new SqlParameter("@serial", SqlDbType.Int);
            parameters[1].Value = intSerail;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_TableDesignMove", parameters);
        }

        public static bool DeleteFormTableFlag(string tableName)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@tablename", SqlDbType.NVarChar);
            parameters[0].Value = tableName;
            DataSet dataSet = SQLHelper.ExecuteDataSet(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_DeleteFormTableFlag", parameters);

            if (int.Parse(dataSet.Tables[0].Rows[0]["BeenLayoutFieldNumber"].ToString()) > 0)
            {
                return false;
            }

            return true;
        }

        public static void DeleteArea(int flowId, string formPage, string strOriHTML, string strHTML, string changedBy)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter("@flowId", SqlDbType.Int);
            parameters[0].Value = flowId;
            parameters[1] = new SqlParameter("@formPage", SqlDbType.NVarChar);
            parameters[1].Value = formPage;
            parameters[2] = new SqlParameter("@strOriHTML", SqlDbType.NVarChar);
            parameters[2].Value = strOriHTML;
            parameters[3] = new SqlParameter("@strHTML", SqlDbType.NVarChar);
            parameters[3].Value = strHTML;
            parameters[4] = new SqlParameter("@changedBy", SqlDbType.NVarChar);
            parameters[4].Value = changedBy;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_TableDesignDeleteArea", parameters);
        }

        public static void DesignTableDelete(string tableName)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@tablename", SqlDbType.NVarChar);
            parameters[0].Value = tableName;
            SQLHelper.ExecuteNonQuery(SQLHelper.MainConnectionStringRDLC, CommandType.StoredProcedure, "usp_FormDesign_TableDesignDelete", parameters);
        }
    }
}
