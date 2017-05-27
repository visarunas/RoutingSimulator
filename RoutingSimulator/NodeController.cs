﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingSimulator
{
    public class NodeController
    {
        private Alphabet alphabet = new Alphabet();
        public List<Node> nodes = new List<Node>();

        public void SendJoinQuery(Node sender)
        {
            sender.SendJoinQuery();

        }

        public void LinkNodes(Node node1, Node node2)
        {

            node1.ConnectedNodes.Add(node2);
            node2.ConnectedNodes.Add(node1);
        }

        public void UnlinkNode(Node removedNode)
        {
            foreach (var node in removedNode.ConnectedNodes)
            {
                node.ConnectedNodes.Remove(removedNode);
            }

        }

        public Node AddNewNode()
        {
            var node = new Node(alphabet.GetNextLetter());
            nodes.Add(node);

            return node;
        }

        public void RemoveNode(Node node)
        {
            nodes.Remove(node);
        }

        public void Reset()
        {
            foreach(var node in nodes)
            {
                node.messageCache.Clear();
                node.routingTable.Clear();
                node.Receiver = false;
            }
        }
    }
}
