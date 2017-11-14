using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Localization;
using Orchard.Services;
using Orchard.Tokens;

namespace LectureLinx.TrainingDemo.Module.Tokens
{
    public class UtcNowTokens : ITokenProvider
    {
        private readonly IClock _clock;

        public Localizer T { get; set; }


        public UtcNowTokens(IClock clock)
        {
            _clock = clock;

            T = NullLocalizer.Instance;
        }


        public void Describe(DescribeContext context)
        {
            // {UtcNow.Default} {UtcNow.Short}

            // LectureLinx.TrainingDemo.Module.Tokens.UtcNowTokens "UTC Date/Time Now" -> "Jelenlegi UTC dátum/idő"

            context.For("UtcNow", T("UTC Date/Time Now"), T("Current UTC Date/Time."))
                .Token("Default", T("Default"), T("The current Date/Time in UTC, with default formatting."), "Text");
        }

        public void Evaluate(EvaluateContext context)
        {
            context.For("UtcNow", () => _clock.UtcNow)
                .Token("Default", dateTime => dateTime.ToString())
                .Chain("Default", "Text", dateTime => dateTime.ToString());
        }
    }
}