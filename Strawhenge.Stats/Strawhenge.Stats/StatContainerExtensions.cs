using System.Linq;

namespace Strawhenge.Stats
{
    public static class StatContainerExtensions
    {
        public static void LoadValues(this StatContainer statContainer, params StatValueDto[] statValues) =>
            statContainer.LoadValues(statValues.AsEnumerable());
    }
}