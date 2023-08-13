using Capstone.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;

namespace Capstone.Services
{
    public class PetFinderService
    {
        private string PetUrl = "https://api.petfinder.com/v2/oauth2/token";
        public IRestClient client;
        public PetFinderApiAuth auth;
        public string Token;

        public PetFinderService(string apiUrl, string clientId, string grantType, string clientSecret)
        {
            client = new RestClient(apiUrl);
            auth = new PetFinderApiAuth();
            auth.client_id = clientId;
            auth.grant_type = grantType;
            auth.client_secret = clientSecret;
        }

        public PetFinderResponseDto GetToken()
        {
            RestRequest request = new RestRequest(PetUrl);
            request.AddJsonBody(auth);
            IRestResponse<PetFinderResponseDto> response = client.Post<PetFinderResponseDto>(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                throw new HttpRequestException("Error occurred - unable to reach server.", response.ErrorException);
            }
            else if (!response.IsSuccessful)
            {
                throw new HttpRequestException("Error occurred - received non-success response: " + (int)response.StatusCode);
            }
            Token = $"{response.Data.Token_type} {response.Data.Access_token}";
            client.AddDefaultHeader("Authorization", Token);
            return response.Data;
        }

        public List<PetApi> GetAnimalsByType(string animalType)
        {
            GetToken();
            RestRequest request = new RestRequest($"/animals?type={animalType}");
            IRestResponse<PetContainer> response = client.Get<PetContainer>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("There was an error made. " + response.StatusCode);
            }
            return response.Data.Animals;
        }

        public List<PetApi> GetAnimalByBreed(string breed)
        {
            GetToken();
            RestRequest request = new RestRequest($"animals?breed={breed}");
            IRestResponse<PetContainer> response = client.Get<PetContainer>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("There was an error made. " + response.StatusCode);
            }
            return response.Data.Animals;
        }

        public List<PetApi> GetAnimalByZip(string address)
        {
            GetToken();
            RestRequest request = new RestRequest($"animals?location={address}");
            IRestResponse<PetContainer> response = client.Get<PetContainer>(request);
            if (!response.IsSuccessful)
            {
                throw new HttpRequestException("There was an error made. " + response.StatusCode);
            }
            return response.Data.Animals;
        }
    }
}