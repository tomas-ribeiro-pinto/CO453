using System;
using System.ComponentModel.DataAnnotations;
using WebApplications.Network;

namespace WebApplications.Pages.Network
{
    public class Comment
    {
        //Primary Key
        public int CommentId { get; set; }

        // Foreign Key
        public int PostId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public virtual Post Post { get; set; }
    }
}
