namespace StreamingService_WPF
{
    internal class Series : IContent
    {
        private string title;
        private List<Video> videos;

        public Series(string title, List<Video> videos)
        {
            this.title = title;
            this.videos = videos;
        }

        public string GetTitle()
        {
            return title;
        }

        public int GetLength()
        {
            int totalLength = 0;
            foreach (var video in videos)
            {
                totalLength += video.Length;
            }
            return totalLength;
        }
    }
}
