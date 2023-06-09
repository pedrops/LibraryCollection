﻿namespace LibraryCollection.Domain.Abstractions
{
    public interface ISystemInfo
    {
        string ConnectionString { get; set; }
        string Persistence { get; set; }
        string DataBase { get; set; }
        void FillSettings();
    }
}
