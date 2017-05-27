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

        public int HopCount { get; set; } = 0;


        public JoinQuery(Node sender)
        {
            this.Source = sender.Name;
            this.LastHop = sender.Name;
        }

        public JoinQuery(JoinQuery jq)
        {
            this.Source = jq.Source;
            this.LastHop = jq.LastHop;
            this.HopCount = jq.HopCount;
        }


    }
}
