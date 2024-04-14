using System.Collections.Generic;
using System.Linq;

namespace ParserTest
{
	class StringParser
	{
		public IEnumerable<TokenAction> Parse(string inputText, IEnumerable<TokenAction> tokens)
		{
			if(inputText == null)
			{
				inputText = string.Empty;
			}
			
			string modifiedString = RemoveAllNonAlphaNumericCharacters(inputText);

			List<TokenAction> initialTokensList = tokens.ToList();
            List<TokenAction> foundTokens = new List<TokenAction>();

			// Iterating backwards assuming that more complex tokens are added later (i.e. 'test2' contains 'test', so 'test2' is added later) in the TOKEN_ACTIONS collection. There is no option to ask before making the assumption here. Normally, I would ask first. 
			for(int i = tokens.Count() - 1; i >= 0; i--)
			{
				TokenAction token = initialTokensList[i];

                bool isDoneWithCurrentIteration = false;
				
				while (isDoneWithCurrentIteration == false)
				{
                    if (modifiedString.ToUpper().Contains(token.Name.ToUpper()))
                    {
                        foundTokens.Add(token);
                    }

					int indexOfTokenToBeRemoved = modifiedString.ToUpper().IndexOf(token.Name.ToUpper());

					// Remove the found token from the tested string once and then check again to find if the same token was present more than once. 
					modifiedString = (indexOfTokenToBeRemoved < 0) ? modifiedString : modifiedString.Remove(indexOfTokenToBeRemoved, token.Name.Length);

                    if (!modifiedString.ToUpper().Contains(token.Name.ToUpper()))
                    {
						// If the current token is not found anymore, time to switch to the next token.
						isDoneWithCurrentIteration = true;
                    }
                }
			}

			// Since we iterated backwards above, this reversal below is required. 
			foundTokens.Reverse();

			return foundTokens;
		}

		/// <summary>
		/// Returns a string with all all non-alphanumeric characters removed from the input string.
		/// </summary>
		private string RemoveAllNonAlphaNumericCharacters(string inputText)
		{
			return string.Concat(inputText.Where(char.IsLetterOrDigit));
        }
    }
}
