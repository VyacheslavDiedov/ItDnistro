using System;

namespace IT_Dnistro.Models
{
    public class ErrorViewModel
    {
        //Todo add description/status-code
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
