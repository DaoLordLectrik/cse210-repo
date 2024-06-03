using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    private List<Comment> comments = new List<Comment>();

    public void AddComment(string commenterName, string commentText)
    {
        comments.Add(new Comment(commenterName, commentText));
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length (seconds): {LengthInSeconds}");
        Console.WriteLine($"Number of comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.CommentText}");
        }
        Console.WriteLine();
    }
}

public class Comment
{
    public string CommenterName { get; set; }
    public string CommentText { get; set; }

    public Comment(string commenterName, string commentText)
    {
        CommenterName = commenterName;
        CommentText = commentText;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        List<Video> videos = new List<Video>();
        Video video1 = new Video { Title = "Video 1", Author = "Author 1", LengthInSeconds = 120 };
        video1.AddComment("Commenter A", "Great video!");
        video1.AddComment("Commenter B", "I learned a lot.");
        videos.Add(video1);

        Video video2 = new Video { Title = "Video 2", Author = "Author 2", LengthInSeconds = 180 };
        video2.AddComment("Commenter C", "Nice content!");
        videos.Add(video2);

        Video video3 = new Video { Title = "Video 3", Author = "Author 3", LengthInSeconds = 150 };
        video3.AddComment("Commenter D", "Interesting topic.");
        video3.AddComment("Commenter E", "Keep up the good work!");
        videos.Add(video3);

        // Display video info
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
