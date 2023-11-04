using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Anchor.FA.Model;

namespace Anchor.FA.BLL.IBLL
{
    public interface IWorker
    {
        B_WORKER GetWorkerById(int? userId);
        List<B_WORKER> GetWorkerByRole(int roleId);
        C_Worker_Level GetLevelByOrg(int workerId, int orgId);
        C_Worker_Level GetDefaultLevel(int workerId);
        object GetUnitList(int workerId);
    }
}
