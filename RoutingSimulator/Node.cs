using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoutingSimulator
{
    public class Node
    {
        public Node(string name)
        {
            this.Name = name;
        }

        public List<Node> ConnectedNodes { get; set; } = new List<Node>();

        public string Name { get; set; }
        public bool Receiver { get; set; } = false;

        public List<JoinQuery> messageCache = new List<JoinQuery>();

        public void ReceiveJoinQuery(JoinQuery joinQuery)
        {
            foreach(var jq in messageCache)
            {
                if (jq.Source == joinQuery.Source)
                {
                    return;
                }
            }
            messageCache.Add(joinQuery);
            UpdateTable(joinQuery);

            if (Receiver)
            {
                SendJoinReply(joinQuery);
                return;
            }

            joinQuery.HopCount++;
            joinQuery.LastHop = this.Name;

            SendJoinQuery();
        }

        public void SendJoinReply(JoinQuery joinQuery)
        {

        }

        public void SendJoinQuery()
        {
            var joinQuery = new JoinQuery(this);

            foreach (var node in this.ConnectedNodes)
            {
                node.ReceiveJoinQuery(joinQuery);
            }

        }

        public void UpdateTable(JoinQuery joinQuery)
        {

        }
    }
}
