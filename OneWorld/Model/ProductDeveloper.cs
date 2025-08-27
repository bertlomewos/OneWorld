using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OneWorld.Model
{
    public class ProductDeveloper
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [JsonIgnore]
        public virtual Product Product { get; set; } = null!;

        public int DeveloperId { get; set; }
        [JsonIgnore]
        public virtual Developer Developer { get; set; } = null!;
    }
}