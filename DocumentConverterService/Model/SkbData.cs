using System;
using System.Data;
namespace DocumentConverterService.Model
{
    public sealed class SkbData
    {
        public long UserId { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public int PrimaryScore { get; set; }
        public int SecondaryScore { get; set; }

        public SkbData(DataRow dataRow)
        {
            UserId = Convert.ToInt64(dataRow["User ID"]);
            Height = Convert.ToDouble(dataRow["Height"]);
            Age = Convert.ToInt32(dataRow["Age"]);
            PrimaryScore = Convert.ToInt32(dataRow["Primary Score"]);
            SecondaryScore = Convert.ToInt32(dataRow["Secondary Score"]);
        }
    }
}
