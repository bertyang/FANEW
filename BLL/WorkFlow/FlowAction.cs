using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Anchor.FA.BLL.IBLL;
using Anchor.FA.Model;
using Anchor.FA.BLL.WorkFlow.Interface;

namespace Anchor.FA.BLL.WorkFlow
{
    internal class FlowAction<T>
    {
        public T action;

        public FlowAction(bool isInner, int flowId)
        {
            if (isInner)
            {
                string actionClassName = string.Format("FLOW{0}.Action", flowId);
                string dllName = string.Format("FLOW{0}", flowId);

                action = (T)Assembly.Load(dllName).CreateInstance(actionClassName);
            }
            else
            {
                F_FLOW_CONFIG actionDllName = DAL.WorkFlow.Flow.
                    GetFlowConfig(flowId, "ActionDllName").SingleOrDefault();
                F_FLOW_CONFIG actionClassName = DAL.WorkFlow.Flow.
                    GetFlowConfig(flowId, "ActionClassName").SingleOrDefault();

                if (actionDllName != null && actionDllName != null
                            && !string.IsNullOrEmpty(actionDllName.ItemValue) 
                            && !string.IsNullOrEmpty(actionClassName.ItemValue))
                {
                    action = (T)Assembly.
                        Load(actionDllName.ItemValue).
                        CreateInstance(actionClassName.ItemValue);

                }
            }
        }
    }
}
