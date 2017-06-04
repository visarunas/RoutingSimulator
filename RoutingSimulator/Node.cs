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
        public List<Packet> packetCache = new List<Packet>();
        private NodeVisualController visual;

        public void ReceiveJoinQuery(JoinQuery joinQuery)
        {
            foreach(var jq in messageCache)
            {
                if (jq.Source == joinQuery.Source && jq.Sequence >= joinQuery.Sequence)
                {
                    Console.WriteLine(this.Name + " received duplicate JQ from " + joinQuery.LastHop);
                    return;
                }
            }
            Console.WriteLine(this.Name + " received JQ from " + joinQuery.LastHop);

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

            Console.WriteLine(this.Name + " transmitting JR");

            foreach(Node node in ConnectedNodes)
            {
                Task.Delay(sendDelay).ContinueWith(t => node.ReceiveJoinReply(reply));
            }
            
            
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
           
            if (reply.NextHop == this.Name)
            {
                Console.WriteLine(this.Name + " received JR");
                this.FG_FLAG = true;

                var routingEntry = routingTable.Find(x => x.Destination == reply.Source);

                var jr = new JoinReply()
                {
                    Source = reply.Source,
                    NextHop = routingEntry.NextNode,
                };

                foreach(var node in ConnectedNodes)
                {
                    Task.Delay(sendDelay).ContinueWith(t => node.ReceiveJoinReply(jr));
                }
                
            }
            else
            {
                Console.WriteLine(this.Name + " Received JR and Dropped");
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
            Console.WriteLine(this.Name + " transmitting JQ");

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

        public void SendPacket(Packet pack = null)
        {
            if (pack == null)
            {
                Console.WriteLine("------------");
                pack = new Packet();
            }

            packetCache.Add(pack);

            Console.WriteLine(this.Name + " transmitting packet");

            foreach (var node in this.ConnectedNodes)
            {

                node.ReceivePacket(pack);
            }
            
        }

        public void ReceivePacket(Packet pack)
        {
            foreach (var packet in packetCache)
            {
                if (pack == packet)
                {
                    Console.WriteLine(this.Name + " received duplicate packet");
                    return;
                }
            }

            if (this.Receiver)
            {
                Console.WriteLine("Receiver " + this.Name + "  received packet");
            }
            else
            {
                Console.WriteLine(this.Name + " received packet");
            }

            if (this.FG_FLAG)
            {
                Task.Delay(sendDelay + 300).ContinueWith(t => this.SendPacket(pack));
                //SendPacket();
            }
            
        }
    }
}
