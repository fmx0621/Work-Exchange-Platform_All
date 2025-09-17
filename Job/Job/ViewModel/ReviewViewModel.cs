using System.ComponentModel.DataAnnotations;

namespace Job.ViewModel
{
    public class ReviewViewModel
    {
        [Range(1, 5, ErrorMessage = "請選 1 到 5 星")]
        public int Rating { get; set; }   // 1~5（整數）
        public string Comment { get; set; }
    }
}
