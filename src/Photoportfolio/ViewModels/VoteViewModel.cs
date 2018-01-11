using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photoportfolio.ViewModels
{
    public class VoteViewModel
    {
        public int UserId { get; set; }
        public int PhotoId { get; set; }

        public float Vote { get; set; }
    }
}
