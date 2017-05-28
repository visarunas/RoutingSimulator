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
        public bool FG_FLAG = false;

        public List<JoinQuery> messageCache = new List<JoinQuery>();
        public List<RoutingEntry> routingTable = new List<RoutingEntry>();

        public void ReceiveJoinQuery(JoinQuery joinQuery)
        {
            Console.WriteLine(joinQuery.LastHop + " > " + this.Name + " JQ");

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
            var reply = new JoinReply()
            {
                Source = joinQuery.Source,
                NextHop = joinQuery.LastHop
            };

            var node = ConnectedNodes.Find(x => x.Name == joinQuery.LastHop);
            Task.Delay(sendDelay).ContinueWith(t => node.ReceiveJoinReply(reply));
        }

        public void ReceiveJoinReply(JoinReply reply)
        {
            if (this.Name == reply.Source)
            {
                Console.WriteLine("Source received JR");
                return;
            }

            Console.WriteLine(this.Name + " Received" + " JR");
            if (reply.NextHop == this.Name)
            {
                this.FG_FLAG = true;

                var routingEntry = routingTable.Find(x => x.Destination == reply.Source);

                var jr = new JoinReply()
                {
                    Source = reply.Source,
                    NextHop = routingEntry.NextNode,
                };

                var node = ConnectedNodes.Find(x => x.Name == routingEntry.NextNode);
                Task.Delay(sendDelay).ContinueWith(t => node.ReceiveJoinReply(reply));
            }
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
            Console.WriteLine("---------");
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
