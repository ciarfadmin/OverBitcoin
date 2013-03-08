using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bitnet.Client;
using Newtonsoft.Json.Linq;

namespace BitcoinBettingCore.Classes
{
    internal class BitcoinDaemonManager
    {

        internal static BitnetClient getBitcoinClient()
        {
            BitnetClient bitnetClient = new BitnetClient("http://127.0.0.1:8332");
            bitnetClient.Credentials = new NetworkCredential("bitcoinrpc_oscar", "F9jP4zHGZ812jahTeaY7WnuBE38dS6vrEUzxp5MS2NWq");

            return bitnetClient;
        }
    }
}
