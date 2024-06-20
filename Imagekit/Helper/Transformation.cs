﻿// <copyright file="Transformation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Imagekit.Helper
{
    public partial class Transformation
    {
        public const string KeyNameRegex = "^\\$[a-zA-Z][a-zA-Z0-9]*$";
        public const string ChainTransformDelimiter = ":";
        public const string TransformDelimiter = ",";
        public const string TransformKeyValueDelimiter = "-";

        /// <summary>
        /// Initializes a new instance of the <see cref="Transformation"/> class.
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
        /// Initializes a new instance of the <see cref="Transformation"/> class.
        /// Creates transformation object initialized with array of transformation parameters.
        /// </summary>
        /// <param name="transformParams">List of transformation parameters represented as pairs 'name=value'.</param>
        public Transformation(params string[] transformParams)
        {
            foreach (var pair in transformParams)
            {
                string[] splittedPair = pair.Split('=');
                if (splittedPair.Length != 2)
                {
                    throw new Exception(string.Format("Couldn't parse '{0}'!", pair));
                }

                this.Add(splittedPair[0], splittedPair[1]);
            }
        }

        /// <summary>
        /// Add transformation parameter.
        /// </summary>
        /// <param name="key">The name.</param>
        /// <param name="value">The value.</param>
        public Transformation Add(string key, object value)
        {
            if (this.transformParams.ContainsKey(key))
            {
                this.transformParams[key] = value;
            }
            else
            {
                this.transformParams.Add(key, value);
            }

            return this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transformation"/> class.
        /// Creates empty transformation object.
        /// </summary>
        public Transformation()
        {
        }

        /// <summary>
        /// A dictionary of transformation parameters.
        /// </summary>
        protected Dictionary<string, object> transformParams = new Dictionary<string, object>();

        /// <summary>
        /// A list of nested transformations.
        /// </summary>
        protected List<Transformation> nestedTransforms = new List<Transformation>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Transformation"/> class.
        /// Creates transformation object chained with other transformations.
        /// </summary>
        /// <param name="transforms">List of transformations to chain with.</param>
        public Transformation(List<Transformation> transforms)
        {
            if (transforms != null)
            {
                this.nestedTransforms = transforms;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Transformation"/> class.
        /// </summary>
        /// <param name="dictionary">
        /// </param>
        public Transformation(Dictionary<string, object>[] dictionary)
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                if (i == dictionary.Length - 1)
                {
                    this.transformParams = dictionary[i];
                }
                else
                {
                    this.nestedTransforms.Add(new Transformation(dictionary[i]));
                }
            }
        }

        /// <summary>
        /// Get the transformation parameters dictionary.
        /// </summary>
        public Dictionary<string, object> Params
        {
            get { return this.transformParams; }
        }

        /// <summary>
        /// Get list of nested transformations.
        /// </summary>
        public List<Transformation> NestedTransforms
        {
            get { return this.nestedTransforms; }
        }

        /// <summary>
        /// Chain transformation.
        /// </summary>
        public Transformation Chain()
        {
            Transformation nested = this.Clone();
            nested.nestedTransforms = null;
            this.nestedTransforms.Add(nested);
            this.transformParams = new Dictionary<string, object>();
            Transformation transform = new Transformation(this.nestedTransforms);
            return transform;
        }

        /// <summary>
        /// Get a deep cloned copy of this transformation.
        /// </summary>
        /// <returns>A deep cloned copy of this transformation.</returns>
        public Transformation Clone()
        {
            Transformation t = (Transformation) this.MemberwiseClone();

            t.transformParams = new Dictionary<string, object>();

            foreach (var key in this.transformParams.Keys)
            {
                var value = this.transformParams[key];

                if (value is Array)
                {
                    t.Add(key, ((Array) value).Clone());
                }
                else if (value is string || value is ValueType)
                {
                    t.Add(key, value);
                }
                else if (value is Dictionary<string, string>)
                {
                    t.Add(key, new Dictionary<string, string>((Dictionary<string, string>) value));
                }
                else
                {
                    throw new Exception(string.Format("Couldn't clone parameter '{0}'!", key));
                }
            }

            if (this.nestedTransforms != null)
            {
                t.nestedTransforms = new List<Transformation>();
                foreach (var nestedTransform in this.nestedTransforms)
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
            List<string> parts = new List<string>(this.nestedTransforms.Select(t => t.GetTrans()).ToList());

            var thisTransform = this.GetTrans();
            if (!string.IsNullOrEmpty(thisTransform))
            {
                parts.Add(thisTransform);
            }

            return string.Join(ChainTransformDelimiter, parts.ToArray());
        }

        public string GetTrans()
        {
            List<string> transformations = new List<string>();
            List<string> varParams = new List<string>();

            foreach (var key in this.transformParams.Keys)
            {
                string val = this.GetString(this.transformParams, key);
                if (string.IsNullOrEmpty(val))
                {
                    varParams.Add($"{key}");
                }
                else
                {
                    if (key == "oi" || key == "di")
                    {
                        val = val.TrimStart('/').TrimEnd('/');
                        val = val.Replace("/", "@@");
                    }

                    varParams.Add($"{key}-{val}");
                }
            }

            if (varParams.Count > 0)
            {
                transformations.Add(string.Join(TransformDelimiter, varParams));
            }

            return string.Join(ChainTransformDelimiter, transformations.ToArray());
        }

        private string GetString(Dictionary<string, object> options, string key)
        {
            if (options.ContainsKey(key))
            {
                return ToString(options[key]);
            }
            else
            {
                return null;
            }
        }

        private static string ToString(object obj)
        {
            if (obj == null)
            {
                return null;
            }

            if (obj is string)
            {
                return obj.ToString();
            }

            if (obj is float || obj is double)
            {
                return string.Format(CultureInfo.InvariantCulture, "{0:0.0#}", obj);
            }

            return string.Format(CultureInfo.InvariantCulture, "{0}", obj);
        }

        /// <summary>
        /// Get this transformation represented as string.
        /// </summary>
        /// <returns>The transformation represented as string.</returns>
        public override string ToString()
        {
            return this.Generate();
        }
    }
}