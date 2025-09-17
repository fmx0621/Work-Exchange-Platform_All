using Job.Models;
using System;
using System.Collections.Generic;

namespace Job.ViewModel
{
    public class CApplyManagementViewModel
    {
        public string txtKeyword { get; set; }

        public string ApplyStatus { get; set; }  // 業主回覆篩選

        public string WorkerReply { get; set; }  // 換宿者回覆篩選

        public IEnumerable<TWorkerApply> TworkerApplies { get; set; }

        public TWorkerApply TworkerApply { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public IEnumerable<TOwnerAdmission> TownerAdmissions { get; set; }

        public TOwnerAdmission TownerAdmission { get; set; }
    }
}
