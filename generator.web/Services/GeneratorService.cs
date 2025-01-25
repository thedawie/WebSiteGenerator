using System;
using Microsoft.SemanticKernel;

namespace generator.web.Services;

public class GeneratorService : IGeneratorService
{
    private readonly Kernel _kernel;

    public GeneratorService(Kernel kernel)
    {
        _kernel = kernel;
    }

    public async Task<string> GenerateHTML()
    {
        const string prompt = @"
                Generate me the html and css for a {{$input}} site.
                The HTML and the CSS should be in seperate sections split by 
                The beginning of the HTML section should read HTMLSECTION followed by the HTML code.
                The beginning of the CSS section should read CSSSECTION followed by the CSS code.
                ";

        string input = "blue";

        var result = await _kernel.InvokePromptAsync(prompt, new KernelArguments
            {
                {"input", input}
            });


        var generatedHtml = result.GetValue<string>() ?? "";

        return generatedHtml;
    }
}
