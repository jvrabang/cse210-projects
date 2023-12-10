using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Video video1 = new Video("LEVEL 16 Elite Barbarians are just BRUTAL", "Ian77 - Clash Royale", 233);
        video1.AddComment("@hellxapo5740", "Level 16 E-Barbs truly bring out the SKILL of Clash Royale players.");
        video1.AddComment("@Stratocaster_", "Your opponent when you need one win to get to the next arena.");
        video1.AddComment("@choda_smeker", "I loved the part where Ian said Its ebarb time, and proceeded to ebarb all over his opponent.");

        Video video2 = new Video("What's inside this crater in Madagascar?", "Vox", 2432);
        video2.AddComment("@Conscience108", "It is suddenly eye-opening to see that there are places beyond our narrow vision. Kudos to the team for this great piece. Deserves awards.");
        video2.AddComment("@Indrakusuma_a", "More of this please, Vox. Make this into a series where we journey into the 'unknown'.");
        video2.AddComment("@thelongboarddude95", "I love that you worked with a local team as opposed to flying there! It really shows that you can make an environmentally friendly choice without compromising on quality!");
        video2.AddComment("@mpvchap", "Love your passion and huge  respect to the hard work you have done. The way you tell the story and compile it into this video is great film making!!");
        

        Video video3 = new Video("Why you have an accent in a foreign language", "The Economist", 258);
        video3.AddComment("@alanlee8590", "Interesting. I am a native Cantonese speaker. It would be in my wildest dream to imagine that Cantonese and Italian actually have something in common!");
        video3.AddComment("@dsdsUserF", "Looking forward to more videos.");
        video3.AddComment("@stevenschilizzi4104", "Very true! And it's rarely taught in language courses, let alone in schools. It'd be great to have more of these videos on specifics for different languages, at least for native English speakers. Cheers!");

        Video video4 = new Video("The #1 Workout That BLEW UP My Arms (4 Exercises)", "Jeremy Ethier", 741);
        video4.AddComment("@jvrabnafg", "Jeremy your videos are so great. I recommend your videos to beginners all the time due to how approachable you are.");
        video4.AddComment("@UsedsdsrH", "Great help as always, keep up the good work");
        video4.AddComment("@joshuabarron7478", "Always such professional content, love your videos");


        List<Video> videoList = new List<Video> { video1, video2, video3, video4 };


        foreach (Video video in videoList)
        {
            Console.WriteLine($"Title: {video.Title}\nAuthor: {video.Author}\nLength: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}\nComments:");

            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.CommentText}");
            }

            Console.WriteLine("\n");
        }
    }
}
