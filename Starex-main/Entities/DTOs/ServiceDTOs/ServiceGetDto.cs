﻿namespace Entities.DTOs.ServiceDTOs
{
    public class ServiceGetDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
    }
}
