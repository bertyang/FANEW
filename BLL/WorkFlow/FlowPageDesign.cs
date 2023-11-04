using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Anchor.FA.BLL.IBLL;
using Anchor.FA.DAL.WorkFlow;

namespace Anchor.FA.BLL.WorkFlow
{
    public class FlowPageDesign : IFlowPageDesign
    {
        public DataSet DesignTableList(int flowId, string tableType)
        {
            return DAL.WorkFlow.FlowPageDesign.DesignTableList(flowId, tableType);
        }

        public DataSet FieldDesignList(int flowId, string tableName)
        {
            return DAL.WorkFlow.FlowPageDesign.FieldDesignList(flowId, tableName);
        }

        public void InitPage(int flowId)
        {
            DAL.WorkFlow.FlowPageDesign.InitPage(flowId);
        }

        public DataSet FieldDesignBeenLayout(int flowId, string fieldId)
        {
            return DAL.WorkFlow.FlowPageDesign.FieldDesignBeenLayout(flowId, fieldId);
        }

        public  bool FieldDesignBeenRef(int flowId, string fieldId)
        {
            return DAL.WorkFlow.FlowPageDesign.FieldDesignBeenRef(flowId, fieldId);
        }

        public void FieldDesignDelete(int flowId, string fieldId)
        {
            DAL.WorkFlow.FlowPageDesign.FieldDesignDelete(flowId, fieldId);
        }

        public DataSet GetFieldDesignLayout(int flowId, string formPage)
        {
            return DAL.WorkFlow.FlowPageDesign.GetFieldDesignLayout(flowId, formPage);
        }

        public DataSet FieldDesignGetFieldActiveList(int flowId, string formPage, int activityId)
        {
            return DAL.WorkFlow.FlowPageDesign.FieldDesignGetFieldActiveList(flowId, formPage, activityId);
        }

        public void FlowPageCopy(int flowId, string pageTo, string pageFrom)
        {
            DAL.WorkFlow.FlowPageDesign.FlowPageCopy(flowId, pageTo, pageFrom);
        }

        public void FieldDesignUpdateFieldProperty(int flowId, string formPage, string empId, int fieldId, string flag)
        {
            DAL.WorkFlow.FlowPageDesign.FieldDesignUpdateFieldProperty(flowId, formPage, empId, fieldId, flag);
        }

        public void FieldDesignUpdateFieldSerial(int flowId, string formPage, string empId, string fieldName, int serial)
        {
            DAL.WorkFlow.FlowPageDesign.FieldDesignUpdateFieldSerial(flowId, formPage, empId, fieldName, serial);
        }

        public void FieldDesignSaveLayout(int flowId, string formPage, string formLayoutOrigin, string formLayout, string createBy, string changedBy)
        {
            DAL.WorkFlow.FlowPageDesign.FieldDesignSaveLayout(flowId, formPage, formLayoutOrigin, formLayout, createBy, changedBy);
        }

        public void DesignTableSave(int flowId, int tableSerial, string tableName, string tableType, string tableLabel, string tableLabelLangId, bool editableA, bool editableV, bool editableP)
        {
            DAL.WorkFlow.FlowPageDesign.DesignTableSave(flowId, tableSerial, tableName, tableType, tableLabel, tableLabelLangId, editableA, editableV, editableP);
        }

        public void DesignTableMove(string tableName, int intSerail)
        {
            DAL.WorkFlow.FlowPageDesign.DesignTableMove(tableName, intSerail);
        }

        public bool DeleteFormTableFlag(string tableName)
        {
            return DAL.WorkFlow.FlowPageDesign.DeleteFormTableFlag(tableName);
        }

        public void DeleteArea(int flowId, string formPage, string strOriHTML, string strHTML, string changedBy)
        {
            DAL.WorkFlow.FlowPageDesign.DeleteArea(flowId, formPage, strOriHTML, strHTML, changedBy);
        }

        public void DesignTableDelete(string tableName)
        {
            DAL.WorkFlow.FlowPageDesign.DesignTableDelete(tableName);
        }
    }
}
