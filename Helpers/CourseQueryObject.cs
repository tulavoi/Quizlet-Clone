namespace api.Helpers
{
    public class CourseQueryObject
    {
        public string? SortBy { get; set; }
        public bool IsDescending { get; set; } = false;
        public int Quantity { get; set; }
        public bool GetAll { get; set; } = false;
        public string? FilterBy { get; set; }
    }
}
