using System;
using System.Collections.Generic;

#nullable disable

namespace QuizApp.Models
{
    public partial class Score
    {
        public int ScoreId { get; set; }
        public int UserId { get; set; }
        public int BestCategoryId { get; set; }
        public int? BestScore { get; set; }
    }
}
