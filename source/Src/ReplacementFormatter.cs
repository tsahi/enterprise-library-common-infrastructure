﻿/*
Copyright 2013 Microsoft Corporation
Licensed under the Apache License, Version 2.0 (the "License");

you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Practices.EnterpriseLibrary.Common
{
    /// <summary>
    /// This class provides an engine to process a string that contains
    /// replacement tokens of the form "{token}" and replace them with
    /// calculated value later.
    /// </summary>
    public class ReplacementFormatter
    {
        private List<ReplacementToken> tokens = new List<ReplacementToken>();

        /// <summary>
        /// Create a new <see cref="ReplacementFormatter"/>.
        /// </summary>
        public ReplacementFormatter()
        {
        }

        /// <summary>
        /// Create a new <see cref="ReplacementFormatter"/>.
        /// </summary>
        /// <param name="tokens">List of tokens to replace.</param>
        public ReplacementFormatter(params ReplacementToken[] tokens)
        {
            AddRange(tokens);
        }
        
        /// <summary>
        /// Create a new <see cref="ReplacementFormatter"/>.
        /// </summary>
        /// <param name="tokens">List of tokens to replace.</param>
        public ReplacementFormatter(IEnumerable<ReplacementToken> tokens)
        {
            AddRange(tokens);
        }

        /// <summary>
        /// Add a new set of replacement tokens.
        /// </summary>
        /// <param name="tokens">Tokens to add to the list.</param>
        public void Add(params ReplacementToken[] tokens)
        {
            AddRange(tokens);    
        }

        /// <summary>
        /// Add new tokens to the set of replacements.
        /// </summary>
        /// <param name="tokens">Tokens to add to the list.</param>
        public void AddRange(IEnumerable<ReplacementToken> tokens)
        {
            this.tokens.AddRange(tokens);
        }

        /// <summary>
        /// Format the given template, replacing any tokens present.
        /// </summary>
        /// <param name="template">The string to format, containing the replacement tokens.</param>
        /// <returns>The formatted string, with tokens replaced.</returns>
        public string Format(string template)
        {
            StringBuilder templateBuilder = new StringBuilder(template);
            // Escape literal backslash
            templateBuilder.Replace(@"\\", @"\\.");
            // Escape the \{ sequence
            templateBuilder.Replace(@"\{", @"\{.");
            foreach(ReplacementToken token in tokens)
            {
                token.ReplaceToken(templateBuilder);
            }
            templateBuilder.Replace(@"\{.", "{");
            templateBuilder.Replace(@"\\.", @"\");
            return templateBuilder.ToString();
        }
    }

    /// <summary>
    /// A single replacement token used by the <see cref="ReplacementFormatter"/>. A
    /// token consists of two things:
    /// <list type="bullet">
    /// <item><description>The actual text of the token (including the {})</description></item>
    /// <item><description>A delegate to retrieve the value to replace the token.</description></item>
    /// </list>
    /// </summary>
    public class ReplacementToken
    {
        private string token;
        private ReplacementTextDelegate getReplacementText;

        /// <summary>
        /// Create a new <see cref="ReplacementToken"/>.
        /// </summary>
        /// <param name="token">The string marking where the token should be replaced.</param>
        /// <param name="getReplacementText">Delegate to return the value that replaces the token.</param>
        public ReplacementToken(string token, ReplacementTextDelegate getReplacementText)
        {
            this.token = token;
            this.getReplacementText = getReplacementText;
        }

        /// <summary>
        /// The token string.
        /// </summary>
        /// <value>The token string.</value>
        public string Token
        {
            get { return token; }
        }

        /// <summary>
        /// The text to replace this token with.
        /// </summary>
        /// <value>Replacement text.</value>
        public string ReplacementText
        {
            get { return getReplacementText(); }
        }

        /// <summary>
        /// Replace this token in the given stringbuilder.
        /// </summary>
        /// <param name="sb"><see cref="StringBuilder"/> holding the template to perform the token replacement on.</param>
        public void ReplaceToken(StringBuilder sb)
        {
            if (sb == null) throw new ArgumentNullException("sb");

            sb.Replace(token, ReplacementText);
        }
    }

    /// <summary>
    /// Delegate type giving a function that returns the replacement text for a token.
    /// </summary>
    /// <returns>The replacement text.</returns>
    public delegate string ReplacementTextDelegate();
}
