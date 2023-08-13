using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Capstone.Models
{
    public class PetContainer
    {
        public List<PetApi> Animals { get; set; }
    }

    public class PetApi
    {
        public int Id { get; set; }
        public string Organization_id { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Species { get; set; }
        public BreedsApi Breed { get; set; }
        public ColorApi Color { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Size { get; set; }
        public string Coat { get; set; }
        public AttributesApi AttributesApi { get; set; }
        public EnvironmentApi Environment { get; set; }
        public List<string> Tags { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Organization_animal_id { get; set; }
        public List<string> Photos { get; set; }
        public Primary_photo_cropped Primary_photo_cropped { get; set; }
        public List<string> Videos { get; set; }
        public string Status { get; set; }
        public Contact Contact { get; set; }
    }

    public class BreedsApi
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public bool Mixed { get; set; }
        public bool Unknown { get; set; }
    }

    public class ColorApi
    {
        public string Primary { get; set; }
        public string Secondary { get; set; }
        public string Tertiary { get; set; }
    }

    public class AttributesApi
    {
        public bool Spayed_neutered { get; set; }
        public bool House_trained { get; set; }
        public bool Declawed { get; set; }
        public bool Special_needs { get; set; }
        public bool Shots_current { get; set; }
    }

    public class EnvironmentApi
    {
        public bool Children { get; set; }
        public bool Dogs { get; set; }
        public bool Cats { get; set; }
    }

    public class Primary_photo_cropped
    {
        public string Small { get; set; }
        public string Medium { get; set; }
        public string Large { get; set; }
        public string Full { get; set; }
    }

    public class Contact
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public AddressApi AddressApi { get; set; }
    }

    public class AddressApi
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
    }
}