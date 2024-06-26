﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace ExtremeWeatherBoardApiv2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string? Text { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime PostedAt { get; set; }
        public int? CommentUserDataId { get; set; }
        [ForeignKey("CommentUserDataId")]
        public virtual UserData? CommentUserData { get; set; }
        public int? CommentAdminUserDataId { get; set; }
        [ForeignKey("CommentAdminUserDataId")]
        public virtual AdminUserData? CommentAdminUserData { get; set; }
        public int CommentThreadId { get; set; }
        [ForeignKey("CommentThreadId")]
        public DiscussionThread? CommentThread { get; set; }
    }
}
