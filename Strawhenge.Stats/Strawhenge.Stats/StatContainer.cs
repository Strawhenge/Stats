using System;
using System.Collections.Generic;
using System.Linq;
using Strawhenge.Common.Logging;

namespace Strawhenge.Stats
{
    public class StatContainer
    {
        readonly Dictionary<string, Stat> _statsByName = new Dictionary<string, Stat>();
        readonly ILogger _logger;

        public StatContainer(ILogger logger)
        {
            _logger = logger;
        }

        public event Action<Stat> StatAdded;

        public IReadOnlyList<Stat> Stats => _statsByName.Values.ToArray();

        public Stat GetStat(string name)
        {
            if (_statsByName.TryGetValue(name, out var stat))
                return stat;

            _logger.LogInformation($"Adding stat '{name}'");

            stat = new Stat(name);
            _statsByName.Add(name, stat);

            StatAdded?.Invoke(stat);
            return stat;
        }
    }
}