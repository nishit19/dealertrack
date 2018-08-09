using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DealerTrack.Core.Utility
{
    /// <summary>
    /// String formatter class
    /// </summary>
    public class StringUtility
    {
        /// <summary>
        /// Format the currency in canadian format
        /// </summary>
        /// <param name="currency"></param>
        /// <returns>Canadian formatted currency i.e. CAD$</returns>
        public static string FormatCurrency(decimal currency)
        {
            var caRegionInfo = new RegionInfo(Constants.CanadaFormat);
            var formattedCurrency = $"{currency:n0}";
            return $"{caRegionInfo.ISOCurrencySymbol}{caRegionInfo.CurrencySymbol}{formattedCurrency}";
            //return currency.ToString("C",
            //    CultureInfo.CreateSpecificCulture(Constants.CanadaFormat));
        }

        /// <summary>
        /// Format date in MM/dd/yyyy format
        /// </summary>
        /// <param name="date"></param>
        /// <returns>formatted date</returns>
        public static string FormatDate(DateTime date)
        {
            return date.ToString(Constants.DateFormat);
        }

        /// <summary>
        /// Check if the value is an integer, otherwise return 0
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Integer representation of an object</returns>
        public static int GetInteger(object value)
        {
            if (value == null || GetString(value) == "")
            {
                return 0;
            }

            try
            {
                return int.Parse(GetString(value));
            }
            catch
            {
                //if we can't parse, then just return 0 as it is not a valid int
                return 0;
            }
        }

        /// <summary>
        /// Check if the object passed is a string, otherwise return blank string
        /// </summary>
        /// <param name="value"></param>
        /// <returns>String representation of an object</returns>
        public static string GetString(object value)
        {
            return value?.ToString().Trim() ?? "";
        }

        /// <summary> 
        /// Test if an object is numeric
        /// </summary>
        /// <param name="expression">The object to test</param>
        /// <return>Boolean representation signifying the expression is numeric</return>
        public static bool IsNumeric(object expression)
        {
            var isNum = double.TryParse(Convert.ToString(expression), NumberStyles.Any, NumberFormatInfo.InvariantInfo, out _);
            return isNum;
        }

        /// <summary> 
        /// Convert an object to decimal value.  
        /// </summary>
        /// <param name="value">An object to convert to a decimal</param>
        /// <return>The decimal representation of an object</return>
        public static decimal GetDecimal(object value)
        {
            if (value == null || GetString(value).Trim() == "")
            {
                return 0;
            }

            if (IsNumeric(value))
            {
                if (decimal.Parse(GetString(value)) == decimal.Round(decimal.Parse(GetString(value))))
                {
                    return decimal.Round(decimal.Parse(GetString(value)));
                }

                if (decimal.Parse(GetString(value)) == decimal.Round(decimal.Parse(GetString(value)), 1))
                {
                    return decimal.Round(decimal.Parse(GetString(value)), 1);
                }

                return decimal.Parse(GetString(value));
            }

            return 0;
        }

        /// <summary>
        /// Check if the date entered is a valid date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>The date and time representation of an object</returns>
        public static DateTime GetDateTime(object date)
        {
            return DateTime.TryParse(date.ToString(), out var dtResult) ? dtResult : DateTime.MinValue;
        }

        /// <summary>
        /// Split the csv rows based on the regex
        /// </summary>
        /// <param name="csvRow"></param>
        /// <returns>String Collection of all the csv column data</returns>
        public static StringCollection SplitCsvRow(string csvRow)
        {
            var resultList = new StringCollection();
            var pattern = new Regex(@"
                    # Parse CVS line. Capture next value in named group: 'csvdata'
                    \s*                      # Ignore leading whitespace.
                    (?:                      # Group of value alternatives.
                      ""                     # Either a double quoted string,
                      (?<csvdata>                # Capture contents between quotes.
                        [^""]*(""""[^""]*)*  # Zero or more non-quotes, allowing 
                      )                      # doubled "" quotes within string.
                      ""\s*                  # Ignore whitespace following quote.
                    |  (?<csvdata>[^,]*)         # Or... zero or more non-commas.
                    )                        # End value alternatives group.
                    (?:,|$)                  # Match end is comma or EOS",
                RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            var matchResult = pattern.Match(csvRow);
            while (matchResult.Success)
            {
                resultList.Add(matchResult.Groups["csvdata"].Value);
                matchResult = matchResult.NextMatch();
            }

            return resultList;
        }
    }
}

