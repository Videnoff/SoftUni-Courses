﻿namespace CarShop.Contracts
{
    public interface IValidationService
    {
        (bool isValid, string error) ValidateModel(object model);
    }
}