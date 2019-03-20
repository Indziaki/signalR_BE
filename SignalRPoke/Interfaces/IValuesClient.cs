using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRPoke.Interfaces
{
    public interface IValuesClient
    {                   
        /// <summary>
        /// This event occurs when a value is posted to the
        /// ValuesController.
        /// </summary>
        /// <param name="value">The value that has been created.</param>
        Task Add(string value);

        /// <summary>
        /// This event occurs when a value is deleted using the
        /// ValuesController.
        /// </summary>
        /// <param name="value">The value that has been deleted</param>
        Task Delete(string value);
    }
}
