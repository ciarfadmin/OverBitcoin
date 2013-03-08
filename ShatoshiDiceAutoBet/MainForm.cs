using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bitnet.Client;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShatoshiDiceAutoBet
{
    public partial class MainForm : Form
    {
        private string account;
        private BitnetClient bc;

        private bool testFirst = true;

        public MainForm()
        {
            InitializeComponent();

            bc = new BitnetClient("http://127.0.0.1:8332");
            bc.Credentials = new NetworkCredential("bitcoinrpc_oscar", "F9jP4zHGZ812jahTeaY7WnuBE38dS6vrEUzxp5MS2NWq");

            account = txtOurAddress.Text;



            var p = bc.ListReceivedByAddress(0, true);
            txtResults.Text += Environment.NewLine + p.ToString();
            /*
            This release no longer maintains a full index of historical transaction ids
            by default, so looking up an arbitrary transaction using the getrawtransaction
            RPC call will not work. If you need that functionality, you must run once
            with -txindex=1 -reindex=1 to rebuild block-chain indices (see below for more
            details).
             * 
             * 
             * https://bitcointalk.org/index.php?topic=115488.0
               Ok from the help of the people on freenode/bitcoin-dev I was able to resolve the addresses from the inputs of a transaction using the vin.prevout

                so just for other people to know...  exmaple to find out the first input's address

                Code:
                CWalletTx wtx;
                pwalletMain->GetTransaction(uint256(txid), wtx);     // get current transaction
                CTxIn vin = wtx.vin[0];                                        //get first input
                CWalletTx wtxPrev;                                     
                pwalletMain->GetTransaction(vin.prevout.hash, wtxPrev);    // get the vin's previous transaction 
                CTxDestination source;
                ExtractDestination(wtxPrev.vout[vin.prevout.n].scriptPubKey, source);  // extract the destination of the previous transaction's vout[n]
                CBitcoinAddress addressSource(source);                // convert this to an address

                print addressSource.ToString() // might as well print it!

             * 
             * http://bitcoin.stackexchange.com/questions/2667/whats-the-best-way-for-a-website-to-detect-payments-from-green-addresses/5981#5981
             * http://bitcoin.stackexchange.com/questions/3896/how-to-findout-the-sender-of-a-transaction/5982#5982     !!!Importante
             * https://bitcointalk.org/index.php?topic=89725.msg990497#msg990497
             * bitcoin-qt.exe" -txindex=1 -reindex=1
            var res = bc.InvokeMethod("getrawtransaction", "84535109ec65e4d39b495907e155e1905527560883c50bdd9a04feac37249bab", 1)["result"] as JObject;
            txtResults.Text += res.ToString();
             */
            //refreshData();
            //timerRefresh.Start();

        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            refreshData();
        }

        private void refreshData()
        {
            txtResults.Clear();
            //1GonMnVkimB9DUWBYxDxfzgeeQREfJ1ddz -> 1,297
            //1Efr3jzUgBVUTHk9BizQBYL2eq4kvJwVTV -> 1,07778
            //1Jz18RTwNSiDBxEfjYEPrYnUFjAGidx1qb -> 0
            //1H9wKeiiXVx8fqGXAL8YZYbURfqkE5YsR8 -> 0

            //var p = bc.ListReceivedByAddress(1, true);
            List<Transaction> tr = null;
            int totalTransactions = 0;

            var p = bc.ListTransactions((txtAccount.Text == null) ? string.Empty : txtAccount.Text, 10000);
            tr = JsonConvert.DeserializeObject<List<Transaction>>(p.ToString());
            totalTransactions += tr.Count();
            txtResults.Text += Environment.NewLine + p.ToString();

            //var p = bc.ListTransactions("MainAccount", 100);
            //tr = JsonConvert.DeserializeObject<List<Transaction>>(p.ToString());
            //totalTransactions += tr.Count();
            //txtResults.Text += Environment.NewLine + p.ToString();

            //p = bc.ListTransactions("Bet_50", 100);
            //tr = JsonConvert.DeserializeObject<List<Transaction>>(p.ToString());
            //totalTransactions += tr.Count();
            //txtResults.Text += Environment.NewLine + p.ToString();

            //var p = bc.ListTransactions("Bet_75", 100);
            //tr = JsonConvert.DeserializeObject<List<Transaction>>(p.ToString());
            //totalTransactions += tr.Count();
            //txtResults.Text += Environment.NewLine + p.ToString();

            //p = bc.ListTransactions("Bet_25", 100);
            //tr = JsonConvert.DeserializeObject<List<Transaction>>(p.ToString());
            //totalTransactions += tr.Count();
            //txtResults.Text += Environment.NewLine + "------------------------" + Environment.NewLine + p.ToString();

            //p = bc.ListReceivedByAccount(1);
            //txtResults.Text += p.ToString();
            txtTotalTr.Text = totalTransactions.ToString();
            txtBalance.Text = bc.GetBalance().ToString();


            txtResults.Text += "DATA::::" + Environment.NewLine;
            int blockcount = bc.GetBlockCount();
            txtResults.Text += blockcount + "--" + bc.GetBlockHash(blockcount);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bc.SendFrom("Bet_75", txtToAddress.Text, float.Parse(txtAmmountToTransfer.Text));
            MessageBox.Show(float.Parse(txtAmmountToTransfer.Text).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                txtResults.Clear();
                //txtResults.Text = bc.GetTransaction(txtTxi.Text).ToString() + Environment.NewLine + "------------------------";

                List<string> addresses = new List<string>();
                var rawTransaction = bc.GetRawTransaction(txtTxi.Text);
                foreach (JObject input in rawTransaction["vin"])
                {
                    var inputRawTx = bc.GetRawTransaction(input["txid"].ToString());
                    int iv = (int)input["vout"];
                    addresses.Add(inputRawTx["vout"][iv]["scriptPubKey"]["addresses"][0].ToString());
                }


                foreach (string s in addresses)
                    txtResults.Text += s + Environment.NewLine;

                //string txid = rawTransaction["vin"][0]["txid"].ToString();
                //var raw = bc.GetRawTransaction(txid);
                //var test = raw["vout"][0];
                //foreach (JValue s in raw["vout"][0]["scriptPubKey"]["addresses"])
                //{
                //    txtResults.Text += s.ToString() + Environment.NewLine;
                //}
                //txtResults.Text = raw["vout"][0]["scriptPubKey"]["addresses"][0].ToString();

                /*
                foreach (Vin v in Vin.GetListFromRawTransaction(rawTransaction))
                {
                    txtResults.Text += Environment.NewLine + v.txid;
                    txtResults.Text += bc.GetRawTransaction(v.txid) + Environment.NewLine;
                }*/
            }
            catch
            {
                MessageBox.Show("Ups");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtResults.Text = bc.GetRawTransaction(txtTxi.Text).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtResults.Clear();

            List<Transaction> transactions = new List<Transaction>();
            var rawTransactions = bc.ListTransactions((txtAccount.Text == null) ? string.Empty : txtAccount.Text, 10000);

            int lastTimeReceived = Convert.ToInt32(txtHash.Text);
            var g = from t in rawTransactions where t["category"].ToString() == "receive" && (int)t["timereceived"] > lastTimeReceived orderby t["timereceived"] select t;

            foreach (var t in g)
            {
                transactions.Add(JsonConvert.DeserializeObject<Transaction>(t.ToString()));
            }

            List<Transaction> computedTrans= new List<Transaction>();
            /*if (!testFirst)
            {
                computedTrans.Add(transactions[0]);
                computedTrans.Add(transactions[1]);
            }
            testFirst = !testFirst;
            */
            var pendingTransactions = transactions.Except(computedTrans);
            foreach (var t in pendingTransactions)
            {
                txtResults.Text += Environment.NewLine + t.txid + " - " + t.amount + " - " + t.confirmations + " - " + t.timereceived;
            }
            txtTotalTr.Text = pendingTransactions.Count().ToString();
            
        }
    }
}
