namespace effiPeople.Api.Client.Model.Common
{
    /// <summary>
    ///     Tipo de cliente
    /// </summary>
    public enum CustomerType
    {
        // Desconocido
        Unknown = 0,

        /// <summary>
        ///     Residencial
        /// </summary>
        Residential = 1,

        /// <summary>
        ///     Terciario
        /// </summary>
        Tertiary = 2,

        /// <summary>
        ///     Industrial
        /// </summary>
        Industrial = 3
    }
}