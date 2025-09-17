namespace Job.Models
{
    public class CFilter
    {
        public string filtered(string s)
        {
            string[] filters = { "幹", "操" };
            foreach (var word in filters)
            {
                s = s.Replace(word, "**"); // 你可以改成 "*", "###" 等
            }
            return s;
        }
    }
}
