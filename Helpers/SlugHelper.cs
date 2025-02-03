namespace SmartCards.Helpers
{
    public static class SlugHelper
    {
        public static int GetIdBySlug(string slug)
        {
            var parts = slug.Split('-');
            return int.Parse(parts[parts.Length - 1]);
        }
    }
}
