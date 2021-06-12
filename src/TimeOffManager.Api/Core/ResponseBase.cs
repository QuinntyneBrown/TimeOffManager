using System.Collections.Generic;

namespace TimeOffManager.Api.Core
{
    public class ResponseBase
    {
        public List<string> ValidationErrors { get; set; }
    }
}
