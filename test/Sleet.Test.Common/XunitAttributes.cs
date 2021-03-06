using System;
using NuGet.Common;
using Xunit;

namespace Sleet.Test.Common
{
    public sealed class WindowsFactAttribute
        : FactAttribute
    {
        public override string Skip => RuntimeEnvironmentHelper.IsWindows ? null : "Windows only test";
    }

    public sealed class WindowsTheoryAttribute
    : TheoryAttribute
    {
        public override string Skip => RuntimeEnvironmentHelper.IsWindows ? null : "Windows only test";
    }

    public sealed class EnvVarExistsFactAttribute
        : FactAttribute
    {
        private readonly string _envVar;

        public EnvVarExistsFactAttribute(string envVar)
        {
            _envVar = envVar;
        }

        public override string Skip => !string.IsNullOrEmpty(Environment.GetEnvironmentVariable(_envVar)) ? null : $"Set env var: {_envVar} to run this test. This can be ignored for non CI scenarios.";
    }
}
