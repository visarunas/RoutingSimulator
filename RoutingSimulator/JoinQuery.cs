using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingSimulator
{
    public class JoinQuery
    {
        public string Source { get; set; }
        public string LastHop { get; set; }
        public int Sequence { get; set; }

        public int HopCount { get; set; } = 0;


        public JoinQuery(Node sender, int seq)
        {
            this.Source = sender.Name;
            this.LastHop = sender.Name;
            this.Sequence = seq;
        }

        public JoinQuery(JoinQuery jq)
        {
            this.Source = jq.Source;
            this.LastHop = jq.LastHop;
            this.HopCount = jq.HopCount;
            this.Sequence = jq.Sequence;
        }


    }
}
