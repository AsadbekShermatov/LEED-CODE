namespace LEED_CODE.Models
{
    public class UserDb
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string About { get; set; }
        public int Submitted { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int SubmissionCount { get; set; }
        public int CommentCount { get; set; }
        public int CreatedAt { get; set; }
    }
}
