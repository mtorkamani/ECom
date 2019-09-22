using ECom.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom.Tests.Doubles
{
    public class FakeOptions : IOptions<EComConfiguration>
    {
        public EComConfiguration Value => new EComConfiguration
        {
            Token = "TOKEN",
            WooliesXBaseUrl = "https://somewhere"
        };
    }
}
