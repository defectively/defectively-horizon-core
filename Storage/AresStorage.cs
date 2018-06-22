using System.Collections.Generic;
using System.Linq;

namespace Defectively.Core.Storage
{
    /// <summary>
    ///     Provides methods for checking permissions.
    /// </summary>
    public class AresStorage
    {
        private readonly List<string> values = new List<string>();

        /// <summary>
        ///     Initializes a new <see cref="AresStorage"/>.
        /// </summary>
        public AresStorage() { }

        /// <summary>
        ///     Initializes a new <see cref="AresStorage"/> with the given values.
        /// </summary>
        /// <param name="values">The values that should be included in this <see cref="AresStorage"/>.</param>
        public AresStorage(params string[] values) {
            this.values.AddRange(values);
        }

        /// <summary>
        ///     Checks if the <see cref="AresStorage"/> contains the given value.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <param name="storage">An optional second <see cref="AresStorage"/> that should be combined with this instance.</param>
        /// <returns>Returns "true" if one of the two <see cref="AresStorage"/> instances contains the value, otherwise "false".</returns>
        public bool HasValue(string value, AresStorage storage = null) {
            // IMPORTANT Rework Ares
            if (storage != null && storage.values.Count > 0) {
                return values.Union(storage.values).Contains(value);
            }

            return values.Contains(value);
        }
    }
}
