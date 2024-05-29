﻿namespace BuildingBlocks.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string Message) : base(Message)
        {

        }
        public NotFoundException(string name, object key) : base($"Entity \"{name}\"({key}) was not found.")
        {

        }
    }
}
