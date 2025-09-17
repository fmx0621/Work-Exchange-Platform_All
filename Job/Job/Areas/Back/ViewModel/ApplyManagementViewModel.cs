using Job.Models;

namespace Job.ViewModel
{
    public class ApplyManagementViewModel
    {
        public string txtKeyword { get; set; }

        public string ApplyStatus { get; set; }  // 狀態篩選

        public IEnumerable<TWorkerApply> TworkerApplies { get; set; }
        //IEnumerable 用來儲存循序遍歷的集合（例如：List、Array、Queue 等）

        public TWorkerApply TworkerApply { get; set; }

        public DateTime? StartDate { get; set; }  // 新增

        public DateTime? EndDate { get; set; }    // 新增

        public IEnumerable<TOwnerAdmission> TownerAdmissions { get; set; }
        public TOwnerAdmission TownerAdmission { get; set; }

    }
}

