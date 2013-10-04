using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson03.Models
{
    public class MessageItemModel
    {
        public MessageItemModel()
        {
            
        }

        public MessageItemModel(string email, string message)
        {
            this.Email = email;
            this.Message = message;
        }

        public string Message { get; set; }

        [RegularExpression(".+@{1}[a-zA-Z0-9]+\\.{1,}.+")]
        public string Email { get; set; }
    }
}