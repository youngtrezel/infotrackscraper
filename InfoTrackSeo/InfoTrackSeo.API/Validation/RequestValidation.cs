using InfoTrackSeo.Common.Exceptions;
using InfoTrackSeo.Common.Models;
using System.Text.RegularExpressions;

namespace InfoTrackSeo.API.Validation
{
    public class RequestValidation : IValidate<SearchEngineRequest>
    {
        public void Validate(SearchEngineRequest model)
        {
            ArgumentNullException.ThrowIfNull(model, nameof(model));

            if(string.IsNullOrEmpty(model.WordToSearch))
            {
                throw new InvalidRequestException("Please enter word to search for.");              
            }
            if (string.IsNullOrEmpty(model.UrlToFind))
            {
                throw new InvalidRequestException("Please enter URL.");
            }

            var validUrl = Regex.IsMatch(model.UrlToFind, "(https:\\/\\/www\\.|http:\\/\\/www\\.|https:\\/\\/|http:\\/\\/)?[a-zA-Z0-9]{2,}(\\.[a-zA-Z0-9]{2,})(\\.[a-zA-Z0-9]{2,})?");

            if (!validUrl)
            {
                throw new InvalidRequestException("Please enter a valid URL.");
            }

        }
    }
}
