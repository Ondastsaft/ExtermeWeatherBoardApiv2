﻿using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;
namespace ExtremeWeatherBoardApiv2.Models
{
    public class DiscussionThread
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool IsReported { get; set; }
        public int? DiscussionThreadUserDataId { get; set; }
        [ForeignKey("DiscussionThreadUserDataId")]
        public virtual UserData? DiscussionThreadUserData { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SubCategory? SubCategory { get; set; }
        [InverseProperty("ParentDiscussionThread")]
        public ICollection<Comment>? Comments { get; set; }
    }
}
