using System.Collections.Generic;
using System.Linq;

namespace Strawhenge.Stats
{
    public static class StatContainerExtensions
    {
        public static void Import(this StatContainer statContainer, params StatValueDto[] statValues) =>
            statContainer.Import(statValues.AsEnumerable());

        public static IReadOnlyList<StatValueDto> Export(this StatContainer statContainer) =>
            statContainer.Stats
                .Select(stat => new StatValueDto(stat.Name, stat.BaseValue))
                .ToArray();
    }
}