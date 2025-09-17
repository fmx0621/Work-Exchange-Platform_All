namespace Job.Models
{
    public class CJobItem
    {
        // 公司資料表(需替換)
        public TCompanyProfile Company { get; set; }
        // 職缺基本資料
        public TJobPosting jobPosting {  get; set; }
        // 職缺狀態
        public TJobPostingStatus jobPostingStatus { get; set; }
        // 職缺詳細資料
        public TJobPostingDetail jobPostingDetail { get; set; }
    }
}
