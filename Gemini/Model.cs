using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialProject.Gemini
{
    public class geminiResponse
    {
        public Candidate[] candidates { get; set; }

        public class Candidate
        {
            public Content content { get; set; }
        }

        public class Content
        {
            public Part[] parts { get; set; }
        }

        public class Part
        {
            public string text { get; set; }
        }
    }
}
