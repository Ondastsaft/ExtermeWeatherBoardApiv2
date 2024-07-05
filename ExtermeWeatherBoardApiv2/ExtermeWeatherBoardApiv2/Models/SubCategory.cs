using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace ExtremeWeatherBoardApiv2.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }
        public int ParentCategoryId { get; set; }
        [ForeignKey("ParentCategoryId")]
        public virtual Category? ParentCategory { get; set; }
        public int CreatorAdminUserDataId { get; set; }
        [ForeignKey("CreatorAdminUserDataId")]
        public AdminUserData? CreatorAdminUserData { get; set; }
        public virtual ICollection<DiscussionThread>? Threads { get; set; }
    }
}
