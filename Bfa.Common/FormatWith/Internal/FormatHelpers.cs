// -----------------------------------------------------------------------
// <copyright file="FormatHelpers.cs" company="bfa solutions ltd">
// Copyright (c) bfa solutions ltd. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Bfa.Common.FormatWith.Internal
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    /// <summary>
    ///     Contains all string processing and tokenizing methods for FormatWith
    /// </summary>
    internal static class FormatHelpers
    {
        /// <summary>
        ///     Processes a list of format tokens into a string
        /// </summary>
        /// <param name="tokens">List of tokens to turn into a string</param>
        /// <param name="handler">An Function with keys and values to inject into the formatted result</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present
        ///     in the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="outputLengthHint">Hint as the initial size</param>
        /// <returns>The processed result of joining the tokens with the replacement dictionary.</returns>
        public static string ProcessTokens(
            IEnumerable<FormatToken> tokens,
            Func<string, ReplacementResult> handler,
            MissingKeyBehavior missingKeyBehavior,
            object fallbackReplacementValue,
            int outputLengthHint)
        {
            // create a StringBuilder to hold the resultant output string
            // use the input hint as the initial size
            var resultBuilder = new StringBuilder(outputLengthHint);

            foreach (var thisToken in tokens)
            {
                switch (thisToken.TokenType)
                {
                    case TokenType.Text:

                        // token is a text token
                        // add the token to the result string builder
                        resultBuilder.Append(thisToken.SourceString, thisToken.StartIndex, thisToken.Length);
                        break;

                    case TokenType.Parameter:

                        // token is a parameter token
                        // perform parameter logic now.

                        // append the replacement for this parameter
                        var replacementResult = handler(thisToken.Value);

                        if (replacementResult.Success)
                        {
                            // the key exists, add the replacement value
                            // this does nothing if replacement value is null
                            resultBuilder.Append(replacementResult.Value);
                        }
                        else
                        {
                            // the key does not exist, handle this using the missing key behavior specified.
                            switch (missingKeyBehavior)
                            {
                                case MissingKeyBehavior.ThrowException:

                                    // the key was not found as a possible replacement, throw exception
                                    throw new KeyNotFoundException(
                                        $"The parameter \"{thisToken.Value}\" was not present in the lookup dictionary");
                                case MissingKeyBehavior.ReplaceWithFallback:
                                    resultBuilder.Append(fallbackReplacementValue);
                                    break;

                                case MissingKeyBehavior.Ignore:

                                    // the replacement value is the input key as a parameter.
                                    // use source string and start/length directly with append rather than
                                    // parameter.ParameterKey to avoid allocating an extra string
                                    resultBuilder.Append(
                                        thisToken.SourceString,
                                        thisToken.StartIndex,
                                        thisToken.Length);
                                    break;

                                default:
                                    throw new ArgumentOutOfRangeException(
                                        nameof(missingKeyBehavior),
                                        missingKeyBehavior,
                                        null);
                            }
                        }

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // return the resultant string
            return resultBuilder.ToString();
        }

        /// <summary>
        ///     Processes a list of format tokens into a string
        /// </summary>
        /// <param name="tokens">List of tokens to turn into a string</param>
        /// <param name="handler">An function with keys and values to inject into the formatted result</param>
        /// <param name="missingKeyBehavior">
        ///     The behavior to use when the format string contains a parameter that is not present
        ///     in the lookup dictionary
        /// </param>
        /// <param name="fallbackReplacementValue">
        ///     When the <see cref="MissingKeyBehavior.ReplaceWithFallback" /> is specified,
        ///     this string is used as a fallback replacement value when the parameter is present in the lookup dictionary.
        /// </param>
        /// <param name="outputLengthHint">Hint as the initial size.</param>
        /// <returns>
        ///     The processed result of joining the tokens with the replacement dictionary.
        /// </returns>
        /// <exception cref="KeyNotFoundException">The parameter \"{thisToken.Value}\" was not present in the lookup dictionary</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     missingKeyBehavior - null
        ///     or
        /// </exception>
        public static FormattableString ProcessTokensIntoFormattableString(
            IEnumerable<FormatToken> tokens,
            Func<string, ReplacementResult> handler,
            MissingKeyBehavior missingKeyBehavior,
            object fallbackReplacementValue,
            int outputLengthHint)
        {
            var replacementParams = new List<object>();

            // create a StringBuilder to hold the resultant output string
            // use the input hint as the initial size
            var resultBuilder = new StringBuilder(outputLengthHint);

            // this is the index of the current placeholder in the composite format string
            var placeholderIndex = 0;

            foreach (var thisToken in tokens)
            {
                switch (thisToken.TokenType)
                {
                    case TokenType.Text:

                        // token is a text token.
                        // add the token to the result string builder.
                        // because this text is going into a standard composite format string,
                        // any instaces of { or } must be escaped with {{ and }}
                        resultBuilder.AppendWithEscapedBrackets(
                            thisToken.SourceString,
                            thisToken.StartIndex,
                            thisToken.Length);
                        break;

                    case TokenType.Parameter:

                        // token is a parameter token
                        // perform parameter logic now.

                        // append the replacement for this parameter
                        var replacementResult = handler(thisToken.Value);

                        // append the replacement for this parameter
                        if (replacementResult.Success)
                        {
                            // Instead of appending the replacement value directly as before,
                            // append the next placeholder with the current placeholder index.
                            // Add the actual replacement format item into the replacement values.
                            resultBuilder.Append(
                                StringFormatWithExtensions.OpenBraceChar + placeholderIndex
                                                                         + StringFormatWithExtensions.CloseBraceChar);
                            placeholderIndex++;
                            replacementParams.Add(replacementResult.Value);
                        }
                        else
                        {
                            // the key does not exist, handle this using the missing key behavior specified.
                            switch (missingKeyBehavior)
                            {
                                case MissingKeyBehavior.ThrowException:

                                    // the key was not found as a possible replacement, throw exception
                                    throw new KeyNotFoundException(
                                        $"The parameter \"{thisToken.Value}\" was not present in the lookup dictionary");
                                case MissingKeyBehavior.ReplaceWithFallback:

                                    // Instead of appending the replacement value directly as before,
                                    // append the next placeholder with the current placeholder index.
                                    // Add the actual replacement format item into the replacement values.
                                    resultBuilder.Append(
                                        StringFormatWithExtensions.OpenBraceChar + placeholderIndex
                                                                                 + StringFormatWithExtensions
                                                                                     .CloseBraceChar);
                                    placeholderIndex++;
                                    replacementParams.Add(fallbackReplacementValue);
                                    break;

                                case MissingKeyBehavior.Ignore:
                                    resultBuilder.AppendWithEscapedBrackets(
                                        thisToken.SourceString,
                                        thisToken.StartIndex,
                                        thisToken.Length);
                                    break;

                                default:
                                    throw new ArgumentOutOfRangeException(
                                        nameof(missingKeyBehavior),
                                        missingKeyBehavior,
                                        null);
                            }
                        }

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // return the resultant string
            return FormattableStringFactory.Create(resultBuilder.ToString(), replacementParams.ToArray());
        }

        /// <summary>
        ///     Tokenizes a named format string into a list of text and parameter tokens for later processing.
        /// </summary>
        /// <param name="formatString">The format string, containing keys like {foo}</param>
        /// <param name="openBraceChar">The character used to begin parameters</param>
        /// <param name="closeBraceChar">The character used to end parameters</param>
        /// <returns>A list of text and parameter tokens representing the input format string</returns>
        public static IEnumerable<FormatToken> Tokenize(
            string formatString,
            char openBraceChar = StringFormatWithExtensions.OpenBraceChar,
            char closeBraceChar = StringFormatWithExtensions.CloseBraceChar)
        {
            if (formatString == null)
            {
                throw new ArgumentNullException($"{nameof(formatString)} cannot be null.");
            }

            var currentTokenStart = 0;

            // start the state machine!
            var insideBraces = false;

            var index = 0;
            while (index < formatString.Length)
            {
                if (!insideBraces)
                {
                    // currently not inside a pair of braces in the format string
                    if (formatString[index] == openBraceChar)
                    {
                        // check if the brace is escaped
                        if ((index < formatString.Length - 1) && (formatString[index + 1] == openBraceChar))
                        {
                            // ESCAPED OPEN BRACE

                            // we have hit an escaped open brace
                            // return current normal text, as well as the first brace
                            // implemented as yield return, this generates a IEnumerator state machine.
                            yield return new FormatToken(
                                TokenType.Text,
                                formatString,
                                currentTokenStart,
                                (index - currentTokenStart) + 1);

                            // skip over braces
                            index += 2;

                            // set new current token start and current token length
                            currentTokenStart = index;
                        }
                        else
                        {
                            // START OF PARAMETER

                            // not an escaped brace, set state to inside brace
                            insideBraces = true;

                            // we are leaving standard text and entering into a parameter
                            // add the text traversed so far as a text token
                            if (currentTokenStart < index)
                            {
                                yield return new FormatToken(
                                    TokenType.Text,
                                    formatString,
                                    currentTokenStart,
                                    index - currentTokenStart);
                            }

                            // set the start index of the token to the start of this parameter
                            currentTokenStart = index;

                            index++;
                        }
                    }
                    else if (formatString[index] == closeBraceChar)
                    {
                        // handle case where closing brace is encountered outside braces
                        if ((index < formatString.Length - 1) && (formatString[index + 1] == closeBraceChar))
                        {
                            // this is an escaped closing brace, this is okay

                            // add the current normal text, as well as the first brace, to the
                            // list of tokens as a text token.
                            yield return new FormatToken(
                                TokenType.Text,
                                formatString,
                                currentTokenStart,
                                (index - currentTokenStart) + 1);

                            // skip over braces
                            index += 2;

                            // set new current token start and current token length
                            currentTokenStart = index;
                        }
                        else
                        {
                            // this is an unescaped closing brace outside of braces.
                            // throw a format exception
                            throw new FormatException($"Unexpected closing brace at position {index}");
                        }
                    }
                    else
                    {
                        // move onto next character
                        index++;
                    }
                }
                else
                {
                    // currently inside a pair of braces in the format string
                    if (formatString[index] == openBraceChar)
                    {
                        // found an opening brace
                        // check if the brace is escaped
                        if ((index < formatString.Length - 1) && (formatString[index + 1] == openBraceChar))
                        {
                            // there are escaped braces within the key
                            // this is illegal, throw a format exception
                            throw new FormatException(
                                $"Illegal escaped opening braces within a parameter at position {index}");
                        }

                        // not an escaped brace, we have an unexpected opening brace within a pair of braces
                        throw new FormatException($"Unexpected opening brace inside a parameter at position {index}");
                    }

                    if (formatString[index] == closeBraceChar)
                    {
                        // END OF PARAMETER
                        // handle case where closing brace is encountered inside braces
                        // don't attempt to check for escaped braces here - always assume the first brace closes the braces
                        // since we cannot have escaped braces within parameters.

                        // Add the parameter information to the parameter list
                        yield return new FormatToken(
                            TokenType.Parameter,
                            formatString,
                            currentTokenStart,
                            (index - currentTokenStart) + 1);

                        // set the state to be outside of any braces
                        insideBraces = false;

                        // jump over brace
                        index++;

                        // update current token start
                        currentTokenStart = index;

                        // jump to next state
                    }
                    else
                    {
                        // character has no special meaning, it is part of the current key
                        // move onto next character
                        index++;
                    }
                }

                // if inside brace
            }

            // while index < formatString.Length

            // after the loop, if all braces were balanced, we should be outside all braces
            // if we're not, the input string was misformatted.
            if (insideBraces)
            {
                throw new FormatException($"The format string ended before the parameter was closed. Position {index}");
            }

            // outside braces. Add on any remaining text at the end of the format string
            if (currentTokenStart < index)
            {
                yield return new FormatToken(
                    TokenType.Text,
                    formatString,
                    currentTokenStart,
                    index - currentTokenStart);
            }

            // finished tokenizing, so yield break to make MoveNext return false on the IEnumerator
        }
    }
}