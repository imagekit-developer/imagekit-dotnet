using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Imagekit
{
    public partial class Transformation
    {
        public const string KEY_NAME_REGEX = "^\\$[a-zA-Z][a-zA-Z0-9]*$";
        public const string CHAIN_TRANSFORM_DELIMITER = ":";
        public const string TRANSFORM_DELIMITER = ",";
        public const string TRANSFORM_KEY_VALUE_DELIMITER = "-";
            

        /// <summary>
        /// </summary>
        /// <param name="transformParams">
        /// </param>
        public Transformation(Dictionary<string, object> transformParams)
        {
            foreach (var key in transformParams.Keys)
            {
                transformParams.Add(key, transformParams[key]);
            }
        }

        /// <summary>
        /// Creates transformation object initialized with array of transformation parameters.
        /// </summary>
        /// <param name="transformParams">List of transformation parameters represented as pairs 'name=value'.</param>
        public Transformation(params string[] transformParams)
        {
            foreach (var pair in transformParams)
            {
                string[] splittedPair = pair.Split('=');
                if (splittedPair.Length != 2)
                    throw new ArgumentException(String.Format("Couldn't parse '{0}'!", pair));

                Add(splittedPair[0], splittedPair[1]);
            }
        }

        /// <summary>
        /// Add transformation parameter.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="value">The value.</param>
        public Transformation Add(string key, object value)
        {
            if (transformParams.ContainsKey(key))
                transformParams[key] = value;
            else
                transformParams.Add(key, value);

            return this;
        }

        /// <summary>
        /// Creates empty transformation object.
        /// </summary>
        public Transformation() { }

        /// <summary>
        /// A dictionary of transformation parameters.
        /// </summary>
        protected Dictionary<string, object> transformParams = new Dictionary<string, object>();

        /// <summary>
        /// A list of nested transformations.
        /// </summary>
        protected List<Transformation> nestedTransforms = new List<Transformation>();

        /// <summary>
        /// Creates transformation object chained with other transformations.
        /// </summary>
        /// <param name="transforms">List of transformations to chain with.</param>
        public Transformation(List<Transformation> transforms)
        {
            if (transforms != null)
                nestedTransforms = transforms;
        }

        /// <summary>
        /// </summary>
        /// <param name="dictionary">
        /// </param>
        public Transformation(Dictionary<string, object>[] dictionary)
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (i == dictionary.Length - 1)
                {
                    transformParams = dictionary[i];
                }
                else
                {
                    nestedTransforms.Add(new Transformation(dictionary[i]));
                }
            }
        }


        /// <summary>
        /// Get the transformation parameters dictionary.
        /// </summary>
        public Dictionary<string, object> Params
        {
            get { return transformParams; }
        }

        /// <summary>
        /// Get list of nested transformations.
        /// </summary>
        public List<Transformation> NestedTransforms
        {
            get { return nestedTransforms; }
        }

        /// <summary>
        /// Chain transformation.
        /// </summary>
        public Transformation Chain()
        {
            Transformation nested = this.Clone();
            nested.nestedTransforms = null;
            nestedTransforms.Add(nested);
            transformParams = new Dictionary<string, object>();
            Transformation transform = new Transformation(nestedTransforms);
            return transform;
        }
        

        /// <summary>
        /// Get a deep cloned copy of this transformation.
        /// </summary>
        /// <returns>A deep cloned copy of this transformation.</returns>
        public Transformation Clone()
        {
            Transformation t = (Transformation)this.MemberwiseClone();

            t.transformParams = new Dictionary<string, object>();

            foreach (var key in transformParams.Keys)
            {
                var value = transformParams[key];

                if (value is Array)
                {
                    t.Add(key, ((Array)value).Clone());
                }
                else if (value is String || value is ValueType )
                {
                    t.Add(key, value);
                }
                else if (value is Dictionary<string, string>)
                {
                    t.Add(key, new Dictionary<string, string>((Dictionary<string, string>)value));
                }
                else
                {
                    throw new Exception(String.Format("Couldn't clone parameter '{0}'!", key));
                }
            }

            if (nestedTransforms != null)
            {
                t.nestedTransforms = new List<Transformation>();
                foreach (var nestedTransform in nestedTransforms)
                {
                    t.nestedTransforms.Add(nestedTransform.Clone());
                }
            }

            return t;
        }

        /// <summary>
        /// Get this transformation represented as string.
        /// </summary>
        /// <returns>The transformation represented as string.</returns>
        public string Generate()
        {
            List<string> parts = new List<string>(nestedTransforms.Select(t => t.getTrans()).ToList());

            var thisTransform = getTrans();
            if (!string.IsNullOrEmpty(thisTransform))
                parts.Add(thisTransform);
            return string.Join(CHAIN_TRANSFORM_DELIMITER, parts.ToArray());
        }

        public string getTrans()
        {
            List<string> transformations = new List<string>();
            SortedSet<string> varParams = new SortedSet<string>();

            foreach (var key in transformParams.Keys)
            {
                //if (Regex.IsMatch(key, KEY_NAME_REGEX)) {}
                string val = GetString(transformParams, key);
                if (string.IsNullOrEmpty(val))
                {
                    varParams.Add($"{key}");
                }
                else
                {
                    varParams.Add($"{key}-{GetString(transformParams, key)}");
                }
            }

            if (varParams.Count > 0)
            {
                transformations.Add(string.Join(TRANSFORM_DELIMITER, varParams));
            }
            return string.Join(CHAIN_TRANSFORM_DELIMITER, transformations.ToArray());

        }

        private string GetString(Dictionary<string, object> options, string key)
        {
            if (options.ContainsKey(key))
                return ToString(options[key]).ToLower();
            else
                return null;
        }

        private static string ToString(object obj)
        {
            if (obj == null) return null;

            if (obj is String) return obj.ToString();

            if (obj is Single || obj is Double)
                return String.Format(CultureInfo.InvariantCulture, "{0:0.0#}", obj);

            return String.Format(CultureInfo.InvariantCulture, "{0}", obj);
        }

        /// <summary>
        /// Get this transformation represented as string.
        /// </summary>
        /// <returns>The transformation represented as string.</returns>
        public override string ToString()
        {
            return Generate();
        }

    }
}
