﻿namespace Planefall.Common.Mapping.Interfaces
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}