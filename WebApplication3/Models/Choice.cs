using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApp.Models
{
    public partial class Choice
    {
        public int ChoiceId { get; set; }
        public byte? IsCorrectChoise { get; set; }
        public string ChoiceText { get; set; }
        public int? QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
