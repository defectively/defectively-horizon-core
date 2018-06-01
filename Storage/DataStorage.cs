using System;
using System.Collections.Generic;
using System.IO;
using Defectively.Core.Models;
using Newtonsoft.Json;

namespace Defectively.Core.Storage
{
    public sealed class DataStorage
    {
        private static volatile DataStorage instance;
        private static readonly object syncRoot = new object();

        /// <summary>
        ///     A thread-safe singleton instance of the <see cref="DataStorage"/>.
        /// </summary>
        public static DataStorage Instance {
            get {
                if (instance == null) {
                    lock (syncRoot) {
                        if (instance == null) {
                            instance = new DataStorage();
                        }
                    }
                }

                return instance;
            }
        }

        public string Directory { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Channel> Channels { get; set; } = new List<Channel>();

        public DataStorage Load() {
            if (!System.IO.Directory.Exists(Directory)) {
                System.IO.Directory.CreateDirectory(Directory);
                Save();
            }

            Accounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(Path.Combine(Directory, "accounts.json")));
            Teams = JsonConvert.DeserializeObject<List<Team>>(File.ReadAllText(Path.Combine(Directory, "teams.json")));
            Channels = JsonConvert.DeserializeObject<List<Channel>>(File.ReadAllText(Path.Combine(Directory, "channels.json")));

            return this;
        }

        public void Save() {
            File.WriteAllText(Path.Combine(Directory, "accounts.json"), JsonConvert.SerializeObject(Accounts, Formatting.Indented));
            File.WriteAllText(Path.Combine(Directory, "teams.json"), JsonConvert.SerializeObject(Teams, Formatting.Indented));
            File.WriteAllText(Path.Combine(Directory, "channels.json"), JsonConvert.SerializeObject(Channels, Formatting.Indented));
        }

        public DataStorage EditAccounts(Predicate<Account> predicate, Action<Account> action) {
            Accounts.FindAll(predicate).ForEach(action);
            return this;
        }

        public DataStorage EditTeams(Predicate<Team> predicate, Action<Team> action) {
            Teams.FindAll(predicate).ForEach(action);
            return this;
        }

        public DataStorage EditChannels(Predicate<Channel> predicate, Action<Channel> action) {
            Channels.FindAll(predicate).ForEach(action);
            return this;
        }

        public DataStorage Add(params Account[] accounts) {
            Accounts.AddRange(accounts);
            return this;
        }

        public DataStorage Add(params Team[] teams) {
            Teams.AddRange(teams);
            return this;
        }

        public DataStorage Add(params Channel[] channels) {
            Channels.AddRange(channels);
            return this;
        }

        public DataStorage Remove(Predicate<Channel> predicate) {
            Channels.RemoveAll(predicate);
            return this;
        }

    private DataStorage() { }
    }
}
