using System.ComponentModel.DataAnnotations;

namespace Group5_Website.Models
{
    public class Clothes
    {
        [Key]  // Primary key, unique identifier
        public int item_Id { get; set; }

        [Required(ErrorMessage = "Item name is required")]
        [StringLength(100, ErrorMessage = "Item name cannot exceed 100 characters")]
        public string item_Name { get; set; }  // Item name

        [StringLength(500, ErrorMessage = "Item description cannot exceed 500 characters")]
        public string item_Description { get; set; }  // Item description

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 10000, ErrorMessage = "Price must be between 0.01 and 10000")]
        public decimal item_Price { get; set; }  // Item price

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        public string item_Category { get; set; }  // Item category

        [Required(ErrorMessage = "Size is required")]
        [StringLength(10, ErrorMessage = "Size cannot exceed 10 characters")]
        public string item_Size { get; set; }  // Item size

        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
        public string item_Type { get; set; }  // Item type (men's or women's wear)

        [Url(ErrorMessage = "Please enter a valid URL")]
        [StringLength(200, ErrorMessage = "Image URL cannot exceed 200 characters")]
        public string item_Imageurl { get; set; }  // Item image URL
    }

}
