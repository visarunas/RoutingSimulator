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
        const int sendDelay = 200;

        public Node(string name, NodeVisualController visual)
        {
            this.Name = name;
            this.visual = visual;
        }

        public List<Node> ConnectedNodes { get; set; } = new List<Node>();

        public string Name { get; set; }
        public bool Receiver { get; set; } = false;
        public int Sequence = 0;
        public bool FG_FLAG = false;

        public List<JoinQuery> messageCache = new List<JoinQuery>();
        public List<RoutingEntry> routingTable = new List<RoutingEntry>();
        private NodeVisualController visual;

        public void ReceiveJoinQuery(JoinQuery joinQuery)
        {
            foreach(var jq in messageCache)
            {
                if (jq.Source == joinQuery.Source && jq.Sequence >= joinQuery.Sequence)
                {
                    Console.WriteLine(joinQuery.LastHop + " > " + this.Name + " JQ duplicate = Dropped");
                    return;
                }
            }
            Console.WriteLine(joinQuery.LastHop + " > " + this.Name + " JQ");

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
                //Task.Delay(sendDelay + 1300).ContinueWith(t => this.SendPacket(null));
                //this.SendPacket(null);
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
                node.ReceiveJoinQuery(jq);
                
            }

        }

        public void SendJoinQuery()
        {
            Console.WriteLine("---------");
            this.Sequence++;
            Console.WriteLine("JQ sequence " + this.Sequence);

            foreach (var node in this.ConnectedNodes)
            {
                var jq = new JoinQuery(this, this.Sequence);
                node.ReceiveJoinQuery(jq);

                this.messageCache.Add(jq);
            }

        }

        public void UpdateTable(JoinQuery joinQuery)
        {
            var previousRoutingEntry = routingTable.Find(x => x.Destination == joinQuery.Source);
            if (previousRoutingEntry != null)
            {
                routingTable.Remove(previousRoutingEntry);
            }
            var entry = new RoutingEntry()
            {
                Destination = joinQuery.Source,
                NextNode = joinQuery.LastHop
            };

            routingTable.Add(entry);
        }

        public void SendPacket(Node sender)
        {
            foreach (var node in this.ConnectedNodes)
            {
                if (sender != node)
                {
                    Console.WriteLine("Packet sending from " + this.Name);

                    node.ReceivePacket(this);
                }
                
            }
            
        }

        public void ReceivePacket(Node sender)
        {
            //visual.SendPacket(this, sendDelay);
            if (this.FG_FLAG)
            {
                Task.Delay(sendDelay + 300).ContinueWith(t => this.SendPacket(sender));
                //SendPacket();
            }
        }
    }
}
