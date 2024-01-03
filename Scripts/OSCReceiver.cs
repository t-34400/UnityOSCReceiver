#nullable enable

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using OSCPacket;

namespace OSCReceiver
{
    public class OSCReceiver : MonoBehaviour
    {
        [SerializeField] private int port = 9000;
        [SerializeField] private List<DispatcherBase> dispatchers = new();

        private readonly object receivedPacketLock = new object();
        private readonly List<Packet> receivedPackets = new();

        private UdpClient? udpServer;

        private void Start()
        {
            udpServer = new UdpClient(port);
            udpServer.BeginReceive(ReceiveCallback, null);
        }

        private void Update()
        {
            lock(receivedPacketLock)
            {
                receivedPackets.ForEach(packet => 
                        dispatchers.ForEach(dispatcher => dispatcher.Dispatch(packet))
                    );
                receivedPackets.Clear();
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] receivedBytes = udpServer!.EndReceive(ar, ref remoteEndPoint);

            if(Packet.TryParseOSCPacket(receivedBytes, out var oscPacket))
            {
                lock(receivedPacketLock)
                {
                    receivedPackets.Add(oscPacket);
                }
            }

            udpServer?.BeginReceive(ReceiveCallback, null);
        }

        private void OnDestroy()
        {
            udpServer?.Close();
        }
    }
}
