namespace CurseForgeClient.Extensions
{
    public static class HttpClientExtensions
    {
        public static void AddHeaders(this HttpClient client, Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
        public static Image Resize(this Image image, Size newSize)
        {
            var newImage = new Bitmap(newSize.Width, newSize.Height);

            using var graphics = Graphics.FromImage((Bitmap)newImage);
            graphics.DrawImage(image, new Rectangle(Point.Empty, newSize));

            return newImage;
        }
    }
}
