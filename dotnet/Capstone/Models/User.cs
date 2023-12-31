﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Capstone.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
        public string Role { get; set; }
        public Address Address { get; set; }
        public string ApplicationStatus { get; set; }
        public bool IsInactive { get; set; }
        public string Email { get; set; }
        public bool IsAdopter { get; set; }
    }

    /// <summary>
    /// Secure model to use when displaying lists of users
    /// </summary>
    public class DisplayUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public Address Address { get; set; }
        public string ApplicationStatus { get; set; }
        public bool IsInactive { get; set; }
        public string Email { get; set; }
        public bool IsAdopter { get; set; }
    }

    /// <summary>
    /// Model to return upon successful login (user data + token)
    /// </summary>
    public class LoginResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }

    /// <summary>
    /// Model to accept login parameters
    /// </summary>
    public class LoginUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Model to accept registration parameters
    /// </summary>
    public class RegisterUser
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "A valid email address is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        // a little data validation
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        [Required(ErrorMessage = "An address is required")]
        public CreateAddress Address { get; set; }
    }

    public class Adopter
    {
        public int AdopterId { get; set; }
        public int PetId { get; set; }
    }
}
