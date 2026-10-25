using System;
using System.Collections.Generic;

public class Comment
{
    private string _commenterName;
    private string _text;

    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"{_commenterName}: {_text}");
    }
}

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideo()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Number of comments: {GetCommentCount()}");

        Console.WriteLine("Comments:");

        foreach (Comment comment in _comments)
        {
            comment.DisplayComment();
        }

        Console.WriteLine();
    }
}

public class Program
{
    public static void Main()
    {
        Video video1 = new Video(
            "How to Learn C#",
            "Programming Teacher",
            600);

        video1.AddComment(new Comment("Logan", "This video was very helpful."));
        video1.AddComment(new Comment("Sarah", "I learned a lot from this."));
        video1.AddComment(new Comment("Mike", "Great explanation!"));

        Video video2 = new Video(
            "Top 10 Gaming Tips",
            "GameMaster",
            480);

        video2.AddComment(new Comment("Alex", "These tips helped me improve."));
        video2.AddComment(new Comment("Jordan", "I liked tip number five."));
        video2.AddComment(new Comment("Chris", "Please make another video."));

        Video video3 = new Video(
            "Beginner Workout",
            "Fitness Coach",
            720);

        video3.AddComment(new Comment("Emily", "This was a great workout."));
        video3.AddComment(new Comment("David", "I am going to try this tomorrow."));
        video3.AddComment(new Comment("Rachel", "The instructions were easy to follow."));

        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3
        };

        foreach (Video video in videos)
        {
            video.DisplayVideo();
        }
    }
}