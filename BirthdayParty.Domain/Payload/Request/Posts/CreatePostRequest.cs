﻿namespace BirthdayParty.Domain.Payload.Request.Posts;

public class CreatePostRequest
{
   public string? Content { get; set; } 
   public string? ImageUrl { get; set; }
}