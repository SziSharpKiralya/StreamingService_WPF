namespace StreamingService_WPF
{
    internal class Video
    {
        private string title;
        private int length;
        public Video(string title, int length)
        {
            this.title = title;
            this.length = length;
        }

        public string Title { get => title; }
        public int Length { get => length; }
    }
}
