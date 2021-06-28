using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApp.Models
{
    public partial class UserQuestionAnswer
    {
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int ChoiceId { get; set; }
        public byte? IsCorrect { get; set; }
        public int? Score { get; set; }
    }
}
