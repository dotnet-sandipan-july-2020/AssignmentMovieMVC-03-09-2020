﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieCustomerMVAAppWithAuthentication.Models
{
    public class Min18YrsIfMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer =(Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.DOB == null)
                return new ValidationResult("Birthdate is required");
            var age = DateTime.Today.Year - customer.DOB.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("customer should be atleast 18 years old to be a member");
           
        }
    }
}