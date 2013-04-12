using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using effiPeople.Api.Client.Model;
using effiPeople.Api.Client.Model.Common;
using effiPeople.Api.Client.Model.Extensions;

namespace effiPeople.Api.Client
{
    public partial class EffiPeopleRestClient
    {
        /// <summary>
        /// Añade o actualiza una medida
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PushMeasureAsync(Measure measure)
        {
            var measures = new List<Measure> {measure};

            return PushMeasuresAsync(measures);
        }

        /// <summary>
        /// Añade o actualiza varias medidas
        /// </summary>
        /// <param name="measures"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PushMeasuresAsync(List<Measure> measures)
        {
            string url = GetUrl("/measures");

            return PutAsync(url, measures);
        }

        /// <summary>
        /// Obtiene las medidas de un CUPS
        /// </summary>
        /// <param name="usagePointId"></param>
        /// <param name="dateTime"></param>
        /// <param name="measureType"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public Task<List<Measure>> GetUsagePointMeasuresAsync(string usagePointId, DateTime? dateTime = null, MeasureType? measureType = null, int? limit = null, int? offset = null)
        {
            return GetMeasuresAsync(usagePointId, null, dateTime, null, measureType, limit, offset);
        }

        /// <summary>
        /// Obtiene las medidas
        /// </summary>
        /// <param name="usagePointId"></param>
        /// <param name="meterId"></param>
        /// <param name="dateTime"></param>
        /// <param name="period"></param>
        /// <param name="measureType"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public Task<List<Measure>> GetMeasuresAsync(string usagePointId = null, string meterId = null, DateTime? dateTime = null, byte? period = null, MeasureType? measureType = null, int? limit = null, int? offset = null)
        {
            string url = GetUrl("/measures");

            long? date = null;

            if (dateTime != null)
                date = dateTime.AsEpochTimeInSeconds();

            var query = new List<string>();

            if (!string.IsNullOrEmpty(usagePointId))
                query.Add(string.Format("usagePointId={0}", usagePointId));

            if (!string.IsNullOrEmpty(meterId))
                query.Add(string.Format("meterId={0}", meterId));

            if (date != null && date > 0)
                query.Add(string.Format("date={0}", date));

            if (period != null && period > 0)
                query.Add(string.Format("period={0}", period));

            if (measureType != null && measureType > 0)
                query.Add(string.Format("energyType={0}", measureType));

            if (limit != null && limit > 0)
                query.Add(string.Format("limit={0}", limit));

            if (offset != null && offset > 0)
                query.Add(string.Format("offset={0}", offset));

            if (query.Count > 0)
                url += "?" + string.Join("&", query);

            return GetAsync<List<Measure>>(url);
        }

        /// <summary>
        /// Elimina varias medidas
        /// </summary>
        /// <param name="usagePointId"></param>
        /// <param name="meterId"></param>
        /// <param name="dateTime"></param>
        /// <param name="period"></param>
        /// <param name="measureType"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteMeasuresAsync(string usagePointId = null, string meterId = null, DateTime? dateTime = null, byte? period = null, MeasureType? measureType = null)
        {
            string url = GetUrl("/measures");

            long? date = null;

            if (dateTime != null)
                date = dateTime.AsEpochTimeInSeconds();

            var query = new List<string>();

            if (!string.IsNullOrEmpty(usagePointId))
                query.Add(string.Format("usagePointId={0}", usagePointId));

            if (!string.IsNullOrEmpty(meterId))
                query.Add(string.Format("meterId={0}", meterId));

            if (date != null && date > 0)
                query.Add(string.Format("date={0}", date));

            if (period != null && period > 0)
                query.Add(string.Format("period={0}", period));

            if (measureType != null && measureType > 0)
                query.Add(string.Format("energyType={0}", measureType));

            if (query.Count > 0)
                url += "?" + string.Join("&", query);

            return DeleteAsync(url);
        }
    }
}