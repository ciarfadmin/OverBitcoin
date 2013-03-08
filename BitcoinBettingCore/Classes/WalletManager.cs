using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace BitcoinBettingCore.Classes
{
    internal class WalletManager : IDisposable
    {
        private MongoCollection<Game> games;
        private List<AddressWatcher> watchers = new List<AddressWatcher>();
        internal List<AddressWatcher> Watchers
        {
            get { return watchers; }
            set { watchers = value; }
        }

        private List<BettingManager> bettingManagers = new List<BettingManager>();
        internal List<BettingManager> BettingManagers
        {
            get { return bettingManagers; }
            set { bettingManagers = value; }
        }

        private MongoServer server;
        private MongoDatabase database;

        #region Constructor

        public WalletManager()
        {
            this.server = MongoServer.Create("mongodb://localhost/?safe=true"); //"mongodb://localhost/?safe=true");
            this.database = server.GetDatabase("BitcoinBettingSystem"); //"CrossBitCore");

            loadAddresses();
            startWatchers();
        }

        #endregion

        #region Internal Methods

        internal void stopProcesses()
        {
            foreach (BettingManager manager in bettingManagers)
                manager.stop();
            foreach (AddressWatcher watcher in watchers)
                watcher.stop();
        }

        #endregion

        #region Private Methods

        private void loadAddresses()
        {
            games = database.GetCollection<Game>("Games");
        }

        private void startWatchers()
        {
            watchers = new List<AddressWatcher>();

            foreach (Game game in games.FindAll())
            {
                AddressWatcher watch = new AddressWatcher(game);
                BettingManager manager = new BettingManager(watch, games);

                watchers.Add(watch);
                bettingManagers.Add(manager);

                Thread tw = new Thread(watch.start);
                tw.Start();
                Thread tp = new Thread(manager.start);
                tp.Start();
            }
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            stopProcesses();
        }

        #endregion
    }
}
