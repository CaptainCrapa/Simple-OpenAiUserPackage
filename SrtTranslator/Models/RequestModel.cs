using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrtTranslator.Models
{
    public class RequestModel
    {
        public string model { get; set; } = "text-davinci-003";
        public string[] prompt { get; set; }
        public string suffix { get; set; }
        public int max_tokens { get; set; } = 16;
        public float temperature { get; set; } = 1;
        public float top_p { get; set; } = 1;
        public int n { get; set; } = 1;
        public bool stream { get; set; } = false;
        public int logprobs { get; set; }
        public bool echo { get; set; } = false;
        public string[] stop { get; set; }
        public float presence_penalty { get; set; } = 0;
        public float frequency_penalty { get; set; } = 0;
        public int best_of { get; set; } = 1;
    }
}
