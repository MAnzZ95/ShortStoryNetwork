using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortStoryNetwork.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string PostName { get; set; }

        public DateTime PostDate { get; set; }
    }
}
