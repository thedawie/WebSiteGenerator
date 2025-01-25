using System;

namespace generator.web.Services;

public interface IHelperService
{
    public Task<string[]> DeconstructGenerateResponse(string generatedResponse);

    public Task<bool> CreateFiles(string[] sections);
}
