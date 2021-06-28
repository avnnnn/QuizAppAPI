using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApp.Models
{
    public partial class Question
    {
        public Question()
        {
            Choices = new HashSet<Choice>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Choice> Choices { get; set; }
    }
}
