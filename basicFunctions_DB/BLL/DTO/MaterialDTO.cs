﻿using basicFunctions_DB.DAL.UserType;

namespace basicFunctions_DB.BLL.DTO
{
    internal class MaterialDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public User Creator { get; set; }
        public override string ToString()
        {
            return $"ID: {Id} | Title: {Title} | added: {Creator.ToString()}";
        }
    }
}
