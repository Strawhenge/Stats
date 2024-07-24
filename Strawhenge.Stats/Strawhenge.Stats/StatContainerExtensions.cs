using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Stats
{
    public static class StatContainerExtensions
    {
        public static void Import(this StatContainer statContainer, params StatValueDto[] statValues) =>
            statContainer.Import(statValues.AsEnumerable());

        public static void Import(this StatContainer statContainer, IEnumerable<StatValueDto> statValues)
        {
            foreach (var statValue in statValues)
            {
                var stat = statContainer.GetStat(statValue.StatName);
                stat.Set(statValue.Value);
            }
        }
        
        public static IReadOnlyList<StatValueDto> Export(this StatContainer statContainer) =>
            statContainer.Stats
                .Select(stat => new StatValueDto(stat.Name, stat.BaseValue))
                .ToArray();
    }
}