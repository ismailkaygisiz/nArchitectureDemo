﻿namespace Core.Persistence.Dynamic
{
    public class Sort
    {
        public Sort()
        {
            Field = string.Empty;
            Direction = string.Empty;
        }

        public Sort(string field, string direction)
        {
            Field = field;
            Direction = direction;
        }

        public string Field { get; set; }
        public string Direction { get; set; }
    }
}
