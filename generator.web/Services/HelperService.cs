using System;
using System.Text;

namespace generator.web.Services;

public class HelperService : IHelperService
{
    const string pathtoFolder = "/Users/david/code/test/websiteGenerator/generator.web/";
    public Task<bool> CreateFiles(string[] sections)
    {
        string htmlSection = "";
        string cssSection = "";

        var generatedFolderPath = pathtoFolder + "Temp/generated/";

        if (Directory.Exists(generatedFolderPath))
        {
            Directory.Delete(generatedFolderPath, true);
            Directory.CreateDirectory(generatedFolderPath);
        }

        foreach (string section in sections)
        {
            // Check if the section starts with "html" or "css"
            if (section.TrimStart().StartsWith("html", StringComparison.OrdinalIgnoreCase))
            {
                htmlSection = section.Replace("html", "");

                using (FileStream fs = File.Create(generatedFolderPath + "index.html"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(htmlSection);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
            else if (section.TrimStart().StartsWith("css", StringComparison.OrdinalIgnoreCase))
            {
                cssSection = section.Replace("css", "");
                using (FileStream fs = File.Create(generatedFolderPath + "styles.css"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(cssSection);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        return Task.FromResult(true);
    }

    public Task<string[]> DeconstructGenerateResponse(string generatedResponse)
    {
        if (string.IsNullOrEmpty(generatedResponse))
        {
            return Task.FromResult(new string[0]);
        }
        string[] sections = generatedResponse.Split(["```"], StringSplitOptions.None);

        for (int i = 0; i < sections.Length; i++)
        {
            Console.WriteLine(sections[i]);
        }

        return Task.FromResult(sections);
    }
}