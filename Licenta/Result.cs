using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta
{
    class Result
    {
        public String url { get; set; }
        public String keyword { get; set; }
        public String context { get; set; }

        public Result(String url, String keyword, String context)
        {
            this.url = url;
            this.keyword = keyword;
            this.context = context;
        }
    }
}
