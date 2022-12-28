using System.ComponentModel.DataAnnotations;

namespace CommonDatabase.Models.Accessories
{
    public class Ring1
    {
        [Key]
        public int Ring1Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int AC { get; set; } 
        public string Class { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
    
}
