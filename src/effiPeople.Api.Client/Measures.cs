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
        /// Obtiene una medida.
        /// </summary>
        /// <param name="measureId">Identificador único de la medida</param>
        /// <returns></returns>
        public Task<Measure> GetMeasureAsync(string measureId)
        {
            string url = GetUrl("/measures/{0}", measureId);

            return GetAsync<Measure>(url);
        }
       
        /// <summary>
        /// Elimina una medida.
        /// </summary>
        /// <param name="measureId">Identificador único de la medida</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> DeleteMeasureAsync(string measureId)
        {
            string url = GetUrl("/measures/{0}", measureId);

            return DeleteAsync(url);
        }

        /// <summary>
        /// Añade una medida
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        public Task<Measure> AddMeasureAsync(Measure measure)
        {
            string url = GetUrl("/measures");

            return PostAsync<Measure, Measure>(url, measure);
        }

        /// <summary>
        /// Añade o actualiza una medida
        /// </summary>
        /// <param name="measure">Medida</param>
        /// <returns></returns>
        public Task<Measure> UpdateMeasureAsync(Measure measure)
        {
            string url = GetUrl("/measures/{0}", measure.Id);

            return PutAsync<Measure, Measure>(url, measure);
        }

        /// <summary>
        /// Añade o actualiza varias medidas
        /// </summary>
        /// <param name="measures"></param>
        /// <returns></returns>
        public Task<HttpResponseMessage> PutMeasuresAsync(List<Measure> measures)
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
            var url = GetMeasureQueryUrl(usagePointId, meterId, dateTime, period, measureType, limit, offset);

            return GetAsync<List<Measure>>(url);
        }

        private string GetMeasureQueryUrl(string usagePointId, string meterId, DateTime? dateTime, byte? period, MeasureType? measureType, int? limit, int? offset)
        {
            string url = GetUrl("/measures");

            long? date = null;

            if (dateTime != null)
                date = dateTime.ToEpochTimeInSeconds();

            var query = new List<string>();

            if (!string.IsNullOrEmpty(usagePointId))
                query.Add(string.Format("usagePointId={0}", usagePointId));

            if (!string.IsNullOrEmpty(meterId))
                query.Add(string.Format("meterId={0}", meterId));

            if (date != null && date > 0)
                query.Add(string.Format("date={0}", date));

            if (period != null && period > 0)
                query.Add(string.Format("period={0}", period));

            if (measureType != null)
                query.Add(string.Format("measureType={0}", measureType));

            if (limit != null && limit > 0)
                query.Add(string.Format("limit={0}", limit));

            if (offset != null && offset > 0)
                query.Add(string.Format("offset={0}", offset));

            if (query.Count > 0)
                url += "?" + string.Join("&", query);
            return url;
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
                date = dateTime.ToEpochTimeInSeconds();

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