using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class CacheSettings
    {
        public Keys Keys { get; set; }
        public int Duration { get; set; }
    }
}
