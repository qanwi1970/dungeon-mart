using System;
using System.Linq;
using System.Net.Http;

namespace DungeonMart.Utils
{
    internal class ControllerUtils
    {
        public static PagedListResult<T> ListResponse<T>(HttpRequestMessage request, IQueryable<T> rawList)
        {
            var fromUnit = 0;
            var toUnit = int.MaxValue;
            var range = request.Headers.Range;
            if (range != null)
            {
                fromUnit = (int)range.Ranges.First().From.Value;
                toUnit = (int)range.Ranges.First().To.Value;
            }
            var unitCount = rawList.Count();
            var unitsToTake = Math.Min(unitCount, toUnit) - fromUnit + 1;
            var units = rawList.Skip(fromUnit).Take(unitsToTake);
            var listResponse = new PagedListResult<T>(request, units.ToList(), fromUnit,
                Math.Min(toUnit, unitCount), unitCount, "feats");
            return listResponse;
        }

    }
}