﻿using CleanArchMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "The Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Price is required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The Stock is required")]
        [Range(1, 9999)]
        public int Stock { get; set; }
        [MaxLength(250)]
        [Display(Name = "Product Image")]
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
