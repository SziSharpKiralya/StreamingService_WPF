namespace StreamingService_WPF
{
    internal class Movie : IContent
    {
        private Video video;

        public Movie(Video video)
        {
            this.video = video;
        }

        public string GetTitle()
        {
            return video.Title;
        }

        public int GetLength()
        {
            return video.Length;
        }
    }
}
