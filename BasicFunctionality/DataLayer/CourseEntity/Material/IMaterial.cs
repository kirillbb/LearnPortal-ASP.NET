// <copyright file="IMaterial.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BasicFunctionality
{
    public interface IMaterial
    {
        string? Title { get; set; }

        int Id { get; set; }

        User Creator { get; set; }

        MaterialType Type { get; }
    }
}
