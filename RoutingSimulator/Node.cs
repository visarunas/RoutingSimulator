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
        const int sendDelay = 1000;

        public Node(string name)
        {
            this.Name = name;
        }

        public List<Node> ConnectedNodes { get; set; } = new List<Node>();

        public string Name { get; set; }
        public bool Receiver { get; set; } = false;

        public List<JoinQuery> messageCache = new List<JoinQuery>();
        public List<RoutingEntry> routingTable = new List<RoutingEntry>();

        public void ReceiveJoinQuery(JoinQuery joinQuery)
        {
            Console.WriteLine("JoinQuery received at " + this.Name);

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
            }

            joinQuery.HopCount++;

            Task.Delay(sendDelay).ContinueWith(t => ContinueJoinQuery(joinQuery));
            
        }

        public void SendJoinReply(JoinQuery joinQuery)
        {
            var reply = new JoinReply();
        }

        public void ContinueJoinQuery(JoinQuery receivedJoinQuery)
        {
            var jq = new JoinQuery(receivedJoinQuery)
            {
                LastHop = this.Name
            };

            foreach (var node in this.ConnectedNodes)
            {
                if (node.Name != receivedJoinQuery.Source && node.Name != receivedJoinQuery.LastHop)
                {
                    node.ReceiveJoinQuery(jq);
                }
                
            }

        }

        public void SendJoinQuery()
        {
            foreach (var node in this.ConnectedNodes)
            {
                node.ReceiveJoinQuery(new JoinQuery(this));
            }

        }

        public void UpdateTable(JoinQuery joinQuery)
        {
            var entry = new RoutingEntry()
            {
                Destination = joinQuery.Source,
                NextNode = joinQuery.LastHop
            };

            routingTable.Add(entry);
        }
    }
}
