using System.Collections.Generic;
using System.Linq;
using FunctionalUtilities;
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

        public IReadOnlyList<Stat> Stats => _statsByName.Values.ToArray();

        public Maybe<Stat> FindStat(string name)
        {
            if (_statsByName.TryGetValue(name, out var stat))
                return stat;

            return Maybe.None<Stat>();
        }

        public Stat AddStat(string name, int max, int value = 0)
        {
            if (_statsByName.TryGetValue(name, out var stat))
            {
                _logger.LogError($"Stat '{name}' already exists.");
                return stat;
            }

            stat = new Stat(name, max, value);
            _statsByName.Add(name, stat);

            return stat;
        }

        public void Import(IEnumerable<StatValueDto> statValues)
        {
            foreach (var statValue in statValues)
            {
                if (!_statsByName.TryGetValue(statValue.StatName, out var stat))
                {
                    _logger.LogError($"Stat '{statValue.StatName}' is missing.");
                    continue;
                }

                stat.Set(statValue.Value);
            }
        }
    }
}