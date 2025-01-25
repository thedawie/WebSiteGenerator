using System;

namespace generator.web.Services;

public interface IGeneratorService
{
    public Task<string> GenerateHTML();
}
