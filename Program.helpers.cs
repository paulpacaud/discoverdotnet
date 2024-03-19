using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

public class helper
{
    public static void ResizeImage(string currentFile)
    {
        using (Image image = Image.Load(currentFile))
        {
            image.Mutate(x => x.Resize(image.Width / 2, image.Height / 2));
            image.Save(currentFile.Replace("raw", "processed"));
        }
    }
}