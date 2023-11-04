using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Anchor.FA.Model
{
    public class V7DataContext : DataContext
    {
        #region Model

        #region View
        public Table<TAcceptEvent> TAcceptEvent;
        public Table<TAccidentPatient> TAccidentPatient;
        public Table<TAccidentReport> TAccidentReport;
        public Table<TAlarmCall> TAlarmCall;
        public Table<TAlarmCallOther> TAlarmCallOther;
        public Table<TAlarmEvent> TAlarmEvent;
        public Table<TAmbulance> TAmbulance;
        public Table<TAmbulancePersonSign> TAmbulancePersonSign;
        public Table<TAmbulanceStateTime> TAmbulanceStateTime;
        public Table<TBackCall> TBackCall;
        public Table<TBackCallAudit> TBackCallAudit;
        public Table<TBackCallRecordLink> TBackCallRecordLink;
        public Table<TBackCallSM> TBackCallSM;
        public Table<TBlackList> TBlackList;
        public Table<TCenter> TCenter;
        public Table<TDesk> TDesk;
        public Table<THospitalInfo> THospitalInfo;
        public Table<TModifyRecord> TModifyRecord;
        public Table<TNotice> TNotice;
        public Table<TNoticeLog> TNoticeLog;
        public Table<TOperatorSign> TOperatorSign;
        public Table<TOperatorSignNew> TOperatorSignNew;
        public Table<TParameterAcceptInfo> TParameterAcceptInfo;
        public Table<TPauseRecord> TPauseRecord;
        public Table<TPerson> TPerson;
        public Table<TRole> TRole;
        public Table<TStation> TStation;
        public Table<TTask> TTask;
        public Table<TTaskPersonLink> TTaskPersonLink;
        public Table<TTelBook> TTelBook;
        public Table<TTelLog> TTelLog;
        public Table<TTelQueue> TTelQueue;
        public Table<TZAcceptEventType> TZAcceptEventType;
        public Table<TZAccidentLevel> TZAccidentLevel;
        public Table<TZAccidentType> TZAccidentType;
        public Table<TZAge> TZAge;
        public Table<TZAlarmCallType> TZAlarmCallType;
        public Table<TZAlarmEventOrigin> TZAlarmEventOrigin;
        public Table<TZAlarmEventType> TZAlarmEventType;
        public Table<TZAlarmReason> TZAlarmReason;
        public Table<TZAmbulanceGroup> TZAmbulanceGroup;
        public Table<TZAmbulanceLevel> TZAmbulanceLevel;
        public Table<TZAmbulanceState> TZAmbulanceState;
        public Table<TZAmbulanceType> TZAmbulanceType;
        public Table<TZArea> TZArea;
        public Table<TZCallType> TZCallType;
        public Table<TZDeskType> TZDeskType;
        public Table<TZDropReason> TZDropReason;
        public Table<TZFolk> TZFolk;
        public Table<TZHangUpReason> TZHangUpReason;
        public Table<TZIllState> TZIllState;
        public Table<TZLocalAddrType> TZLocalAddrType;
        public Table<TZNational> TZNational;
        public Table<TZNoticeType> TZNoticeType;
        public Table<TZOperationOrigin> TZOperationOrigin;
        public Table<TZPauseReason> TZPauseReason;
        public Table<TZRejectReason> TZRejectReason;
        public Table<TZSendAddrType> TZSendAddrType;
        public Table<TZTaskAbendReason> TZTaskAbendReason;
        public Table<TZTelLogOperator> TZTelLogOperator;
        public Table<TZTelLogRecordType> TZTelLogRecordType;
        public Table<TZTelLogResult> TZTelLogResult;
        public Table<TZTelType> TZTelType;

        public Table<TZModifyRecordType> TZModifyRecordType;
        public Table<TZCommandAspect> TZCommandAspect;
        public Table<TZBranch> TZBranch;
        
        #endregion
        #endregion


        private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();

        public V7DataContext() :
            base(System.Configuration.ConfigurationManager.ConnectionStrings["Anchor120V7"].ConnectionString, mappingSource)
        {
        }
        public V7DataContext(string connection) : base(connection, mappingSource) { }
        public V7DataContext(IDbConnection con) : base(con, mappingSource) { }
    }
}
