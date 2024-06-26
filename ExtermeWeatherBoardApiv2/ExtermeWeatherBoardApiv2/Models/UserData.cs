﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;


namespace ExtremeWeatherBoardApiv2.Models
{
    public class UserData
    {
        public int Id { get; set; }
        public virtual IdentityUser? User { get; set; }
        [Required]
        public string? UserId { get; set; }
        public string? ImageURL { get; set; }
        [InverseProperty("DiscussionThreadUserData")]
        public virtual ICollection<DiscussionThread>? Threads { get; set; }
        [InverseProperty("CommentUserData")]
        public virtual ICollection<Comment>? Comments { get; set; }
        [InverseProperty("Receiver")]
        public virtual ICollection<Message>? ReceivedMessages { get; set; }
        [InverseProperty("Sender")]
        public virtual ICollection<Message>? SentMessages { get; set; }
    }
}
