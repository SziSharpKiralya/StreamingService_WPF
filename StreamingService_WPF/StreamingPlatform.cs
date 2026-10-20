namespace StreamingService_WPF
{
    internal class StreamingPlatform
    {
        private List<IContent> contents;

        public StreamingPlatform()
        {
            this.contents = [];
        }

        public void AddContent(IContent content)
        {
            contents.Add(content);
        }

        public List<IContent> GetContent()
        {
            return contents;
        }

        public int GetLongest()
        {
            int maxLength = 0;
            foreach (var content in contents)
            {
                int contentLength = content.GetLength();
                if (contentLength > maxLength)
                {
                    maxLength = contentLength;
                }
            }
            return maxLength;
        }
    }
}
