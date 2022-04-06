using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    /// <summary>
    /// Provides with custom methods to avoid code repetition
    /// </summary>
    public class Utils
    {
        /// <summary>
        /// Obtains a segment of the InstanceName from the object.
        /// </summary>
        /// <param name="instance">The instance of the object which invokes this method</param>
        /// <param name="wordToFind">the word that is going to be used as a separator (i.e Course)</param>
        /// <returns></returns>
        public static string ExtractStringFromInstanceName(object instance, string wordToFind) {
            string instanceName = instance.GetType().Name;
            return instanceName.Substring(0, instanceName.IndexOf(wordToFind, 0));
        }
    }
}

